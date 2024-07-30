namespace Listeners.Forms.Roles.Secretary.Directories
{
    partial class Employment
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.buttonBack = new System.Windows.Forms.Button();
            this.buttonUpdate = new System.Windows.Forms.Button();
            this.buttonCreate = new System.Windows.Forms.Button();
            this.textBoxEmployment = new System.Windows.Forms.TextBox();
            this.labelEmployment = new System.Windows.Forms.Label();
            this.labelUser = new System.Windows.Forms.Label();
            this.textBoxSearchTitle = new System.Windows.Forms.TextBox();
            this.labelSearch = new System.Windows.Forms.Label();
            this.dataGridViewEmployments = new System.Windows.Forms.DataGridView();
            this.contextMenuStripDgv = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.удалениеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonExport = new System.Windows.Forms.Button();
            this.buttonImport = new System.Windows.Forms.Button();
            this.folderBrowserDialogCsv = new System.Windows.Forms.FolderBrowserDialog();
            this.openFileDialogCsv = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEmployments)).BeginInit();
            this.contextMenuStripDgv.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonBack
            // 
            this.buttonBack.BackColor = System.Drawing.Color.LightGray;
            this.buttonBack.Location = new System.Drawing.Point(308, 489);
            this.buttonBack.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonBack.Name = "buttonBack";
            this.buttonBack.Size = new System.Drawing.Size(189, 30);
            this.buttonBack.TabIndex = 129;
            this.buttonBack.Text = "К выбору справочников";
            this.buttonBack.UseVisualStyleBackColor = false;
            this.buttonBack.Click += new System.EventHandler(this.buttonBack_Click);
            // 
            // buttonUpdate
            // 
            this.buttonUpdate.BackColor = System.Drawing.Color.LightGray;
            this.buttonUpdate.Enabled = false;
            this.buttonUpdate.Location = new System.Drawing.Point(139, 489);
            this.buttonUpdate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonUpdate.Name = "buttonUpdate";
            this.buttonUpdate.Size = new System.Drawing.Size(134, 30);
            this.buttonUpdate.TabIndex = 128;
            this.buttonUpdate.Text = "Редактировать";
            this.buttonUpdate.UseVisualStyleBackColor = false;
            this.buttonUpdate.Click += new System.EventHandler(this.buttonUpdate_Click);
            // 
            // buttonCreate
            // 
            this.buttonCreate.BackColor = System.Drawing.Color.LightGray;
            this.buttonCreate.Location = new System.Drawing.Point(14, 489);
            this.buttonCreate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonCreate.Name = "buttonCreate";
            this.buttonCreate.Size = new System.Drawing.Size(95, 30);
            this.buttonCreate.TabIndex = 127;
            this.buttonCreate.Text = "Добавить";
            this.buttonCreate.UseVisualStyleBackColor = false;
            this.buttonCreate.Click += new System.EventHandler(this.buttonCreate_Click);
            // 
            // textBoxEmployment
            // 
            this.textBoxEmployment.Location = new System.Drawing.Point(100, 388);
            this.textBoxEmployment.MaxLength = 20;
            this.textBoxEmployment.Name = "textBoxEmployment";
            this.textBoxEmployment.Size = new System.Drawing.Size(295, 26);
            this.textBoxEmployment.TabIndex = 126;
            this.textBoxEmployment.TextChanged += new System.EventHandler(this.textBoxEmployment_TextChanged);
            this.textBoxEmployment.Enter += new System.EventHandler(this.textBoxSearchTitle_Enter);
            this.textBoxEmployment.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxSearchTitle_KeyPress);
            // 
            // labelEmployment
            // 
            this.labelEmployment.AutoSize = true;
            this.labelEmployment.Location = new System.Drawing.Point(15, 391);
            this.labelEmployment.Name = "labelEmployment";
            this.labelEmployment.Size = new System.Drawing.Size(70, 20);
            this.labelEmployment.TabIndex = 125;
            this.labelEmployment.Text = "Занятость";
            // 
            // labelUser
            // 
            this.labelUser.AutoSize = true;
            this.labelUser.Location = new System.Drawing.Point(13, 15);
            this.labelUser.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelUser.Name = "labelUser";
            this.labelUser.Size = new System.Drawing.Size(0, 20);
            this.labelUser.TabIndex = 124;
            // 
            // textBoxSearchTitle
            // 
            this.textBoxSearchTitle.Location = new System.Drawing.Point(148, 41);
            this.textBoxSearchTitle.MaxLength = 100;
            this.textBoxSearchTitle.Name = "textBoxSearchTitle";
            this.textBoxSearchTitle.Size = new System.Drawing.Size(247, 26);
            this.textBoxSearchTitle.TabIndex = 123;
            this.textBoxSearchTitle.TextChanged += new System.EventHandler(this.textBoxSearchTitle_TextChanged);
            this.textBoxSearchTitle.Enter += new System.EventHandler(this.textBoxSearchTitle_Enter);
            this.textBoxSearchTitle.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxSearchTitle_KeyPress);
            // 
            // labelSearch
            // 
            this.labelSearch.AutoSize = true;
            this.labelSearch.Location = new System.Drawing.Point(14, 44);
            this.labelSearch.Name = "labelSearch";
            this.labelSearch.Size = new System.Drawing.Size(128, 20);
            this.labelSearch.TabIndex = 122;
            this.labelSearch.Text = "Поиск по занятости";
            // 
            // dataGridViewEmployments
            // 
            this.dataGridViewEmployments.AllowUserToAddRows = false;
            this.dataGridViewEmployments.AllowUserToDeleteRows = false;
            this.dataGridViewEmployments.AllowUserToResizeColumns = false;
            this.dataGridViewEmployments.AllowUserToResizeRows = false;
            this.dataGridViewEmployments.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewEmployments.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridViewEmployments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewEmployments.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewEmployments.Location = new System.Drawing.Point(14, 81);
            this.dataGridViewEmployments.MultiSelect = false;
            this.dataGridViewEmployments.Name = "dataGridViewEmployments";
            this.dataGridViewEmployments.ReadOnly = true;
            this.dataGridViewEmployments.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewEmployments.Size = new System.Drawing.Size(481, 283);
            this.dataGridViewEmployments.TabIndex = 121;
            this.dataGridViewEmployments.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewEmployments_CellContentClick);
            this.dataGridViewEmployments.SelectionChanged += new System.EventHandler(this.dataGridViewEmployments_SelectionChanged);
            this.dataGridViewEmployments.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dataGridViewEmployments_MouseClick);
            // 
            // contextMenuStripDgv
            // 
            this.contextMenuStripDgv.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.удалениеToolStripMenuItem});
            this.contextMenuStripDgv.Name = "contextMenuStripDgv";
            this.contextMenuStripDgv.Size = new System.Drawing.Size(127, 26);
            // 
            // удалениеToolStripMenuItem
            // 
            this.удалениеToolStripMenuItem.Name = "удалениеToolStripMenuItem";
            this.удалениеToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.удалениеToolStripMenuItem.Text = "Удаление";
            this.удалениеToolStripMenuItem.Click += new System.EventHandler(this.удалениеToolStripMenuItem_Click);
            // 
            // buttonExport
            // 
            this.buttonExport.BackColor = System.Drawing.Color.LightGray;
            this.buttonExport.Location = new System.Drawing.Point(383, 439);
            this.buttonExport.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonExport.Name = "buttonExport";
            this.buttonExport.Size = new System.Drawing.Size(114, 28);
            this.buttonExport.TabIndex = 131;
            this.buttonExport.Text = "Экспорт CSV";
            this.buttonExport.UseVisualStyleBackColor = false;
            this.buttonExport.Click += new System.EventHandler(this.buttonExport_Click);
            // 
            // buttonImport
            // 
            this.buttonImport.BackColor = System.Drawing.Color.LightGray;
            this.buttonImport.Location = new System.Drawing.Point(251, 439);
            this.buttonImport.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonImport.Name = "buttonImport";
            this.buttonImport.Size = new System.Drawing.Size(99, 28);
            this.buttonImport.TabIndex = 130;
            this.buttonImport.Text = "Импорт CSV";
            this.buttonImport.UseVisualStyleBackColor = false;
            this.buttonImport.Click += new System.EventHandler(this.buttonImport_Click);
            // 
            // openFileDialogCsv
            // 
            this.openFileDialogCsv.FileName = "openFileDialog1";
            // 
            // Employment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(516, 539);
            this.ControlBox = false;
            this.Controls.Add(this.buttonExport);
            this.Controls.Add(this.buttonImport);
            this.Controls.Add(this.buttonBack);
            this.Controls.Add(this.buttonUpdate);
            this.Controls.Add(this.buttonCreate);
            this.Controls.Add(this.textBoxEmployment);
            this.Controls.Add(this.labelEmployment);
            this.Controls.Add(this.labelUser);
            this.Controls.Add(this.textBoxSearchTitle);
            this.Controls.Add(this.labelSearch);
            this.Controls.Add(this.dataGridViewEmployments);
            this.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Employment";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Занятость";
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.SelectDirectory_KeyPress);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.SelectDirectory_MouseMove);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEmployments)).EndInit();
            this.contextMenuStripDgv.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonBack;
        private System.Windows.Forms.Button buttonUpdate;
        private System.Windows.Forms.Button buttonCreate;
        private System.Windows.Forms.TextBox textBoxEmployment;
        private System.Windows.Forms.Label labelEmployment;
        private System.Windows.Forms.Label labelUser;
        private System.Windows.Forms.TextBox textBoxSearchTitle;
        private System.Windows.Forms.Label labelSearch;
        private System.Windows.Forms.DataGridView dataGridViewEmployments;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripDgv;
        private System.Windows.Forms.ToolStripMenuItem удалениеToolStripMenuItem;
        private System.Windows.Forms.Button buttonExport;
        private System.Windows.Forms.Button buttonImport;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialogCsv;
        private System.Windows.Forms.OpenFileDialog openFileDialogCsv;
    }
}