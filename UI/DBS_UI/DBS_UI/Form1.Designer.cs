namespace DBS_UI
{
    partial class Form1
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
            this.userLoginLabel = new System.Windows.Forms.Label();
            this.usernameLabel = new System.Windows.Forms.Label();
            this.passwordLabel = new System.Windows.Forms.Label();
            this.usernameTextBox = new System.Windows.Forms.TextBox();
            this.passwordTextbox = new System.Windows.Forms.TextBox();
            this.loginButton = new System.Windows.Forms.Button();
            this.adminLoginButton = new System.Windows.Forms.Button();
            this.dontHaveAccountLabel = new System.Windows.Forms.Label();
            this.signupLinkL = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // userLoginLabel
            // 
            this.userLoginLabel.AutoSize = true;
            this.userLoginLabel.Font = new System.Drawing.Font("Segoe UI", 32F, System.Drawing.FontStyle.Bold);
            this.userLoginLabel.ForeColor = System.Drawing.Color.White;
            this.userLoginLabel.Location = new System.Drawing.Point(745, 185);
            this.userLoginLabel.Name = "userLoginLabel";
            this.userLoginLabel.Size = new System.Drawing.Size(410, 86);
            this.userLoginLabel.TabIndex = 0;
            this.userLoginLabel.Text = "USER LOGIN";
            this.userLoginLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.userLoginLabel.Click += new System.EventHandler(this.label1_Click);
            // 
            // usernameLabel
            // 
            this.usernameLabel.AutoSize = true;
            this.usernameLabel.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.usernameLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.usernameLabel.Location = new System.Drawing.Point(710, 348);
            this.usernameLabel.Name = "usernameLabel";
            this.usernameLabel.Size = new System.Drawing.Size(148, 38);
            this.usernameLabel.TabIndex = 1;
            this.usernameLabel.Text = "Username:";
            this.usernameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.usernameLabel.Click += new System.EventHandler(this.label2_Click);
            // 
            // passwordLabel
            // 
            this.passwordLabel.AutoSize = true;
            this.passwordLabel.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.passwordLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.passwordLabel.Location = new System.Drawing.Point(720, 432);
            this.passwordLabel.Name = "passwordLabel";
            this.passwordLabel.Size = new System.Drawing.Size(138, 38);
            this.passwordLabel.TabIndex = 2;
            this.passwordLabel.Text = "Password:";
            this.passwordLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.passwordLabel.Click += new System.EventHandler(this.label3_Click);
            // 
            // usernameTextBox
            // 
            this.usernameTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.usernameTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.usernameTextBox.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.usernameTextBox.ForeColor = System.Drawing.Color.White;
            this.usernameTextBox.Location = new System.Drawing.Point(880, 341);
            this.usernameTextBox.Name = "usernameTextBox";
            this.usernameTextBox.Size = new System.Drawing.Size(300, 45);
            this.usernameTextBox.TabIndex = 3;
            this.usernameTextBox.TextChanged += new System.EventHandler(this.emailTextBox_TextChanged);
            // 
            // passwordTextbox
            // 
            this.passwordTextbox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.passwordTextbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.passwordTextbox.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.passwordTextbox.ForeColor = System.Drawing.Color.White;
            this.passwordTextbox.Location = new System.Drawing.Point(880, 430);
            this.passwordTextbox.Name = "passwordTextbox";
            this.passwordTextbox.PasswordChar = '●';
            this.passwordTextbox.Size = new System.Drawing.Size(300, 45);
            this.passwordTextbox.TabIndex = 4;
            this.passwordTextbox.TextChanged += new System.EventHandler(this.passwordTextbox_TextChanged);
            // 
            // loginButton
            // 
            this.loginButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(255)))));
            this.loginButton.FlatAppearance.BorderSize = 0;
            this.loginButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.loginButton.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.loginButton.ForeColor = System.Drawing.Color.White;
            this.loginButton.Location = new System.Drawing.Point(857, 528);
            this.loginButton.Name = "loginButton";
            this.loginButton.Size = new System.Drawing.Size(140, 50);
            this.loginButton.TabIndex = 5;
            this.loginButton.Text = "LOGIN";
            this.loginButton.UseVisualStyleBackColor = false;
            this.loginButton.Click += new System.EventHandler(this.loginButton_Click);
            // 
            // adminLoginButton
            // 
            this.adminLoginButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(69)))), ((int)(((byte)(58)))));
            this.adminLoginButton.FlatAppearance.BorderSize = 0;
            this.adminLoginButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.adminLoginButton.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.adminLoginButton.ForeColor = System.Drawing.Color.White;
            this.adminLoginButton.Location = new System.Drawing.Point(1035, 528);
            this.adminLoginButton.Name = "adminLoginButton";
            this.adminLoginButton.Size = new System.Drawing.Size(160, 50);
            this.adminLoginButton.TabIndex = 6;
            this.adminLoginButton.Text = "ADMIN LOGIN";
            this.adminLoginButton.UseVisualStyleBackColor = false;
            this.adminLoginButton.Click += new System.EventHandler(this.adminLoginButton_Click);
            // 
            // dontHaveAccountLabel
            // 
            this.dontHaveAccountLabel.AutoSize = true;
            this.dontHaveAccountLabel.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.dontHaveAccountLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.dontHaveAccountLabel.Location = new System.Drawing.Point(754, 610);
            this.dontHaveAccountLabel.Name = "dontHaveAccountLabel";
            this.dontHaveAccountLabel.Size = new System.Drawing.Size(266, 32);
            this.dontHaveAccountLabel.TabIndex = 8;
            this.dontHaveAccountLabel.Text = "Don\'t have an account?";
            // 
            // signupLinkL
            // 
            this.signupLinkL.ActiveLinkColor = System.Drawing.Color.LightBlue;
            this.signupLinkL.AutoSize = true;
            this.signupLinkL.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.signupLinkL.LinkColor = System.Drawing.Color.Cyan;
            this.signupLinkL.Location = new System.Drawing.Point(1039, 610);
            this.signupLinkL.Name = "signupLinkL";
            this.signupLinkL.Size = new System.Drawing.Size(103, 32);
            this.signupLinkL.TabIndex = 9;
            this.signupLinkL.TabStop = true;
            this.signupLinkL.Text = "Sign Up";
            this.signupLinkL.VisitedLinkColor = System.Drawing.Color.Cyan;
            this.signupLinkL.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.signupLinkL_LinkClicked);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.ClientSize = new System.Drawing.Size(1920, 1050);
            this.Controls.Add(this.signupLinkL);
            this.Controls.Add(this.dontHaveAccountLabel);
            this.Controls.Add(this.adminLoginButton);
            this.Controls.Add(this.loginButton);
            this.Controls.Add(this.passwordTextbox);
            this.Controls.Add(this.usernameTextBox);
            this.Controls.Add(this.passwordLabel);
            this.Controls.Add(this.usernameLabel);
            this.Controls.Add(this.userLoginLabel);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label userLoginLabel;
        private System.Windows.Forms.Label usernameLabel;
        private System.Windows.Forms.Label passwordLabel;
        private System.Windows.Forms.TextBox usernameTextBox;
        private System.Windows.Forms.TextBox passwordTextbox;
        private System.Windows.Forms.Button loginButton;
        private System.Windows.Forms.Button adminLoginButton;
        private System.Windows.Forms.Label dontHaveAccountLabel;
        private System.Windows.Forms.LinkLabel signupLinkL;
    }
}

