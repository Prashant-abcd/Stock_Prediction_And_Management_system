using Oracle.ManagedDataAccess.Client;
using System;
using System.Data;
using System.Diagnostics; // For Process.Start to open URLs
using System.Drawing;
using System.Windows.Forms;

namespace DBS_UI
{
    public partial class NewsForm : Form
    {
        private DataGridView newsGridView;
        private PictureBox adPictureBox;

        public NewsForm()
        {
            // Set up form properties
            this.Text = "Market News";
            this.Size = new Size(900, 650); // Increased height to accommodate the ad
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.White;

            // Create a panel to hold the grid and ad
            Panel mainPanel = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.White
            };
            this.Controls.Add(mainPanel);

            // Initialize DataGridView programmatically
            newsGridView = new DataGridView
            {
                Location = new Point(0, 0),
                Size = new Size(900, 550), // Adjusted height to leave space for the ad
                BackgroundColor = Color.White,
                ForeColor = Color.Black,
                RowHeadersVisible = false,
                AllowUserToAddRows = false,
                ReadOnly = true,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None,
                RowTemplate = { Height = 60 },
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    BackColor = Color.White,
                    ForeColor = Color.Black,
                    SelectionBackColor = Color.FromArgb(0, 122, 255),
                    SelectionForeColor = Color.White
                },
                ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle
                {
                    BackColor = Color.White,
                    ForeColor = Color.Black,
                    Font = new Font("Segoe UI", 10F, FontStyle.Bold)
                }
            };
            newsGridView.CellDoubleClick += new DataGridViewCellEventHandler(newsGridView_CellDoubleClick);
            mainPanel.Controls.Add(newsGridView);

          
            adPictureBox = new PictureBox
            {
                Location = new Point(0, 550), 
                Size = new Size(900, 100), 
                SizeMode = PictureBoxSizeMode.StretchImage,
                Cursor = Cursors.Hand 
            };
            try
            {
                
                Bitmap placeholder = new Bitmap(900, 100);
                using (Graphics g = Graphics.FromImage(placeholder))
                {
                    g.Clear(Color.LightBlue);
                    using (Font font = new Font("Segoe UI", 12, FontStyle.Bold))
                    {
                        g.DrawString("Want to double your money? - Click Here!", font, Brushes.Black, new PointF(10, 40));
                    }
                }
                adPictureBox.Image = placeholder;
            }
            catch
            {
                // Fallback if image loading fails
                adPictureBox.BackColor = Color.LightBlue;
                adPictureBox.Text = "Want to double your money? - Click Here!";
            }
            adPictureBox.Click += new EventHandler(adPictureBox_Click);
            mainPanel.Controls.Add(adPictureBox);

            // Ensure the form is not transparent
            this.Opacity = 1.0;

            // Load news data
            LoadNews();

            this.Load += new EventHandler(NewsForm_Load);
        }

        private void LoadNews()
        {
            try
            {
                using (OracleConnection conn = new OracleConnection(Form1.DBHelper.ConnectionString))
                {
                    conn.Open();
                    string query = "SELECT NewsID, Title, Content, PublishDate FROM MarketNews ORDER BY PublishDate DESC";
                    using (OracleCommand cmd = new OracleCommand(query, conn))
                    {
                        using (OracleDataReader reader = cmd.ExecuteReader())
                        {
                            DataTable newsTable = new DataTable();
                            newsTable.Columns.Add("NewsID", typeof(int));
                            newsTable.Columns.Add("Title", typeof(string));
                            newsTable.Columns.Add("Content", typeof(string)); // Hidden, used for full content
                            newsTable.Columns.Add("Content Preview", typeof(string));
                            newsTable.Columns.Add("Publish Date", typeof(string));

                            int rowCount = 0;
                            while (reader.Read())
                            {
                                try
                                {
                                    int newsId = reader.GetInt32(0);
                                    string title = reader.IsDBNull(1) ? "N/A" : reader.GetString(1);

                                    // Handle CLOB content safely
                                    string content = "N/A";
                                    if (!reader.IsDBNull(2))
                                    {
                                        using (var clob = reader.GetOracleClob(2))
                                        {
                                            content = clob.Value.Length > 0 ? clob.Value : "N/A";
                                        }
                                    }

                                    DateTime publishDate = reader.IsDBNull(3) ? DateTime.MinValue : reader.GetDateTime(3);

                                    // Truncate content for preview
                                    string contentPreview = content.Length > 100 ? content.Substring(0, 100) + "..." : content;

                                    newsTable.Rows.Add(newsId, title, content, contentPreview, publishDate == DateTime.MinValue ? "N/A" : publishDate.ToString("yyyy-MM-dd"));
                                    rowCount++;
                                }
                                catch (Exception rowEx)
                                {
                                    MessageBox.Show($"Error loading row {rowCount + 1}: {rowEx.Message}", "Row Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    continue;
                                }
                            }

                            newsGridView.DataSource = newsTable;

                            // Hide the full Content column
                            if (newsGridView.Columns["Content"] != null)
                                newsGridView.Columns["Content"].Visible = false;

                            // Set column headers and properties
                            int formWidth = this.ClientSize.Width;
                            int fixedColumnsWidth = 80 + 200 + 120;
                            int contentPreviewWidth = formWidth - fixedColumnsWidth;

                            if (newsGridView.Columns["NewsID"] != null)
                            {
                                newsGridView.Columns["NewsID"].HeaderText = "News ID";
                                newsGridView.Columns["NewsID"].Width = 80;
                            }
                            if (newsGridView.Columns["Title"] != null)
                            {
                                newsGridView.Columns["Title"].HeaderText = "Title";
                                newsGridView.Columns["Title"].Width = 200;
                            }
                            if (newsGridView.Columns["Content Preview"] != null)
                            {
                                newsGridView.Columns["Content Preview"].HeaderText = "Content (Preview)";
                                newsGridView.Columns["Content Preview"].Width = contentPreviewWidth;
                                newsGridView.Columns["Content Preview"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                            }
                            if (newsGridView.Columns["Publish Date"] != null)
                            {
                                newsGridView.Columns["Publish Date"].HeaderText = "Publish Date";
                                newsGridView.Columns["Publish Date"].Width = 120;
                            }

                            // Ensure the grid refreshes
                            newsGridView.Refresh();

                            // Check if data was loaded
                            if (rowCount == 0)
                            {
                                MessageBox.Show("No news articles found in the MarketNews table.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                               // MessageBox.Show($"Loaded {rowCount} news articles.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading news: {ex.Message}\nStack Trace: {ex.StackTrace}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void adPictureBox_Click(object sender, EventArgs e)
        {
            try
            {

                Process.Start(new ProcessStartInfo
                {
                    FileName = "https://www.youtube.com/watch?v=j5Gs6Zv-ylM",
                    UseShellExecute = true
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error opening ad URL: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void newsGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = newsGridView.Rows[e.RowIndex];
                string title = row.Cells["Title"].Value.ToString();
                string content = row.Cells["Content"].Value.ToString();
                string publishDate = row.Cells["Publish Date"].Value.ToString();

                string message = $"Title: {title}\n\nDate: {publishDate}\n\nContent:\n{content}";
                MessageBox.Show(message, "News Article", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void NewsForm_Load(object sender, EventArgs e)
        {
            // LoadNews is already called in the constructor
        }
    }
}