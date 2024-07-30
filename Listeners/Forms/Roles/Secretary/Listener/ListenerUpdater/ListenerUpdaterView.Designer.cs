namespace Listeners.Forms.Roles.Secretary.Listener.ListenerUpdater
{
    partial class ListenerUpdaterView
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
            this.buttonBack = new System.Windows.Forms.Button();
            this.buttonUpdate = new System.Windows.Forms.Button();
            this.labelAge = new System.Windows.Forms.Label();
            this.checkBoxFemale = new System.Windows.Forms.CheckBox();
            this.checkBoxMale = new System.Windows.Forms.CheckBox();
            this.labelGender = new System.Windows.Forms.Label();
            this.labelEducation = new System.Windows.Forms.Label();
            this.comboBoxEducation = new System.Windows.Forms.ComboBox();
            this.labelEmployment = new System.Windows.Forms.Label();
            this.labelPhone = new System.Windows.Forms.Label();
            this.maskedTextBoxPhone = new System.Windows.Forms.MaskedTextBox();
            this.labelBirthday = new System.Windows.Forms.Label();
            this.maskedTextBoxBirthday = new System.Windows.Forms.MaskedTextBox();
            this.textBoxAddress = new System.Windows.Forms.TextBox();
            this.groupBoxDocument = new System.Windows.Forms.GroupBox();
            this.maskedTextBoxInsurance = new System.Windows.Forms.MaskedTextBox();
            this.labelInsurance = new System.Windows.Forms.Label();
            this.groupBoxPassport = new System.Windows.Forms.GroupBox();
            this.maskedTextBoxIssuedDate = new System.Windows.Forms.MaskedTextBox();
            this.labelIssuedDate = new System.Windows.Forms.Label();
            this.labelIssuedBy = new System.Windows.Forms.Label();
            this.textBoxIssuedBy = new System.Windows.Forms.TextBox();
            this.labelCode = new System.Windows.Forms.Label();
            this.maskedTextBoxCode = new System.Windows.Forms.MaskedTextBox();
            this.labelNumber = new System.Windows.Forms.Label();
            this.maskedTextBoxNumber = new System.Windows.Forms.MaskedTextBox();
            this.labelSeries = new System.Windows.Forms.Label();
            this.maskedTextBoxSeries = new System.Windows.Forms.MaskedTextBox();
            this.labelAddress = new System.Windows.Forms.Label();
            this.labelPatronymic = new System.Windows.Forms.Label();
            this.textBoxPatronymic = new System.Windows.Forms.TextBox();
            this.labelName = new System.Windows.Forms.Label();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.comboBoxEmployment = new System.Windows.Forms.ComboBox();
            this.labelSurname = new System.Windows.Forms.Label();
            this.textBoxSurname = new System.Windows.Forms.TextBox();
            this.labelUser = new System.Windows.Forms.Label();
            this.buttonReset = new System.Windows.Forms.Button();
            this.labelHelp = new System.Windows.Forms.Label();
            this.groupBoxDocument.SuspendLayout();
            this.groupBoxPassport.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonBack
            // 
            this.buttonBack.BackColor = System.Drawing.Color.LightGray;
            this.buttonBack.Location = new System.Drawing.Point(625, 529);
            this.buttonBack.Name = "buttonBack";
            this.buttonBack.Size = new System.Drawing.Size(178, 33);
            this.buttonBack.TabIndex = 19;
            this.buttonBack.Text = "К слушателям";
            this.buttonBack.UseVisualStyleBackColor = false;
            this.buttonBack.Click += new System.EventHandler(this.buttonBack_Click);
            // 
            // buttonUpdate
            // 
            this.buttonUpdate.BackColor = System.Drawing.Color.LightGray;
            this.buttonUpdate.Location = new System.Drawing.Point(18, 529);
            this.buttonUpdate.Name = "buttonUpdate";
            this.buttonUpdate.Size = new System.Drawing.Size(172, 33);
            this.buttonUpdate.TabIndex = 18;
            this.buttonUpdate.Text = "Изменение";
            this.buttonUpdate.UseVisualStyleBackColor = false;
            this.buttonUpdate.Click += new System.EventHandler(this.buttonUpdate_Click);
            // 
            // labelAge
            // 
            this.labelAge.AutoSize = true;
            this.labelAge.Location = new System.Drawing.Point(565, 50);
            this.labelAge.Name = "labelAge";
            this.labelAge.Size = new System.Drawing.Size(34, 20);
            this.labelAge.TabIndex = 53;
            this.labelAge.Text = "Age";
            // 
            // checkBoxFemale
            // 
            this.checkBoxFemale.AutoSize = true;
            this.checkBoxFemale.Location = new System.Drawing.Point(579, 210);
            this.checkBoxFemale.Name = "checkBoxFemale";
            this.checkBoxFemale.Size = new System.Drawing.Size(79, 24);
            this.checkBoxFemale.TabIndex = 11;
            this.checkBoxFemale.Text = "женский";
            this.checkBoxFemale.UseVisualStyleBackColor = true;
            this.checkBoxFemale.CheckedChanged += new System.EventHandler(this.checkBoxFemale_CheckedChanged);
            // 
            // checkBoxMale
            // 
            this.checkBoxMale.AutoSize = true;
            this.checkBoxMale.Location = new System.Drawing.Point(478, 210);
            this.checkBoxMale.Name = "checkBoxMale";
            this.checkBoxMale.Size = new System.Drawing.Size(81, 24);
            this.checkBoxMale.TabIndex = 10;
            this.checkBoxMale.Text = "мужской";
            this.checkBoxMale.UseVisualStyleBackColor = true;
            this.checkBoxMale.CheckedChanged += new System.EventHandler(this.checkBoxMale_CheckedChanged);
            // 
            // labelGender
            // 
            this.labelGender.AutoSize = true;
            this.labelGender.Location = new System.Drawing.Point(369, 212);
            this.labelGender.Name = "labelGender";
            this.labelGender.Size = new System.Drawing.Size(39, 20);
            this.labelGender.TabIndex = 52;
            this.labelGender.Text = "Пол*";
            // 
            // labelEducation
            // 
            this.labelEducation.AutoSize = true;
            this.labelEducation.Location = new System.Drawing.Point(366, 174);
            this.labelEducation.Name = "labelEducation";
            this.labelEducation.Size = new System.Drawing.Size(97, 20);
            this.labelEducation.TabIndex = 50;
            this.labelEducation.Text = "Образование*";
            // 
            // comboBoxEducation
            // 
            this.comboBoxEducation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxEducation.FormattingEnabled = true;
            this.comboBoxEducation.Location = new System.Drawing.Point(479, 171);
            this.comboBoxEducation.Name = "comboBoxEducation";
            this.comboBoxEducation.Size = new System.Drawing.Size(324, 28);
            this.comboBoxEducation.TabIndex = 8;
            // 
            // labelEmployment
            // 
            this.labelEmployment.AutoSize = true;
            this.labelEmployment.Location = new System.Drawing.Point(366, 135);
            this.labelEmployment.Name = "labelEmployment";
            this.labelEmployment.Size = new System.Drawing.Size(75, 20);
            this.labelEmployment.TabIndex = 47;
            this.labelEmployment.Text = "Занятость*";
            // 
            // labelPhone
            // 
            this.labelPhone.AutoSize = true;
            this.labelPhone.Location = new System.Drawing.Point(366, 92);
            this.labelPhone.Name = "labelPhone";
            this.labelPhone.Size = new System.Drawing.Size(71, 20);
            this.labelPhone.TabIndex = 46;
            this.labelPhone.Text = "Телефон*";
            // 
            // maskedTextBoxPhone
            // 
            this.maskedTextBoxPhone.Location = new System.Drawing.Point(479, 89);
            this.maskedTextBoxPhone.Mask = "+7 (000) 000-0000";
            this.maskedTextBoxPhone.Name = "maskedTextBoxPhone";
            this.maskedTextBoxPhone.Size = new System.Drawing.Size(120, 26);
            this.maskedTextBoxPhone.TabIndex = 6;
            this.maskedTextBoxPhone.Click += new System.EventHandler(this.maskedTextBoxBirthday_Click);
            this.maskedTextBoxPhone.Enter += new System.EventHandler(this.MaskedTextBox_Enter);
            // 
            // labelBirthday
            // 
            this.labelBirthday.AutoSize = true;
            this.labelBirthday.Location = new System.Drawing.Point(366, 51);
            this.labelBirthday.Name = "labelBirthday";
            this.labelBirthday.Size = new System.Drawing.Size(108, 20);
            this.labelBirthday.TabIndex = 45;
            this.labelBirthday.Text = "Дата рождения*";
            // 
            // maskedTextBoxBirthday
            // 
            this.maskedTextBoxBirthday.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.maskedTextBoxBirthday.Location = new System.Drawing.Point(478, 48);
            this.maskedTextBoxBirthday.Mask = "00/00/0000";
            this.maskedTextBoxBirthday.Name = "maskedTextBoxBirthday";
            this.maskedTextBoxBirthday.Size = new System.Drawing.Size(85, 26);
            this.maskedTextBoxBirthday.TabIndex = 5;
            this.maskedTextBoxBirthday.Click += new System.EventHandler(this.maskedTextBoxBirthday_Click);
            this.maskedTextBoxBirthday.TextChanged += new System.EventHandler(this.maskedTextBoxBirthday_TextChanged);
            this.maskedTextBoxBirthday.Enter += new System.EventHandler(this.MaskedTextBox_Enter);
            // 
            // textBoxAddress
            // 
            this.textBoxAddress.Location = new System.Drawing.Point(98, 157);
            this.textBoxAddress.Multiline = true;
            this.textBoxAddress.Name = "textBoxAddress";
            this.textBoxAddress.Size = new System.Drawing.Size(230, 51);
            this.textBoxAddress.TabIndex = 4;
            this.textBoxAddress.Enter += new System.EventHandler(this.textBox_Enter);
            this.textBoxAddress.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxAddress_KeyPress);
            // 
            // groupBoxDocument
            // 
            this.groupBoxDocument.Controls.Add(this.maskedTextBoxInsurance);
            this.groupBoxDocument.Controls.Add(this.labelInsurance);
            this.groupBoxDocument.Controls.Add(this.groupBoxPassport);
            this.groupBoxDocument.Location = new System.Drawing.Point(18, 293);
            this.groupBoxDocument.Name = "groupBoxDocument";
            this.groupBoxDocument.Size = new System.Drawing.Size(785, 219);
            this.groupBoxDocument.TabIndex = 43;
            this.groupBoxDocument.TabStop = false;
            this.groupBoxDocument.Text = "Документы";
            // 
            // maskedTextBoxInsurance
            // 
            this.maskedTextBoxInsurance.Location = new System.Drawing.Point(82, 179);
            this.maskedTextBoxInsurance.Mask = "000-000-000 00";
            this.maskedTextBoxInsurance.Name = "maskedTextBoxInsurance";
            this.maskedTextBoxInsurance.Size = new System.Drawing.Size(106, 26);
            this.maskedTextBoxInsurance.TabIndex = 17;
            this.maskedTextBoxInsurance.Click += new System.EventHandler(this.maskedTextBoxBirthday_Click);
            this.maskedTextBoxInsurance.Enter += new System.EventHandler(this.MaskedTextBox_Enter);
            // 
            // labelInsurance
            // 
            this.labelInsurance.AutoSize = true;
            this.labelInsurance.Location = new System.Drawing.Point(22, 182);
            this.labelInsurance.Name = "labelInsurance";
            this.labelInsurance.Size = new System.Drawing.Size(59, 20);
            this.labelInsurance.TabIndex = 30;
            this.labelInsurance.Text = "СНИЛС*";
            // 
            // groupBoxPassport
            // 
            this.groupBoxPassport.Controls.Add(this.maskedTextBoxIssuedDate);
            this.groupBoxPassport.Controls.Add(this.labelIssuedDate);
            this.groupBoxPassport.Controls.Add(this.labelIssuedBy);
            this.groupBoxPassport.Controls.Add(this.textBoxIssuedBy);
            this.groupBoxPassport.Controls.Add(this.labelCode);
            this.groupBoxPassport.Controls.Add(this.maskedTextBoxCode);
            this.groupBoxPassport.Controls.Add(this.labelNumber);
            this.groupBoxPassport.Controls.Add(this.maskedTextBoxNumber);
            this.groupBoxPassport.Controls.Add(this.labelSeries);
            this.groupBoxPassport.Controls.Add(this.maskedTextBoxSeries);
            this.groupBoxPassport.Location = new System.Drawing.Point(4, 25);
            this.groupBoxPassport.Name = "groupBoxPassport";
            this.groupBoxPassport.Size = new System.Drawing.Size(766, 142);
            this.groupBoxPassport.TabIndex = 0;
            this.groupBoxPassport.TabStop = false;
            this.groupBoxPassport.Text = "Паспорт";
            // 
            // maskedTextBoxIssuedDate
            // 
            this.maskedTextBoxIssuedDate.Location = new System.Drawing.Point(409, 25);
            this.maskedTextBoxIssuedDate.Mask = "00/00/0000";
            this.maskedTextBoxIssuedDate.Name = "maskedTextBoxIssuedDate";
            this.maskedTextBoxIssuedDate.Size = new System.Drawing.Size(85, 26);
            this.maskedTextBoxIssuedDate.TabIndex = 14;
            this.maskedTextBoxIssuedDate.Click += new System.EventHandler(this.maskedTextBoxBirthday_Click);
            this.maskedTextBoxIssuedDate.TextChanged += new System.EventHandler(this.maskedTextBoxIssuedDate_TextChanged);
            this.maskedTextBoxIssuedDate.Enter += new System.EventHandler(this.MaskedTextBox_Enter);
            // 
            // labelIssuedDate
            // 
            this.labelIssuedDate.AutoSize = true;
            this.labelIssuedDate.Location = new System.Drawing.Point(311, 28);
            this.labelIssuedDate.Name = "labelIssuedDate";
            this.labelIssuedDate.Size = new System.Drawing.Size(92, 20);
            this.labelIssuedDate.TabIndex = 30;
            this.labelIssuedDate.Text = "Дата выдачи*";
            // 
            // labelIssuedBy
            // 
            this.labelIssuedBy.AutoSize = true;
            this.labelIssuedBy.Location = new System.Drawing.Point(19, 79);
            this.labelIssuedBy.Name = "labelIssuedBy";
            this.labelIssuedBy.Size = new System.Drawing.Size(53, 40);
            this.labelIssuedBy.TabIndex = 29;
            this.labelIssuedBy.Text = "Кем \r\nвыдан*";
            // 
            // textBoxIssuedBy
            // 
            this.textBoxIssuedBy.Location = new System.Drawing.Point(78, 76);
            this.textBoxIssuedBy.Multiline = true;
            this.textBoxIssuedBy.Name = "textBoxIssuedBy";
            this.textBoxIssuedBy.Size = new System.Drawing.Size(664, 45);
            this.textBoxIssuedBy.TabIndex = 16;
            this.textBoxIssuedBy.Enter += new System.EventHandler(this.textBox_Enter);
            this.textBoxIssuedBy.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxAddress_KeyPress);
            // 
            // labelCode
            // 
            this.labelCode.AutoSize = true;
            this.labelCode.Location = new System.Drawing.Point(537, 28);
            this.labelCode.Name = "labelCode";
            this.labelCode.Size = new System.Drawing.Size(139, 20);
            this.labelCode.TabIndex = 27;
            this.labelCode.Text = "Код подразделения*";
            // 
            // maskedTextBoxCode
            // 
            this.maskedTextBoxCode.Location = new System.Drawing.Point(683, 25);
            this.maskedTextBoxCode.Mask = "000-000";
            this.maskedTextBoxCode.Name = "maskedTextBoxCode";
            this.maskedTextBoxCode.Size = new System.Drawing.Size(59, 26);
            this.maskedTextBoxCode.TabIndex = 15;
            this.maskedTextBoxCode.Click += new System.EventHandler(this.maskedTextBoxBirthday_Click);
            this.maskedTextBoxCode.Enter += new System.EventHandler(this.MaskedTextBox_Enter);
            // 
            // labelNumber
            // 
            this.labelNumber.AutoSize = true;
            this.labelNumber.Location = new System.Drawing.Point(149, 28);
            this.labelNumber.Name = "labelNumber";
            this.labelNumber.Size = new System.Drawing.Size(56, 20);
            this.labelNumber.TabIndex = 25;
            this.labelNumber.Text = "Номер*";
            // 
            // maskedTextBoxNumber
            // 
            this.maskedTextBoxNumber.Location = new System.Drawing.Point(211, 25);
            this.maskedTextBoxNumber.Mask = "000000";
            this.maskedTextBoxNumber.Name = "maskedTextBoxNumber";
            this.maskedTextBoxNumber.Size = new System.Drawing.Size(61, 26);
            this.maskedTextBoxNumber.TabIndex = 13;
            this.maskedTextBoxNumber.Click += new System.EventHandler(this.maskedTextBoxBirthday_Click);
            this.maskedTextBoxNumber.Enter += new System.EventHandler(this.MaskedTextBox_Enter);
            // 
            // labelSeries
            // 
            this.labelSeries.AutoSize = true;
            this.labelSeries.Location = new System.Drawing.Point(18, 28);
            this.labelSeries.Name = "labelSeries";
            this.labelSeries.Size = new System.Drawing.Size(53, 20);
            this.labelSeries.TabIndex = 23;
            this.labelSeries.Text = "Серия*";
            // 
            // maskedTextBoxSeries
            // 
            this.maskedTextBoxSeries.Location = new System.Drawing.Point(77, 25);
            this.maskedTextBoxSeries.Mask = "0000";
            this.maskedTextBoxSeries.Name = "maskedTextBoxSeries";
            this.maskedTextBoxSeries.Size = new System.Drawing.Size(53, 26);
            this.maskedTextBoxSeries.TabIndex = 12;
            this.maskedTextBoxSeries.Click += new System.EventHandler(this.maskedTextBoxBirthday_Click);
            this.maskedTextBoxSeries.Enter += new System.EventHandler(this.MaskedTextBox_Enter);
            // 
            // labelAddress
            // 
            this.labelAddress.AutoSize = true;
            this.labelAddress.Location = new System.Drawing.Point(14, 176);
            this.labelAddress.Name = "labelAddress";
            this.labelAddress.Size = new System.Drawing.Size(49, 20);
            this.labelAddress.TabIndex = 42;
            this.labelAddress.Text = "Адрес";
            // 
            // labelPatronymic
            // 
            this.labelPatronymic.AutoSize = true;
            this.labelPatronymic.Location = new System.Drawing.Point(11, 123);
            this.labelPatronymic.Name = "labelPatronymic";
            this.labelPatronymic.Size = new System.Drawing.Size(66, 20);
            this.labelPatronymic.TabIndex = 40;
            this.labelPatronymic.Text = "Отчество";
            // 
            // textBoxPatronymic
            // 
            this.textBoxPatronymic.Location = new System.Drawing.Point(98, 122);
            this.textBoxPatronymic.Name = "textBoxPatronymic";
            this.textBoxPatronymic.Size = new System.Drawing.Size(230, 26);
            this.textBoxPatronymic.TabIndex = 3;
            this.textBoxPatronymic.Enter += new System.EventHandler(this.textBox_Enter);
            this.textBoxPatronymic.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxPersonalData_KeyPress);
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(11, 89);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(39, 20);
            this.labelName.TabIndex = 37;
            this.labelName.Text = "Имя*";
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(98, 87);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(230, 26);
            this.textBoxName.TabIndex = 2;
            this.textBoxName.Enter += new System.EventHandler(this.textBox_Enter);
            this.textBoxName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxPersonalData_KeyPress);
            // 
            // comboBoxEmployment
            // 
            this.comboBoxEmployment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxEmployment.FormattingEnabled = true;
            this.comboBoxEmployment.Location = new System.Drawing.Point(479, 132);
            this.comboBoxEmployment.Name = "comboBoxEmployment";
            this.comboBoxEmployment.Size = new System.Drawing.Size(324, 28);
            this.comboBoxEmployment.TabIndex = 7;
            // 
            // labelSurname
            // 
            this.labelSurname.AutoSize = true;
            this.labelSurname.Location = new System.Drawing.Point(11, 52);
            this.labelSurname.Name = "labelSurname";
            this.labelSurname.Size = new System.Drawing.Size(69, 20);
            this.labelSurname.TabIndex = 32;
            this.labelSurname.Text = "Фамилия*";
            // 
            // textBoxSurname
            // 
            this.textBoxSurname.Location = new System.Drawing.Point(98, 49);
            this.textBoxSurname.Name = "textBoxSurname";
            this.textBoxSurname.Size = new System.Drawing.Size(230, 26);
            this.textBoxSurname.TabIndex = 1;
            this.textBoxSurname.Enter += new System.EventHandler(this.textBox_Enter);
            this.textBoxSurname.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxPersonalData_KeyPress);
            // 
            // labelUser
            // 
            this.labelUser.AutoSize = true;
            this.labelUser.Location = new System.Drawing.Point(18, 15);
            this.labelUser.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelUser.Name = "labelUser";
            this.labelUser.Size = new System.Drawing.Size(0, 20);
            this.labelUser.TabIndex = 29;
            // 
            // buttonReset
            // 
            this.buttonReset.BackColor = System.Drawing.Color.LightGray;
            this.buttonReset.Location = new System.Drawing.Point(625, 250);
            this.buttonReset.Name = "buttonReset";
            this.buttonReset.Size = new System.Drawing.Size(177, 28);
            this.buttonReset.TabIndex = 20;
            this.buttonReset.Text = "Очистить все поля";
            this.buttonReset.UseVisualStyleBackColor = false;
            this.buttonReset.Click += new System.EventHandler(this.buttonReset_Click);
            // 
            // labelHelp
            // 
            this.labelHelp.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelHelp.Location = new System.Drawing.Point(95, 211);
            this.labelHelp.Name = "labelHelp";
            this.labelHelp.Size = new System.Drawing.Size(248, 40);
            this.labelHelp.TabIndex = 76;
            this.labelHelp.Text = "Подсказка: область, район, город, улица, дом/квартира.";
            // 
            // ListenerUpdaterView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(818, 575);
            this.ControlBox = false;
            this.Controls.Add(this.labelHelp);
            this.Controls.Add(this.buttonReset);
            this.Controls.Add(this.buttonBack);
            this.Controls.Add(this.buttonUpdate);
            this.Controls.Add(this.labelAge);
            this.Controls.Add(this.checkBoxFemale);
            this.Controls.Add(this.checkBoxMale);
            this.Controls.Add(this.labelGender);
            this.Controls.Add(this.labelEducation);
            this.Controls.Add(this.comboBoxEducation);
            this.Controls.Add(this.labelEmployment);
            this.Controls.Add(this.labelPhone);
            this.Controls.Add(this.maskedTextBoxPhone);
            this.Controls.Add(this.labelBirthday);
            this.Controls.Add(this.maskedTextBoxBirthday);
            this.Controls.Add(this.textBoxAddress);
            this.Controls.Add(this.groupBoxDocument);
            this.Controls.Add(this.labelAddress);
            this.Controls.Add(this.labelPatronymic);
            this.Controls.Add(this.textBoxPatronymic);
            this.Controls.Add(this.labelName);
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(this.comboBoxEmployment);
            this.Controls.Add(this.labelSurname);
            this.Controls.Add(this.textBoxSurname);
            this.Controls.Add(this.labelUser);
            this.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ListenerUpdaterView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Изменение слушателя";
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.SecretaryMenu_KeyPress);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.SecretaryMenu_MouseMove);
            this.groupBoxDocument.ResumeLayout(false);
            this.groupBoxDocument.PerformLayout();
            this.groupBoxPassport.ResumeLayout(false);
            this.groupBoxPassport.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonBack;
        private System.Windows.Forms.Button buttonUpdate;
        private System.Windows.Forms.Label labelAge;
        private System.Windows.Forms.CheckBox checkBoxFemale;
        private System.Windows.Forms.CheckBox checkBoxMale;
        private System.Windows.Forms.Label labelGender;
        private System.Windows.Forms.Label labelEducation;
        private System.Windows.Forms.ComboBox comboBoxEducation;
        private System.Windows.Forms.Label labelEmployment;
        private System.Windows.Forms.Label labelPhone;
        private System.Windows.Forms.MaskedTextBox maskedTextBoxPhone;
        private System.Windows.Forms.Label labelBirthday;
        private System.Windows.Forms.MaskedTextBox maskedTextBoxBirthday;
        private System.Windows.Forms.TextBox textBoxAddress;
        private System.Windows.Forms.GroupBox groupBoxDocument;
        private System.Windows.Forms.MaskedTextBox maskedTextBoxInsurance;
        private System.Windows.Forms.Label labelInsurance;
        private System.Windows.Forms.GroupBox groupBoxPassport;
        private System.Windows.Forms.MaskedTextBox maskedTextBoxIssuedDate;
        private System.Windows.Forms.Label labelIssuedDate;
        private System.Windows.Forms.Label labelIssuedBy;
        private System.Windows.Forms.TextBox textBoxIssuedBy;
        private System.Windows.Forms.Label labelCode;
        private System.Windows.Forms.MaskedTextBox maskedTextBoxCode;
        private System.Windows.Forms.Label labelNumber;
        private System.Windows.Forms.MaskedTextBox maskedTextBoxNumber;
        private System.Windows.Forms.Label labelSeries;
        private System.Windows.Forms.MaskedTextBox maskedTextBoxSeries;
        private System.Windows.Forms.Label labelAddress;
        private System.Windows.Forms.Label labelPatronymic;
        private System.Windows.Forms.TextBox textBoxPatronymic;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.ComboBox comboBoxEmployment;
        private System.Windows.Forms.Label labelSurname;
        private System.Windows.Forms.TextBox textBoxSurname;
        private System.Windows.Forms.Label labelUser;
        private System.Windows.Forms.Button buttonReset;
        private System.Windows.Forms.Label labelHelp;
    }
}