using DBS_UI;
using Microsoft.VisualBasic;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Windows.Forms;

namespace DBS_UI
{
    public partial class InvestForm : Form
    {
        private int stockId;
        private string stockName;
        private int userId;
        private float currentPrice;
        private int netSharesOwned;

        public InvestForm()
        {
            InitializeComponent();
        }

        public InvestForm(int stockId, string stockName, string username)
        {
            InitializeComponent();
            this.stockId = stockId;
            this.stockName = stockName;
            this.userId = GetUserId(username);
            if (this.userId == -1)
            {
                MessageBox.Show("Error: User not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }
            InitializeForm();
        }

        private void InitializeForm()
        {
            lblStockInfo.Text = "Selected stock: " + stockId + " - " + stockName;
            FetchCurrentPrice();
            FetchCurrentHoldings();
            lblCurrentPrice.Text = "Current Price: $" + currentPrice.ToString("F2");
            lblHoldings.Text = "No. of stocks owned: " + netSharesOwned;
            lblPortfolioValue.Text = "Current value: $" + (netSharesOwned * currentPrice).ToString("F2");
            radioBuy.Checked = true;
        }

        private int GetUserId(string username)
        {
            try
            {
                using (OracleConnection conn = new OracleConnection(Form1.DBHelper.ConnectionString))
                {
                    conn.Open();
                    string query = "SELECT UserID FROM Users WHERE Username = :username";
                    using (OracleCommand cmd = new OracleCommand(query, conn))
                    {
                        cmd.Parameters.Add("username", OracleDbType.Varchar2).Value = username;
                        object result = cmd.ExecuteScalar();
                        return result != null ? Convert.ToInt32(result) : -1;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error fetching UserID: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
        }

        private void FetchCurrentPrice()
        {
            try
            {
                using (OracleConnection conn = new OracleConnection(Form1.DBHelper.ConnectionString))
                {
                    conn.Open();
                    string query = "SELECT ClosePrice FROM PriceData WHERE StockID = :stockId AND TradeDate = (SELECT MAX(TradeDate) FROM PriceData WHERE StockID = :stockId)";
                    using (OracleCommand cmd = new OracleCommand(query, conn))
                    {
                        cmd.Parameters.Add("stockId", OracleDbType.Int32).Value = stockId;
                        object result = cmd.ExecuteScalar();
                        currentPrice = result != null ? (float)Convert.ToDouble(result) : 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error fetching current price: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                currentPrice = 0;
            }
        }

        private void FetchCurrentHoldings()
        {
            try
            {
                using (OracleConnection conn = new OracleConnection(Form1.DBHelper.ConnectionString))
                {
                    conn.Open();
                    string query = "SELECT NVL(SUM(CASE WHEN TransactionType = 'Buy' THEN Shares ELSE 0 END), 0) - NVL(SUM(CASE WHEN TransactionType = 'Sell' THEN Shares ELSE 0 END), 0) AS NetShares FROM Transaction WHERE StockID = :stockId AND UserID = :userId";
                    using (OracleCommand cmd = new OracleCommand(query, conn))
                    {
                        cmd.Parameters.Add("stockId", OracleDbType.Int32).Value = stockId;
                        cmd.Parameters.Add("userId", OracleDbType.Int32).Value = userId;
                        object result = cmd.ExecuteScalar();
                        netSharesOwned = result != null ? Convert.ToInt32(result) : 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error fetching holdings: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                netSharesOwned = 0;
            }
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            string actionType = radioBuy.Checked ? "Buy" : radioSell.Checked ? "Sell" : "AddToWatchlist";

            if (actionType == "Buy" || actionType == "Sell")
            {
                if (!int.TryParse(txtShares.Text, out int shares) || shares <= 0)
                {
                    MessageBox.Show("Please enter a valid number of shares!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (actionType == "Sell" && shares > netSharesOwned)
                {
                    MessageBox.Show("You cannot sell " + shares + " shares. You only own " + netSharesOwned + " shares of this stock!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                decimal transactionAmount = shares * (decimal)currentPrice;

                try
                {
                    using (OracleConnection conn = new OracleConnection(Form1.DBHelper.ConnectionString))
                    {
                        conn.Open();
                        OracleTransaction transaction = conn.BeginTransaction();

                        string insertQuery = "INSERT INTO Transaction (StockID, UserID, TransactionDate, TransactionType, TransactionAmount, Shares) VALUES (:stockId, :userId, TRUNC(SYSDATE), :transactionType, :transactionAmount, :shares)";
                        using (OracleCommand cmd = new OracleCommand(insertQuery, conn))
                        {
                            cmd.Transaction = transaction;
                            cmd.Parameters.Add("stockId", OracleDbType.Int32).Value = stockId;
                            cmd.Parameters.Add("userId", OracleDbType.Int32).Value = userId;
                            cmd.Parameters.Add("transactionType", OracleDbType.Varchar2).Value = actionType;
                            cmd.Parameters.Add("transactionAmount", OracleDbType.Decimal).Value = transactionAmount;
                            cmd.Parameters.Add("shares", OracleDbType.Int32).Value = shares;

                            cmd.ExecuteNonQuery();
                            transaction.Commit();

                            if (actionType == "Buy")
                            {
                                netSharesOwned += shares;
                            }
                            else
                            {
                                netSharesOwned -= shares;
                            }

                            lblHoldings.Text = "No. of stocks owned: " + netSharesOwned;
                            lblPortfolioValue.Text = "Current value: $" + (netSharesOwned * currentPrice).ToString("F2");

                            string action = actionType == "Buy" ? "Bought" : "Sold";
                            MessageBox.Show(action + " " + shares + " shares of StockID " + stockId + " for $" + transactionAmount.ToString("F2") + " on " + DateTime.Now.ToString("yyyy-MM-dd"));
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error processing transaction: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (actionType == "AddToWatchlist")
            {
                try
                {
                    using (OracleConnection conn = new OracleConnection(Form1.DBHelper.ConnectionString))
                    {
                        conn.Open();

                        string checkQuery = "SELECT COUNT(*) FROM Watchlist WHERE UserID = :userId AND StockID = :stockId AND DateAdded = TRUNC(SYSDATE)";
                        using (OracleCommand checkCmd = new OracleCommand(checkQuery, conn))
                        {
                            checkCmd.Parameters.Add("userId", OracleDbType.Int32).Value = userId;
                            checkCmd.Parameters.Add("stockId", OracleDbType.Int32).Value = stockId;
                            int count = Convert.ToInt32(checkCmd.ExecuteScalar());

                            if (count > 0)
                            {
                                MessageBox.Show("Stock already added to watchlist today!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                            }
                        }

                        string insertQuery = "INSERT INTO Watchlist (UserID, StockID, DateAdded) VALUES (:userId, :stockId, TRUNC(SYSDATE))";
                        using (OracleCommand cmd = new OracleCommand(insertQuery, conn))
                        {
                            cmd.Parameters.Add("userId", OracleDbType.Int32).Value = userId;
                            cmd.Parameters.Add("stockId", OracleDbType.Int32).Value = stockId;
                            cmd.ExecuteNonQuery();
                        }

                        string currentDate = DateTime.Now.ToString("yyyy-MM-dd");
                        MessageBox.Show(stockName + " added to watchlist for the date: " + currentDate);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error adding to watchlist: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void radioBuy_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void radioSell_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void InvestForm_Load_1(object sender, EventArgs e)
        {
        }

        private void btnBestPerformingStocks_Click(object sender, EventArgs e)
        {
            try
            {
                using (OracleConnection conn = new OracleConnection(Form1.DBHelper.ConnectionString))
                {
                    conn.Open();
                    string query = "SELECT s.StockID, s.StockName, (latest_price.ClosePrice - second_latest_price.ClosePrice) AS PriceDifference FROM Stock s INNER JOIN (SELECT p1.StockID, p1.ClosePrice FROM PriceData p1 WHERE p1.TradeDate = (SELECT MAX(TradeDate) FROM PriceData p2 WHERE p2.StockID = p1.StockID)) latest_price ON s.StockID = latest_price.StockID INNER JOIN (SELECT p1.StockID, p1.ClosePrice FROM PriceData p1 WHERE p1.TradeDate = (SELECT MAX(TradeDate) FROM PriceData p2 WHERE p2.StockID = p1.StockID AND p2.TradeDate < (SELECT MAX(TradeDate) FROM PriceData p3 WHERE p3.StockID = p1.StockID))) second_latest_price ON s.StockID = second_latest_price.StockID ORDER BY PriceDifference DESC FETCH FIRST 3 ROWS ONLY";
                    using (OracleCommand cmd = new OracleCommand(query, conn))
                    {
                        OracleDataReader reader = cmd.ExecuteReader();
                        string result = "Top 3 Best Performing Stocks (by price difference):\n";
                        int rowCount = 0;

                        while (reader.Read())
                        {
                            int stockId = reader.GetInt32(0);
                            string stockName = reader.IsDBNull(1) ? "Unknown" : reader.GetString(1);
                            decimal priceDifference = reader.GetDecimal(2);
                            result = result + "StockID: " + stockId + ", StockName: " + stockName + ", Price Difference: $" + priceDifference.ToString("F2") + "\n";
                            rowCount++;
                        }

                        if (rowCount > 0)
                        {
                            MessageBox.Show(result, "Best Performing Stocks");
                        }
                        else
                        {
                            MessageBox.Show("No stocks found with enough data (at least 2 price records) to determine the best performers.", "No Data", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error fetching best performing stocks: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnWorstPerformingStocks_Click(object sender, EventArgs e)
        {
            try
            {
                using (OracleConnection conn = new OracleConnection(Form1.DBHelper.ConnectionString))
                {
                    conn.Open();
                    string query = "SELECT s.StockID, s.StockName, (latest_price.ClosePrice - second_latest_price.ClosePrice) AS PriceDifference FROM Stock s INNER JOIN (SELECT p1.StockID, p1.ClosePrice FROM PriceData p1 WHERE p1.TradeDate = (SELECT MAX(TradeDate) FROM PriceData p2 WHERE p2.StockID = p1.StockID)) latest_price ON s.StockID = latest_price.StockID INNER JOIN (SELECT p1.StockID, p1.ClosePrice FROM PriceData p1 WHERE p1.TradeDate = (SELECT MAX(TradeDate) FROM PriceData p2 WHERE p2.StockID = p1.StockID AND p2.TradeDate < (SELECT MAX(TradeDate) FROM PriceData p3 WHERE p3.StockID = p1.StockID))) second_latest_price ON s.StockID = second_latest_price.StockID ORDER BY PriceDifference ASC FETCH FIRST 3 ROWS ONLY";
                    using (OracleCommand cmd = new OracleCommand(query, conn))
                    {
                        OracleDataReader reader = cmd.ExecuteReader();
                        string result = "Top 3 Worst Performing Stocks (by price difference):\n";
                        int rowCount = 0;

                        while (reader.Read())
                        {
                            int stockId = reader.GetInt32(0);
                            string stockName = reader.IsDBNull(1) ? "Unknown" : reader.GetString(1);
                            decimal priceDifference = reader.GetDecimal(2);
                            result = result + "StockID: " + stockId + ", StockName: " + stockName + ", Price Difference: $" + priceDifference.ToString("F2") + "\n";
                            rowCount++;
                        }

                        if (rowCount > 0)
                        {
                            MessageBox.Show(result, "Worst Performing Stocks");
                        }
                        else
                        {
                            MessageBox.Show("No stocks found with enough data (at least 2 price records) to determine the worst performers.", "No Data", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error fetching worst performing stocks: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void transHistoryBtn_Click(object sender, EventArgs e)
        {
            TransactionHistoryForm historyForm = new TransactionHistoryForm(stockId, userId, currentPrice);
            historyForm.ShowDialog();
        }

        private void checkPerformance_Click(object sender, EventArgs e)
        {
            string daysInput = Interaction.InputBox("Enter the number of days for average price comparison (e.g., 30):", "Check Performance", "30");
            if (string.IsNullOrEmpty(daysInput))
            {
                MessageBox.Show("Please enter a valid number of days!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!int.TryParse(daysInput, out int days) || days <= 0)
            {
                MessageBox.Show("Please enter a positive number of days!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (stockId <= 0)
            {
                MessageBox.Show("Invalid stock selected! Please ensure a valid stock is loaded.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                using (OracleConnection conn = new OracleConnection(Form1.DBHelper.ConnectionString))
                {
                    conn.Open();
                    string query = "SELECT p.ClosePrice AS LatestPrice, (SELECT AVG(ClosePrice) FROM PriceData WHERE StockID = :stockId2 AND TradeDate >= TRUNC(SYSDATE) - :days2 AND TradeDate <= p.TradeDate) AS AvgPrice FROM PriceData p WHERE StockID = :stockId1 AND TradeDate = (SELECT MAX(TradeDate) FROM PriceData WHERE StockID = :stockId3)";
                    using (OracleCommand cmd = new OracleCommand(query, conn))
                    {
                        cmd.Parameters.Add(new OracleParameter("stockId1", OracleDbType.Int32) { Value = stockId });
                        cmd.Parameters.Add(new OracleParameter("stockId2", OracleDbType.Int32) { Value = stockId });
                        cmd.Parameters.Add(new OracleParameter("days2", OracleDbType.Int32) { Value = days });
                        cmd.Parameters.Add(new OracleParameter("stockId3", OracleDbType.Int32) { Value = stockId });

                        using (OracleDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                decimal? latestPrice = reader.IsDBNull(0) ? (decimal?)null : reader.GetDecimal(0);
                                decimal? avgPrice = reader.IsDBNull(1) ? (decimal?)null : reader.GetDecimal(1);

                                string result = "Performance for " + stockName + " (StockID: " + stockId + "):\n";
                                result = result + "Latest Closing Price: " + (latestPrice.HasValue ? "$" + latestPrice.Value.ToString("F2") : "No Data") + "\n";
                                result = result + "Average Closing Price (Last " + days + " Days): " + (avgPrice.HasValue ? "$" + avgPrice.Value.ToString("F2") : "No Data") + "\n";

                                if (latestPrice.HasValue && avgPrice.HasValue)
                                {
                                    decimal difference = latestPrice.Value - avgPrice.Value;
                                    result = result + "Difference: " + (difference >= 0 ? "+" : "") + "$" + difference.ToString("F2") + " ";
                                    result = result + "(" + (difference >= 0 ? "Above" : "Below") + " " + days + "-day average)";
                                }

                                MessageBox.Show(result, "Stock Performance");
                            }
                            else
                            {
                                MessageBox.Show("No data available for the selected stock.", "No Data", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error checking performance: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}