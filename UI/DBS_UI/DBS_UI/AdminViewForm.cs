using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Oracle.ManagedDataAccess.Client;
using System;
using System.Data;
using System.Windows.Forms;
using DBS_UI;

namespace DBS_UI
{
    public partial class AdminViewForm : Form
    {
        private string tableName;

        public AdminViewForm(string tableName)
        {
            InitializeComponent();
            this.tableName = tableName;
            this.Text = "Viewing " + tableName;
            LoadGrid();
        }

        private void LoadGrid()
        {
            DataGridView grid = new DataGridView();
            grid.Dock = DockStyle.Fill;
            grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            grid.ReadOnly = true;
            grid.AllowUserToAddRows = false;
            this.Controls.Add(grid);

            try
            {
                OracleConnection conn = new OracleConnection(Form1.DBHelper.ConnectionString);
                conn.Open();

                string query = "SELECT * FROM " + tableName;
                OracleCommand cmd = new OracleCommand(query, conn);

                OracleDataAdapter adapter = new OracleDataAdapter(cmd);
                DataTable table = new DataTable();
                adapter.Fill(table);

                grid.DataSource = table;

                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AdminViewForm_Load(object sender, EventArgs e)
        {
        }
    }
}
