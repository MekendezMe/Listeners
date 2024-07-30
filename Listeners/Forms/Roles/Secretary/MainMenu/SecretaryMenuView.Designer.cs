namespace Listeners.MainMenu.Secretary
{
    partial class SecretaryMenuView
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
            this.buttonListeners = new System.Windows.Forms.Button();
            this.buttonRecords = new System.Windows.Forms.Button();
            this.buttonDirectory = new System.Windows.Forms.Button();
            this.buttonAuthorization = new System.Windows.Forms.Button();
            this.pictureBoxLogo = new System.Windows.Forms.PictureBox();
            this.buttonReportFRDO = new System.Windows.Forms.Button();
            this.groupBoxGroup = new System.Windows.Forms.GroupBox();
            this.buttonHide = new System.Windows.Forms.Button();
            this.buttonReport = new System.Windows.Forms.Button();
            this.labelGroup = new System.Windows.Forms.Label();
            this.comboBoxGroup = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).BeginInit();
            this.groupBoxGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelUser
            // 
            this.labelUser.AutoSize = true;
            this.labelUser.Location = new System.Drawing.Point(22, 18);
            this.labelUser.Name = "labelUser";
            this.labelUser.Size = new System.Drawing.Size(0, 20);
            this.labelUser.TabIndex = 1;
            // 
            // buttonListeners
            // 
            this.buttonListeners.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonListeners.BackColor = System.Drawing.Color.LightGray;
            this.buttonListeners.Location = new System.Drawing.Point(26, 114);
            this.buttonListeners.Name = "buttonListeners";
            this.buttonListeners.Size = new System.Drawing.Size(198, 33);
            this.buttonListeners.TabIndex = 2;
            this.buttonListeners.Text = "Слушатели";
            this.buttonListeners.UseVisualStyleBackColor = false;
            this.buttonListeners.Click += new System.EventHandler(this.buttonListeners_Click);
            // 
            // buttonRecords
            // 
            this.buttonRecords.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonRecords.BackColor = System.Drawing.Color.LightGray;
            this.buttonRecords.Location = new System.Drawing.Point(26, 175);
            this.buttonRecords.Name = "buttonRecords";
            this.buttonRecords.Size = new System.Drawing.Size(198, 35);
            this.buttonRecords.TabIndex = 7;
            this.buttonRecords.Text = "Договоры";
            this.buttonRecords.UseVisualStyleBackColor = false;
            this.buttonRecords.Click += new System.EventHandler(this.buttonRecords_Click);
            // 
            // buttonDirectory
            // 
            this.buttonDirectory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonDirectory.BackColor = System.Drawing.Color.LightGray;
            this.buttonDirectory.Location = new System.Drawing.Point(26, 51);
            this.buttonDirectory.Name = "buttonDirectory";
            this.buttonDirectory.Size = new System.Drawing.Size(198, 35);
            this.buttonDirectory.TabIndex = 9;
            this.buttonDirectory.Text = "Справочники";
            this.buttonDirectory.UseVisualStyleBackColor = false;
            this.buttonDirectory.Click += new System.EventHandler(this.buttonDirectory_Click);
            // 
            // buttonAuthorization
            // 
            this.buttonAuthorization.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAuthorization.BackColor = System.Drawing.Color.LightGray;
            this.buttonAuthorization.Location = new System.Drawing.Point(26, 310);
            this.buttonAuthorization.Name = "buttonAuthorization";
            this.buttonAuthorization.Size = new System.Drawing.Size(198, 35);
            this.buttonAuthorization.TabIndex = 10;
            this.buttonAuthorization.Text = "К авторизации";
            this.buttonAuthorization.UseVisualStyleBackColor = false;
            this.buttonAuthorization.Click += new System.EventHandler(this.buttonAuthorization_Click);
            // 
            // pictureBoxLogo
            // 
            this.pictureBoxLogo.Image = global::Listeners.Properties.Resources.update_logo;
            this.pictureBoxLogo.Location = new System.Drawing.Point(241, 51);
            this.pictureBoxLogo.Name = "pictureBoxLogo";
            this.pictureBoxLogo.Size = new System.Drawing.Size(556, 415);
            this.pictureBoxLogo.TabIndex = 8;
            this.pictureBoxLogo.TabStop = false;
            // 
            // buttonReportFRDO
            // 
            this.buttonReportFRDO.Location = new System.Drawing.Point(26, 232);
            this.buttonReportFRDO.Name = "buttonReportFRDO";
            this.buttonReportFRDO.Size = new System.Drawing.Size(198, 53);
            this.buttonReportFRDO.TabIndex = 26;
            this.buttonReportFRDO.Text = "Сформировать отчет ФИС ФРДО";
            this.buttonReportFRDO.UseVisualStyleBackColor = true;
            this.buttonReportFRDO.Click += new System.EventHandler(this.buttonReportFRDO_Click);
            // 
            // groupBoxGroup
            // 
            this.groupBoxGroup.Controls.Add(this.buttonHide);
            this.groupBoxGroup.Controls.Add(this.buttonReport);
            this.groupBoxGroup.Controls.Add(this.labelGroup);
            this.groupBoxGroup.Controls.Add(this.comboBoxGroup);
            this.groupBoxGroup.Location = new System.Drawing.Point(12, 204);
            this.groupBoxGroup.Name = "groupBoxGroup";
            this.groupBoxGroup.Size = new System.Drawing.Size(223, 110);
            this.groupBoxGroup.TabIndex = 27;
            this.groupBoxGroup.TabStop = false;
            this.groupBoxGroup.Text = "ФИС ФРДО";
            this.groupBoxGroup.Visible = false;
            // 
            // buttonHide
            // 
            this.buttonHide.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonHide.BackColor = System.Drawing.Color.LightGray;
            this.buttonHide.Location = new System.Drawing.Point(145, 72);
            this.buttonHide.Name = "buttonHide";
            this.buttonHide.Size = new System.Drawing.Size(67, 31);
            this.buttonHide.TabIndex = 29;
            this.buttonHide.Text = "Скрыть";
            this.buttonHide.UseVisualStyleBackColor = false;
            this.buttonHide.Click += new System.EventHandler(this.buttonHide_Click);
            // 
            // buttonReport
            // 
            this.buttonReport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonReport.BackColor = System.Drawing.Color.LightGray;
            this.buttonReport.Enabled = false;
            this.buttonReport.Location = new System.Drawing.Point(10, 72);
            this.buttonReport.Name = "buttonReport";
            this.buttonReport.Size = new System.Drawing.Size(67, 31);
            this.buttonReport.TabIndex = 28;
            this.buttonReport.Text = "Печать";
            this.buttonReport.UseVisualStyleBackColor = false;
            this.buttonReport.Click += new System.EventHandler(this.buttonReport_Click);
            // 
            // labelGroup
            // 
            this.labelGroup.AutoSize = true;
            this.labelGroup.Location = new System.Drawing.Point(6, 31);
            this.labelGroup.Name = "labelGroup";
            this.labelGroup.Size = new System.Drawing.Size(52, 20);
            this.labelGroup.TabIndex = 1;
            this.labelGroup.Text = "Группа";
            // 
            // comboBoxGroup
            // 
            this.comboBoxGroup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxGroup.FormattingEnabled = true;
            this.comboBoxGroup.Location = new System.Drawing.Point(64, 28);
            this.comboBoxGroup.Name = "comboBoxGroup";
            this.comboBoxGroup.Size = new System.Drawing.Size(148, 28);
            this.comboBoxGroup.TabIndex = 0;
            this.comboBoxGroup.SelectedIndexChanged += new System.EventHandler(this.comboBoxGroup_SelectedIndexChanged);
            // 
            // SecretaryMenuView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(819, 533);
            this.ControlBox = false;
            this.Controls.Add(this.groupBoxGroup);
            this.Controls.Add(this.buttonReportFRDO);
            this.Controls.Add(this.buttonAuthorization);
            this.Controls.Add(this.buttonDirectory);
            this.Controls.Add(this.pictureBoxLogo);
            this.Controls.Add(this.buttonRecords);
            this.Controls.Add(this.buttonListeners);
            this.Controls.Add(this.labelUser);
            this.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SecretaryMenuView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Главное меню";
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.SecretaryMenu_KeyPress);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.SecretaryMenu_MouseMove);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).EndInit();
            this.groupBoxGroup.ResumeLayout(false);
            this.groupBoxGroup.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelUser;
        private System.Windows.Forms.Button buttonListeners;
        private System.Windows.Forms.Button buttonRecords;
        private System.Windows.Forms.PictureBox pictureBoxLogo;
        private System.Windows.Forms.Button buttonDirectory;
        private System.Windows.Forms.Button buttonAuthorization;
        private System.Windows.Forms.Button buttonReportFRDO;
        private System.Windows.Forms.GroupBox groupBoxGroup;
        private System.Windows.Forms.Label labelGroup;
        private System.Windows.Forms.ComboBox comboBoxGroup;
        private System.Windows.Forms.Button buttonHide;
        private System.Windows.Forms.Button buttonReport;
    }
}