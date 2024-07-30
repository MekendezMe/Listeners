namespace Listeners
{
    partial class AuthorizationView
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
            this.components = new System.ComponentModel.Container();
            this.textBoxCaptcha = new System.Windows.Forms.TextBox();
            this.buttonShowPassword = new System.Windows.Forms.Button();
            this.buttonOut = new System.Windows.Forms.Button();
            this.buttonEntry = new System.Windows.Forms.Button();
            this.labelPassword = new System.Windows.Forms.Label();
            this.labelLogin = new System.Windows.Forms.Label();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.textBoxLogin = new System.Windows.Forms.TextBox();
            this.blockTimer = new System.Windows.Forms.Timer(this.components);
            this.textBoxTimer = new System.Windows.Forms.TextBox();
            this.textBoxCaptchaEnter = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // textBoxCaptcha
            // 
            this.textBoxCaptcha.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxCaptcha.Location = new System.Drawing.Point(115, 237);
            this.textBoxCaptcha.MaxLength = 6;
            this.textBoxCaptcha.Name = "textBoxCaptcha";
            this.textBoxCaptcha.Size = new System.Drawing.Size(145, 26);
            this.textBoxCaptcha.TabIndex = 17;
            this.textBoxCaptcha.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxCaptcha.Visible = false;
            this.textBoxCaptcha.Enter += new System.EventHandler(this.textBoxCaptcha_Enter);
            // 
            // buttonShowPassword
            // 
            this.buttonShowPassword.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonShowPassword.BackColor = System.Drawing.Color.LightGray;
            this.buttonShowPassword.Location = new System.Drawing.Point(342, 142);
            this.buttonShowPassword.Name = "buttonShowPassword";
            this.buttonShowPassword.Size = new System.Drawing.Size(29, 28);
            this.buttonShowPassword.TabIndex = 15;
            this.buttonShowPassword.Text = "👁";
            this.buttonShowPassword.UseVisualStyleBackColor = false;
            this.buttonShowPassword.Click += new System.EventHandler(this.buttonShowPassword_Click);
            // 
            // buttonOut
            // 
            this.buttonOut.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonOut.BackColor = System.Drawing.Color.LightGray;
            this.buttonOut.Location = new System.Drawing.Point(115, 380);
            this.buttonOut.Name = "buttonOut";
            this.buttonOut.Size = new System.Drawing.Size(145, 33);
            this.buttonOut.TabIndex = 14;
            this.buttonOut.Text = "Выход";
            this.buttonOut.UseVisualStyleBackColor = false;
            this.buttonOut.Click += new System.EventHandler(this.buttonOut_Click);
            // 
            // buttonEntry
            // 
            this.buttonEntry.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonEntry.BackColor = System.Drawing.Color.LightGreen;
            this.buttonEntry.Location = new System.Drawing.Point(115, 315);
            this.buttonEntry.Name = "buttonEntry";
            this.buttonEntry.Size = new System.Drawing.Size(145, 36);
            this.buttonEntry.TabIndex = 13;
            this.buttonEntry.Text = "Вход";
            this.buttonEntry.UseVisualStyleBackColor = false;
            this.buttonEntry.Click += new System.EventHandler(this.buttonEntry_Click);
            // 
            // labelPassword
            // 
            this.labelPassword.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelPassword.AutoSize = true;
            this.labelPassword.Location = new System.Drawing.Point(8, 109);
            this.labelPassword.Name = "labelPassword";
            this.labelPassword.Size = new System.Drawing.Size(61, 20);
            this.labelPassword.TabIndex = 12;
            this.labelPassword.Text = "Пароль*";
            // 
            // labelLogin
            // 
            this.labelLogin.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelLogin.AutoSize = true;
            this.labelLogin.Location = new System.Drawing.Point(8, 19);
            this.labelLogin.Name = "labelLogin";
            this.labelLogin.Size = new System.Drawing.Size(50, 20);
            this.labelLogin.TabIndex = 11;
            this.labelLogin.Text = "Логин*";
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxPassword.Location = new System.Drawing.Point(12, 144);
            this.textBoxPassword.MaxLength = 100;
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.Size = new System.Drawing.Size(318, 26);
            this.textBoxPassword.TabIndex = 10;
            this.textBoxPassword.UseSystemPasswordChar = true;
            this.textBoxPassword.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxPassword_KeyPress);
            // 
            // textBoxLogin
            // 
            this.textBoxLogin.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxLogin.Location = new System.Drawing.Point(12, 54);
            this.textBoxLogin.MaxLength = 50;
            this.textBoxLogin.Name = "textBoxLogin";
            this.textBoxLogin.Size = new System.Drawing.Size(318, 26);
            this.textBoxLogin.TabIndex = 9;
            this.textBoxLogin.Enter += new System.EventHandler(this.textBoxCaptcha_Enter);
            this.textBoxLogin.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxPassword_KeyPress);
            // 
            // blockTimer
            // 
            this.blockTimer.Interval = 1000;
            this.blockTimer.Tick += new System.EventHandler(this.blockTimer_Tick);
            // 
            // textBoxTimer
            // 
            this.textBoxTimer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxTimer.Location = new System.Drawing.Point(160, 272);
            this.textBoxTimer.MaxLength = 100;
            this.textBoxTimer.Name = "textBoxTimer";
            this.textBoxTimer.Size = new System.Drawing.Size(56, 26);
            this.textBoxTimer.TabIndex = 19;
            this.textBoxTimer.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxTimer.Visible = false;
            // 
            // textBoxCaptchaEnter
            // 
            this.textBoxCaptchaEnter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxCaptchaEnter.Location = new System.Drawing.Point(115, 195);
            this.textBoxCaptchaEnter.MaxLength = 100;
            this.textBoxCaptchaEnter.Name = "textBoxCaptchaEnter";
            this.textBoxCaptchaEnter.Size = new System.Drawing.Size(145, 26);
            this.textBoxCaptchaEnter.TabIndex = 20;
            this.textBoxCaptchaEnter.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxCaptchaEnter.Visible = false;
            // 
            // AuthorizationView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(383, 494);
            this.ControlBox = false;
            this.Controls.Add(this.textBoxCaptchaEnter);
            this.Controls.Add(this.textBoxTimer);
            this.Controls.Add(this.textBoxCaptcha);
            this.Controls.Add(this.buttonShowPassword);
            this.Controls.Add(this.buttonOut);
            this.Controls.Add(this.buttonEntry);
            this.Controls.Add(this.labelPassword);
            this.Controls.Add(this.labelLogin);
            this.Controls.Add(this.textBoxPassword);
            this.Controls.Add(this.textBoxLogin);
            this.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(506, 604);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(399, 510);
            this.Name = "AuthorizationView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Авторизация";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxCaptcha;
        private System.Windows.Forms.Button buttonShowPassword;
        private System.Windows.Forms.Button buttonOut;
        private System.Windows.Forms.Button buttonEntry;
        private System.Windows.Forms.Label labelPassword;
        private System.Windows.Forms.Label labelLogin;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.TextBox textBoxLogin;
        private System.Windows.Forms.Timer blockTimer;
        private System.Windows.Forms.TextBox textBoxTimer;
        private System.Windows.Forms.TextBox textBoxCaptchaEnter;
    }
}