namespace Listeners.Forms.Roles.Secretary.Organization
{
    partial class OrganizationChangerView
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
            this.labelName = new System.Windows.Forms.Label();
            this.labelLittleName = new System.Windows.Forms.Label();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.textBoxLittleName = new System.Windows.Forms.TextBox();
            this.labelRequisites = new System.Windows.Forms.Label();
            this.textBoxRequisites = new System.Windows.Forms.TextBox();
            this.labelINN = new System.Windows.Forms.Label();
            this.maskedTextBoxINN = new System.Windows.Forms.MaskedTextBox();
            this.maskedTextBoxKPP = new System.Windows.Forms.MaskedTextBox();
            this.labelKPP = new System.Windows.Forms.Label();
            this.maskedTextBoxBIK = new System.Windows.Forms.MaskedTextBox();
            this.labelBIK = new System.Windows.Forms.Label();
            this.textBoxPersonal = new System.Windows.Forms.TextBox();
            this.LabelPersonal = new System.Windows.Forms.Label();
            this.textBoxPayment = new System.Windows.Forms.TextBox();
            this.labelPayment = new System.Windows.Forms.Label();
            this.maskedTextBoxOnlyTreasure = new System.Windows.Forms.MaskedTextBox();
            this.labelOnlyTreasure = new System.Windows.Forms.Label();
            this.labelUser = new System.Windows.Forms.Label();
            this.textBoxLicense = new System.Windows.Forms.TextBox();
            this.labelLicense = new System.Windows.Forms.Label();
            this.textBoxDirector = new System.Windows.Forms.TextBox();
            this.labelDirector = new System.Windows.Forms.Label();
            this.textBoxBank = new System.Windows.Forms.TextBox();
            this.labelBank = new System.Windows.Forms.Label();
            this.buttonBack = new System.Windows.Forms.Button();
            this.buttonChange = new System.Windows.Forms.Button();
            this.labelHelp = new System.Windows.Forms.Label();
            this.maskedTextBoxTreasure = new System.Windows.Forms.MaskedTextBox();
            this.labelTreasure = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(16, 101);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(91, 40);
            this.labelName.TabIndex = 0;
            this.labelName.Text = "Название\r\nорганизации*";
            // 
            // labelLittleName
            // 
            this.labelLittleName.AutoSize = true;
            this.labelLittleName.Location = new System.Drawing.Point(16, 162);
            this.labelLittleName.Name = "labelLittleName";
            this.labelLittleName.Size = new System.Drawing.Size(96, 40);
            this.labelLittleName.TabIndex = 1;
            this.labelLittleName.Text = "Сокращенное\r\nназвание";
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(117, 101);
            this.textBoxName.MaxLength = 150;
            this.textBoxName.Multiline = true;
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(247, 49);
            this.textBoxName.TabIndex = 2;
            this.textBoxName.Enter += new System.EventHandler(this.textBoxName_Enter);
            // 
            // textBoxLittleName
            // 
            this.textBoxLittleName.Location = new System.Drawing.Point(117, 162);
            this.textBoxLittleName.MaxLength = 150;
            this.textBoxLittleName.Multiline = true;
            this.textBoxLittleName.Name = "textBoxLittleName";
            this.textBoxLittleName.Size = new System.Drawing.Size(247, 45);
            this.textBoxLittleName.TabIndex = 3;
            this.textBoxLittleName.Enter += new System.EventHandler(this.textBoxName_Enter);
            // 
            // labelRequisites
            // 
            this.labelRequisites.AutoSize = true;
            this.labelRequisites.Location = new System.Drawing.Point(13, 224);
            this.labelRequisites.Name = "labelRequisites";
            this.labelRequisites.Size = new System.Drawing.Size(79, 20);
            this.labelRequisites.TabIndex = 4;
            this.labelRequisites.Text = "Реквизиты*";
            // 
            // textBoxRequisites
            // 
            this.textBoxRequisites.Location = new System.Drawing.Point(117, 224);
            this.textBoxRequisites.MaxLength = 100;
            this.textBoxRequisites.Multiline = true;
            this.textBoxRequisites.Name = "textBoxRequisites";
            this.textBoxRequisites.Size = new System.Drawing.Size(247, 51);
            this.textBoxRequisites.TabIndex = 4;
            this.textBoxRequisites.Enter += new System.EventHandler(this.textBoxName_Enter);
            // 
            // labelINN
            // 
            this.labelINN.AutoSize = true;
            this.labelINN.Location = new System.Drawing.Point(151, 50);
            this.labelINN.Name = "labelINN";
            this.labelINN.Size = new System.Drawing.Size(41, 20);
            this.labelINN.TabIndex = 6;
            this.labelINN.Text = "ИНН*";
            // 
            // maskedTextBoxINN
            // 
            this.maskedTextBoxINN.Location = new System.Drawing.Point(198, 47);
            this.maskedTextBoxINN.Mask = "000000000000";
            this.maskedTextBoxINN.Name = "maskedTextBoxINN";
            this.maskedTextBoxINN.Size = new System.Drawing.Size(100, 26);
            this.maskedTextBoxINN.TabIndex = 6;
            this.maskedTextBoxINN.Click += new System.EventHandler(this.maskedTextBox_Click);
            // 
            // maskedTextBoxKPP
            // 
            this.maskedTextBoxKPP.Location = new System.Drawing.Point(486, 47);
            this.maskedTextBoxKPP.Mask = "000000000";
            this.maskedTextBoxKPP.Name = "maskedTextBoxKPP";
            this.maskedTextBoxKPP.Size = new System.Drawing.Size(80, 26);
            this.maskedTextBoxKPP.TabIndex = 8;
            this.maskedTextBoxKPP.Click += new System.EventHandler(this.maskedTextBox_Click);
            // 
            // labelKPP
            // 
            this.labelKPP.AutoSize = true;
            this.labelKPP.Location = new System.Drawing.Point(444, 50);
            this.labelKPP.Name = "labelKPP";
            this.labelKPP.Size = new System.Drawing.Size(40, 20);
            this.labelKPP.TabIndex = 117;
            this.labelKPP.Text = "КПП*";
            // 
            // maskedTextBoxBIK
            // 
            this.maskedTextBoxBIK.Location = new System.Drawing.Point(351, 47);
            this.maskedTextBoxBIK.Mask = "000000000";
            this.maskedTextBoxBIK.Name = "maskedTextBoxBIK";
            this.maskedTextBoxBIK.Size = new System.Drawing.Size(82, 26);
            this.maskedTextBoxBIK.TabIndex = 7;
            this.maskedTextBoxBIK.Click += new System.EventHandler(this.maskedTextBox_Click);
            // 
            // labelBIK
            // 
            this.labelBIK.AutoSize = true;
            this.labelBIK.Location = new System.Drawing.Point(305, 50);
            this.labelBIK.Name = "labelBIK";
            this.labelBIK.Size = new System.Drawing.Size(40, 20);
            this.labelBIK.TabIndex = 119;
            this.labelBIK.Text = "БИК*";
            // 
            // textBoxPersonal
            // 
            this.textBoxPersonal.Location = new System.Drawing.Point(499, 98);
            this.textBoxPersonal.MaxLength = 150;
            this.textBoxPersonal.Multiline = true;
            this.textBoxPersonal.Name = "textBoxPersonal";
            this.textBoxPersonal.Size = new System.Drawing.Size(235, 52);
            this.textBoxPersonal.TabIndex = 9;
            this.textBoxPersonal.Enter += new System.EventHandler(this.textBoxName_Enter);
            // 
            // LabelPersonal
            // 
            this.LabelPersonal.AutoSize = true;
            this.LabelPersonal.Location = new System.Drawing.Point(410, 98);
            this.LabelPersonal.Name = "LabelPersonal";
            this.LabelPersonal.Size = new System.Drawing.Size(63, 40);
            this.LabelPersonal.TabIndex = 121;
            this.LabelPersonal.Text = "Лицевой\r\nсчет";
            // 
            // textBoxPayment
            // 
            this.textBoxPayment.Location = new System.Drawing.Point(499, 162);
            this.textBoxPayment.MaxLength = 150;
            this.textBoxPayment.Multiline = true;
            this.textBoxPayment.Name = "textBoxPayment";
            this.textBoxPayment.Size = new System.Drawing.Size(235, 49);
            this.textBoxPayment.TabIndex = 10;
            this.textBoxPayment.Enter += new System.EventHandler(this.textBoxName_Enter);
            // 
            // labelPayment
            // 
            this.labelPayment.AutoSize = true;
            this.labelPayment.Location = new System.Drawing.Point(410, 162);
            this.labelPayment.Name = "labelPayment";
            this.labelPayment.Size = new System.Drawing.Size(83, 40);
            this.labelPayment.TabIndex = 123;
            this.labelPayment.Text = "Рассчетный\r\nсчет*";
            // 
            // maskedTextBoxOnlyTreasure
            // 
            this.maskedTextBoxOnlyTreasure.Location = new System.Drawing.Point(499, 224);
            this.maskedTextBoxOnlyTreasure.Mask = "00000000000000000000";
            this.maskedTextBoxOnlyTreasure.Name = "maskedTextBoxOnlyTreasure";
            this.maskedTextBoxOnlyTreasure.Size = new System.Drawing.Size(157, 26);
            this.maskedTextBoxOnlyTreasure.TabIndex = 11;
            this.maskedTextBoxOnlyTreasure.Click += new System.EventHandler(this.maskedTextBox_Click);
            // 
            // labelOnlyTreasure
            // 
            this.labelOnlyTreasure.AutoSize = true;
            this.labelOnlyTreasure.Location = new System.Drawing.Point(410, 218);
            this.labelOnlyTreasure.Name = "labelOnlyTreasure";
            this.labelOnlyTreasure.Size = new System.Drawing.Size(68, 40);
            this.labelOnlyTreasure.TabIndex = 125;
            this.labelOnlyTreasure.Text = "Единый\r\nказ. счет*";
            // 
            // labelUser
            // 
            this.labelUser.AutoSize = true;
            this.labelUser.Location = new System.Drawing.Point(12, 9);
            this.labelUser.Name = "labelUser";
            this.labelUser.Size = new System.Drawing.Size(0, 20);
            this.labelUser.TabIndex = 127;
            // 
            // textBoxLicense
            // 
            this.textBoxLicense.Location = new System.Drawing.Point(117, 352);
            this.textBoxLicense.MaxLength = 150;
            this.textBoxLicense.Multiline = true;
            this.textBoxLicense.Name = "textBoxLicense";
            this.textBoxLicense.Size = new System.Drawing.Size(247, 63);
            this.textBoxLicense.TabIndex = 5;
            this.textBoxLicense.Enter += new System.EventHandler(this.textBoxName_Enter);
            // 
            // labelLicense
            // 
            this.labelLicense.AutoSize = true;
            this.labelLicense.Location = new System.Drawing.Point(13, 352);
            this.labelLicense.Name = "labelLicense";
            this.labelLicense.Size = new System.Drawing.Size(68, 20);
            this.labelLicense.TabIndex = 130;
            this.labelLicense.Text = "Лицензия";
            // 
            // textBoxDirector
            // 
            this.textBoxDirector.Location = new System.Drawing.Point(499, 320);
            this.textBoxDirector.MaxLength = 13;
            this.textBoxDirector.Name = "textBoxDirector";
            this.textBoxDirector.Size = new System.Drawing.Size(235, 26);
            this.textBoxDirector.TabIndex = 129;
            this.textBoxDirector.Enter += new System.EventHandler(this.textBoxName_Enter);
            this.textBoxDirector.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxDirector_KeyPress);
            // 
            // labelDirector
            // 
            this.labelDirector.AutoSize = true;
            this.labelDirector.Location = new System.Drawing.Point(410, 323);
            this.labelDirector.Name = "labelDirector";
            this.labelDirector.Size = new System.Drawing.Size(68, 20);
            this.labelDirector.TabIndex = 128;
            this.labelDirector.Text = "Директор";
            // 
            // textBoxBank
            // 
            this.textBoxBank.Location = new System.Drawing.Point(498, 361);
            this.textBoxBank.MaxLength = 150;
            this.textBoxBank.Multiline = true;
            this.textBoxBank.Name = "textBoxBank";
            this.textBoxBank.Size = new System.Drawing.Size(235, 42);
            this.textBoxBank.TabIndex = 14;
            this.textBoxBank.Enter += new System.EventHandler(this.textBoxName_Enter);
            // 
            // labelBank
            // 
            this.labelBank.AutoSize = true;
            this.labelBank.Location = new System.Drawing.Point(409, 361);
            this.labelBank.Name = "labelBank";
            this.labelBank.Size = new System.Drawing.Size(38, 20);
            this.labelBank.TabIndex = 132;
            this.labelBank.Text = "Банк";
            // 
            // buttonBack
            // 
            this.buttonBack.Location = new System.Drawing.Point(567, 427);
            this.buttonBack.Name = "buttonBack";
            this.buttonBack.Size = new System.Drawing.Size(163, 32);
            this.buttonBack.TabIndex = 16;
            this.buttonBack.Text = "К организациям";
            this.buttonBack.UseVisualStyleBackColor = true;
            this.buttonBack.Click += new System.EventHandler(this.buttonBack_Click);
            // 
            // buttonChange
            // 
            this.buttonChange.Location = new System.Drawing.Point(12, 427);
            this.buttonChange.Name = "buttonChange";
            this.buttonChange.Size = new System.Drawing.Size(90, 32);
            this.buttonChange.TabIndex = 15;
            this.buttonChange.Text = "Добавить";
            this.buttonChange.UseVisualStyleBackColor = true;
            this.buttonChange.Click += new System.EventHandler(this.buttonChange_Click);
            // 
            // labelHelp
            // 
            this.labelHelp.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelHelp.Location = new System.Drawing.Point(116, 278);
            this.labelHelp.Name = "labelHelp";
            this.labelHelp.Size = new System.Drawing.Size(248, 40);
            this.labelHelp.TabIndex = 139;
            this.labelHelp.Text = "Подсказка: область, район, город, улица, дом/квартира.";
            // 
            // maskedTextBoxTreasure
            // 
            this.maskedTextBoxTreasure.Location = new System.Drawing.Point(499, 276);
            this.maskedTextBoxTreasure.Mask = "00000000000000000000";
            this.maskedTextBoxTreasure.Name = "maskedTextBoxTreasure";
            this.maskedTextBoxTreasure.Size = new System.Drawing.Size(157, 26);
            this.maskedTextBoxTreasure.TabIndex = 12;
            // 
            // labelTreasure
            // 
            this.labelTreasure.AutoSize = true;
            this.labelTreasure.Location = new System.Drawing.Point(410, 279);
            this.labelTreasure.Name = "labelTreasure";
            this.labelTreasure.Size = new System.Drawing.Size(70, 20);
            this.labelTreasure.TabIndex = 141;
            this.labelTreasure.Text = "Каз. счет*";
            // 
            // OrganizationChangerView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(751, 471);
            this.ControlBox = false;
            this.Controls.Add(this.labelTreasure);
            this.Controls.Add(this.maskedTextBoxTreasure);
            this.Controls.Add(this.labelHelp);
            this.Controls.Add(this.buttonBack);
            this.Controls.Add(this.buttonChange);
            this.Controls.Add(this.textBoxBank);
            this.Controls.Add(this.labelBank);
            this.Controls.Add(this.textBoxLicense);
            this.Controls.Add(this.labelLicense);
            this.Controls.Add(this.textBoxDirector);
            this.Controls.Add(this.labelDirector);
            this.Controls.Add(this.labelUser);
            this.Controls.Add(this.maskedTextBoxOnlyTreasure);
            this.Controls.Add(this.labelOnlyTreasure);
            this.Controls.Add(this.textBoxPayment);
            this.Controls.Add(this.labelPayment);
            this.Controls.Add(this.textBoxPersonal);
            this.Controls.Add(this.LabelPersonal);
            this.Controls.Add(this.maskedTextBoxBIK);
            this.Controls.Add(this.labelBIK);
            this.Controls.Add(this.maskedTextBoxKPP);
            this.Controls.Add(this.labelKPP);
            this.Controls.Add(this.maskedTextBoxINN);
            this.Controls.Add(this.labelINN);
            this.Controls.Add(this.textBoxRequisites);
            this.Controls.Add(this.labelRequisites);
            this.Controls.Add(this.textBoxLittleName);
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(this.labelLittleName);
            this.Controls.Add(this.labelName);
            this.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OrganizationChangerView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Изменение организации";
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.GroupView_KeyPress);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.GroupView_MouseMove);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.Label labelLittleName;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.TextBox textBoxLittleName;
        private System.Windows.Forms.Label labelRequisites;
        private System.Windows.Forms.TextBox textBoxRequisites;
        private System.Windows.Forms.Label labelINN;
        private System.Windows.Forms.MaskedTextBox maskedTextBoxINN;
        private System.Windows.Forms.MaskedTextBox maskedTextBoxKPP;
        private System.Windows.Forms.Label labelKPP;
        private System.Windows.Forms.MaskedTextBox maskedTextBoxBIK;
        private System.Windows.Forms.Label labelBIK;
        private System.Windows.Forms.TextBox textBoxPersonal;
        private System.Windows.Forms.Label LabelPersonal;
        private System.Windows.Forms.TextBox textBoxPayment;
        private System.Windows.Forms.Label labelPayment;
        private System.Windows.Forms.MaskedTextBox maskedTextBoxOnlyTreasure;
        private System.Windows.Forms.Label labelOnlyTreasure;
        private System.Windows.Forms.Label labelUser;
        private System.Windows.Forms.TextBox textBoxLicense;
        private System.Windows.Forms.Label labelLicense;
        private System.Windows.Forms.TextBox textBoxDirector;
        private System.Windows.Forms.Label labelDirector;
        private System.Windows.Forms.TextBox textBoxBank;
        private System.Windows.Forms.Label labelBank;
        private System.Windows.Forms.Button buttonBack;
        private System.Windows.Forms.Button buttonChange;
        private System.Windows.Forms.Label labelHelp;
        private System.Windows.Forms.MaskedTextBox maskedTextBoxTreasure;
        private System.Windows.Forms.Label labelTreasure;
    }
}