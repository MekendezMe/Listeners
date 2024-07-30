namespace Listeners.Forms.Roles.Secretary.AboutOrganization
{
    partial class AboutOrganizationView
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
            this.maskedTextBoxBIK = new System.Windows.Forms.MaskedTextBox();
            this.labelBIK = new System.Windows.Forms.Label();
            this.maskedTextBoxKPP = new System.Windows.Forms.MaskedTextBox();
            this.labelKPP = new System.Windows.Forms.Label();
            this.maskedTextBoxINN = new System.Windows.Forms.MaskedTextBox();
            this.labelINN = new System.Windows.Forms.Label();
            this.labelHelp = new System.Windows.Forms.Label();
            this.textBoxLicense = new System.Windows.Forms.TextBox();
            this.labelLicense = new System.Windows.Forms.Label();
            this.textBoxRequisites = new System.Windows.Forms.TextBox();
            this.labelRequisites = new System.Windows.Forms.Label();
            this.textBoxLittleName = new System.Windows.Forms.TextBox();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.labelLittleName = new System.Windows.Forms.Label();
            this.labelName = new System.Windows.Forms.Label();
            this.labelTreasure = new System.Windows.Forms.Label();
            this.maskedTextBoxTreasure = new System.Windows.Forms.MaskedTextBox();
            this.textBoxDirector = new System.Windows.Forms.TextBox();
            this.labelDirector = new System.Windows.Forms.Label();
            this.maskedTextBoxOnlyTreasure = new System.Windows.Forms.MaskedTextBox();
            this.labelOnlyTreasure = new System.Windows.Forms.Label();
            this.textBoxPayment = new System.Windows.Forms.TextBox();
            this.labelPayment = new System.Windows.Forms.Label();
            this.buttonBack = new System.Windows.Forms.Button();
            this.buttonUpdate = new System.Windows.Forms.Button();
            this.textBoxPersonal = new System.Windows.Forms.TextBox();
            this.LabelPersonal = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelUser
            // 
            this.labelUser.AutoSize = true;
            this.labelUser.Location = new System.Drawing.Point(13, 9);
            this.labelUser.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelUser.Name = "labelUser";
            this.labelUser.Size = new System.Drawing.Size(0, 20);
            this.labelUser.TabIndex = 4;
            // 
            // maskedTextBoxBIK
            // 
            this.maskedTextBoxBIK.Location = new System.Drawing.Point(388, 53);
            this.maskedTextBoxBIK.Mask = "000000000";
            this.maskedTextBoxBIK.Name = "maskedTextBoxBIK";
            this.maskedTextBoxBIK.Size = new System.Drawing.Size(82, 26);
            this.maskedTextBoxBIK.TabIndex = 122;
            // 
            // labelBIK
            // 
            this.labelBIK.AutoSize = true;
            this.labelBIK.Location = new System.Drawing.Point(342, 56);
            this.labelBIK.Name = "labelBIK";
            this.labelBIK.Size = new System.Drawing.Size(40, 20);
            this.labelBIK.TabIndex = 125;
            this.labelBIK.Text = "БИК*";
            // 
            // maskedTextBoxKPP
            // 
            this.maskedTextBoxKPP.Location = new System.Drawing.Point(523, 53);
            this.maskedTextBoxKPP.Mask = "000000000";
            this.maskedTextBoxKPP.Name = "maskedTextBoxKPP";
            this.maskedTextBoxKPP.Size = new System.Drawing.Size(80, 26);
            this.maskedTextBoxKPP.TabIndex = 123;
            // 
            // labelKPP
            // 
            this.labelKPP.AutoSize = true;
            this.labelKPP.Location = new System.Drawing.Point(481, 56);
            this.labelKPP.Name = "labelKPP";
            this.labelKPP.Size = new System.Drawing.Size(40, 20);
            this.labelKPP.TabIndex = 124;
            this.labelKPP.Text = "КПП*";
            // 
            // maskedTextBoxINN
            // 
            this.maskedTextBoxINN.Location = new System.Drawing.Point(235, 53);
            this.maskedTextBoxINN.Mask = "0000000000";
            this.maskedTextBoxINN.Name = "maskedTextBoxINN";
            this.maskedTextBoxINN.Size = new System.Drawing.Size(100, 26);
            this.maskedTextBoxINN.TabIndex = 120;
            // 
            // labelINN
            // 
            this.labelINN.AutoSize = true;
            this.labelINN.Location = new System.Drawing.Point(188, 56);
            this.labelINN.Name = "labelINN";
            this.labelINN.Size = new System.Drawing.Size(41, 20);
            this.labelINN.TabIndex = 121;
            this.labelINN.Text = "ИНН*";
            // 
            // labelHelp
            // 
            this.labelHelp.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelHelp.Location = new System.Drawing.Point(131, 378);
            this.labelHelp.Name = "labelHelp";
            this.labelHelp.Size = new System.Drawing.Size(252, 40);
            this.labelHelp.TabIndex = 149;
            this.labelHelp.Text = "Подсказка: область, район, город, улица, дом/квартира.";
            // 
            // textBoxLicense
            // 
            this.textBoxLicense.Location = new System.Drawing.Point(129, 443);
            this.textBoxLicense.MaxLength = 150;
            this.textBoxLicense.Multiline = true;
            this.textBoxLicense.Name = "textBoxLicense";
            this.textBoxLicense.Size = new System.Drawing.Size(254, 92);
            this.textBoxLicense.TabIndex = 146;
            this.textBoxLicense.Enter += new System.EventHandler(this.textBoxName_Enter);
            // 
            // labelLicense
            // 
            this.labelLicense.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelLicense.AutoSize = true;
            this.labelLicense.Location = new System.Drawing.Point(25, 443);
            this.labelLicense.Name = "labelLicense";
            this.labelLicense.Size = new System.Drawing.Size(68, 20);
            this.labelLicense.TabIndex = 148;
            this.labelLicense.Text = "Лицензия";
            // 
            // textBoxRequisites
            // 
            this.textBoxRequisites.Location = new System.Drawing.Point(132, 290);
            this.textBoxRequisites.MaxLength = 100;
            this.textBoxRequisites.Multiline = true;
            this.textBoxRequisites.Name = "textBoxRequisites";
            this.textBoxRequisites.Size = new System.Drawing.Size(254, 80);
            this.textBoxRequisites.TabIndex = 144;
            this.textBoxRequisites.Enter += new System.EventHandler(this.textBoxName_Enter);
            // 
            // labelRequisites
            // 
            this.labelRequisites.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelRequisites.AutoSize = true;
            this.labelRequisites.Location = new System.Drawing.Point(28, 290);
            this.labelRequisites.Name = "labelRequisites";
            this.labelRequisites.Size = new System.Drawing.Size(79, 20);
            this.labelRequisites.TabIndex = 145;
            this.labelRequisites.Text = "Реквизиты*";
            // 
            // textBoxLittleName
            // 
            this.textBoxLittleName.Location = new System.Drawing.Point(135, 212);
            this.textBoxLittleName.MaxLength = 150;
            this.textBoxLittleName.Multiline = true;
            this.textBoxLittleName.Name = "textBoxLittleName";
            this.textBoxLittleName.Size = new System.Drawing.Size(251, 45);
            this.textBoxLittleName.TabIndex = 143;
            this.textBoxLittleName.Enter += new System.EventHandler(this.textBoxName_Enter);
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(135, 111);
            this.textBoxName.MaxLength = 150;
            this.textBoxName.Multiline = true;
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(254, 70);
            this.textBoxName.TabIndex = 142;
            this.textBoxName.Enter += new System.EventHandler(this.textBoxName_Enter);
            // 
            // labelLittleName
            // 
            this.labelLittleName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelLittleName.AutoSize = true;
            this.labelLittleName.Location = new System.Drawing.Point(29, 212);
            this.labelLittleName.Name = "labelLittleName";
            this.labelLittleName.Size = new System.Drawing.Size(96, 40);
            this.labelLittleName.TabIndex = 141;
            this.labelLittleName.Text = "Сокращенное\r\nназвание";
            // 
            // labelName
            // 
            this.labelName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(34, 111);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(91, 40);
            this.labelName.TabIndex = 140;
            this.labelName.Text = "Название\r\nорганизации*";
            // 
            // labelTreasure
            // 
            this.labelTreasure.AutoSize = true;
            this.labelTreasure.Location = new System.Drawing.Point(475, 372);
            this.labelTreasure.Name = "labelTreasure";
            this.labelTreasure.Size = new System.Drawing.Size(70, 20);
            this.labelTreasure.TabIndex = 159;
            this.labelTreasure.Text = "Каз. счет*";
            // 
            // maskedTextBoxTreasure
            // 
            this.maskedTextBoxTreasure.Location = new System.Drawing.Point(560, 369);
            this.maskedTextBoxTreasure.Mask = "00000000000000000000";
            this.maskedTextBoxTreasure.Name = "maskedTextBoxTreasure";
            this.maskedTextBoxTreasure.Size = new System.Drawing.Size(161, 26);
            this.maskedTextBoxTreasure.TabIndex = 152;
            // 
            // textBoxDirector
            // 
            this.textBoxDirector.Location = new System.Drawing.Point(560, 413);
            this.textBoxDirector.MaxLength = 13;
            this.textBoxDirector.Name = "textBoxDirector";
            this.textBoxDirector.Size = new System.Drawing.Size(239, 26);
            this.textBoxDirector.TabIndex = 157;
            this.textBoxDirector.Enter += new System.EventHandler(this.textBoxName_Enter);
            this.textBoxDirector.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxDirector_KeyPress);
            // 
            // labelDirector
            // 
            this.labelDirector.AutoSize = true;
            this.labelDirector.Location = new System.Drawing.Point(475, 416);
            this.labelDirector.Name = "labelDirector";
            this.labelDirector.Size = new System.Drawing.Size(68, 20);
            this.labelDirector.TabIndex = 156;
            this.labelDirector.Text = "Директор";
            // 
            // maskedTextBoxOnlyTreasure
            // 
            this.maskedTextBoxOnlyTreasure.Location = new System.Drawing.Point(560, 317);
            this.maskedTextBoxOnlyTreasure.Mask = "00000000000000000000";
            this.maskedTextBoxOnlyTreasure.Name = "maskedTextBoxOnlyTreasure";
            this.maskedTextBoxOnlyTreasure.Size = new System.Drawing.Size(161, 26);
            this.maskedTextBoxOnlyTreasure.TabIndex = 151;
            // 
            // labelOnlyTreasure
            // 
            this.labelOnlyTreasure.AutoSize = true;
            this.labelOnlyTreasure.Location = new System.Drawing.Point(475, 311);
            this.labelOnlyTreasure.Name = "labelOnlyTreasure";
            this.labelOnlyTreasure.Size = new System.Drawing.Size(68, 40);
            this.labelOnlyTreasure.TabIndex = 155;
            this.labelOnlyTreasure.Text = "Единый\r\nказ. счет*";
            // 
            // textBoxPayment
            // 
            this.textBoxPayment.Location = new System.Drawing.Point(560, 212);
            this.textBoxPayment.MaxLength = 150;
            this.textBoxPayment.Multiline = true;
            this.textBoxPayment.Name = "textBoxPayment";
            this.textBoxPayment.Size = new System.Drawing.Size(239, 67);
            this.textBoxPayment.TabIndex = 150;
            this.textBoxPayment.Enter += new System.EventHandler(this.textBoxName_Enter);
            // 
            // labelPayment
            // 
            this.labelPayment.AutoSize = true;
            this.labelPayment.Location = new System.Drawing.Point(475, 212);
            this.labelPayment.Name = "labelPayment";
            this.labelPayment.Size = new System.Drawing.Size(83, 40);
            this.labelPayment.TabIndex = 154;
            this.labelPayment.Text = "Рассчетный\r\nсчет*";
            // 
            // buttonBack
            // 
            this.buttonBack.BackColor = System.Drawing.Color.LightGray;
            this.buttonBack.Location = new System.Drawing.Point(664, 575);
            this.buttonBack.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonBack.Name = "buttonBack";
            this.buttonBack.Size = new System.Drawing.Size(135, 28);
            this.buttonBack.TabIndex = 161;
            this.buttonBack.Text = "К справочникам";
            this.buttonBack.UseVisualStyleBackColor = false;
            this.buttonBack.Click += new System.EventHandler(this.buttonBack_Click);
            // 
            // buttonUpdate
            // 
            this.buttonUpdate.BackColor = System.Drawing.Color.LightGray;
            this.buttonUpdate.Location = new System.Drawing.Point(12, 575);
            this.buttonUpdate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonUpdate.Name = "buttonUpdate";
            this.buttonUpdate.Size = new System.Drawing.Size(121, 28);
            this.buttonUpdate.TabIndex = 160;
            this.buttonUpdate.Text = "Изменить";
            this.buttonUpdate.UseVisualStyleBackColor = false;
            this.buttonUpdate.Click += new System.EventHandler(this.buttonUpdate_Click);
            // 
            // textBoxPersonal
            // 
            this.textBoxPersonal.Location = new System.Drawing.Point(560, 111);
            this.textBoxPersonal.MaxLength = 150;
            this.textBoxPersonal.Multiline = true;
            this.textBoxPersonal.Name = "textBoxPersonal";
            this.textBoxPersonal.Size = new System.Drawing.Size(239, 70);
            this.textBoxPersonal.TabIndex = 162;
            this.textBoxPersonal.Enter += new System.EventHandler(this.textBoxName_Enter);
            // 
            // LabelPersonal
            // 
            this.LabelPersonal.AutoSize = true;
            this.LabelPersonal.Location = new System.Drawing.Point(475, 111);
            this.LabelPersonal.Name = "LabelPersonal";
            this.LabelPersonal.Size = new System.Drawing.Size(63, 40);
            this.LabelPersonal.TabIndex = 163;
            this.LabelPersonal.Text = "Лицевой\r\nсчет*";
            // 
            // AboutOrganizationView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(823, 625);
            this.ControlBox = false;
            this.Controls.Add(this.textBoxPersonal);
            this.Controls.Add(this.LabelPersonal);
            this.Controls.Add(this.buttonBack);
            this.Controls.Add(this.buttonUpdate);
            this.Controls.Add(this.labelTreasure);
            this.Controls.Add(this.maskedTextBoxTreasure);
            this.Controls.Add(this.textBoxDirector);
            this.Controls.Add(this.labelDirector);
            this.Controls.Add(this.maskedTextBoxOnlyTreasure);
            this.Controls.Add(this.labelOnlyTreasure);
            this.Controls.Add(this.textBoxPayment);
            this.Controls.Add(this.labelPayment);
            this.Controls.Add(this.labelHelp);
            this.Controls.Add(this.textBoxLicense);
            this.Controls.Add(this.labelLicense);
            this.Controls.Add(this.textBoxRequisites);
            this.Controls.Add(this.labelRequisites);
            this.Controls.Add(this.textBoxLittleName);
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(this.labelLittleName);
            this.Controls.Add(this.labelName);
            this.Controls.Add(this.maskedTextBoxBIK);
            this.Controls.Add(this.labelBIK);
            this.Controls.Add(this.maskedTextBoxKPP);
            this.Controls.Add(this.labelKPP);
            this.Controls.Add(this.maskedTextBoxINN);
            this.Controls.Add(this.labelINN);
            this.Controls.Add(this.labelUser);
            this.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(839, 641);
            this.Name = "AboutOrganizationView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Об организации";
            this.Enter += new System.EventHandler(this.textBoxName_Enter);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.SelectDirectory_KeyPress);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.SelectDirectory_MouseMove);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelUser;
        private System.Windows.Forms.MaskedTextBox maskedTextBoxBIK;
        private System.Windows.Forms.Label labelBIK;
        private System.Windows.Forms.MaskedTextBox maskedTextBoxKPP;
        private System.Windows.Forms.Label labelKPP;
        private System.Windows.Forms.MaskedTextBox maskedTextBoxINN;
        private System.Windows.Forms.Label labelINN;
        private System.Windows.Forms.Label labelHelp;
        private System.Windows.Forms.TextBox textBoxLicense;
        private System.Windows.Forms.Label labelLicense;
        private System.Windows.Forms.TextBox textBoxRequisites;
        private System.Windows.Forms.Label labelRequisites;
        private System.Windows.Forms.TextBox textBoxLittleName;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.Label labelLittleName;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.Label labelTreasure;
        private System.Windows.Forms.MaskedTextBox maskedTextBoxTreasure;
        private System.Windows.Forms.TextBox textBoxDirector;
        private System.Windows.Forms.Label labelDirector;
        private System.Windows.Forms.MaskedTextBox maskedTextBoxOnlyTreasure;
        private System.Windows.Forms.Label labelOnlyTreasure;
        private System.Windows.Forms.TextBox textBoxPayment;
        private System.Windows.Forms.Label labelPayment;
        private System.Windows.Forms.Button buttonBack;
        private System.Windows.Forms.Button buttonUpdate;
        private System.Windows.Forms.TextBox textBoxPersonal;
        private System.Windows.Forms.Label LabelPersonal;
    }
}