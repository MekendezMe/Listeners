namespace Listeners.Forms.Roles.Secretary.Organization
{
    partial class OrganizationView
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
            this.buttonTake = new System.Windows.Forms.Button();
            this.buttonBack = new System.Windows.Forms.Button();
            this.buttonCreateRepresentative = new System.Windows.Forms.Button();
            this.labelPage = new System.Windows.Forms.Label();
            this.buttonPrevious = new System.Windows.Forms.Button();
            this.buttonNext = new System.Windows.Forms.Button();
            this.labelCountRows = new System.Windows.Forms.Label();
            this.textBoxSearchTitle = new System.Windows.Forms.TextBox();
            this.labelSearch = new System.Windows.Forms.Label();
            this.dataGridViewOrganizations = new System.Windows.Forms.DataGridView();
            this.labelUser = new System.Windows.Forms.Label();
            this.labelINN = new System.Windows.Forms.Label();
            this.maskedTextBoxINN = new System.Windows.Forms.MaskedTextBox();
            this.contextMenuStripDgv = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.редактированиеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.удалениеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOrganizations)).BeginInit();
            this.contextMenuStripDgv.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonTake
            // 
            this.buttonTake.BackColor = System.Drawing.Color.LightGray;
            this.buttonTake.Enabled = false;
            this.buttonTake.Location = new System.Drawing.Point(478, 501);
            this.buttonTake.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonTake.Name = "buttonTake";
            this.buttonTake.Size = new System.Drawing.Size(135, 28);
            this.buttonTake.TabIndex = 112;
            this.buttonTake.Text = "Выбрать";
            this.buttonTake.UseVisualStyleBackColor = false;
            this.buttonTake.Visible = false;
            this.buttonTake.Click += new System.EventHandler(this.buttonTake_Click);
            // 
            // buttonBack
            // 
            this.buttonBack.BackColor = System.Drawing.Color.LightGray;
            this.buttonBack.Location = new System.Drawing.Point(1038, 501);
            this.buttonBack.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonBack.Name = "buttonBack";
            this.buttonBack.Size = new System.Drawing.Size(173, 28);
            this.buttonBack.TabIndex = 111;
            this.buttonBack.Text = "К справочникам";
            this.buttonBack.UseVisualStyleBackColor = false;
            this.buttonBack.Click += new System.EventHandler(this.buttonBack_Click);
            // 
            // buttonCreateRepresentative
            // 
            this.buttonCreateRepresentative.BackColor = System.Drawing.Color.LightGray;
            this.buttonCreateRepresentative.Location = new System.Drawing.Point(12, 501);
            this.buttonCreateRepresentative.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonCreateRepresentative.Name = "buttonCreateRepresentative";
            this.buttonCreateRepresentative.Size = new System.Drawing.Size(121, 28);
            this.buttonCreateRepresentative.TabIndex = 110;
            this.buttonCreateRepresentative.Text = "Добавление";
            this.buttonCreateRepresentative.UseVisualStyleBackColor = false;
            this.buttonCreateRepresentative.Click += new System.EventHandler(this.buttonCreateOrganization_Click);
            // 
            // labelPage
            // 
            this.labelPage.AutoSize = true;
            this.labelPage.Location = new System.Drawing.Point(1118, 447);
            this.labelPage.Name = "labelPage";
            this.labelPage.Size = new System.Drawing.Size(48, 20);
            this.labelPage.TabIndex = 109;
            this.labelPage.Text = "Pages";
            // 
            // buttonPrevious
            // 
            this.buttonPrevious.Enabled = false;
            this.buttonPrevious.Location = new System.Drawing.Point(1062, 443);
            this.buttonPrevious.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonPrevious.Name = "buttonPrevious";
            this.buttonPrevious.Size = new System.Drawing.Size(41, 28);
            this.buttonPrevious.TabIndex = 108;
            this.buttonPrevious.Text = "<";
            this.buttonPrevious.UseVisualStyleBackColor = true;
            this.buttonPrevious.Click += new System.EventHandler(this.buttonPrevious_Click);
            // 
            // buttonNext
            // 
            this.buttonNext.Location = new System.Drawing.Point(1170, 443);
            this.buttonNext.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonNext.Name = "buttonNext";
            this.buttonNext.Size = new System.Drawing.Size(41, 28);
            this.buttonNext.TabIndex = 107;
            this.buttonNext.Text = ">";
            this.buttonNext.UseVisualStyleBackColor = true;
            this.buttonNext.Click += new System.EventHandler(this.buttonNext_Click);
            // 
            // labelCountRows
            // 
            this.labelCountRows.AutoSize = true;
            this.labelCountRows.Location = new System.Drawing.Point(8, 447);
            this.labelCountRows.Name = "labelCountRows";
            this.labelCountRows.Size = new System.Drawing.Size(42, 20);
            this.labelCountRows.TabIndex = 106;
            this.labelCountRows.Text = "Rows";
            // 
            // textBoxSearchTitle
            // 
            this.textBoxSearchTitle.Location = new System.Drawing.Point(143, 41);
            this.textBoxSearchTitle.MaxLength = 100;
            this.textBoxSearchTitle.Name = "textBoxSearchTitle";
            this.textBoxSearchTitle.Size = new System.Drawing.Size(186, 26);
            this.textBoxSearchTitle.TabIndex = 105;
            this.textBoxSearchTitle.TextChanged += new System.EventHandler(this.textBoxSearchTitle_TextChanged);
            this.textBoxSearchTitle.Enter += new System.EventHandler(this.textBoxSearchTitle_Enter);
            this.textBoxSearchTitle.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxSearchTitle_KeyPress);
            // 
            // labelSearch
            // 
            this.labelSearch.AutoSize = true;
            this.labelSearch.Location = new System.Drawing.Point(12, 44);
            this.labelSearch.Name = "labelSearch";
            this.labelSearch.Size = new System.Drawing.Size(127, 20);
            this.labelSearch.TabIndex = 104;
            this.labelSearch.Text = "Поиск по названию";
            // 
            // dataGridViewOrganizations
            // 
            this.dataGridViewOrganizations.AllowUserToAddRows = false;
            this.dataGridViewOrganizations.AllowUserToDeleteRows = false;
            this.dataGridViewOrganizations.AllowUserToResizeColumns = false;
            this.dataGridViewOrganizations.AllowUserToResizeRows = false;
            this.dataGridViewOrganizations.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewOrganizations.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridViewOrganizations.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewOrganizations.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewOrganizations.Location = new System.Drawing.Point(12, 79);
            this.dataGridViewOrganizations.MultiSelect = false;
            this.dataGridViewOrganizations.Name = "dataGridViewOrganizations";
            this.dataGridViewOrganizations.ReadOnly = true;
            this.dataGridViewOrganizations.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewOrganizations.Size = new System.Drawing.Size(1199, 359);
            this.dataGridViewOrganizations.TabIndex = 103;
            this.dataGridViewOrganizations.SelectionChanged += new System.EventHandler(this.dataGridViewOrganizations_SelectionChanged);
            this.dataGridViewOrganizations.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dataGridViewOrganizations_MouseClick);
            // 
            // labelUser
            // 
            this.labelUser.AutoSize = true;
            this.labelUser.Location = new System.Drawing.Point(12, 12);
            this.labelUser.Name = "labelUser";
            this.labelUser.Size = new System.Drawing.Size(0, 20);
            this.labelUser.TabIndex = 113;
            // 
            // labelINN
            // 
            this.labelINN.AutoSize = true;
            this.labelINN.Location = new System.Drawing.Point(357, 45);
            this.labelINN.Name = "labelINN";
            this.labelINN.Size = new System.Drawing.Size(96, 20);
            this.labelINN.TabIndex = 114;
            this.labelINN.Text = "Поиск по ИНН";
            // 
            // maskedTextBoxINN
            // 
            this.maskedTextBoxINN.Location = new System.Drawing.Point(459, 42);
            this.maskedTextBoxINN.Mask = "000000000000";
            this.maskedTextBoxINN.Name = "maskedTextBoxINN";
            this.maskedTextBoxINN.Size = new System.Drawing.Size(94, 26);
            this.maskedTextBoxINN.TabIndex = 115;
            this.maskedTextBoxINN.Click += new System.EventHandler(this.maskedTextBoxINN_Click);
            this.maskedTextBoxINN.TextChanged += new System.EventHandler(this.maskedTextBoxINN_TextChanged);
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
            // OrganizationView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1223, 538);
            this.ControlBox = false;
            this.Controls.Add(this.maskedTextBoxINN);
            this.Controls.Add(this.labelINN);
            this.Controls.Add(this.labelUser);
            this.Controls.Add(this.buttonTake);
            this.Controls.Add(this.buttonBack);
            this.Controls.Add(this.buttonCreateRepresentative);
            this.Controls.Add(this.labelPage);
            this.Controls.Add(this.buttonPrevious);
            this.Controls.Add(this.buttonNext);
            this.Controls.Add(this.labelCountRows);
            this.Controls.Add(this.textBoxSearchTitle);
            this.Controls.Add(this.labelSearch);
            this.Controls.Add(this.dataGridViewOrganizations);
            this.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OrganizationView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Организации";
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.GroupView_KeyPress);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.GroupView_MouseMove);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOrganizations)).EndInit();
            this.contextMenuStripDgv.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonTake;
        private System.Windows.Forms.Button buttonBack;
        private System.Windows.Forms.Button buttonCreateRepresentative;
        private System.Windows.Forms.Label labelPage;
        private System.Windows.Forms.Button buttonPrevious;
        private System.Windows.Forms.Button buttonNext;
        private System.Windows.Forms.Label labelCountRows;
        private System.Windows.Forms.TextBox textBoxSearchTitle;
        private System.Windows.Forms.Label labelSearch;
        private System.Windows.Forms.DataGridView dataGridViewOrganizations;
        private System.Windows.Forms.Label labelUser;
        private System.Windows.Forms.Label labelINN;
        private System.Windows.Forms.MaskedTextBox maskedTextBoxINN;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripDgv;
        private System.Windows.Forms.ToolStripMenuItem редактированиеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem удалениеToolStripMenuItem;
    }
}