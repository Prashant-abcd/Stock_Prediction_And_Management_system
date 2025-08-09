using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Microsoft.VisualBasic;

namespace DBS_UI
{
    public partial class UserDashboard : Form
    {
        private string username;

        private class StockItem
        {
            public int StockID { get; set; }
            public string StockName { get; set; }
            public override string ToString()
            {
                return StockID + " - " + StockName;
            }
        }

        public UserDashboard(string username)
        {
            InitializeComponent();
            this.username = username;
            WelcomeLabel.Text = "Welcome, " + username;
            PopulateStockComboBox();
        }

        private void PopulateStockComboBox()
        {
            using (OracleConnection conn = new OracleConnection(Form1.DBHelper.ConnectionString))
            {
                conn.Open();
                string query = "SELECT StockID, StockName FROM Stock";
                using (OracleCommand cmd = new OracleCommand(query, conn))
                {
                    using (OracleDataReader reader = cmd.ExecuteReader())
                    {
                        comboBox1.Items.Clear();
                        while (reader.Read())
                        {
                            comboBox1.Items.Add(new StockItem
                            {
                                StockID = reader.GetInt32(0),
                                StockName = reader.GetString(1)
                            });
                        }
                    }
                }
                if (comboBox1.Items.Count > 0)
                    comboBox1.SelectedIndex = 0;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem == null)
            {
                MessageBox.Show("Please select a stock!");
                return;
            }

            string fromDate = Microsoft.VisualBasic.Interaction.InputBox("Enter From Date (YYYY-MM-DD):", "Track Stock");
            string toDate = Microsoft.VisualBasic.Interaction.InputBox("Enter To Date (YYYY-MM-DD):", "Track Stock");

            if (string.IsNullOrEmpty(fromDate) || string.IsNullOrEmpty(toDate))
            {
                MessageBox.Show("Please enter both dates!");
                return;
            }

            DateTime from;
            DateTime to;
            try
            {
                from = DateTime.Parse(fromDate);
                to = DateTime.Parse(toDate);
            }
            catch (FormatException)
            {
                MessageBox.Show("Invalid date format! Please enter dates in YYYY-MM-DD format.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (from > to)
            {
                MessageBox.Show("From Date must be earlier than To Date!");
                return;
            }

            int stockId = ((StockItem)comboBox1.SelectedItem).StockID;

            using (OracleConnection conn = new OracleConnection(Form1.DBHelper.ConnectionString))
            {
                conn.Open();
                string query = "SELECT TradeDate, ClosePrice, Volume FROM PriceData WHERE StockID = :stockId AND TradeDate BETWEEN TO_DATE(:fromDate, 'YYYY-MM-DD') AND TO_DATE(:toDate, 'YYYY-MM-DD') ORDER BY TradeDate";
                using (OracleCommand cmd = new OracleCommand(query, conn))
                {
                    cmd.Parameters.Add("stockId", OracleDbType.Int32).Value = stockId;
                    cmd.Parameters.Add("fromDate", OracleDbType.Varchar2).Value = fromDate;
                    cmd.Parameters.Add("toDate", OracleDbType.Varchar2).Value = toDate;

                    using (OracleDataReader reader = cmd.ExecuteReader())
                    {
                        StringBuilder result = new StringBuilder("Price Data for StockID " + stockId + " (" + fromDate + " to " + toDate + "):\n");
                        List<(DateTime, float)> priceData = new List<(DateTime, float)>();

                        while (reader.Read())
                        {
                            DateTime tradeDate = reader.GetDateTime(0);
                            float closePrice = (float)reader.GetDouble(1);
                            long volume = reader.GetInt64(2);

                            result.Append("Date: " + tradeDate.ToString("yyyy-MM-dd") + ", Close Price: " + closePrice + ", Volume: " + volume + "\n");
                            priceData.Add((tradeDate, closePrice));
                        }

                        if (priceData.Count > 0)
                        {
                            DialogResult dialogResult = MessageBox.Show(result.ToString() + "\nWould you like to generate a trend graph?", "Price Data", MessageBoxButtons.YesNo);
                            if (dialogResult == DialogResult.Yes)
                            {
                                GenerateTrendGraph(priceData, "Price Trend for StockID " + stockId);
                            }
                        }
                        else
                        {
                            MessageBox.Show("No data found for the selected stock and date range!");
                        }
                    }
                }
            }
        }

        private void GenerateTrendGraph(List<(DateTime Date, float Price)> priceData, string title)
        {
            Form graphForm = new Form
            {
                Text = title,
                Width = 800,
                Height = 600
            };

            Chart chart = new Chart { Dock = DockStyle.Fill };
            chart.ChartAreas.Add(new ChartArea());

            Series series = new Series
            {
                ChartType = SeriesChartType.Line,
                XValueType = ChartValueType.DateTime,
                YValueType = ChartValueType.Single
            };

            foreach (var data in priceData)
            {
                series.Points.AddXY(data.Date, data.Price);
            }

            chart.Series.Add(series);
            chart.Titles.Add(title);

            graphForm.Controls.Add(chart);
            graphForm.ShowDialog();
        }

        private void btnPredictStock_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem == null)
            {
                MessageBox.Show("Please select a stock!");
                return;
            }

            int stockId = ((StockItem)comboBox1.SelectedItem).StockID;

            using (OracleConnection conn = new OracleConnection(Form1.DBHelper.ConnectionString))
            {
                conn.Open();
                string query = "SELECT TradeDate, ClosePrice FROM PriceData WHERE StockID = :stockId ORDER BY TradeDate";
                using (OracleCommand cmd = new OracleCommand(query, conn))
                {
                    cmd.Parameters.Add("stockId", OracleDbType.Int32).Value = stockId;
                    using (OracleDataReader reader = cmd.ExecuteReader())
                    {
                        List<float> prices = new List<float>();
                        while (reader.Read())
                        {
                            prices.Add((float)reader.GetDouble(1));
                        }

                        if (prices.Count < 10)
                        {
                            MessageBox.Show("Not enough historical data to make a prediction! At least 10 data points are required.");
                            return;
                        }

                        float predictedPrice = PredictStockPriceForNextDay(prices);

                        string insertQuery = "INSERT INTO Prediction (StockID, PredictedDate, PredictedClosePrice) VALUES (:stockId, TRUNC(SYSDATE), :predictedPrice)";
                        using (OracleCommand insertCmd = new OracleCommand(insertQuery, conn))
                        {
                            insertCmd.Parameters.Add("stockId", OracleDbType.Int32).Value = stockId;
                            insertCmd.Parameters.Add("predictedPrice", OracleDbType.Decimal).Value = predictedPrice;
                            insertCmd.ExecuteNonQuery();
                        }

                        MessageBox.Show("Price Prediction for StockID " + stockId + ":\nFor Next Functioning Date: Predicted Price: " + predictedPrice.ToString("F2"));
                    }
                }
            }
        }

        private float PredictStockPriceForNextDay(List<float> prices)
        {
            float alpha = 0.2f;
            float smoothedValue = prices[0];

            for (int i = 1; i < prices.Count; i++)
            {
                smoothedValue = alpha * prices[i] + (1 - alpha) * smoothedValue;
            }

            return smoothedValue;
        }

        private void btnInvest_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem == null)
            {
                MessageBox.Show("Please select a stock!");
                return;
            }

            StockItem selectedStock = (StockItem)comboBox1.SelectedItem;
            int stockId = selectedStock.StockID;
            string stockName = selectedStock.StockName;

            InvestForm investForm = new InvestForm(stockId, stockName, username);
            investForm.ShowDialog();
        }

        private void linkLogout_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form1 loginForm = new Form1();
            loginForm.Show();
            this.Hide();
        }

        private void checkWatchlistButton_Click(object sender, EventArgs e)
        {
            WatchlistForm watchlistForm = new WatchlistForm(username);
            watchlistForm.ShowDialog();
        }

        private void newsButton_Click(object sender, EventArgs e)
        {
            NewsForm newsForm = new NewsForm();
            newsForm.ShowDialog();
        }

        // Empty event handlers for designer compatibility
        private void UserDashboard_Load(object sender, EventArgs e) { }
        private void WelcomeLabel_Click(object sender, EventArgs e) { }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) { }
    }
}