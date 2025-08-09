using DBS_UI;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using static DBS_UI.Form1;

namespace DBS_UI
{
    public partial class signupForm : Form
    {
        public signupForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = usernameTextbox.Text;
            string password = passwordTextbox.Text;
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter both username and password!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                using (OracleConnection conn = new OracleConnection(DBHelper.ConnectionString))
                {
                    conn.Open();
                    string query = "INSERT INTO Users (Username, Passwordhash) VALUES (:username, :password)";
                    using (OracleCommand cmd = new OracleCommand(query, conn))
                    {
                        cmd.Parameters.Add("username", OracleDbType.Varchar2).Value = username;
                        cmd.Parameters.Add("passwordhash", OracleDbType.Varchar2).Value = password;
                        cmd.ExecuteNonQuery();
                    }
                    conn.Close();
                }
                MessageBox.Show("Account created! You can use these credentials to log in now.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Form1 loginForm = new Form1();
                loginForm.Show();
                this.Close();
            }

            catch (OracleException ex)
            {
                // Handle duplicate username
                if (ex.Number == 1)
                {
                    MessageBox.Show("Username already exists! Please choose a different username.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show($"Error: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void backtologinlinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form1 loginForm = new Form1();
            loginForm.Show();
            this.Close();
        }

        private void signupForm_Load(object sender, EventArgs e)
        {

        }

        private void passwordTextbox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

