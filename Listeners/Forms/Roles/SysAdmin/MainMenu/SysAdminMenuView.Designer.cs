namespace Listeners.MainMenu.SysAdmin
{
    partial class SysAdminMenuView
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
            this.labelUser = new System.Windows.Forms.Label();
            this.buttonEmployees = new System.Windows.Forms.Button();
            this.buttonExportDatabase = new System.Windows.Forms.Button();
            this.buttonImportDatabase = new System.Windows.Forms.Button();
            this.buttonDirectory = new System.Windows.Forms.Button();
            this.buttonBack = new System.Windows.Forms.Button();
            this.buttonUsers = new System.Windows.Forms.Button();
            this.folderBrowserDialogDatabase = new System.Windows.Forms.FolderBrowserDialog();
            this.openFileDialogDatabase = new System.Windows.Forms.OpenFileDialog();
            this.pictureBoxLogo = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // labelUser
            // 
            this.labelUser.AutoSize = true;
            this.labelUser.Location = new System.Drawing.Point(16, 9);
            this.labelUser.Name = "labelUser";
            this.labelUser.Size = new System.Drawing.Size(0, 20);
            this.labelUser.TabIndex = 0;
            // 
            // buttonEmployees
            // 
            this.buttonEmployees.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonEmployees.Location = new System.Drawing.Point(20, 99);
            this.buttonEmployees.Name = "buttonEmployees";
            this.buttonEmployees.Size = new System.Drawing.Size(224, 32);
            this.buttonEmployees.TabIndex = 16;
            this.buttonEmployees.Text = "Сотрудники";
            this.buttonEmployees.UseVisualStyleBackColor = true;
            this.buttonEmployees.Click += new System.EventHandler(this.buttonEmployees_Click);
            // 
            // buttonExportDatabase
            // 
            this.buttonExportDatabase.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonExportDatabase.Location = new System.Drawing.Point(20, 198);
            this.buttonExportDatabase.Name = "buttonExportDatabase";
            this.buttonExportDatabase.Size = new System.Drawing.Size(224, 32);
            this.buttonExportDatabase.TabIndex = 17;
            this.buttonExportDatabase.Text = "Выгрузить базу данных";
            this.buttonExportDatabase.UseVisualStyleBackColor = true;
            this.buttonExportDatabase.Click += new System.EventHandler(this.buttonExportDatabase_Click);
            // 
            // buttonImportDatabase
            // 
            this.buttonImportDatabase.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonImportDatabase.Location = new System.Drawing.Point(20, 247);
            this.buttonImportDatabase.Name = "buttonImportDatabase";
            this.buttonImportDatabase.Size = new System.Drawing.Size(224, 32);
            this.buttonImportDatabase.TabIndex = 18;
            this.buttonImportDatabase.Text = "Загрузить базу данных";
            this.buttonImportDatabase.UseVisualStyleBackColor = true;
            this.buttonImportDatabase.Click += new System.EventHandler(this.buttonImportDatabase_Click);
            // 
            // buttonDirectory
            // 
            this.buttonDirectory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonDirectory.Location = new System.Drawing.Point(20, 43);
            this.buttonDirectory.Name = "buttonDirectory";
            this.buttonDirectory.Size = new System.Drawing.Size(224, 32);
            this.buttonDirectory.TabIndex = 19;
            this.buttonDirectory.Text = "Справочники";
            this.buttonDirectory.UseVisualStyleBackColor = true;
            this.buttonDirectory.Click += new System.EventHandler(this.buttonDirectory_Click);
            // 
            // buttonBack
            // 
            this.buttonBack.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonBack.Location = new System.Drawing.Point(20, 310);
            this.buttonBack.Name = "buttonBack";
            this.buttonBack.Size = new System.Drawing.Size(224, 32);
            this.buttonBack.TabIndex = 20;
            this.buttonBack.Text = "К авторизации";
            this.buttonBack.UseVisualStyleBackColor = true;
            this.buttonBack.Click += new System.EventHandler(this.buttonBack_Click);
            // 
            // buttonUsers
            // 
            this.buttonUsers.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonUsers.Location = new System.Drawing.Point(20, 149);
            this.buttonUsers.Name = "buttonUsers";
            this.buttonUsers.Size = new System.Drawing.Size(224, 32);
            this.buttonUsers.TabIndex = 21;
            this.buttonUsers.Text = "Пользователи";
            this.buttonUsers.UseVisualStyleBackColor = true;
            this.buttonUsers.Click += new System.EventHandler(this.buttonUsers_Click);
            // 
            // openFileDialogDatabase
            // 
            this.openFileDialogDatabase.FileName = "openFileDialog1";
            // 
            // pictureBoxLogo
            // 
            this.pictureBoxLogo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBoxLogo.Image = global::Listeners.Properties.Resources.update_logo;
            this.pictureBoxLogo.Location = new System.Drawing.Point(279, 20);
            this.pictureBoxLogo.Name = "pictureBoxLogo";
            this.pictureBoxLogo.Size = new System.Drawing.Size(539, 428);
            this.pictureBoxLogo.TabIndex = 9;
            this.pictureBoxLogo.TabStop = false;
            // 
            // SysAdminMenuView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(841, 484);
            this.ControlBox = false;
            this.Controls.Add(this.buttonUsers);
            this.Controls.Add(this.buttonBack);
            this.Controls.Add(this.buttonDirectory);
            this.Controls.Add(this.buttonImportDatabase);
            this.Controls.Add(this.buttonExportDatabase);
            this.Controls.Add(this.buttonEmployees);
            this.Controls.Add(this.pictureBoxLogo);
            this.Controls.Add(this.labelUser);
            this.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1034, 556);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(857, 500);
            this.Name = "SysAdminMenuView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Главное меню";
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.SysAdminMenuView_KeyPress);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.SysAdminMenuView_MouseMove);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelUser;
        private System.Windows.Forms.PictureBox pictureBoxLogo;
        private System.Windows.Forms.Button buttonEmployees;
        private System.Windows.Forms.Button buttonExportDatabase;
        private System.Windows.Forms.Button buttonImportDatabase;
        private System.Windows.Forms.Button buttonDirectory;
        private System.Windows.Forms.Button buttonBack;
        private System.Windows.Forms.Button buttonUsers;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialogDatabase;
        private System.Windows.Forms.OpenFileDialog openFileDialogDatabase;
    }
}