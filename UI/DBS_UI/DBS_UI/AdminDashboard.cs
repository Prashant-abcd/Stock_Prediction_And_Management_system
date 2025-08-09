using Oracle.ManagedDataAccess.Client;
using System;
using System.Data;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using DBS_UI;

namespace DBS_UI
{
    public partial class AdminDashboard : Form
    {
        public AdminDashboard()
        {
            InitializeComponent();
        }

        // Manage Users: Delete, view all, or search a user's details
        private void btnManageUsers_Click(object sender, EventArgs e)
        {
            string choice = Interaction.InputBox("Enter 'delete' to delete a user, 'view' to see all users, or 'search' to find a user:", "Manage Users");
            if (choice == "") return;

            if (choice.ToLower() == "delete")
            {
                string userId = Interaction.InputBox("Enter UserID to delete:", "Delete User");
                if (userId == "") return;

                try
                {
                    OracleConnection conn = new OracleConnection(Form1.DBHelper.ConnectionString);
                    conn.Open();

                    string query = "DELETE FROM Users WHERE UserID = :userId";
                    OracleCommand cmd = new OracleCommand(query, conn);
                    cmd.Parameters.Add("userId", OracleDbType.Int32).Value = Convert.ToInt32(userId);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("User deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("UserID not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    conn.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (choice.ToLower() == "view")
            {
                AdminViewForm viewForm = new AdminViewForm("Users");
                viewForm.ShowDialog();
            }
            else if (choice.ToLower() == "search")
            {
                string userId = Interaction.InputBox("Enter UserID to search:", "Search User");
                if (userId == "") return;

                try
                {
                    OracleConnection conn = new OracleConnection(Form1.DBHelper.ConnectionString);
                    conn.Open();

                    string query = "SELECT * FROM Users WHERE UserID = :userId";
                    OracleCommand cmd = new OracleCommand(query, conn);
                    cmd.Parameters.Add("userId", OracleDbType.Int32).Value = Convert.ToInt32(userId);

                    OracleDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        string result = "User Details:\n";
                        result = result + "UserID: " + reader["UserID"].ToString() + "\n";
                        result = result + "Username: " + reader["Username"].ToString() + "\n";
                        result = result + "PasswordHash: " + reader["PasswordHash"].ToString() + "\n";
                        result = result + "Role: " + reader["Role"].ToString() + "\n";
                        MessageBox.Show(result, "User Details", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("UserID not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    conn.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Manage Stocks: Delete, view all, or search a stock's details
        private void btnManageStocks_Click(object sender, EventArgs e)
        {
            string choice = Interaction.InputBox("Enter 'delete' to delete a stock, 'view' to see all stocks, or 'search' to find a stock:", "Manage Stocks");
            if (choice == "") return;

            if (choice.ToLower() == "delete")
            {
                string stockId = Interaction.InputBox("Enter StockID to delete:", "Delete Stock");
                if (stockId == "") return;

                try
                {
                    OracleConnection conn = new OracleConnection(Form1.DBHelper.ConnectionString);
                    conn.Open();

                    string query = "DELETE FROM Stock WHERE StockID = :stockId";
                    OracleCommand cmd = new OracleCommand(query, conn);
                    cmd.Parameters.Add("stockId", OracleDbType.Int32).Value = Convert.ToInt32(stockId);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Stock deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("StockID not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    conn.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (choice.ToLower() == "view")
            {
                AdminViewForm viewForm = new AdminViewForm("Stock");
                viewForm.ShowDialog();
            }
            else if (choice.ToLower() == "search")
            {
                string stockId = Interaction.InputBox("Enter StockID to search:", "Search Stock");
                if (stockId == "") return;

                try
                {
                    OracleConnection conn = new OracleConnection(Form1.DBHelper.ConnectionString);
                    conn.Open();

                    string query = "SELECT * FROM Stock WHERE StockID = :stockId";
                    OracleCommand cmd = new OracleCommand(query, conn);
                    cmd.Parameters.Add("stockId", OracleDbType.Int32).Value = Convert.ToInt32(stockId);

                    OracleDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        string result = "Stock Details:\n";
                        result = result + "StockID: " + reader["StockID"].ToString() + "\n";
                        result = result + "StockName: " + reader["StockName"].ToString() + "\n";
                        result = result + "StockSymbol: " + reader["StockSymbol"].ToString() + "\n";
                        result = result + "Sector: " + reader["Sector"].ToString() + "\n";
                        MessageBox.Show(result, "Stock Details", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("StockID not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    conn.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Manage Stock Data: Delete, view all, or search a stock data entry
        private void btnManageStockData_Click(object sender, EventArgs e)
        {
            string choice = Interaction.InputBox("Enter 'delete' to delete stock data, 'view' to see all stock data, or 'search' to find stock data:", "Manage Stock Data");
            if (choice == "") return;

            if (choice.ToLower() == "delete")
            {
                string stockId = Interaction.InputBox("Enter StockID:", "Delete Stock Data");
                string tradeDate = Interaction.InputBox("Enter TradeDate (DD-MON-RR, e.g., 27-MAR-25):", "Delete Stock Data");

                if (stockId == "" || tradeDate == "") return;

                try
                {
                    DateTime parsedTradeDate = DateTime.ParseExact(tradeDate, "dd-MMM-yy", System.Globalization.CultureInfo.InvariantCulture);

                    OracleConnection conn = new OracleConnection(Form1.DBHelper.ConnectionString);
                    conn.Open();

                    string query = "DELETE FROM PriceData WHERE StockID = :stockId AND TradeDate = TO_DATE(:tradeDate, 'DD-MON-RR')";
                    OracleCommand cmd = new OracleCommand(query, conn);
                    cmd.Parameters.Add("stockId", OracleDbType.Int32).Value = Convert.ToInt32(stockId);
                    cmd.Parameters.Add("tradeDate", OracleDbType.Varchar2).Value = tradeDate;

                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Stock data deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Stock data not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    conn.Close();
                }
                catch (FormatException)
                {
                    MessageBox.Show("Invalid date format! Please enter the date in DD-MON-RR format (e.g., 27-MAR-25).");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (choice.ToLower() == "view")
            {
                AdminViewForm viewForm = new AdminViewForm("PriceData");
                viewForm.ShowDialog();
            }
            else if (choice.ToLower() == "search")
            {
                string stockId = Interaction.InputBox("Enter StockID:", "Search Stock Data");
                string tradeDate = Interaction.InputBox("Enter TradeDate (DD-MON-RR, e.g., 27-MAR-25):", "Search Stock Data");

                if (stockId == "" || tradeDate == "") return;

                try
                {
                    DateTime parsedTradeDate = DateTime.ParseExact(tradeDate, "dd-MMM-yy", System.Globalization.CultureInfo.InvariantCulture);

                    OracleConnection conn = new OracleConnection(Form1.DBHelper.ConnectionString);
                    conn.Open();

                    string query = "SELECT * FROM PriceData WHERE StockID = :stockId AND TradeDate = TO_DATE(:tradeDate, 'DD-MON-RR')";
                    OracleCommand cmd = new OracleCommand(query, conn);
                    cmd.Parameters.Add("stockId", OracleDbType.Int32).Value = Convert.ToInt32(stockId);
                    cmd.Parameters.Add("tradeDate", OracleDbType.Varchar2).Value = tradeDate;

                    OracleDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        string result = "Stock Data Details:\n";
                        result = result + "StockID: " + reader["StockID"].ToString() + "\n";
                        result = result + "TradeDate: " + reader["TradeDate"].ToString() + "\n";
                        result = result + "OpenPrice: " + reader["OpenPrice"].ToString() + "\n";
                        result = result + "HighPrice: " + reader["HighPrice"].ToString() + "\n";
                        result = result + "LowPrice: " + reader["LowPrice"].ToString() + "\n";
                        result = result + "ClosePrice: " + reader["ClosePrice"].ToString() + "\n";
                        result = result + "AdjClosePrice: " + reader["AdjClosePrice"].ToString() + "\n";
                        result = result + "Volume: " + reader["Volume"].ToString() + "\n";
                        MessageBox.Show(result, "Stock Data Details", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Stock data not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    conn.Close();
                }
                catch (FormatException)
                {
                    MessageBox.Show("Invalid date format! Please enter the date in DD-MON-RR format (e.g., 27-MAR-25).");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Manage Predictions: Delete, view all, or search a prediction
        private void button4_Click(object sender, EventArgs e)
        {
            string choice = Interaction.InputBox("Enter 'delete' to delete a prediction, 'view' to see all predictions, or 'search' to find a prediction:", "Manage Predictions");
            if (choice == "") return;

            if (choice.ToLower() == "delete")
            {
                string predictionId = Interaction.InputBox("Enter PredictionID to delete:", "Delete Prediction");
                if (predictionId == "") return;

                try
                {
                    OracleConnection conn = new OracleConnection(Form1.DBHelper.ConnectionString);
                    conn.Open();

                    string query = "DELETE FROM Prediction WHERE PredictionID = :predictionId";
                    OracleCommand cmd = new OracleCommand(query, conn);
                    cmd.Parameters.Add("predictionId", OracleDbType.Int32).Value = Convert.ToInt32(predictionId);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Prediction deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("PredictionID not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    conn.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (choice.ToLower() == "view")
            {
                AdminViewForm viewForm = new AdminViewForm("Prediction");
                viewForm.ShowDialog();
            }
            else if (choice.ToLower() == "search")
            {
                string predictionId = Interaction.InputBox("Enter PredictionID to search:", "Search Prediction");
                if (predictionId == "") return;

                try
                {
                    OracleConnection conn = new OracleConnection(Form1.DBHelper.ConnectionString);
                    conn.Open();

                    string query = "SELECT * FROM Prediction WHERE PredictionID = :predictionId";
                    OracleCommand cmd = new OracleCommand(query, conn);
                    cmd.Parameters.Add("predictionId", OracleDbType.Int32).Value = Convert.ToInt32(predictionId);

                    OracleDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        string result = "Prediction Details:\n";
                        result = result + "PredictionID: " + reader["PredictionID"].ToString() + "\n";
                        result = result + "StockID: " + reader["StockID"].ToString() + "\n";
                        result = result + "PredictedDate: " + reader["PredictedDate"].ToString() + "\n";
                        result = result + "PredictedClosePrice: " + reader["PredictedClosePrice"].ToString() + "\n";
                        MessageBox.Show(result, "Prediction Details", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("PredictionID not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    conn.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Manage Transactions: Delete, view all, or search a transaction
        private void btnManageTrans_Click(object sender, EventArgs e)
        {
            string choice = Interaction.InputBox("Enter 'delete' to delete a transaction, 'view' to see all transactions, or 'search' to find a transaction:", "Manage Transactions");
            if (choice == "") return;

            if (choice.ToLower() == "delete")
            {
                string transactionId = Interaction.InputBox("Enter TransactionID to delete:", "Delete Transaction").Trim();
                if (transactionId == "")
                {
                    MessageBox.Show("TransactionID is required!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                try
                {
                    if (!int.TryParse(transactionId, out int parsedTransactionId))
                    {
                        MessageBox.Show("TransactionID must be a valid integer!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    using (OracleConnection conn = new OracleConnection(Form1.DBHelper.ConnectionString))
                    {
                        conn.Open();

                        string query = "DELETE FROM Transaction WHERE TransactionID = :transactionId";
                        using (OracleCommand cmd = new OracleCommand(query, conn))
                        {
                            cmd.Parameters.Add("transactionId", OracleDbType.Int32).Value = parsedTransactionId;

                            int rowsAffected = cmd.ExecuteNonQuery();
                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Transaction deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                MessageBox.Show("TransactionID not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }

                        conn.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (choice.ToLower() == "view")
            {
                AdminViewForm viewForm = new AdminViewForm("Transaction");
                viewForm.ShowDialog();
            }
            else if (choice.ToLower() == "search")
            {
                string transactionId = Interaction.InputBox("Enter TransactionID to search:", "Search Transaction").Trim();
                if (transactionId == "")
                {
                    MessageBox.Show("TransactionID is required!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                try
                {
                    if (!int.TryParse(transactionId, out int parsedTransactionId))
                    {
                        MessageBox.Show("TransactionID must be a valid integer!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    using (OracleConnection conn = new OracleConnection(Form1.DBHelper.ConnectionString))
                    {
                        conn.Open();

                        string query = "SELECT * FROM Transaction WHERE TransactionID = :transactionId";
                        using (OracleCommand cmd = new OracleCommand(query, conn))
                        {
                            cmd.Parameters.Add("transactionId", OracleDbType.Int32).Value = parsedTransactionId;

                            OracleDataReader reader = cmd.ExecuteReader();
                            if (reader.Read())
                            {
                                string result = "Transaction Details:\n";
                                result = result + "TransactionID: " + reader["TransactionID"].ToString() + "\n";
                                result = result + "StockID: " + reader["StockID"].ToString() + "\n";
                                result = result + "UserID: " + reader["UserID"].ToString() + "\n";
                                result = result + "TransactionDate: " + reader["TransactionDate"].ToString() + "\n";
                                result = result + "TransactionType: " + reader["TransactionType"].ToString() + "\n";
                                result = result + "TransactionAmount: " + reader["TransactionAmount"].ToString() + "\n";
                                result = result + "Shares: " + reader["Shares"].ToString() + "\n";
                                MessageBox.Show(result, "Transaction Details", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                MessageBox.Show("TransactionID not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }

                        conn.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Manage Watchlist: Delete, view all, or search a watchlist entry
        private void button1_Click(object sender, EventArgs e)
        {
            string choice = Interaction.InputBox("Enter 'delete' to delete a watchlist entry, 'view' to see all watchlist entries, or 'search' to find a watchlist entry:", "Manage Watchlist");
            if (choice == "") return;

            if (choice.ToLower() == "delete")
            {
                string watchlistId = Interaction.InputBox("Enter WatchlistID to delete:", "Delete Watchlist Entry");
                if (watchlistId == "") return;

                try
                {
                    OracleConnection conn = new OracleConnection(Form1.DBHelper.ConnectionString);
                    conn.Open();

                    string query = "DELETE FROM Watchlist WHERE WatchlistID = :watchlistId";
                    OracleCommand cmd = new OracleCommand(query, conn);
                    cmd.Parameters.Add("watchlistId", OracleDbType.Int32).Value = Convert.ToInt32(watchlistId);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Watchlist entry deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("WatchlistID not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    conn.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (choice.ToLower() == "view")
            {
                AdminViewForm viewForm = new AdminViewForm("Watchlist");
                viewForm.ShowDialog();
            }
            else if (choice.ToLower() == "search")
            {
                string watchlistId = Interaction.InputBox("Enter WatchlistID to search:", "Search Watchlist");
                if (watchlistId == "") return;

                try
                {
                    OracleConnection conn = new OracleConnection(Form1.DBHelper.ConnectionString);
                    conn.Open();

                    string query = "SELECT * FROM Watchlist WHERE WatchlistID = :watchlistId";
                    OracleCommand cmd = new OracleCommand(query, conn);
                    cmd.Parameters.Add("watchlistId", OracleDbType.Int32).Value = Convert.ToInt32(watchlistId);

                    OracleDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        string result = "Watchlist Details:\n";
                        result = result + "WatchlistID: " + reader["WatchlistID"].ToString() + "\n";
                        result = result + "UserID: " + reader["UserID"].ToString() + "\n";
                        result = result + "StockID: " + reader["StockID"].ToString() + "\n";
                        result = result + "DateAdded: " + reader["DateAdded"].ToString() + "\n";
                        MessageBox.Show(result, "Watchlist Details", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("WatchlistID not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    conn.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Manage Market News: Delete, view all, or search a news article
        private void button2_Click(object sender, EventArgs e)
        {
            string choice = Interaction.InputBox("Enter 'delete' to delete a news article, 'view' to see all news articles, or 'search' to find a news article:", "Manage Market News");
            if (choice == "") return;

            if (choice.ToLower() == "delete")
            {
                string newsId = Interaction.InputBox("Enter NewsID to delete:", "Delete News Article");
                if (newsId == "") return;

                try
                {
                    OracleConnection conn = new OracleConnection(Form1.DBHelper.ConnectionString);
                    conn.Open();

                    string query = "DELETE FROM MarketNews WHERE NewsID = :newsId";
                    OracleCommand cmd = new OracleCommand(query, conn);
                    cmd.Parameters.Add("newsId", OracleDbType.Int32).Value = Convert.ToInt32(newsId);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("News article deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("NewsID not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    conn.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (choice.ToLower() == "view")
            {
                AdminViewForm viewForm = new AdminViewForm("MarketNews");
                viewForm.ShowDialog();
            }
            else if (choice.ToLower() == "search")
            {
                string newsId = Interaction.InputBox("Enter NewsID to search:", "Search News");
                if (newsId == "") return;

                try
                {
                    OracleConnection conn = new OracleConnection(Form1.DBHelper.ConnectionString);
                    conn.Open();

                    string query = "SELECT * FROM MarketNews WHERE NewsID = :newsId";
                    OracleCommand cmd = new OracleCommand(query, conn);
                    cmd.Parameters.Add("newsId", OracleDbType.Int32).Value = Convert.ToInt32(newsId);

                    OracleDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        string result = "News Details:\n";
                        result = result + "NewsID: " + reader["NewsID"].ToString() + "\n";
                        result = result + "Title: " + reader["Title"].ToString() + "\n";
                        result = result + "Content: " + reader["Content"].ToString() + "\n";
                        result = result + "Source: " + reader["Source"].ToString() + "\n";
                        result = result + "PublishDate: " + reader["PublishDate"].ToString() + "\n";
                        MessageBox.Show(result, "News Details", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("NewsID not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    conn.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Manage Alerts: Delete, view all, or search an alert
        private void button3_Click(object sender, EventArgs e)
        {
            string choice = Interaction.InputBox("Enter 'delete' to delete an alert, 'view' to see all alerts, or 'search' to find an alert:", "Manage Alerts");
            if (choice == "") return;

            if (choice.ToLower() == "delete")
            {
                string alertId = Interaction.InputBox("Enter AlertID to delete:", "Delete Alert");
                if (alertId == "") return;

                try
                {
                    OracleConnection conn = new OracleConnection(Form1.DBHelper.ConnectionString);
                    conn.Open();

                    string query = "DELETE FROM Alert WHERE AlertID = :alertId";
                    OracleCommand cmd = new OracleCommand(query, conn);
                    cmd.Parameters.Add("alertId", OracleDbType.Int32).Value = Convert.ToInt32(alertId);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Alert deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("AlertID not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    conn.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (choice.ToLower() == "view")
            {
                AdminViewForm viewForm = new AdminViewForm("Alert");
                viewForm.ShowDialog();
            }
            else if (choice.ToLower() == "search")
            {
                string alertId = Interaction.InputBox("Enter AlertID to search:", "Search Alert");
                if (alertId == "") return;

                try
                {
                    OracleConnection conn = new OracleConnection(Form1.DBHelper.ConnectionString);
                    conn.Open();

                    string query = "SELECT * FROM Alert WHERE AlertID = :alertId";
                    OracleCommand cmd = new OracleCommand(query, conn);
                    cmd.Parameters.Add("alertId", OracleDbType.Int32).Value = Convert.ToInt32(alertId);

                    OracleDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        string result = "Alert Details:\n";
                        result = result + "AlertID: " + reader["AlertID"].ToString() + "\n";
                        result = result + "UserID: " + reader["UserID"].ToString() + "\n";
                        result = result + "StockID: " + reader["StockID"].ToString() + "\n";
                        result = result + "AlertType: " + reader["AlertType"].ToString() + "\n";
                        result = result + "AlertValue: " + reader["AlertValue"].ToString() + "\n";
                        result = result + "IsActive: " + reader["IsActive"].ToString() + "\n";
                        MessageBox.Show(result, "Alert Details", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("AlertID not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    conn.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form1 loginForm = new Form1();
            loginForm.Show();
            this.Close();
        }

        private void AdminDashboard_Load(object sender, EventArgs e)
        {
        }

        private void lblAdminTitle_Click(object sender, EventArgs e)
        {

        }
    }
}