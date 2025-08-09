namespace DBS_UI
{
    partial class UserDashboard
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.WelcomeLabel = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.chooseStockInComboboxLabel = new System.Windows.Forms.Label();
            this.btnTrackStock = new System.Windows.Forms.Button();
            this.btnPredictStock = new System.Windows.Forms.Button();
            this.btnInvest = new System.Windows.Forms.Button();
            this.checkWatchlistButton = new System.Windows.Forms.Button();
            this.linkLogout = new System.Windows.Forms.LinkLabel();
            this.newsButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // WelcomeLabel
            // 
            this.WelcomeLabel.AutoSize = true;
            this.WelcomeLabel.Font = new System.Drawing.Font("Segoe UI", 32F, System.Drawing.FontStyle.Bold);
            this.WelcomeLabel.ForeColor = System.Drawing.Color.White;
            this.WelcomeLabel.Location = new System.Drawing.Point(682, 114);
            this.WelcomeLabel.Name = "WelcomeLabel";
            this.WelcomeLabel.Size = new System.Drawing.Size(333, 86);
            this.WelcomeLabel.TabIndex = 0;
            this.WelcomeLabel.Text = "Welcome,";
            this.WelcomeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.WelcomeLabel.Click += new System.EventHandler(this.WelcomeLabel_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.comboBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBox1.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.comboBox1.ForeColor = System.Drawing.Color.White;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(880, 245);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(393, 46);
            this.comboBox1.TabIndex = 2;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // chooseStockInComboboxLabel
            // 
            this.chooseStockInComboboxLabel.AutoSize = true;
            this.chooseStockInComboboxLabel.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.chooseStockInComboboxLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.chooseStockInComboboxLabel.Location = new System.Drawing.Point(673, 248);
            this.chooseStockInComboboxLabel.Name = "chooseStockInComboboxLabel";
            this.chooseStockInComboboxLabel.Size = new System.Drawing.Size(189, 38);
            this.chooseStockInComboboxLabel.TabIndex = 1;
            this.chooseStockInComboboxLabel.Text = "Choose Stock:";
            this.chooseStockInComboboxLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnTrackStock
            // 
            this.btnTrackStock.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(255)))));
            this.btnTrackStock.FlatAppearance.BorderSize = 0;
            this.btnTrackStock.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTrackStock.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.btnTrackStock.ForeColor = System.Drawing.Color.White;
            this.btnTrackStock.Location = new System.Drawing.Point(551, 350);
            this.btnTrackStock.Name = "btnTrackStock";
            this.btnTrackStock.Size = new System.Drawing.Size(259, 60);
            this.btnTrackStock.TabIndex = 3;
            this.btnTrackStock.Text = "TRACK STOCK";
            this.btnTrackStock.UseVisualStyleBackColor = false;
            this.btnTrackStock.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnPredictStock
            // 
            this.btnPredictStock.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(255)))));
            this.btnPredictStock.FlatAppearance.BorderSize = 0;
            this.btnPredictStock.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPredictStock.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.btnPredictStock.ForeColor = System.Drawing.Color.White;
            this.btnPredictStock.Location = new System.Drawing.Point(849, 350);
            this.btnPredictStock.Name = "btnPredictStock";
            this.btnPredictStock.Size = new System.Drawing.Size(275, 60);
            this.btnPredictStock.TabIndex = 4;
            this.btnPredictStock.Text = "PREDICT STOCK";
            this.btnPredictStock.UseVisualStyleBackColor = false;
            this.btnPredictStock.Click += new System.EventHandler(this.btnPredictStock_Click);
            // 
            // btnInvest
            // 
            this.btnInvest.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(255)))));
            this.btnInvest.FlatAppearance.BorderSize = 0;
            this.btnInvest.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInvest.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.btnInvest.ForeColor = System.Drawing.Color.White;
            this.btnInvest.Location = new System.Drawing.Point(1180, 350);
            this.btnInvest.Name = "btnInvest";
            this.btnInvest.Size = new System.Drawing.Size(180, 60);
            this.btnInvest.TabIndex = 5;
            this.btnInvest.Text = "INVEST";
            this.btnInvest.UseVisualStyleBackColor = false;
            this.btnInvest.Click += new System.EventHandler(this.btnInvest_Click);
            // 
            // checkWatchlistButton
            // 
            this.checkWatchlistButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(255)))));
            this.checkWatchlistButton.FlatAppearance.BorderSize = 0;
            this.checkWatchlistButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkWatchlistButton.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.checkWatchlistButton.ForeColor = System.Drawing.Color.White;
            this.checkWatchlistButton.Location = new System.Drawing.Point(601, 470);
            this.checkWatchlistButton.Name = "checkWatchlistButton";
            this.checkWatchlistButton.Size = new System.Drawing.Size(309, 60);
            this.checkWatchlistButton.TabIndex = 7;
            this.checkWatchlistButton.Text = "CHECK WATCHLIST";
            this.checkWatchlistButton.UseVisualStyleBackColor = false;
            this.checkWatchlistButton.Click += new System.EventHandler(this.checkWatchlistButton_Click);
            // 
            // linkLogout
            // 
            this.linkLogout.ActiveLinkColor = System.Drawing.Color.LightBlue;
            this.linkLogout.AutoSize = true;
            this.linkLogout.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.linkLogout.LinkColor = System.Drawing.Color.Cyan;
            this.linkLogout.Location = new System.Drawing.Point(920, 600);
            this.linkLogout.Name = "linkLogout";
            this.linkLogout.Size = new System.Drawing.Size(95, 32);
            this.linkLogout.TabIndex = 8;
            this.linkLogout.TabStop = true;
            this.linkLogout.Text = "Logout";
            this.linkLogout.VisitedLinkColor = System.Drawing.Color.Cyan;
            this.linkLogout.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLogout_LinkClicked_1);
            // 
            // newsButton
            // 
            this.newsButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(255)))));
            this.newsButton.FlatAppearance.BorderSize = 0;
            this.newsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.newsButton.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.newsButton.ForeColor = System.Drawing.Color.White;
            this.newsButton.Location = new System.Drawing.Point(948, 470);
            this.newsButton.Name = "newsButton";
            this.newsButton.Size = new System.Drawing.Size(193, 60);
            this.newsButton.TabIndex = 9;
            this.newsButton.Text = "NEWS ";
            this.newsButton.UseVisualStyleBackColor = false;
            this.newsButton.Click += new System.EventHandler(this.newsButton_Click);
            // 
            // UserDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.ClientSize = new System.Drawing.Size(1920, 1050);
            this.Controls.Add(this.newsButton);
            this.Controls.Add(this.linkLogout);
            this.Controls.Add(this.checkWatchlistButton);
            this.Controls.Add(this.btnInvest);
            this.Controls.Add(this.btnPredictStock);
            this.Controls.Add(this.btnTrackStock);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.chooseStockInComboboxLabel);
            this.Controls.Add(this.WelcomeLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "UserDashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "User Dashboard";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.UserDashboard_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label WelcomeLabel;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label chooseStockInComboboxLabel;
        private System.Windows.Forms.Button btnTrackStock;
        private System.Windows.Forms.Button btnPredictStock;
        private System.Windows.Forms.Button btnInvest;
        private System.Windows.Forms.Button checkWatchlistButton;
        private System.Windows.Forms.LinkLabel linkLogout;
        private System.Windows.Forms.Button newsButton;
    }
}