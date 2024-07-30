namespace Listeners.Forms.Roles.Secretary.Course
{
    partial class CourseView
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.buttonTake = new System.Windows.Forms.Button();
            this.buttonBack = new System.Windows.Forms.Button();
            this.buttonCreateCourse = new System.Windows.Forms.Button();
            this.labelPage = new System.Windows.Forms.Label();
            this.buttonPrevious = new System.Windows.Forms.Button();
            this.buttonNext = new System.Windows.Forms.Button();
            this.labelCountRows = new System.Windows.Forms.Label();
            this.textBoxSearch = new System.Windows.Forms.TextBox();
            this.labelSearch = new System.Windows.Forms.Label();
            this.labelUser = new System.Windows.Forms.Label();
            this.dataGridViewCourses = new System.Windows.Forms.DataGridView();
            this.comboBoxQualification = new System.Windows.Forms.ComboBox();
            this.labelQualification = new System.Windows.Forms.Label();
            this.contextMenuStripDgv = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.редактированиеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.удалениеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.labelSort = new System.Windows.Forms.Label();
            this.comboBoxSort = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCourses)).BeginInit();
            this.contextMenuStripDgv.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonTake
            // 
            this.buttonTake.BackColor = System.Drawing.Color.LightGray;
            this.buttonTake.Enabled = false;
            this.buttonTake.Location = new System.Drawing.Point(227, 456);
            this.buttonTake.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonTake.Name = "buttonTake";
            this.buttonTake.Size = new System.Drawing.Size(112, 28);
            this.buttonTake.TabIndex = 103;
            this.buttonTake.Text = "Выбрать";
            this.buttonTake.UseVisualStyleBackColor = false;
            this.buttonTake.Visible = false;
            this.buttonTake.Click += new System.EventHandler(this.buttonTake_Click);
            // 
            // buttonBack
            // 
            this.buttonBack.BackColor = System.Drawing.Color.LightGray;
            this.buttonBack.Location = new System.Drawing.Point(479, 456);
            this.buttonBack.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonBack.Name = "buttonBack";
            this.buttonBack.Size = new System.Drawing.Size(169, 28);
            this.buttonBack.TabIndex = 102;
            this.buttonBack.Text = "К справочникам";
            this.buttonBack.UseVisualStyleBackColor = false;
            this.buttonBack.Click += new System.EventHandler(this.buttonBack_Click);
            // 
            // buttonCreateCourse
            // 
            this.buttonCreateCourse.BackColor = System.Drawing.Color.LightGray;
            this.buttonCreateCourse.Location = new System.Drawing.Point(16, 456);
            this.buttonCreateCourse.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonCreateCourse.Name = "buttonCreateCourse";
            this.buttonCreateCourse.Size = new System.Drawing.Size(97, 28);
            this.buttonCreateCourse.TabIndex = 101;
            this.buttonCreateCourse.Text = "Добавление";
            this.buttonCreateCourse.UseVisualStyleBackColor = false;
            this.buttonCreateCourse.Click += new System.EventHandler(this.buttonCreateCourse_Click);
            // 
            // labelPage
            // 
            this.labelPage.AutoSize = true;
            this.labelPage.Location = new System.Drawing.Point(556, 410);
            this.labelPage.Name = "labelPage";
            this.labelPage.Size = new System.Drawing.Size(48, 20);
            this.labelPage.TabIndex = 100;
            this.labelPage.Text = "Pages";
            // 
            // buttonPrevious
            // 
            this.buttonPrevious.Enabled = false;
            this.buttonPrevious.Location = new System.Drawing.Point(500, 406);
            this.buttonPrevious.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonPrevious.Name = "buttonPrevious";
            this.buttonPrevious.Size = new System.Drawing.Size(41, 28);
            this.buttonPrevious.TabIndex = 99;
            this.buttonPrevious.Text = "<";
            this.buttonPrevious.UseVisualStyleBackColor = true;
            this.buttonPrevious.Click += new System.EventHandler(this.buttonPrevious_Click);
            // 
            // buttonNext
            // 
            this.buttonNext.Location = new System.Drawing.Point(607, 406);
            this.buttonNext.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonNext.Name = "buttonNext";
            this.buttonNext.Size = new System.Drawing.Size(41, 28);
            this.buttonNext.TabIndex = 98;
            this.buttonNext.Text = ">";
            this.buttonNext.UseVisualStyleBackColor = true;
            this.buttonNext.Click += new System.EventHandler(this.buttonNext_Click);
            // 
            // labelCountRows
            // 
            this.labelCountRows.AutoSize = true;
            this.labelCountRows.Location = new System.Drawing.Point(12, 410);
            this.labelCountRows.Name = "labelCountRows";
            this.labelCountRows.Size = new System.Drawing.Size(42, 20);
            this.labelCountRows.TabIndex = 97;
            this.labelCountRows.Text = "Rows";
            // 
            // textBoxSearch
            // 
            this.textBoxSearch.Location = new System.Drawing.Point(16, 58);
            this.textBoxSearch.MaxLength = 100;
            this.textBoxSearch.Name = "textBoxSearch";
            this.textBoxSearch.Size = new System.Drawing.Size(177, 26);
            this.textBoxSearch.TabIndex = 96;
            this.textBoxSearch.TextChanged += new System.EventHandler(this.textBoxSearch_TextChanged);
            this.textBoxSearch.Enter += new System.EventHandler(this.textBoxSearch_Enter);
            this.textBoxSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxSearch_KeyPress);
            // 
            // labelSearch
            // 
            this.labelSearch.AutoSize = true;
            this.labelSearch.Location = new System.Drawing.Point(22, 35);
            this.labelSearch.Name = "labelSearch";
            this.labelSearch.Size = new System.Drawing.Size(166, 20);
            this.labelSearch.TabIndex = 95;
            this.labelSearch.Text = "Поиск по названию курса";
            // 
            // labelUser
            // 
            this.labelUser.AutoSize = true;
            this.labelUser.Location = new System.Drawing.Point(12, 9);
            this.labelUser.Name = "labelUser";
            this.labelUser.Size = new System.Drawing.Size(0, 20);
            this.labelUser.TabIndex = 94;
            // 
            // dataGridViewCourses
            // 
            this.dataGridViewCourses.AllowUserToAddRows = false;
            this.dataGridViewCourses.AllowUserToDeleteRows = false;
            this.dataGridViewCourses.AllowUserToResizeColumns = false;
            this.dataGridViewCourses.AllowUserToResizeRows = false;
            this.dataGridViewCourses.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewCourses.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridViewCourses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewCourses.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewCourses.Location = new System.Drawing.Point(16, 95);
            this.dataGridViewCourses.MultiSelect = false;
            this.dataGridViewCourses.Name = "dataGridViewCourses";
            this.dataGridViewCourses.ReadOnly = true;
            this.dataGridViewCourses.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewCourses.Size = new System.Drawing.Size(632, 295);
            this.dataGridViewCourses.TabIndex = 93;
            this.dataGridViewCourses.SelectionChanged += new System.EventHandler(this.dataGridViewCourses_SelectionChanged);
            this.dataGridViewCourses.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dataGridViewCourses_MouseClick);
            // 
            // comboBoxQualification
            // 
            this.comboBoxQualification.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxQualification.FormattingEnabled = true;
            this.comboBoxQualification.Location = new System.Drawing.Point(227, 56);
            this.comboBoxQualification.Name = "comboBoxQualification";
            this.comboBoxQualification.Size = new System.Drawing.Size(198, 28);
            this.comboBoxQualification.TabIndex = 104;
            this.comboBoxQualification.SelectedIndexChanged += new System.EventHandler(this.comboBoxQualification_SelectedIndexChanged);
            // 
            // labelQualification
            // 
            this.labelQualification.AutoSize = true;
            this.labelQualification.Location = new System.Drawing.Point(228, 33);
            this.labelQualification.Name = "labelQualification";
            this.labelQualification.Size = new System.Drawing.Size(194, 20);
            this.labelQualification.TabIndex = 105;
            this.labelQualification.Text = "Фильтрация по квалификации";
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
            // labelSort
            // 
            this.labelSort.AutoSize = true;
            this.labelSort.Location = new System.Drawing.Point(451, 33);
            this.labelSort.Name = "labelSort";
            this.labelSort.Size = new System.Drawing.Size(193, 20);
            this.labelSort.TabIndex = 107;
            this.labelSort.Text = "Сортировка по квалификации";
            // 
            // comboBoxSort
            // 
            this.comboBoxSort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSort.FormattingEnabled = true;
            this.comboBoxSort.Items.AddRange(new object[] {
            "",
            "по алфавиту",
            "в обратном порядке"});
            this.comboBoxSort.Location = new System.Drawing.Point(450, 56);
            this.comboBoxSort.Name = "comboBoxSort";
            this.comboBoxSort.Size = new System.Drawing.Size(198, 28);
            this.comboBoxSort.TabIndex = 106;
            this.comboBoxSort.SelectedIndexChanged += new System.EventHandler(this.comboBoxSort_SelectedIndexChanged);
            // 
            // CourseView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(660, 495);
            this.ControlBox = false;
            this.Controls.Add(this.labelSort);
            this.Controls.Add(this.comboBoxSort);
            this.Controls.Add(this.labelQualification);
            this.Controls.Add(this.comboBoxQualification);
            this.Controls.Add(this.buttonTake);
            this.Controls.Add(this.buttonBack);
            this.Controls.Add(this.buttonCreateCourse);
            this.Controls.Add(this.labelPage);
            this.Controls.Add(this.buttonPrevious);
            this.Controls.Add(this.buttonNext);
            this.Controls.Add(this.labelCountRows);
            this.Controls.Add(this.textBoxSearch);
            this.Controls.Add(this.labelSearch);
            this.Controls.Add(this.labelUser);
            this.Controls.Add(this.dataGridViewCourses);
            this.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CourseView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Курсы";
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.GroupView_KeyPress);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.GroupView_MouseMove);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCourses)).EndInit();
            this.contextMenuStripDgv.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonTake;
        private System.Windows.Forms.Button buttonBack;
        private System.Windows.Forms.Button buttonCreateCourse;
        private System.Windows.Forms.Label labelPage;
        private System.Windows.Forms.Button buttonPrevious;
        private System.Windows.Forms.Button buttonNext;
        private System.Windows.Forms.Label labelCountRows;
        private System.Windows.Forms.TextBox textBoxSearch;
        private System.Windows.Forms.Label labelSearch;
        private System.Windows.Forms.Label labelUser;
        private System.Windows.Forms.DataGridView dataGridViewCourses;
        private System.Windows.Forms.ComboBox comboBoxQualification;
        private System.Windows.Forms.Label labelQualification;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripDgv;
        private System.Windows.Forms.ToolStripMenuItem редактированиеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem удалениеToolStripMenuItem;
        private System.Windows.Forms.Label labelSort;
        private System.Windows.Forms.ComboBox comboBoxSort;
    }
}