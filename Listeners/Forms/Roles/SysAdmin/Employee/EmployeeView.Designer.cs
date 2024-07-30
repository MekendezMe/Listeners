namespace Listeners.Forms.Roles.SysAdmin.Employee
{
    partial class EmployeeView
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.contextMenuStripDgv = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.редактированиеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.удалениеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.labelUser = new System.Windows.Forms.Label();
            this.dataGridViewUsers = new System.Windows.Forms.DataGridView();
            this.Номер = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Код = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Фамилия = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Имя = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Отчество = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Должность = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Картинка = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Фото = new System.Windows.Forms.DataGridViewImageColumn();
            this.labelSearch = new System.Windows.Forms.Label();
            this.comboBoxSort = new System.Windows.Forms.ComboBox();
            this.labelSort = new System.Windows.Forms.Label();
            this.buttonCreate = new System.Windows.Forms.Button();
            this.buttonBack = new System.Windows.Forms.Button();
            this.maskedTextBoxSearch = new System.Windows.Forms.MaskedTextBox();
            this.contextMenuStripDgv.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewUsers)).BeginInit();
            this.SuspendLayout();
            // 
            // contextMenuStripDgv
            // 
            this.contextMenuStripDgv.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.редактированиеToolStripMenuItem,
            this.удалениеToolStripMenuItem});
            this.contextMenuStripDgv.Name = "contextMenuStripDgv";
            this.contextMenuStripDgv.Size = new System.Drawing.Size(164, 48);
            // 
            // редактированиеToolStripMenuItem
            // 
            this.редактированиеToolStripMenuItem.Name = "редактированиеToolStripMenuItem";
            this.редактированиеToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.редактированиеToolStripMenuItem.Text = "Редактирование";
            this.редактированиеToolStripMenuItem.Click += new System.EventHandler(this.редактированиеToolStripMenuItem_Click);
            // 
            // удалениеToolStripMenuItem
            // 
            this.удалениеToolStripMenuItem.Name = "удалениеToolStripMenuItem";
            this.удалениеToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.удалениеToolStripMenuItem.Text = "Удаление";
            this.удалениеToolStripMenuItem.Click += new System.EventHandler(this.удалениеToolStripMenuItem_Click);
            // 
            // labelUser
            // 
            this.labelUser.AutoSize = true;
            this.labelUser.Location = new System.Drawing.Point(12, 9);
            this.labelUser.Name = "labelUser";
            this.labelUser.Size = new System.Drawing.Size(0, 20);
            this.labelUser.TabIndex = 92;
            // 
            // dataGridViewUsers
            // 
            this.dataGridViewUsers.AllowUserToAddRows = false;
            this.dataGridViewUsers.AllowUserToDeleteRows = false;
            this.dataGridViewUsers.AllowUserToResizeColumns = false;
            this.dataGridViewUsers.AllowUserToResizeRows = false;
            this.dataGridViewUsers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewUsers.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridViewUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewUsers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Номер,
            this.Код,
            this.Фамилия,
            this.Имя,
            this.Отчество,
            this.Должность,
            this.Картинка,
            this.Фото});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewUsers.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewUsers.Location = new System.Drawing.Point(12, 97);
            this.dataGridViewUsers.MultiSelect = false;
            this.dataGridViewUsers.Name = "dataGridViewUsers";
            this.dataGridViewUsers.ReadOnly = true;
            this.dataGridViewUsers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewUsers.Size = new System.Drawing.Size(621, 339);
            this.dataGridViewUsers.TabIndex = 1;
            this.dataGridViewUsers.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dataGridViewUsers_MouseClick);
            // 
            // Номер
            // 
            this.Номер.HeaderText = "Номер";
            this.Номер.Name = "Номер";
            this.Номер.ReadOnly = true;
            this.Номер.Visible = false;
            // 
            // Код
            // 
            this.Код.FillWeight = 34F;
            this.Код.HeaderText = "Код";
            this.Код.Name = "Код";
            this.Код.ReadOnly = true;
            // 
            // Фамилия
            // 
            this.Фамилия.FillWeight = 60.08132F;
            this.Фамилия.HeaderText = "Фамилия";
            this.Фамилия.Name = "Фамилия";
            this.Фамилия.ReadOnly = true;
            // 
            // Имя
            // 
            this.Имя.FillWeight = 60.08132F;
            this.Имя.HeaderText = "Имя";
            this.Имя.Name = "Имя";
            this.Имя.ReadOnly = true;
            // 
            // Отчество
            // 
            this.Отчество.FillWeight = 60.08132F;
            this.Отчество.HeaderText = "Отчество";
            this.Отчество.Name = "Отчество";
            this.Отчество.ReadOnly = true;
            // 
            // Должность
            // 
            this.Должность.FillWeight = 60.08132F;
            this.Должность.HeaderText = "Должность";
            this.Должность.Name = "Должность";
            this.Должность.ReadOnly = true;
            // 
            // Картинка
            // 
            this.Картинка.HeaderText = "Картинка";
            this.Картинка.Name = "Картинка";
            this.Картинка.ReadOnly = true;
            this.Картинка.Visible = false;
            // 
            // Фото
            // 
            this.Фото.FillWeight = 60.08132F;
            this.Фото.HeaderText = "Фото";
            this.Фото.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.Фото.Name = "Фото";
            this.Фото.ReadOnly = true;
            // 
            // labelSearch
            // 
            this.labelSearch.AutoSize = true;
            this.labelSearch.Location = new System.Drawing.Point(8, 52);
            this.labelSearch.Name = "labelSearch";
            this.labelSearch.Size = new System.Drawing.Size(98, 20);
            this.labelSearch.TabIndex = 5;
            this.labelSearch.Text = "Поиск по коду";
            // 
            // comboBoxSort
            // 
            this.comboBoxSort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSort.FormattingEnabled = true;
            this.comboBoxSort.Items.AddRange(new object[] {
            "",
            "по алфавиту",
            "не по алфавиту"});
            this.comboBoxSort.Location = new System.Drawing.Point(412, 44);
            this.comboBoxSort.Name = "comboBoxSort";
            this.comboBoxSort.Size = new System.Drawing.Size(221, 28);
            this.comboBoxSort.TabIndex = 7;
            this.comboBoxSort.SelectedIndexChanged += new System.EventHandler(this.comboBoxSort_SelectedIndexChanged);
            // 
            // labelSort
            // 
            this.labelSort.AutoSize = true;
            this.labelSort.Location = new System.Drawing.Point(245, 50);
            this.labelSort.Name = "labelSort";
            this.labelSort.Size = new System.Drawing.Size(161, 20);
            this.labelSort.TabIndex = 8;
            this.labelSort.Text = "Сортировка по фамилии";
            // 
            // buttonCreate
            // 
            this.buttonCreate.BackColor = System.Drawing.Color.LightGray;
            this.buttonCreate.Location = new System.Drawing.Point(12, 464);
            this.buttonCreate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonCreate.Name = "buttonCreate";
            this.buttonCreate.Size = new System.Drawing.Size(174, 28);
            this.buttonCreate.TabIndex = 90;
            this.buttonCreate.Text = "Добавление";
            this.buttonCreate.UseVisualStyleBackColor = false;
            this.buttonCreate.Click += new System.EventHandler(this.buttonCreate_Click);
            // 
            // buttonBack
            // 
            this.buttonBack.BackColor = System.Drawing.Color.LightGray;
            this.buttonBack.Location = new System.Drawing.Point(451, 464);
            this.buttonBack.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonBack.Name = "buttonBack";
            this.buttonBack.Size = new System.Drawing.Size(182, 28);
            this.buttonBack.TabIndex = 91;
            this.buttonBack.Text = "В меню";
            this.buttonBack.UseVisualStyleBackColor = false;
            this.buttonBack.Click += new System.EventHandler(this.buttonBack_Click);
            // 
            // maskedTextBoxSearch
            // 
            this.maskedTextBoxSearch.Location = new System.Drawing.Point(112, 49);
            this.maskedTextBoxSearch.Mask = "000";
            this.maskedTextBoxSearch.Name = "maskedTextBoxSearch";
            this.maskedTextBoxSearch.Size = new System.Drawing.Size(35, 26);
            this.maskedTextBoxSearch.TabIndex = 93;
            this.maskedTextBoxSearch.TextChanged += new System.EventHandler(this.maskedTextBoxSearch_TextChanged);
            // 
            // EmployeeView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(645, 503);
            this.ControlBox = false;
            this.Controls.Add(this.maskedTextBoxSearch);
            this.Controls.Add(this.labelUser);
            this.Controls.Add(this.buttonBack);
            this.Controls.Add(this.buttonCreate);
            this.Controls.Add(this.labelSort);
            this.Controls.Add(this.comboBoxSort);
            this.Controls.Add(this.labelSearch);
            this.Controls.Add(this.dataGridViewUsers);
            this.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(682, 542);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(661, 522);
            this.Name = "EmployeeView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Сотрудники";
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.SelectDirectory_KeyPress);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.SelectDirectory_MouseMove);
            this.contextMenuStripDgv.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewUsers)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ContextMenuStrip contextMenuStripDgv;
        private System.Windows.Forms.ToolStripMenuItem редактированиеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem удалениеToolStripMenuItem;
        private System.Windows.Forms.Label labelUser;
        private System.Windows.Forms.DataGridView dataGridViewUsers;
        private System.Windows.Forms.Label labelSearch;
        private System.Windows.Forms.ComboBox comboBoxSort;
        private System.Windows.Forms.Label labelSort;
        private System.Windows.Forms.Button buttonCreate;
        private System.Windows.Forms.Button buttonBack;
        private System.Windows.Forms.MaskedTextBox maskedTextBoxSearch;
        private System.Windows.Forms.DataGridViewTextBoxColumn Номер;
        private System.Windows.Forms.DataGridViewTextBoxColumn Код;
        private System.Windows.Forms.DataGridViewTextBoxColumn Фамилия;
        private System.Windows.Forms.DataGridViewTextBoxColumn Имя;
        private System.Windows.Forms.DataGridViewTextBoxColumn Отчество;
        private System.Windows.Forms.DataGridViewTextBoxColumn Должность;
        private System.Windows.Forms.DataGridViewTextBoxColumn Картинка;
        private System.Windows.Forms.DataGridViewImageColumn Фото;
    }
}