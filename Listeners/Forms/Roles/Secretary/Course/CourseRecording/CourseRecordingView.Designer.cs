namespace Listeners.Forms.Roles.Secretary.Course.CourseRecording
{
    partial class CourseRecordingView
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
            this.labelAboutListener = new System.Windows.Forms.Label();
            this.labelListener = new System.Windows.Forms.Label();
            this.comboBoxFrom = new System.Windows.Forms.ComboBox();
            this.textBoxCode = new System.Windows.Forms.TextBox();
            this.buttonGetListener = new System.Windows.Forms.Button();
            this.labelAboutCourse = new System.Windows.Forms.Label();
            this.labelCourse = new System.Windows.Forms.Label();
            this.buttonGetCourse = new System.Windows.Forms.Button();
            this.buttonGetGroup = new System.Windows.Forms.Button();
            this.labelAboutGroup = new System.Windows.Forms.Label();
            this.labelGroup = new System.Windows.Forms.Label();
            this.labelCode = new System.Windows.Forms.Label();
            this.maskedTextBoxEnd = new System.Windows.Forms.MaskedTextBox();
            this.labelBefore = new System.Windows.Forms.Label();
            this.maskedTextBoxStart = new System.Windows.Forms.MaskedTextBox();
            this.labelTerm = new System.Windows.Forms.Label();
            this.labelFrom = new System.Windows.Forms.Label();
            this.checkBoxCapital = new System.Windows.Forms.CheckBox();
            this.labelMaternity = new System.Windows.Forms.Label();
            this.labelDate = new System.Windows.Forms.Label();
            this.buttonGetRepresentative = new System.Windows.Forms.Button();
            this.labelAboutRepresentative = new System.Windows.Forms.Label();
            this.labelRepresentative = new System.Windows.Forms.Label();
            this.buttonGetOrganization = new System.Windows.Forms.Button();
            this.buttonRecordInCourse = new System.Windows.Forms.Button();
            this.buttonBack = new System.Windows.Forms.Button();
            this.labelAboutOrganization = new System.Windows.Forms.Label();
            this.clearGroup = new System.Windows.Forms.Button();
            this.clearRepresentative = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelUser
            // 
            this.labelUser.AutoSize = true;
            this.labelUser.Location = new System.Drawing.Point(13, 10);
            this.labelUser.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelUser.Name = "labelUser";
            this.labelUser.Size = new System.Drawing.Size(0, 20);
            this.labelUser.TabIndex = 2;
            // 
            // labelAboutListener
            // 
            this.labelAboutListener.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelAboutListener.AutoSize = true;
            this.labelAboutListener.Font = new System.Drawing.Font("Arial Narrow", 14F);
            this.labelAboutListener.Location = new System.Drawing.Point(196, 53);
            this.labelAboutListener.Name = "labelAboutListener";
            this.labelAboutListener.Size = new System.Drawing.Size(90, 23);
            this.labelAboutListener.TabIndex = 11;
            this.labelAboutListener.Text = "Не выбран";
            // 
            // labelListener
            // 
            this.labelListener.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelListener.AutoSize = true;
            this.labelListener.Font = new System.Drawing.Font("Arial Narrow", 14F);
            this.labelListener.Location = new System.Drawing.Point(91, 52);
            this.labelListener.Name = "labelListener";
            this.labelListener.Size = new System.Drawing.Size(111, 23);
            this.labelListener.TabIndex = 10;
            this.labelListener.Text = "Слушатель* - ";
            // 
            // comboBoxFrom
            // 
            this.comboBoxFrom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxFrom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxFrom.FormattingEnabled = true;
            this.comboBoxFrom.Location = new System.Drawing.Point(628, 180);
            this.comboBoxFrom.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBoxFrom.Name = "comboBoxFrom";
            this.comboBoxFrom.Size = new System.Drawing.Size(225, 28);
            this.comboBoxFrom.TabIndex = 11;
            this.comboBoxFrom.SelectedIndexChanged += new System.EventHandler(this.comboBoxFrom_SelectedIndexChanged);
            // 
            // textBoxCode
            // 
            this.textBoxCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxCode.Location = new System.Drawing.Point(627, 91);
            this.textBoxCode.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxCode.MaxLength = 15;
            this.textBoxCode.Name = "textBoxCode";
            this.textBoxCode.Size = new System.Drawing.Size(226, 26);
            this.textBoxCode.TabIndex = 8;
            this.textBoxCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxCode_KeyPress);
            // 
            // buttonGetListener
            // 
            this.buttonGetListener.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonGetListener.BackColor = System.Drawing.Color.LightGray;
            this.buttonGetListener.Location = new System.Drawing.Point(11, 51);
            this.buttonGetListener.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonGetListener.Name = "buttonGetListener";
            this.buttonGetListener.Size = new System.Drawing.Size(74, 27);
            this.buttonGetListener.TabIndex = 1;
            this.buttonGetListener.Text = "Выбор слушателя";
            this.buttonGetListener.UseVisualStyleBackColor = false;
            this.buttonGetListener.Click += new System.EventHandler(this.buttonGetListener_Click);
            // 
            // labelAboutCourse
            // 
            this.labelAboutCourse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelAboutCourse.AutoSize = true;
            this.labelAboutCourse.Font = new System.Drawing.Font("Arial Narrow", 14F);
            this.labelAboutCourse.Location = new System.Drawing.Point(146, 145);
            this.labelAboutCourse.Name = "labelAboutCourse";
            this.labelAboutCourse.Size = new System.Drawing.Size(90, 23);
            this.labelAboutCourse.TabIndex = 22;
            this.labelAboutCourse.Text = "Не выбран";
            // 
            // labelCourse
            // 
            this.labelCourse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelCourse.AutoSize = true;
            this.labelCourse.Font = new System.Drawing.Font("Arial Narrow", 14F);
            this.labelCourse.Location = new System.Drawing.Point(91, 144);
            this.labelCourse.Name = "labelCourse";
            this.labelCourse.Size = new System.Drawing.Size(62, 23);
            this.labelCourse.TabIndex = 21;
            this.labelCourse.Text = "Курс* - ";
            // 
            // buttonGetCourse
            // 
            this.buttonGetCourse.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonGetCourse.BackColor = System.Drawing.Color.LightGray;
            this.buttonGetCourse.Location = new System.Drawing.Point(11, 142);
            this.buttonGetCourse.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonGetCourse.Name = "buttonGetCourse";
            this.buttonGetCourse.Size = new System.Drawing.Size(74, 26);
            this.buttonGetCourse.TabIndex = 4;
            this.buttonGetCourse.Text = "Выбор курса";
            this.buttonGetCourse.UseVisualStyleBackColor = false;
            this.buttonGetCourse.Click += new System.EventHandler(this.buttonGetCourse_Click);
            // 
            // buttonGetGroup
            // 
            this.buttonGetGroup.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonGetGroup.BackColor = System.Drawing.Color.LightGray;
            this.buttonGetGroup.Location = new System.Drawing.Point(11, 97);
            this.buttonGetGroup.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonGetGroup.Name = "buttonGetGroup";
            this.buttonGetGroup.Size = new System.Drawing.Size(74, 26);
            this.buttonGetGroup.TabIndex = 2;
            this.buttonGetGroup.Text = "Выбор группы";
            this.buttonGetGroup.UseVisualStyleBackColor = false;
            this.buttonGetGroup.Click += new System.EventHandler(this.buttonGetGroup_Click);
            // 
            // labelAboutGroup
            // 
            this.labelAboutGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelAboutGroup.AutoSize = true;
            this.labelAboutGroup.Font = new System.Drawing.Font("Arial Narrow", 14F);
            this.labelAboutGroup.Location = new System.Drawing.Point(157, 99);
            this.labelAboutGroup.Name = "labelAboutGroup";
            this.labelAboutGroup.Size = new System.Drawing.Size(99, 23);
            this.labelAboutGroup.TabIndex = 25;
            this.labelAboutGroup.Text = "Не выбрана";
            // 
            // labelGroup
            // 
            this.labelGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelGroup.AutoSize = true;
            this.labelGroup.Font = new System.Drawing.Font("Arial Narrow", 14F);
            this.labelGroup.Location = new System.Drawing.Point(91, 98);
            this.labelGroup.Name = "labelGroup";
            this.labelGroup.Size = new System.Drawing.Size(72, 23);
            this.labelGroup.TabIndex = 24;
            this.labelGroup.Text = "Группа - ";
            // 
            // labelCode
            // 
            this.labelCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelCode.AutoSize = true;
            this.labelCode.Font = new System.Drawing.Font("Arial Narrow", 14F);
            this.labelCode.Location = new System.Drawing.Point(487, 91);
            this.labelCode.Name = "labelCode";
            this.labelCode.Size = new System.Drawing.Size(119, 23);
            this.labelCode.TabIndex = 27;
            this.labelCode.Text = "Код договора* ";
            // 
            // maskedTextBoxEnd
            // 
            this.maskedTextBoxEnd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.maskedTextBoxEnd.Font = new System.Drawing.Font("Arial Narrow", 14F);
            this.maskedTextBoxEnd.Location = new System.Drawing.Point(765, 135);
            this.maskedTextBoxEnd.Mask = "00/00/0000";
            this.maskedTextBoxEnd.Name = "maskedTextBoxEnd";
            this.maskedTextBoxEnd.Size = new System.Drawing.Size(88, 29);
            this.maskedTextBoxEnd.TabIndex = 10;
            this.maskedTextBoxEnd.ValidatingType = typeof(System.DateTime);
            this.maskedTextBoxEnd.Click += new System.EventHandler(this.maskedTextBoxStart_Click);
            this.maskedTextBoxEnd.TextChanged += new System.EventHandler(this.maskedTextBoxEnd_TextChanged);
            // 
            // labelBefore
            // 
            this.labelBefore.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelBefore.AutoSize = true;
            this.labelBefore.Font = new System.Drawing.Font("Arial Narrow", 14F);
            this.labelBefore.Location = new System.Drawing.Point(732, 138);
            this.labelBefore.Name = "labelBefore";
            this.labelBefore.Size = new System.Drawing.Size(27, 23);
            this.labelBefore.TabIndex = 69;
            this.labelBefore.Text = "по";
            // 
            // maskedTextBoxStart
            // 
            this.maskedTextBoxStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.maskedTextBoxStart.Font = new System.Drawing.Font("Arial Narrow", 14F);
            this.maskedTextBoxStart.Location = new System.Drawing.Point(627, 135);
            this.maskedTextBoxStart.Mask = "00/00/0000";
            this.maskedTextBoxStart.Name = "maskedTextBoxStart";
            this.maskedTextBoxStart.Size = new System.Drawing.Size(99, 29);
            this.maskedTextBoxStart.TabIndex = 9;
            this.maskedTextBoxStart.ValidatingType = typeof(System.DateTime);
            this.maskedTextBoxStart.Click += new System.EventHandler(this.maskedTextBoxStart_Click);
            this.maskedTextBoxStart.TextChanged += new System.EventHandler(this.maskedTextBoxStart_TextChanged);
            // 
            // labelTerm
            // 
            this.labelTerm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelTerm.AutoSize = true;
            this.labelTerm.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelTerm.Location = new System.Drawing.Point(486, 138);
            this.labelTerm.Name = "labelTerm";
            this.labelTerm.Size = new System.Drawing.Size(136, 23);
            this.labelTerm.TabIndex = 67;
            this.labelTerm.Text = "Срок обучения* с";
            // 
            // labelFrom
            // 
            this.labelFrom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelFrom.AutoSize = true;
            this.labelFrom.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelFrom.Location = new System.Drawing.Point(487, 184);
            this.labelFrom.Name = "labelFrom";
            this.labelFrom.Size = new System.Drawing.Size(128, 23);
            this.labelFrom.TabIndex = 71;
            this.labelFrom.Text = "Кем направлен*";
            // 
            // checkBoxCapital
            // 
            this.checkBoxCapital.AutoSize = true;
            this.checkBoxCapital.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.checkBoxCapital.Location = new System.Drawing.Point(187, 225);
            this.checkBoxCapital.Name = "checkBoxCapital";
            this.checkBoxCapital.Size = new System.Drawing.Size(49, 27);
            this.checkBoxCapital.TabIndex = 7;
            this.checkBoxCapital.Text = "Да";
            this.checkBoxCapital.UseVisualStyleBackColor = true;
            this.checkBoxCapital.Visible = false;
            // 
            // labelMaternity
            // 
            this.labelMaternity.AutoSize = true;
            this.labelMaternity.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelMaternity.Location = new System.Drawing.Point(11, 225);
            this.labelMaternity.Name = "labelMaternity";
            this.labelMaternity.Size = new System.Drawing.Size(170, 23);
            this.labelMaternity.TabIndex = 81;
            this.labelMaternity.Text = "Материнский капитал";
            this.labelMaternity.Visible = false;
            // 
            // labelDate
            // 
            this.labelDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelDate.AutoSize = true;
            this.labelDate.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelDate.Location = new System.Drawing.Point(487, 51);
            this.labelDate.Name = "labelDate";
            this.labelDate.Size = new System.Drawing.Size(145, 23);
            this.labelDate.TabIndex = 83;
            this.labelDate.Text = "Дата оформления";
            // 
            // buttonGetRepresentative
            // 
            this.buttonGetRepresentative.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonGetRepresentative.BackColor = System.Drawing.Color.LightGray;
            this.buttonGetRepresentative.Location = new System.Drawing.Point(11, 183);
            this.buttonGetRepresentative.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonGetRepresentative.Name = "buttonGetRepresentative";
            this.buttonGetRepresentative.Size = new System.Drawing.Size(74, 26);
            this.buttonGetRepresentative.TabIndex = 5;
            this.buttonGetRepresentative.Text = "Выбор законного представителя";
            this.buttonGetRepresentative.UseVisualStyleBackColor = false;
            this.buttonGetRepresentative.Visible = false;
            this.buttonGetRepresentative.Click += new System.EventHandler(this.buttonGetRepresentative_Click);
            // 
            // labelAboutRepresentative
            // 
            this.labelAboutRepresentative.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelAboutRepresentative.AutoSize = true;
            this.labelAboutRepresentative.Font = new System.Drawing.Font("Arial Narrow", 14F);
            this.labelAboutRepresentative.Location = new System.Drawing.Point(221, 183);
            this.labelAboutRepresentative.Name = "labelAboutRepresentative";
            this.labelAboutRepresentative.Size = new System.Drawing.Size(90, 23);
            this.labelAboutRepresentative.TabIndex = 86;
            this.labelAboutRepresentative.Text = "Не выбран";
            this.labelAboutRepresentative.Visible = false;
            // 
            // labelRepresentative
            // 
            this.labelRepresentative.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelRepresentative.AutoSize = true;
            this.labelRepresentative.Font = new System.Drawing.Font("Arial Narrow", 14F);
            this.labelRepresentative.Location = new System.Drawing.Point(91, 182);
            this.labelRepresentative.Name = "labelRepresentative";
            this.labelRepresentative.Size = new System.Drawing.Size(135, 23);
            this.labelRepresentative.TabIndex = 85;
            this.labelRepresentative.Text = "Представитель - ";
            this.labelRepresentative.Visible = false;
            // 
            // buttonGetOrganization
            // 
            this.buttonGetOrganization.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonGetOrganization.BackColor = System.Drawing.Color.LightGray;
            this.buttonGetOrganization.Location = new System.Drawing.Point(627, 217);
            this.buttonGetOrganization.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonGetOrganization.Name = "buttonGetOrganization";
            this.buttonGetOrganization.Size = new System.Drawing.Size(226, 30);
            this.buttonGetOrganization.TabIndex = 12;
            this.buttonGetOrganization.Text = "Выбор организации";
            this.buttonGetOrganization.UseVisualStyleBackColor = false;
            this.buttonGetOrganization.Visible = false;
            this.buttonGetOrganization.Click += new System.EventHandler(this.buttonGetOrganization_Click);
            // 
            // buttonRecordInCourse
            // 
            this.buttonRecordInCourse.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonRecordInCourse.BackColor = System.Drawing.Color.LightGray;
            this.buttonRecordInCourse.Location = new System.Drawing.Point(15, 291);
            this.buttonRecordInCourse.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonRecordInCourse.Name = "buttonRecordInCourse";
            this.buttonRecordInCourse.Size = new System.Drawing.Size(187, 33);
            this.buttonRecordInCourse.TabIndex = 13;
            this.buttonRecordInCourse.Text = "Записать на курс";
            this.buttonRecordInCourse.UseVisualStyleBackColor = false;
            this.buttonRecordInCourse.Click += new System.EventHandler(this.buttonRecordInCourse_Click);
            // 
            // buttonBack
            // 
            this.buttonBack.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonBack.BackColor = System.Drawing.Color.LightGray;
            this.buttonBack.Location = new System.Drawing.Point(627, 291);
            this.buttonBack.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonBack.Name = "buttonBack";
            this.buttonBack.Size = new System.Drawing.Size(226, 33);
            this.buttonBack.TabIndex = 14;
            this.buttonBack.Text = "К слушателям";
            this.buttonBack.UseVisualStyleBackColor = false;
            this.buttonBack.Click += new System.EventHandler(this.buttonBack_Click);
            // 
            // labelAboutOrganization
            // 
            this.labelAboutOrganization.AutoSize = true;
            this.labelAboutOrganization.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelAboutOrganization.Location = new System.Drawing.Point(487, 256);
            this.labelAboutOrganization.Name = "labelAboutOrganization";
            this.labelAboutOrganization.Size = new System.Drawing.Size(0, 23);
            this.labelAboutOrganization.TabIndex = 90;
            // 
            // clearGroup
            // 
            this.clearGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.clearGroup.BackColor = System.Drawing.Color.LightGray;
            this.clearGroup.Location = new System.Drawing.Point(262, 99);
            this.clearGroup.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.clearGroup.Name = "clearGroup";
            this.clearGroup.Size = new System.Drawing.Size(60, 26);
            this.clearGroup.TabIndex = 3;
            this.clearGroup.Text = "Сброс";
            this.clearGroup.UseVisualStyleBackColor = false;
            this.clearGroup.Visible = false;
            this.clearGroup.Click += new System.EventHandler(this.clearGroup_Click);
            // 
            // clearRepresentative
            // 
            this.clearRepresentative.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.clearRepresentative.BackColor = System.Drawing.Color.LightGray;
            this.clearRepresentative.Location = new System.Drawing.Point(317, 183);
            this.clearRepresentative.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.clearRepresentative.Name = "clearRepresentative";
            this.clearRepresentative.Size = new System.Drawing.Size(60, 26);
            this.clearRepresentative.TabIndex = 6;
            this.clearRepresentative.Text = "Сброс";
            this.clearRepresentative.UseVisualStyleBackColor = false;
            this.clearRepresentative.Visible = false;
            this.clearRepresentative.Click += new System.EventHandler(this.clearRepresentative_Click);
            // 
            // CourseRecordingView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(882, 381);
            this.ControlBox = false;
            this.Controls.Add(this.clearRepresentative);
            this.Controls.Add(this.clearGroup);
            this.Controls.Add(this.labelAboutOrganization);
            this.Controls.Add(this.buttonBack);
            this.Controls.Add(this.buttonRecordInCourse);
            this.Controls.Add(this.buttonGetRepresentative);
            this.Controls.Add(this.labelAboutRepresentative);
            this.Controls.Add(this.labelRepresentative);
            this.Controls.Add(this.buttonGetOrganization);
            this.Controls.Add(this.labelDate);
            this.Controls.Add(this.checkBoxCapital);
            this.Controls.Add(this.labelMaternity);
            this.Controls.Add(this.labelFrom);
            this.Controls.Add(this.maskedTextBoxEnd);
            this.Controls.Add(this.labelBefore);
            this.Controls.Add(this.maskedTextBoxStart);
            this.Controls.Add(this.labelTerm);
            this.Controls.Add(this.labelCode);
            this.Controls.Add(this.buttonGetGroup);
            this.Controls.Add(this.labelAboutGroup);
            this.Controls.Add(this.labelGroup);
            this.Controls.Add(this.buttonGetCourse);
            this.Controls.Add(this.labelAboutCourse);
            this.Controls.Add(this.labelCourse);
            this.Controls.Add(this.buttonGetListener);
            this.Controls.Add(this.labelAboutListener);
            this.Controls.Add(this.labelListener);
            this.Controls.Add(this.comboBoxFrom);
            this.Controls.Add(this.textBoxCode);
            this.Controls.Add(this.labelUser);
            this.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1012, 456);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(898, 397);
            this.Name = "CourseRecordingView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Запись на курсы";
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CourseRecordingView_KeyPress);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.CourseRecordingView_MouseMove);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelUser;
        private System.Windows.Forms.Label labelAboutListener;
        private System.Windows.Forms.Label labelListener;
        private System.Windows.Forms.ComboBox comboBoxFrom;
        private System.Windows.Forms.TextBox textBoxCode;
        private System.Windows.Forms.Button buttonGetListener;
        private System.Windows.Forms.Label labelAboutCourse;
        private System.Windows.Forms.Label labelCourse;
        private System.Windows.Forms.Button buttonGetCourse;
        private System.Windows.Forms.Button buttonGetGroup;
        private System.Windows.Forms.Label labelAboutGroup;
        private System.Windows.Forms.Label labelGroup;
        private System.Windows.Forms.Label labelCode;
        private System.Windows.Forms.MaskedTextBox maskedTextBoxEnd;
        private System.Windows.Forms.Label labelBefore;
        private System.Windows.Forms.MaskedTextBox maskedTextBoxStart;
        private System.Windows.Forms.Label labelTerm;
        private System.Windows.Forms.Label labelFrom;
        private System.Windows.Forms.CheckBox checkBoxCapital;
        private System.Windows.Forms.Label labelMaternity;
        private System.Windows.Forms.Label labelDate;
        private System.Windows.Forms.Button buttonGetRepresentative;
        private System.Windows.Forms.Label labelAboutRepresentative;
        private System.Windows.Forms.Label labelRepresentative;
        private System.Windows.Forms.Button buttonGetOrganization;
        private System.Windows.Forms.Button buttonRecordInCourse;
        private System.Windows.Forms.Button buttonBack;
        private System.Windows.Forms.Label labelAboutOrganization;
        private System.Windows.Forms.Button clearGroup;
        private System.Windows.Forms.Button clearRepresentative;
    }
}