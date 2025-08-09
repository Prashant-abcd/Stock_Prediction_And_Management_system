using DBS_UI;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Data;
using System.Windows.Forms;

namespace DBS_UI
{
    public partial class WatchlistForm : Form
    {
        private string username;

        public WatchlistForm(string username)
        {
            InitializeComponent();
            this.username = username;
            this.Text = "Watchlist for " + username;
            LoadWatchlistGrid();
        }

        private void LoadWatchlistGrid()
        {
            DataGridView grid = new DataGridView();
            grid.Dock = DockStyle.Fill;
            grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            grid.ReadOnly = true;
            grid.AllowUserToAddRows = false;
            this.Controls.Add(grid);

            using (OracleConnection conn = new OracleConnection(Form1.DBHelper.ConnectionString))
            {
                conn.Open();
                string query = @"
            SELECT s.StockName AS ""Stock Name"", 
                   w.DateAdded AS ""Date Added"", 
                   (
                       (SELECT p.ClosePrice 
                        FROM PriceData p 
                        WHERE p.StockID = w.StockID 
                        AND p.TradeDate = (SELECT MAX(TradeDate) 
                                          FROM PriceData 
                                          WHERE StockID = w.StockID))
                       -
                       (SELECT p.ClosePrice 
                        FROM PriceData p 
                        WHERE p.StockID = w.StockID 
                        AND p.TradeDate = (SELECT MAX(TradeDate) 
                                          FROM PriceData 
                                          WHERE StockID = w.StockID 
                                          AND TradeDate <= w.DateAdded))
                   ) AS ""Performance""
            FROM Watchlist w 
            JOIN Stock s ON w.StockID = s.StockID 
            JOIN Users u ON w.UserID = u.UserID 
            WHERE u.Username = :username 
            ORDER BY w.DateAdded DESC";
                using (OracleCommand cmd = new OracleCommand(query, conn))
                {
                    cmd.Parameters.Add("username", OracleDbType.Varchar2).Value = username;
                    using (OracleDataAdapter adapter = new OracleDataAdapter(cmd))
                    {
                        DataTable table = new DataTable();
                        adapter.Fill(table);
                        grid.DataSource = table;
                    }
                }
                conn.Close();
            }
        }

        private void WatchlistForm_Load(object sender, EventArgs e)
        {
        }
    }
}