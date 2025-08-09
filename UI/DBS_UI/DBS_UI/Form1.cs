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


namespace DBS_UI
{
    public partial class Form1 : Form
    {
        public static class DBHelper
        {
            public static string ConnectionString = "User Id=system;Password=Prashant11;Data Source=//localhost:1521/FREE";

            public static bool TestConnection()
            {
                try
                {
                    using (OracleConnection conn = new OracleConnection(ConnectionString))
                    {
                        conn.Open();
                        return true; // Connection successful
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Database Connection Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
        }

        public Form1()
        {
            InitializeComponent();


            if (DBHelper.TestConnection())
            {
              //  MessageBox.Show("Database Connection Successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void emailTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void passwordTextbox_TextChanged(object sender, EventArgs e)
        {

        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            string username = usernameTextBox.Text;
            string password = passwordTextbox.Text;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter both username and password!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                OracleConnection conn = new OracleConnection(DBHelper.ConnectionString);
                conn.Open();

                string query = "SELECT Passwordhash, Role FROM Users WHERE Username = :username";
                OracleCommand cmd = new OracleCommand(query, conn);
                cmd.Parameters.Add("username", OracleDbType.Varchar2).Value = username;

                OracleDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    string storedPassword = reader["Passwordhash"].ToString();
                    string role = reader["Role"].ToString();

                    if (storedPassword == password)
                    {
                        if (role == "Admin")
                        {
                            MessageBox.Show("Admins should use the Admin Login button!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                           // MessageBox.Show("Login successful! Welcome, " + username, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                             UserDashboard userDashboard = new UserDashboard(username);
                               userDashboard.Show();
                            this.Hide();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Wrong password!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Username not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Something went wrong: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void adminLoginButton_Click(object sender, EventArgs e)
        {
            string username = usernameTextBox.Text;
            string password = passwordTextbox.Text;


            if (username == "" || password == "")
            {
                MessageBox.Show("Please enter both username and password!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                OracleConnection conn = new OracleConnection(DBHelper.ConnectionString);
                conn.Open();
                string query = "SELECT Passwordhash, Role FROM Users WHERE Username = :username";
                OracleCommand cmd = new OracleCommand(query, conn);
                cmd.Parameters.Add("username", OracleDbType.Varchar2).Value = username;

                OracleDataReader reader = cmd.ExecuteReader();

                if (reader.Read()) // If a row is found
                {
                    string storedPassword = reader["Passwordhash"].ToString();
                    string role = reader["Role"].ToString();


                    if (storedPassword == password)
                    {
                        if (role == "Admin")
                        {
//MessageBox.Show("Admin login successful! Welcome, " + username, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                               AdminDashboard adminDashboard = new AdminDashboard();
                               adminDashboard.Show();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("You are not an admin!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Wrong password!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Username not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Something went wrong: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void signupLinkL_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            signupForm signupForm = new signupForm();
            signupForm.Show();
            this.Hide();
        }
    }
}
