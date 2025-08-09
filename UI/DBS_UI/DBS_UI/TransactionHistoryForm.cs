using DBS_UI;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Data;
using System.Windows.Forms;

namespace DBS_UI
{
    public partial class TransactionHistoryForm : Form
    {
        private readonly int stockId;
        private readonly int userId;
        private readonly float currentPrice;
        private DataGridView grid;

        public TransactionHistoryForm(int stockId, int userId, float currentPrice)
        {
            this.stockId = stockId;
            this.userId = userId;
            this.currentPrice = currentPrice;
            InitializeComponent();
        }

        private void TransactionHistoryForm_Load(object sender, EventArgs e)
        {
            this.Text = "Transaction History";
            this.Width = 800;
            this.Height = 400;

            grid = new DataGridView();
            grid.Dock = DockStyle.Fill;
            grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            grid.ReadOnly = true;
            grid.AllowUserToAddRows = false;
            this.Controls.Add(grid);
            LoadDataIntoGrid();
        }

        private void LoadDataIntoGrid()
        {
            try
            {
                using (OracleConnection conn = new OracleConnection(Form1.DBHelper.ConnectionString))
                {
                    conn.Open();
                    string query = "SELECT StockID AS \"Stock ID\", " +
                                   "TransactionDate AS \"Trade Date\", " +
                                   "TransactionType AS \"Type\", " +
                                   "TransactionAmount AS \"Amount\", " +
                                   "Shares AS \"No. of Stocks\" " +
                                   "FROM Transaction " +
                                   "WHERE StockID = :stockId AND UserID = :userId " +
                                   "ORDER BY TransactionDate DESC";

                    using (OracleCommand cmd = new OracleCommand(query, conn))
                    {
                        cmd.Parameters.Add("stockId", OracleDbType.Int32).Value = stockId;
                        cmd.Parameters.Add("userId", OracleDbType.Int32).Value = userId;

                        using (OracleDataAdapter adapter = new OracleDataAdapter(cmd))
                        {
                            DataTable table = new DataTable();
                            adapter.Fill(table);
                            CalculateStatus(table);
                            grid.DataSource = table;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Something went wrong: " + ex.Message);
            }
        }

        private void CalculateStatus(DataTable table)
        {
            if (table.Rows.Count == 0) return;

            table.Columns.Add("Status", typeof(string));

            foreach (DataRow row in table.Rows)
            {
                decimal amount = row["Amount"] != DBNull.Value ? Convert.ToDecimal(row["Amount"]) : 0;
                int shares = row["No. of Stocks"] != DBNull.Value ? Convert.ToInt32(row["No. of Stocks"]) : 0;
                string type = row["Type"].ToString().ToLower();
                DateTime tradeDate = row["Trade Date"] != DBNull.Value ? Convert.ToDateTime(row["Trade Date"]) : DateTime.Now;

                // Calculate the price per share at the time of transaction
                float transactionPricePerShare = shares != 0 ? (float)amount / shares : 0;
                float currentValue = currentPrice * shares;
                float transactionValue = transactionPricePerShare * shares;
                float difference = 0;

                // Get the latest transaction date for this stock
                DateTime latestTradeDate = DateTime.MinValue;
                foreach (DataRow r in table.Rows)
                {
                    DateTime date = Convert.ToDateTime(r["Trade Date"]);
                    if (date > latestTradeDate)
                    {
                        latestTradeDate = date;
                    }
                }

                // If this transaction is the latest, no change to calculate, so difference is 0
                if (tradeDate.Date == latestTradeDate.Date)
                {
                    difference = 0;
                }
                else
                {
                    if (type == "buy")
                    {
                        // For Buy: Profit if current value > transaction value
                        difference = currentValue - transactionValue;
                    }
                    else if (type == "sell")
                    {
                        // For Sell: Profit if transaction value > current value
                        difference = transactionValue - currentValue;
                    }
                }

                if (difference >= 0)
                {
                    row["Status"] = "$" + difference.ToString("F2") + " (Profit)";
                }
                else
                {
                    row["Status"] = "$" + difference.ToString("F2") + " (Loss)";
                }
            }
        }
    }
}