namespace Listeners.Forms.Roles.Secretary.Directories
{
    partial class Education
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
            this.textBoxSearchTitle = new System.Windows.Forms.TextBox();
            this.labelSearch = new System.Windows.Forms.Label();
            this.dataGridViewEducations = new System.Windows.Forms.DataGridView();
            this.labelUser = new System.Windows.Forms.Label();
            this.contextMenuStripDgv = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.удалениеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.textBoxEducation = new System.Windows.Forms.TextBox();
            this.labelEducation = new System.Windows.Forms.Label();
            this.buttonCreate = new System.Windows.Forms.Button();
            this.buttonUpdate = new System.Windows.Forms.Button();
            this.buttonBack = new System.Windows.Forms.Button();
            this.buttonExport = new System.Windows.Forms.Button();
            this.buttonImport = new System.Windows.Forms.Button();
            this.openFileDialogCsv = new System.Windows.Forms.OpenFileDialog();
            this.folderBrowserDialogCsv = new System.Windows.Forms.FolderBrowserDialog();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEducations)).BeginInit();
            this.contextMenuStripDgv.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxSearchTitle
            // 
            this.textBoxSearchTitle.Location = new System.Drawing.Point(170, 36);
            this.textBoxSearchTitle.MaxLength = 100;
            this.textBoxSearchTitle.Name = "textBoxSearchTitle";
            this.textBoxSearchTitle.Size = new System.Drawing.Size(241, 26);
            this.textBoxSearchTitle.TabIndex = 108;
            this.textBoxSearchTitle.TextChanged += new System.EventHandler(this.textBoxSearchTitle_TextChanged);
            this.textBoxSearchTitle.Enter += new System.EventHandler(this.textBoxSearchTitle_Enter);
            this.textBoxSearchTitle.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxSearchTitle_KeyPress);
            // 
            // labelSearch
            // 
            this.labelSearch.AutoSize = true;
            this.labelSearch.Location = new System.Drawing.Point(12, 39);
            this.labelSearch.Name = "labelSearch";
            this.labelSearch.Size = new System.Drawing.Size(152, 20);
            this.labelSearch.TabIndex = 107;
            this.labelSearch.Text = "Поиск по образованию";
            // 
            // dataGridViewEducations
            // 
            this.dataGridViewEducations.AllowUserToAddRows = false;
            this.dataGridViewEducations.AllowUserToDeleteRows = false;
            this.dataGridViewEducations.AllowUserToResizeColumns = false;
            this.dataGridViewEducations.AllowUserToResizeRows = false;
            this.dataGridViewEducations.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewEducations.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridViewEducations.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewEducations.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewEducations.Location = new System.Drawing.Point(12, 76);
            this.dataGridViewEducations.MultiSelect = false;
            this.dataGridViewEducations.Name = "dataGridViewEducations";
            this.dataGridViewEducations.ReadOnly = true;
            this.dataGridViewEducations.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewEducations.Size = new System.Drawing.Size(481, 283);
            this.dataGridViewEducations.TabIndex = 106;
            this.dataGridViewEducations.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewEducations_CellContentClick);
            this.dataGridViewEducations.SelectionChanged += new System.EventHandler(this.dataGridViewEducations_SelectionChanged);
            this.dataGridViewEducations.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dataGridViewEducations_MouseClick);
            // 
            // labelUser
            // 
            this.labelUser.AutoSize = true;
            this.labelUser.Location = new System.Drawing.Point(13, 10);
            this.labelUser.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelUser.Name = "labelUser";
            this.labelUser.Size = new System.Drawing.Size(0, 20);
            this.labelUser.TabIndex = 109;
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
            // textBoxEducation
            // 
            this.textBoxEducation.Location = new System.Drawing.Point(111, 383);
            this.textBoxEducation.MaxLength = 20;
            this.textBoxEducation.Name = "textBoxEducation";
            this.textBoxEducation.Size = new System.Drawing.Size(300, 26);
            this.textBoxEducation.TabIndex = 112;
            this.textBoxEducation.TextChanged += new System.EventHandler(this.textBoxEducation_TextChanged);
            this.textBoxEducation.Enter += new System.EventHandler(this.textBoxSearchTitle_Enter);
            this.textBoxEducation.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxSearchTitle_KeyPress);
            // 
            // labelEducation
            // 
            this.labelEducation.AutoSize = true;
            this.labelEducation.Location = new System.Drawing.Point(13, 386);
            this.labelEducation.Name = "labelEducation";
            this.labelEducation.Size = new System.Drawing.Size(92, 20);
            this.labelEducation.TabIndex = 111;
            this.labelEducation.Text = "Образование";
            // 
            // buttonCreate
            // 
            this.buttonCreate.BackColor = System.Drawing.Color.LightGray;
            this.buttonCreate.Location = new System.Drawing.Point(12, 500);
            this.buttonCreate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonCreate.Name = "buttonCreate";
            this.buttonCreate.Size = new System.Drawing.Size(95, 30);
            this.buttonCreate.TabIndex = 118;
            this.buttonCreate.Text = "Добавить";
            this.buttonCreate.UseVisualStyleBackColor = false;
            this.buttonCreate.Click += new System.EventHandler(this.buttonCreate_Click);
            // 
            // buttonUpdate
            // 
            this.buttonUpdate.BackColor = System.Drawing.Color.LightGray;
            this.buttonUpdate.Enabled = false;
            this.buttonUpdate.Location = new System.Drawing.Point(132, 500);
            this.buttonUpdate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonUpdate.Name = "buttonUpdate";
            this.buttonUpdate.Size = new System.Drawing.Size(134, 30);
            this.buttonUpdate.TabIndex = 119;
            this.buttonUpdate.Text = "Редактировать";
            this.buttonUpdate.UseVisualStyleBackColor = false;
            this.buttonUpdate.Click += new System.EventHandler(this.buttonUpdate_Click);
            // 
            // buttonBack
            // 
            this.buttonBack.BackColor = System.Drawing.Color.LightGray;
            this.buttonBack.Location = new System.Drawing.Point(304, 500);
            this.buttonBack.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonBack.Name = "buttonBack";
            this.buttonBack.Size = new System.Drawing.Size(189, 30);
            this.buttonBack.TabIndex = 120;
            this.buttonBack.Text = "К выбору справочников";
            this.buttonBack.UseVisualStyleBackColor = false;
            this.buttonBack.Click += new System.EventHandler(this.buttonBack_Click);
            // 
            // buttonExport
            // 
            this.buttonExport.BackColor = System.Drawing.Color.LightGray;
            this.buttonExport.Location = new System.Drawing.Point(379, 442);
            this.buttonExport.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonExport.Name = "buttonExport";
            this.buttonExport.Size = new System.Drawing.Size(114, 28);
            this.buttonExport.TabIndex = 122;
            this.buttonExport.Text = "Экспорт CSV";
            this.buttonExport.UseVisualStyleBackColor = false;
            this.buttonExport.Click += new System.EventHandler(this.buttonExport_Click);
            // 
            // buttonImport
            // 
            this.buttonImport.BackColor = System.Drawing.Color.LightGray;
            this.buttonImport.Location = new System.Drawing.Point(247, 442);
            this.buttonImport.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonImport.Name = "buttonImport";
            this.buttonImport.Size = new System.Drawing.Size(99, 28);
            this.buttonImport.TabIndex = 121;
            this.buttonImport.Text = "Импорт CSV";
            this.buttonImport.UseVisualStyleBackColor = false;
            this.buttonImport.Click += new System.EventHandler(this.buttonImport_Click);
            // 
            // openFileDialogCsv
            // 
            this.openFileDialogCsv.FileName = "openFileDialog1";
            // 
            // Education
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(505, 541);
            this.ControlBox = false;
            this.Controls.Add(this.buttonExport);
            this.Controls.Add(this.buttonImport);
            this.Controls.Add(this.buttonBack);
            this.Controls.Add(this.buttonUpdate);
            this.Controls.Add(this.buttonCreate);
            this.Controls.Add(this.textBoxEducation);
            this.Controls.Add(this.labelEducation);
            this.Controls.Add(this.labelUser);
            this.Controls.Add(this.textBoxSearchTitle);
            this.Controls.Add(this.labelSearch);
            this.Controls.Add(this.dataGridViewEducations);
            this.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Education";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Образование";
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.SelectDirectory_KeyPress);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.SelectDirectory_MouseMove);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEducations)).EndInit();
            this.contextMenuStripDgv.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxSearchTitle;
        private System.Windows.Forms.Label labelSearch;
        private System.Windows.Forms.DataGridView dataGridViewEducations;
        private System.Windows.Forms.Label labelUser;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripDgv;
        private System.Windows.Forms.ToolStripMenuItem удалениеToolStripMenuItem;
        private System.Windows.Forms.TextBox textBoxEducation;
        private System.Windows.Forms.Label labelEducation;
        private System.Windows.Forms.Button buttonCreate;
        private System.Windows.Forms.Button buttonUpdate;
        private System.Windows.Forms.Button buttonBack;
        private System.Windows.Forms.Button buttonExport;
        private System.Windows.Forms.Button buttonImport;
        private System.Windows.Forms.OpenFileDialog openFileDialogCsv;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialogCsv;
    }
}