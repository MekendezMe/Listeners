namespace Listeners.MainMenu.Manager
{
    partial class ManagerMenuView
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
            this.buttonReports = new System.Windows.Forms.Button();
            this.buttonContracts = new System.Windows.Forms.Button();
            this.pictureBoxLogo = new System.Windows.Forms.PictureBox();
            this.buttonBack = new System.Windows.Forms.Button();
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
            this.labelUser.Location = new System.Drawing.Point(21, 19);
            this.labelUser.Name = "labelUser";
            this.labelUser.Size = new System.Drawing.Size(0, 20);
            this.labelUser.TabIndex = 1;
            // 
            // buttonReports
            // 
            this.buttonReports.Location = new System.Drawing.Point(35, 126);
            this.buttonReports.Name = "buttonReports";
            this.buttonReports.Size = new System.Drawing.Size(228, 32);
            this.buttonReports.TabIndex = 23;
            this.buttonReports.Text = "Отчеты";
            this.buttonReports.UseVisualStyleBackColor = true;
            this.buttonReports.Click += new System.EventHandler(this.buttonReports_Click);
            // 
            // buttonContracts
            // 
            this.buttonContracts.Location = new System.Drawing.Point(35, 68);
            this.buttonContracts.Name = "buttonContracts";
            this.buttonContracts.Size = new System.Drawing.Size(228, 32);
            this.buttonContracts.TabIndex = 22;
            this.buttonContracts.Text = "Договоры";
            this.buttonContracts.UseVisualStyleBackColor = true;
            this.buttonContracts.Click += new System.EventHandler(this.buttonContracts_Click);
            // 
            // pictureBoxLogo
            // 
            this.pictureBoxLogo.Image = global::Listeners.Properties.Resources.update_logo;
            this.pictureBoxLogo.Location = new System.Drawing.Point(284, 22);
            this.pictureBoxLogo.Name = "pictureBoxLogo";
            this.pictureBoxLogo.Size = new System.Drawing.Size(556, 428);
            this.pictureBoxLogo.TabIndex = 21;
            this.pictureBoxLogo.TabStop = false;
            // 
            // buttonBack
            // 
            this.buttonBack.Location = new System.Drawing.Point(35, 233);
            this.buttonBack.Name = "buttonBack";
            this.buttonBack.Size = new System.Drawing.Size(228, 32);
            this.buttonBack.TabIndex = 24;
            this.buttonBack.Text = "К авторизации";
            this.buttonBack.UseVisualStyleBackColor = true;
            this.buttonBack.Click += new System.EventHandler(this.buttonBack_Click);
            // 
            // buttonReportFRDO
            // 
            this.buttonReportFRDO.Location = new System.Drawing.Point(35, 182);
            this.buttonReportFRDO.Name = "buttonReportFRDO";
            this.buttonReportFRDO.Size = new System.Drawing.Size(228, 32);
            this.buttonReportFRDO.TabIndex = 25;
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
            this.groupBoxGroup.Location = new System.Drawing.Point(40, 211);
            this.groupBoxGroup.Name = "groupBoxGroup";
            this.groupBoxGroup.Size = new System.Drawing.Size(223, 110);
            this.groupBoxGroup.TabIndex = 28;
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
            // ManagerMenuView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(875, 472);
            this.ControlBox = false;
            this.Controls.Add(this.groupBoxGroup);
            this.Controls.Add(this.buttonReportFRDO);
            this.Controls.Add(this.buttonBack);
            this.Controls.Add(this.buttonReports);
            this.Controls.Add(this.buttonContracts);
            this.Controls.Add(this.pictureBoxLogo);
            this.Controls.Add(this.labelUser);
            this.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ManagerMenuView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Главное меню";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).EndInit();
            this.groupBoxGroup.ResumeLayout(false);
            this.groupBoxGroup.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelUser;
        private System.Windows.Forms.Button buttonReports;
        private System.Windows.Forms.Button buttonContracts;
        private System.Windows.Forms.PictureBox pictureBoxLogo;
        private System.Windows.Forms.Button buttonBack;
        private System.Windows.Forms.Button buttonReportFRDO;
        private System.Windows.Forms.GroupBox groupBoxGroup;
        private System.Windows.Forms.Button buttonHide;
        private System.Windows.Forms.Button buttonReport;
        private System.Windows.Forms.Label labelGroup;
        private System.Windows.Forms.ComboBox comboBoxGroup;
    }
}