namespace Listeners.Forms.Roles.Secretary.Record
{
    partial class RecordView
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.labelSearchListener = new System.Windows.Forms.Label();
            this.textBoxSearchListener = new System.Windows.Forms.TextBox();
            this.comboBoxSortDate = new System.Windows.Forms.ComboBox();
            this.labelUser = new System.Windows.Forms.Label();
            this.textBoxSearchCode = new System.Windows.Forms.TextBox();
            this.labelSearchByCode = new System.Windows.Forms.Label();
            this.groupBoxFilter = new System.Windows.Forms.GroupBox();
            this.buttonReset = new System.Windows.Forms.Button();
            this.maskedTextBoxEnd = new System.Windows.Forms.MaskedTextBox();
            this.maskedTextBoxStart = new System.Windows.Forms.MaskedTextBox();
            this.labelEndDate = new System.Windows.Forms.Label();
            this.labelCreditedStatus = new System.Windows.Forms.Label();
            this.labelStartDate = new System.Windows.Forms.Label();
            this.comboBoxCreditedStatus = new System.Windows.Forms.ComboBox();
            this.labelPayStatus = new System.Windows.Forms.Label();
            this.comboBoxPayStatus = new System.Windows.Forms.ComboBox();
            this.labelStatusRecord = new System.Windows.Forms.Label();
            this.comboBoxOpenStatus = new System.Windows.Forms.ComboBox();
            this.labelQualification = new System.Windows.Forms.Label();
            this.comboBoxQualification = new System.Windows.Forms.ComboBox();
            this.labelCourse = new System.Windows.Forms.Label();
            this.comboBoxCourse = new System.Windows.Forms.ComboBox();
            this.labelGroup = new System.Windows.Forms.Label();
            this.comboBoxGroup = new System.Windows.Forms.ComboBox();
            this.labelSortDate = new System.Windows.Forms.Label();
            this.dataGridViewRecords = new System.Windows.Forms.DataGridView();
            this.labelPage = new System.Windows.Forms.Label();
            this.buttonPrevious = new System.Windows.Forms.Button();
            this.buttonNext = new System.Windows.Forms.Button();
            this.labelCountRows = new System.Windows.Forms.Label();
            this.buttonCreateRecord = new System.Windows.Forms.Button();
            this.buttonBack = new System.Windows.Forms.Button();
            this.contextMenuStripDgv = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.изменитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.удалитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonExportExcel = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.labelPay = new System.Windows.Forms.Label();
            this.groupBoxFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRecords)).BeginInit();
            this.contextMenuStripDgv.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelSearchListener
            // 
            this.labelSearchListener.AutoSize = true;
            this.labelSearchListener.Location = new System.Drawing.Point(8, 52);
            this.labelSearchListener.Name = "labelSearchListener";
            this.labelSearchListener.Size = new System.Drawing.Size(140, 20);
            this.labelSearchListener.TabIndex = 0;
            this.labelSearchListener.Text = "Поиск по слушателю";
            // 
            // textBoxSearchListener
            // 
            this.textBoxSearchListener.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxSearchListener.Location = new System.Drawing.Point(12, 75);
            this.textBoxSearchListener.MaxLength = 100;
            this.textBoxSearchListener.Name = "textBoxSearchListener";
            this.textBoxSearchListener.Size = new System.Drawing.Size(242, 26);
            this.textBoxSearchListener.TabIndex = 1;
            this.textBoxSearchListener.TextChanged += new System.EventHandler(this.textBoxSearchListener_TextChanged);
            this.textBoxSearchListener.Enter += new System.EventHandler(this.textBoxSearchListener_Enter);
            this.textBoxSearchListener.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxSearchListener_KeyPress);
            // 
            // comboBoxSortDate
            // 
            this.comboBoxSortDate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxSortDate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSortDate.FormattingEnabled = true;
            this.comboBoxSortDate.Items.AddRange(new object[] {
            "",
            "по возрастанию",
            "по убыванию"});
            this.comboBoxSortDate.Location = new System.Drawing.Point(12, 198);
            this.comboBoxSortDate.Name = "comboBoxSortDate";
            this.comboBoxSortDate.Size = new System.Drawing.Size(242, 28);
            this.comboBoxSortDate.TabIndex = 2;
            this.comboBoxSortDate.SelectedIndexChanged += new System.EventHandler(this.comboBoxSortDate_SelectedIndexChanged);
            // 
            // labelUser
            // 
            this.labelUser.AutoSize = true;
            this.labelUser.Location = new System.Drawing.Point(13, 9);
            this.labelUser.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelUser.Name = "labelUser";
            this.labelUser.Size = new System.Drawing.Size(0, 20);
            this.labelUser.TabIndex = 3;
            // 
            // textBoxSearchCode
            // 
            this.textBoxSearchCode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxSearchCode.Location = new System.Drawing.Point(12, 136);
            this.textBoxSearchCode.MaxLength = 30;
            this.textBoxSearchCode.Name = "textBoxSearchCode";
            this.textBoxSearchCode.Size = new System.Drawing.Size(242, 26);
            this.textBoxSearchCode.TabIndex = 5;
            this.textBoxSearchCode.TextChanged += new System.EventHandler(this.textBoxSearchCode_TextChanged);
            this.textBoxSearchCode.Enter += new System.EventHandler(this.textBoxSearchListener_Enter);
            this.textBoxSearchCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxSearchCode_KeyPress);
            // 
            // labelSearchByCode
            // 
            this.labelSearchByCode.AutoSize = true;
            this.labelSearchByCode.Location = new System.Drawing.Point(8, 113);
            this.labelSearchByCode.Name = "labelSearchByCode";
            this.labelSearchByCode.Size = new System.Drawing.Size(161, 20);
            this.labelSearchByCode.TabIndex = 4;
            this.labelSearchByCode.Text = "Поиск по коду договора";
            // 
            // groupBoxFilter
            // 
            this.groupBoxFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxFilter.BackColor = System.Drawing.Color.Silver;
            this.groupBoxFilter.Controls.Add(this.buttonReset);
            this.groupBoxFilter.Controls.Add(this.maskedTextBoxEnd);
            this.groupBoxFilter.Controls.Add(this.maskedTextBoxStart);
            this.groupBoxFilter.Controls.Add(this.labelEndDate);
            this.groupBoxFilter.Controls.Add(this.labelCreditedStatus);
            this.groupBoxFilter.Controls.Add(this.labelStartDate);
            this.groupBoxFilter.Controls.Add(this.comboBoxCreditedStatus);
            this.groupBoxFilter.Controls.Add(this.labelPayStatus);
            this.groupBoxFilter.Controls.Add(this.comboBoxPayStatus);
            this.groupBoxFilter.Controls.Add(this.labelStatusRecord);
            this.groupBoxFilter.Controls.Add(this.comboBoxOpenStatus);
            this.groupBoxFilter.Controls.Add(this.labelQualification);
            this.groupBoxFilter.Controls.Add(this.comboBoxQualification);
            this.groupBoxFilter.Controls.Add(this.labelCourse);
            this.groupBoxFilter.Controls.Add(this.comboBoxCourse);
            this.groupBoxFilter.Controls.Add(this.labelGroup);
            this.groupBoxFilter.Controls.Add(this.comboBoxGroup);
            this.groupBoxFilter.Location = new System.Drawing.Point(308, 24);
            this.groupBoxFilter.Name = "groupBoxFilter";
            this.groupBoxFilter.Size = new System.Drawing.Size(638, 202);
            this.groupBoxFilter.TabIndex = 6;
            this.groupBoxFilter.TabStop = false;
            this.groupBoxFilter.Text = "Фильтрация";
            // 
            // buttonReset
            // 
            this.buttonReset.BackColor = System.Drawing.Color.LightGray;
            this.buttonReset.Location = new System.Drawing.Point(476, 162);
            this.buttonReset.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonReset.Name = "buttonReset";
            this.buttonReset.Size = new System.Drawing.Size(157, 33);
            this.buttonReset.TabIndex = 24;
            this.buttonReset.Text = "Сброс условий";
            this.buttonReset.UseVisualStyleBackColor = false;
            this.buttonReset.Click += new System.EventHandler(this.buttonReset_Click);
            // 
            // maskedTextBoxEnd
            // 
            this.maskedTextBoxEnd.Font = new System.Drawing.Font("Arial Narrow", 14F);
            this.maskedTextBoxEnd.Location = new System.Drawing.Point(533, 67);
            this.maskedTextBoxEnd.Mask = "00/00/0000";
            this.maskedTextBoxEnd.Name = "maskedTextBoxEnd";
            this.maskedTextBoxEnd.Size = new System.Drawing.Size(99, 29);
            this.maskedTextBoxEnd.TabIndex = 23;
            this.maskedTextBoxEnd.ValidatingType = typeof(System.DateTime);
            this.maskedTextBoxEnd.Click += new System.EventHandler(this.MaskedTextBox_Click);
            this.maskedTextBoxEnd.TextChanged += new System.EventHandler(this.maskedTextBoxEnd_TextChanged);
            // 
            // maskedTextBoxStart
            // 
            this.maskedTextBoxStart.Font = new System.Drawing.Font("Arial Narrow", 14F);
            this.maskedTextBoxStart.Location = new System.Drawing.Point(533, 26);
            this.maskedTextBoxStart.Mask = "00/00/0000";
            this.maskedTextBoxStart.Name = "maskedTextBoxStart";
            this.maskedTextBoxStart.Size = new System.Drawing.Size(99, 29);
            this.maskedTextBoxStart.TabIndex = 22;
            this.maskedTextBoxStart.ValidatingType = typeof(System.DateTime);
            this.maskedTextBoxStart.Click += new System.EventHandler(this.MaskedTextBox_Click);
            this.maskedTextBoxStart.TextChanged += new System.EventHandler(this.maskedTextBoxStart_TextChanged);
            // 
            // labelEndDate
            // 
            this.labelEndDate.AutoSize = true;
            this.labelEndDate.Location = new System.Drawing.Point(503, 73);
            this.labelEndDate.Name = "labelEndDate";
            this.labelEndDate.Size = new System.Drawing.Size(24, 20);
            this.labelEndDate.TabIndex = 21;
            this.labelEndDate.Text = "по";
            // 
            // labelCreditedStatus
            // 
            this.labelCreditedStatus.AutoSize = true;
            this.labelCreditedStatus.Location = new System.Drawing.Point(229, 145);
            this.labelCreditedStatus.Name = "labelCreditedStatus";
            this.labelCreditedStatus.Size = new System.Drawing.Size(112, 20);
            this.labelCreditedStatus.TabIndex = 19;
            this.labelCreditedStatus.Text = "Статус обучения";
            // 
            // labelStartDate
            // 
            this.labelStartDate.AutoSize = true;
            this.labelStartDate.Location = new System.Drawing.Point(442, 32);
            this.labelStartDate.Name = "labelStartDate";
            this.labelStartDate.Size = new System.Drawing.Size(85, 20);
            this.labelStartDate.TabIndex = 20;
            this.labelStartDate.Text = "За период с";
            // 
            // comboBoxCreditedStatus
            // 
            this.comboBoxCreditedStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCreditedStatus.FormattingEnabled = true;
            this.comboBoxCreditedStatus.Location = new System.Drawing.Point(233, 168);
            this.comboBoxCreditedStatus.Name = "comboBoxCreditedStatus";
            this.comboBoxCreditedStatus.Size = new System.Drawing.Size(193, 28);
            this.comboBoxCreditedStatus.TabIndex = 18;
            this.comboBoxCreditedStatus.SelectedIndexChanged += new System.EventHandler(this.ComboboxFilter_SelectedIndexChanged);
            // 
            // labelPayStatus
            // 
            this.labelPayStatus.AutoSize = true;
            this.labelPayStatus.Location = new System.Drawing.Point(229, 85);
            this.labelPayStatus.Name = "labelPayStatus";
            this.labelPayStatus.Size = new System.Drawing.Size(98, 20);
            this.labelPayStatus.TabIndex = 17;
            this.labelPayStatus.Text = "Статус оплаты";
            // 
            // comboBoxPayStatus
            // 
            this.comboBoxPayStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxPayStatus.FormattingEnabled = true;
            this.comboBoxPayStatus.Location = new System.Drawing.Point(233, 108);
            this.comboBoxPayStatus.Name = "comboBoxPayStatus";
            this.comboBoxPayStatus.Size = new System.Drawing.Size(193, 28);
            this.comboBoxPayStatus.TabIndex = 16;
            this.comboBoxPayStatus.SelectedIndexChanged += new System.EventHandler(this.ComboboxFilter_SelectedIndexChanged);
            // 
            // labelStatusRecord
            // 
            this.labelStatusRecord.AutoSize = true;
            this.labelStatusRecord.Location = new System.Drawing.Point(229, 26);
            this.labelStatusRecord.Name = "labelStatusRecord";
            this.labelStatusRecord.Size = new System.Drawing.Size(112, 20);
            this.labelStatusRecord.TabIndex = 15;
            this.labelStatusRecord.Text = "Статус договора";
            // 
            // comboBoxOpenStatus
            // 
            this.comboBoxOpenStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxOpenStatus.FormattingEnabled = true;
            this.comboBoxOpenStatus.Location = new System.Drawing.Point(233, 49);
            this.comboBoxOpenStatus.Name = "comboBoxOpenStatus";
            this.comboBoxOpenStatus.Size = new System.Drawing.Size(193, 28);
            this.comboBoxOpenStatus.TabIndex = 14;
            this.comboBoxOpenStatus.SelectedIndexChanged += new System.EventHandler(this.ComboboxFilter_SelectedIndexChanged);
            // 
            // labelQualification
            // 
            this.labelQualification.AutoSize = true;
            this.labelQualification.Location = new System.Drawing.Point(13, 145);
            this.labelQualification.Name = "labelQualification";
            this.labelQualification.Size = new System.Drawing.Size(99, 20);
            this.labelQualification.TabIndex = 13;
            this.labelQualification.Text = "Квалификация";
            // 
            // comboBoxQualification
            // 
            this.comboBoxQualification.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxQualification.FormattingEnabled = true;
            this.comboBoxQualification.Location = new System.Drawing.Point(17, 168);
            this.comboBoxQualification.Name = "comboBoxQualification";
            this.comboBoxQualification.Size = new System.Drawing.Size(192, 28);
            this.comboBoxQualification.TabIndex = 12;
            this.comboBoxQualification.SelectedIndexChanged += new System.EventHandler(this.ComboboxFilter_SelectedIndexChanged);
            // 
            // labelCourse
            // 
            this.labelCourse.AutoSize = true;
            this.labelCourse.Location = new System.Drawing.Point(13, 85);
            this.labelCourse.Name = "labelCourse";
            this.labelCourse.Size = new System.Drawing.Size(39, 20);
            this.labelCourse.TabIndex = 11;
            this.labelCourse.Text = "Курс";
            // 
            // comboBoxCourse
            // 
            this.comboBoxCourse.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCourse.FormattingEnabled = true;
            this.comboBoxCourse.Location = new System.Drawing.Point(17, 108);
            this.comboBoxCourse.Name = "comboBoxCourse";
            this.comboBoxCourse.Size = new System.Drawing.Size(192, 28);
            this.comboBoxCourse.TabIndex = 10;
            this.comboBoxCourse.SelectedIndexChanged += new System.EventHandler(this.ComboboxFilter_SelectedIndexChanged);
            // 
            // labelGroup
            // 
            this.labelGroup.AutoSize = true;
            this.labelGroup.Location = new System.Drawing.Point(13, 26);
            this.labelGroup.Name = "labelGroup";
            this.labelGroup.Size = new System.Drawing.Size(52, 20);
            this.labelGroup.TabIndex = 9;
            this.labelGroup.Text = "Группа";
            // 
            // comboBoxGroup
            // 
            this.comboBoxGroup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxGroup.FormattingEnabled = true;
            this.comboBoxGroup.Location = new System.Drawing.Point(17, 49);
            this.comboBoxGroup.Name = "comboBoxGroup";
            this.comboBoxGroup.Size = new System.Drawing.Size(192, 28);
            this.comboBoxGroup.TabIndex = 8;
            this.comboBoxGroup.SelectedIndexChanged += new System.EventHandler(this.ComboboxFilter_SelectedIndexChanged);
            // 
            // labelSortDate
            // 
            this.labelSortDate.AutoSize = true;
            this.labelSortDate.Location = new System.Drawing.Point(8, 175);
            this.labelSortDate.Name = "labelSortDate";
            this.labelSortDate.Size = new System.Drawing.Size(122, 20);
            this.labelSortDate.TabIndex = 7;
            this.labelSortDate.Text = "Дата оформления";
            // 
            // dataGridViewRecords
            // 
            this.dataGridViewRecords.AllowUserToAddRows = false;
            this.dataGridViewRecords.AllowUserToDeleteRows = false;
            this.dataGridViewRecords.AllowUserToResizeColumns = false;
            this.dataGridViewRecords.AllowUserToResizeRows = false;
            this.dataGridViewRecords.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewRecords.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewRecords.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridViewRecords.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewRecords.DefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridViewRecords.Location = new System.Drawing.Point(12, 242);
            this.dataGridViewRecords.Name = "dataGridViewRecords";
            this.dataGridViewRecords.ReadOnly = true;
            this.dataGridViewRecords.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewRecords.Size = new System.Drawing.Size(1251, 355);
            this.dataGridViewRecords.TabIndex = 8;
            this.dataGridViewRecords.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dataGridViewRecords_RowsAdded);
            this.dataGridViewRecords.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dataGridViewRecords_MouseClick);
            // 
            // labelPage
            // 
            this.labelPage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.labelPage.AutoSize = true;
            this.labelPage.Location = new System.Drawing.Point(1171, 618);
            this.labelPage.Name = "labelPage";
            this.labelPage.Size = new System.Drawing.Size(48, 20);
            this.labelPage.TabIndex = 104;
            this.labelPage.Text = "Pages";
            // 
            // buttonPrevious
            // 
            this.buttonPrevious.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonPrevious.Enabled = false;
            this.buttonPrevious.Location = new System.Drawing.Point(1115, 614);
            this.buttonPrevious.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonPrevious.Name = "buttonPrevious";
            this.buttonPrevious.Size = new System.Drawing.Size(41, 28);
            this.buttonPrevious.TabIndex = 103;
            this.buttonPrevious.Text = "<";
            this.buttonPrevious.UseVisualStyleBackColor = true;
            this.buttonPrevious.Click += new System.EventHandler(this.buttonPrevious_Click);
            // 
            // buttonNext
            // 
            this.buttonNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonNext.Location = new System.Drawing.Point(1222, 614);
            this.buttonNext.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonNext.Name = "buttonNext";
            this.buttonNext.Size = new System.Drawing.Size(41, 28);
            this.buttonNext.TabIndex = 102;
            this.buttonNext.Text = ">";
            this.buttonNext.UseVisualStyleBackColor = true;
            this.buttonNext.Click += new System.EventHandler(this.buttonNext_Click);
            // 
            // labelCountRows
            // 
            this.labelCountRows.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelCountRows.AutoSize = true;
            this.labelCountRows.Location = new System.Drawing.Point(8, 614);
            this.labelCountRows.Name = "labelCountRows";
            this.labelCountRows.Size = new System.Drawing.Size(42, 20);
            this.labelCountRows.TabIndex = 101;
            this.labelCountRows.Text = "Rows";
            // 
            // buttonCreateRecord
            // 
            this.buttonCreateRecord.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonCreateRecord.BackColor = System.Drawing.Color.LightGray;
            this.buttonCreateRecord.Location = new System.Drawing.Point(12, 673);
            this.buttonCreateRecord.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonCreateRecord.Name = "buttonCreateRecord";
            this.buttonCreateRecord.Size = new System.Drawing.Size(166, 33);
            this.buttonCreateRecord.TabIndex = 105;
            this.buttonCreateRecord.Text = "Добавление договора";
            this.buttonCreateRecord.UseVisualStyleBackColor = false;
            this.buttonCreateRecord.Click += new System.EventHandler(this.buttonCreateRecord_Click);
            // 
            // buttonBack
            // 
            this.buttonBack.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonBack.BackColor = System.Drawing.Color.LightGray;
            this.buttonBack.Location = new System.Drawing.Point(1097, 673);
            this.buttonBack.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonBack.Name = "buttonBack";
            this.buttonBack.Size = new System.Drawing.Size(166, 33);
            this.buttonBack.TabIndex = 106;
            this.buttonBack.Text = "В меню";
            this.buttonBack.UseVisualStyleBackColor = false;
            this.buttonBack.Click += new System.EventHandler(this.buttonBack_Click);
            // 
            // contextMenuStripDgv
            // 
            this.contextMenuStripDgv.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.изменитьToolStripMenuItem,
            this.удалитьToolStripMenuItem});
            this.contextMenuStripDgv.Name = "contextMenuStripDgv";
            this.contextMenuStripDgv.Size = new System.Drawing.Size(129, 48);
            // 
            // изменитьToolStripMenuItem
            // 
            this.изменитьToolStripMenuItem.Name = "изменитьToolStripMenuItem";
            this.изменитьToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.изменитьToolStripMenuItem.Text = "Изменить";
            this.изменитьToolStripMenuItem.Click += new System.EventHandler(this.изменитьToolStripMenuItem_Click);
            // 
            // удалитьToolStripMenuItem
            // 
            this.удалитьToolStripMenuItem.Name = "удалитьToolStripMenuItem";
            this.удалитьToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.удалитьToolStripMenuItem.Text = "Удалить";
            this.удалитьToolStripMenuItem.Click += new System.EventHandler(this.удалитьToolStripMenuItem_Click);
            // 
            // buttonExportExcel
            // 
            this.buttonExportExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonExportExcel.BackColor = System.Drawing.Color.LightGray;
            this.buttonExportExcel.Location = new System.Drawing.Point(991, 189);
            this.buttonExportExcel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonExportExcel.Name = "buttonExportExcel";
            this.buttonExportExcel.Size = new System.Drawing.Size(272, 33);
            this.buttonExportExcel.TabIndex = 107;
            this.buttonExportExcel.Text = "Экспорт отчета по договорам в Excel";
            this.buttonExportExcel.UseVisualStyleBackColor = false;
            this.buttonExportExcel.Click += new System.EventHandler(this.buttonExportExcel_Click);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.Font = new System.Drawing.Font("Arial Narrow", 14F);
            this.label2.Location = new System.Drawing.Point(454, 611);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(131, 23);
            this.label2.TabIndex = 110;
            this.label2.Text = "Статус договора";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.White;
            this.label3.Font = new System.Drawing.Font("Arial Narrow", 14F);
            this.label3.Location = new System.Drawing.Point(654, 611);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 23);
            this.label3.TabIndex = 111;
            this.label3.Text = "Оплата";
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.White;
            this.label6.Font = new System.Drawing.Font("Arial Narrow", 14F);
            this.label6.Location = new System.Drawing.Point(493, 644);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(70, 23);
            this.label6.TabIndex = 115;
            this.label6.Text = "- открыт";
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.BackColor = System.Drawing.Color.IndianRed;
            this.label7.Location = new System.Drawing.Point(454, 643);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(29, 28);
            this.label7.TabIndex = 114;
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.White;
            this.label8.Font = new System.Drawing.Font("Arial Narrow", 14F);
            this.label8.Location = new System.Drawing.Point(493, 682);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(70, 23);
            this.label8.TabIndex = 117;
            this.label8.Text = "- закрыт";
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.BackColor = System.Drawing.Color.LightGreen;
            this.label9.Location = new System.Drawing.Point(454, 681);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(29, 28);
            this.label9.TabIndex = 116;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.White;
            this.label4.Font = new System.Drawing.Font("Arial Narrow", 14F);
            this.label4.Location = new System.Drawing.Point(689, 681);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(102, 23);
            this.label4.TabIndex = 121;
            this.label4.Text = "- не оплачен";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.BackColor = System.Drawing.Color.LightSalmon;
            this.label5.Location = new System.Drawing.Point(654, 680);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 28);
            this.label5.TabIndex = 120;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("Arial Narrow", 14F);
            this.label1.Location = new System.Drawing.Point(689, 644);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 23);
            this.label1.TabIndex = 119;
            this.label1.Text = "- оплачен";
            // 
            // labelPay
            // 
            this.labelPay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.labelPay.BackColor = System.Drawing.Color.LightGreen;
            this.labelPay.Location = new System.Drawing.Point(654, 643);
            this.labelPay.Name = "labelPay";
            this.labelPay.Size = new System.Drawing.Size(29, 28);
            this.labelPay.TabIndex = 118;
            // 
            // RecordView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1281, 720);
            this.ControlBox = false;
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelPay);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.buttonExportExcel);
            this.Controls.Add(this.buttonBack);
            this.Controls.Add(this.buttonCreateRecord);
            this.Controls.Add(this.labelPage);
            this.Controls.Add(this.buttonPrevious);
            this.Controls.Add(this.buttonNext);
            this.Controls.Add(this.labelCountRows);
            this.Controls.Add(this.dataGridViewRecords);
            this.Controls.Add(this.labelSortDate);
            this.Controls.Add(this.comboBoxSortDate);
            this.Controls.Add(this.groupBoxFilter);
            this.Controls.Add(this.textBoxSearchCode);
            this.Controls.Add(this.labelSearchByCode);
            this.Controls.Add(this.labelUser);
            this.Controls.Add(this.textBoxSearchListener);
            this.Controls.Add(this.labelSearchListener);
            this.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1425, 816);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(1297, 759);
            this.Name = "RecordView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Записи";
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.RecordView_KeyPress);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.RecordView_MouseMove);
            this.groupBoxFilter.ResumeLayout(false);
            this.groupBoxFilter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRecords)).EndInit();
            this.contextMenuStripDgv.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelSearchListener;
        private System.Windows.Forms.TextBox textBoxSearchListener;
        private System.Windows.Forms.ComboBox comboBoxSortDate;
        private System.Windows.Forms.Label labelUser;
        private System.Windows.Forms.TextBox textBoxSearchCode;
        private System.Windows.Forms.Label labelSearchByCode;
        private System.Windows.Forms.GroupBox groupBoxFilter;
        private System.Windows.Forms.Label labelSortDate;
        private System.Windows.Forms.Label labelQualification;
        private System.Windows.Forms.ComboBox comboBoxQualification;
        private System.Windows.Forms.Label labelCourse;
        private System.Windows.Forms.ComboBox comboBoxCourse;
        private System.Windows.Forms.Label labelGroup;
        private System.Windows.Forms.ComboBox comboBoxGroup;
        private System.Windows.Forms.Label labelCreditedStatus;
        private System.Windows.Forms.ComboBox comboBoxCreditedStatus;
        private System.Windows.Forms.Label labelPayStatus;
        private System.Windows.Forms.ComboBox comboBoxPayStatus;
        private System.Windows.Forms.Label labelStatusRecord;
        private System.Windows.Forms.ComboBox comboBoxOpenStatus;
        private System.Windows.Forms.Label labelEndDate;
        private System.Windows.Forms.Label labelStartDate;
        private System.Windows.Forms.MaskedTextBox maskedTextBoxEnd;
        private System.Windows.Forms.MaskedTextBox maskedTextBoxStart;
        private System.Windows.Forms.Button buttonReset;
        private System.Windows.Forms.DataGridView dataGridViewRecords;
        private System.Windows.Forms.Label labelPage;
        private System.Windows.Forms.Button buttonPrevious;
        private System.Windows.Forms.Button buttonNext;
        private System.Windows.Forms.Label labelCountRows;
        private System.Windows.Forms.Button buttonCreateRecord;
        private System.Windows.Forms.Button buttonBack;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripDgv;
        private System.Windows.Forms.ToolStripMenuItem изменитьToolStripMenuItem;
        private System.Windows.Forms.Button buttonExportExcel;
        private System.Windows.Forms.ToolStripMenuItem удалитьToolStripMenuItem;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelPay;
    }
}