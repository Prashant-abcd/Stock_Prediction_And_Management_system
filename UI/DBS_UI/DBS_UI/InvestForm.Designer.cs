namespace DBS_UI
{
    partial class InvestForm
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
            this.lblStockInfo = new System.Windows.Forms.Label();
            this.lblCurrentPrice = new System.Windows.Forms.Label();
            this.lblHoldings = new System.Windows.Forms.Label();
            this.lblPortfolioValue = new System.Windows.Forms.Label();
            this.radioBuy = new System.Windows.Forms.RadioButton();
            this.radioSell = new System.Windows.Forms.RadioButton();
            this.addStockToWatchlistRadioButton = new System.Windows.Forms.RadioButton();
            this.txtShares = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnBestPerformingStocks = new System.Windows.Forms.Button();
            this.btnWorstPerformingStocks = new System.Windows.Forms.Button();
            this.transHistoryBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblStockInfo
            // 
            this.lblStockInfo.AutoSize = true;
            this.lblStockInfo.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.lblStockInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.lblStockInfo.Location = new System.Drawing.Point(710, 200);
            this.lblStockInfo.Name = "lblStockInfo";
            this.lblStockInfo.Size = new System.Drawing.Size(202, 38);
            this.lblStockInfo.TabIndex = 0;
            this.lblStockInfo.Text = "Selected Stock:";
            this.lblStockInfo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblCurrentPrice
            // 
            this.lblCurrentPrice.AutoSize = true;
            this.lblCurrentPrice.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.lblCurrentPrice.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.lblCurrentPrice.Location = new System.Drawing.Point(710, 250);
            this.lblCurrentPrice.Name = "lblCurrentPrice";
            this.lblCurrentPrice.Size = new System.Drawing.Size(185, 38);
            this.lblCurrentPrice.TabIndex = 1;
            this.lblCurrentPrice.Text = "Current Price:";
            this.lblCurrentPrice.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblHoldings
            // 
            this.lblHoldings.AutoSize = true;
            this.lblHoldings.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.lblHoldings.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.lblHoldings.Location = new System.Drawing.Point(710, 300);
            this.lblHoldings.Name = "lblHoldings";
            this.lblHoldings.Size = new System.Drawing.Size(133, 38);
            this.lblHoldings.TabIndex = 2;
            this.lblHoldings.Text = "Holdings:";
            this.lblHoldings.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblPortfolioValue
            // 
            this.lblPortfolioValue.AutoSize = true;
            this.lblPortfolioValue.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.lblPortfolioValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.lblPortfolioValue.Location = new System.Drawing.Point(710, 350);
            this.lblPortfolioValue.Name = "lblPortfolioValue";
            this.lblPortfolioValue.Size = new System.Drawing.Size(203, 38);
            this.lblPortfolioValue.TabIndex = 3;
            this.lblPortfolioValue.Text = "Portfolio Value:";
            this.lblPortfolioValue.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // radioBuy
            // 
            this.radioBuy.AutoSize = true;
            this.radioBuy.BackColor = System.Drawing.Color.Transparent;
            this.radioBuy.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.radioBuy.ForeColor = System.Drawing.Color.White;
            this.radioBuy.Location = new System.Drawing.Point(717, 502);
            this.radioBuy.Name = "radioBuy";
            this.radioBuy.Size = new System.Drawing.Size(88, 42);
            this.radioBuy.TabIndex = 4;
            this.radioBuy.Text = "Buy";
            this.radioBuy.UseVisualStyleBackColor = false;
            this.radioBuy.CheckedChanged += new System.EventHandler(this.radioBuy_CheckedChanged);
            // 
            // radioSell
            // 
            this.radioSell.AutoSize = true;
            this.radioSell.BackColor = System.Drawing.Color.Transparent;
            this.radioSell.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.radioSell.ForeColor = System.Drawing.Color.White;
            this.radioSell.Location = new System.Drawing.Point(874, 502);
            this.radioSell.Name = "radioSell";
            this.radioSell.Size = new System.Drawing.Size(86, 42);
            this.radioSell.TabIndex = 5;
            this.radioSell.Text = "Sell";
            this.radioSell.UseVisualStyleBackColor = false;
            this.radioSell.CheckedChanged += new System.EventHandler(this.radioSell_CheckedChanged);
            // 
            // addStockToWatchlistRadioButton
            // 
            this.addStockToWatchlistRadioButton.AutoSize = true;
            this.addStockToWatchlistRadioButton.BackColor = System.Drawing.Color.Transparent;
            this.addStockToWatchlistRadioButton.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.addStockToWatchlistRadioButton.ForeColor = System.Drawing.Color.White;
            this.addStockToWatchlistRadioButton.Location = new System.Drawing.Point(1029, 502);
            this.addStockToWatchlistRadioButton.Name = "addStockToWatchlistRadioButton";
            this.addStockToWatchlistRadioButton.Size = new System.Drawing.Size(245, 42);
            this.addStockToWatchlistRadioButton.TabIndex = 6;
            this.addStockToWatchlistRadioButton.Text = "Add to Watchlist";
            this.addStockToWatchlistRadioButton.UseVisualStyleBackColor = false;
            // 
            // txtShares
            // 
            this.txtShares.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.txtShares.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtShares.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.txtShares.ForeColor = System.Drawing.Color.White;
            this.txtShares.Location = new System.Drawing.Point(811, 445);
            this.txtShares.Name = "txtShares";
            this.txtShares.Size = new System.Drawing.Size(300, 45);
            this.txtShares.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.label1.Location = new System.Drawing.Point(648, 447);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 38);
            this.label1.TabIndex = 8;
            this.label1.Text = "Shares:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnConfirm
            // 
            this.btnConfirm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(255)))));
            this.btnConfirm.FlatAppearance.BorderSize = 0;
            this.btnConfirm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfirm.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.btnConfirm.ForeColor = System.Drawing.Color.White;
            this.btnConfirm.Location = new System.Drawing.Point(717, 571);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(262, 60);
            this.btnConfirm.TabIndex = 9;
            this.btnConfirm.Text = "CONFIRM";
            this.btnConfirm.UseVisualStyleBackColor = false;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(69)))), ((int)(((byte)(58)))));
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(1029, 571);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(140, 60);
            this.btnCancel.TabIndex = 10;
            this.btnCancel.Text = "CANCEL";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnBestPerformingStocks
            // 
            this.btnBestPerformingStocks.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(255)))));
            this.btnBestPerformingStocks.FlatAppearance.BorderSize = 0;
            this.btnBestPerformingStocks.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBestPerformingStocks.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.btnBestPerformingStocks.ForeColor = System.Drawing.Color.White;
            this.btnBestPerformingStocks.Location = new System.Drawing.Point(470, 650);
            this.btnBestPerformingStocks.Name = "btnBestPerformingStocks";
            this.btnBestPerformingStocks.Size = new System.Drawing.Size(457, 60);
            this.btnBestPerformingStocks.TabIndex = 11;
            this.btnBestPerformingStocks.Text = "BEST PERFORMING STOCKS";
            this.btnBestPerformingStocks.UseVisualStyleBackColor = false;
            this.btnBestPerformingStocks.Click += new System.EventHandler(this.btnBestPerformingStocks_Click);
            // 
            // btnWorstPerformingStocks
            // 
            this.btnWorstPerformingStocks.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(255)))));
            this.btnWorstPerformingStocks.FlatAppearance.BorderSize = 0;
            this.btnWorstPerformingStocks.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnWorstPerformingStocks.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.btnWorstPerformingStocks.ForeColor = System.Drawing.Color.White;
            this.btnWorstPerformingStocks.Location = new System.Drawing.Point(980, 650);
            this.btnWorstPerformingStocks.Name = "btnWorstPerformingStocks";
            this.btnWorstPerformingStocks.Size = new System.Drawing.Size(460, 60);
            this.btnWorstPerformingStocks.TabIndex = 12;
            this.btnWorstPerformingStocks.Text = "WORST PERFORMING STOCKS";
            this.btnWorstPerformingStocks.UseVisualStyleBackColor = false;
            this.btnWorstPerformingStocks.Click += new System.EventHandler(this.btnWorstPerformingStocks_Click);
            // 
            // transHistoryBtn
            // 
            this.transHistoryBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(255)))));
            this.transHistoryBtn.FlatAppearance.BorderSize = 0;
            this.transHistoryBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.transHistoryBtn.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.transHistoryBtn.ForeColor = System.Drawing.Color.White;
            this.transHistoryBtn.Location = new System.Drawing.Point(743, 743);
            this.transHistoryBtn.Name = "transHistoryBtn";
            this.transHistoryBtn.Size = new System.Drawing.Size(466, 60);
            this.transHistoryBtn.TabIndex = 13;
            this.transHistoryBtn.Text = "TRANSACTION HISTORY";
            this.transHistoryBtn.UseVisualStyleBackColor = false;
            this.transHistoryBtn.Click += new System.EventHandler(this.transHistoryBtn_Click);
            // 
            // InvestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.ClientSize = new System.Drawing.Size(1920, 1050);
            this.Controls.Add(this.transHistoryBtn);
            this.Controls.Add(this.btnWorstPerformingStocks);
            this.Controls.Add(this.btnBestPerformingStocks);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtShares);
            this.Controls.Add(this.addStockToWatchlistRadioButton);
            this.Controls.Add(this.radioSell);
            this.Controls.Add(this.radioBuy);
            this.Controls.Add(this.lblPortfolioValue);
            this.Controls.Add(this.lblHoldings);
            this.Controls.Add(this.lblCurrentPrice);
            this.Controls.Add(this.lblStockInfo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "InvestForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Invest in Stock";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.InvestForm_Load_1);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblStockInfo;
        private System.Windows.Forms.Label lblCurrentPrice;
        private System.Windows.Forms.Label lblHoldings;
        private System.Windows.Forms.Label lblPortfolioValue;
        private System.Windows.Forms.RadioButton radioBuy;
        private System.Windows.Forms.RadioButton radioSell;
        private System.Windows.Forms.RadioButton addStockToWatchlistRadioButton;
        private System.Windows.Forms.TextBox txtShares;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnBestPerformingStocks;
        private System.Windows.Forms.Button btnWorstPerformingStocks;
        private System.Windows.Forms.Button transHistoryBtn;
    }
}