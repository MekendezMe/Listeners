namespace Listeners.Forms.Roles.SysAdmin.Employee
{
    partial class EmployeeChangerView
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
            this.labelPatronymic = new System.Windows.Forms.Label();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.labelName = new System.Windows.Forms.Label();
            this.textBoxSurname = new System.Windows.Forms.TextBox();
            this.labelSurname = new System.Windows.Forms.Label();
            this.labelCode = new System.Windows.Forms.Label();
            this.buttonBack = new System.Windows.Forms.Button();
            this.buttonChange = new System.Windows.Forms.Button();
            this.labelUser = new System.Windows.Forms.Label();
            this.textBoxJob = new System.Windows.Forms.TextBox();
            this.labelJob = new System.Windows.Forms.Label();
            this.maskedTextBoxCode = new System.Windows.Forms.MaskedTextBox();
            this.textBoxPatronymic = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBoxImage = new System.Windows.Forms.PictureBox();
            this.buttonChangeImage = new System.Windows.Forms.Button();
            this.openFileDialogImage = new System.Windows.Forms.OpenFileDialog();
            this.buttonClear = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxImage)).BeginInit();
            this.SuspendLayout();
            // 
            // labelPatronymic
            // 
            this.labelPatronymic.AutoSize = true;
            this.labelPatronymic.Location = new System.Drawing.Point(12, 160);
            this.labelPatronymic.Name = "labelPatronymic";
            this.labelPatronymic.Size = new System.Drawing.Size(66, 20);
            this.labelPatronymic.TabIndex = 25;
            this.labelPatronymic.Text = "Отчество";
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(107, 114);
            this.textBoxName.MaxLength = 50;
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(200, 26);
            this.textBoxName.TabIndex = 3;
            this.textBoxName.Enter += new System.EventHandler(this.textBoxName_Enter);
            this.textBoxName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxPersonalData_KeyPress);
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(12, 117);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(39, 20);
            this.labelName.TabIndex = 24;
            this.labelName.Text = "Имя*";
            // 
            // textBoxSurname
            // 
            this.textBoxSurname.Location = new System.Drawing.Point(107, 74);
            this.textBoxSurname.MaxLength = 50;
            this.textBoxSurname.Name = "textBoxSurname";
            this.textBoxSurname.Size = new System.Drawing.Size(200, 26);
            this.textBoxSurname.TabIndex = 2;
            this.textBoxSurname.Enter += new System.EventHandler(this.textBoxName_Enter);
            this.textBoxSurname.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxPersonalData_KeyPress);
            // 
            // labelSurname
            // 
            this.labelSurname.AutoSize = true;
            this.labelSurname.Location = new System.Drawing.Point(12, 74);
            this.labelSurname.Name = "labelSurname";
            this.labelSurname.Size = new System.Drawing.Size(69, 20);
            this.labelSurname.TabIndex = 23;
            this.labelSurname.Text = "Фамилия*";
            // 
            // labelCode
            // 
            this.labelCode.AutoSize = true;
            this.labelCode.Location = new System.Drawing.Point(12, 42);
            this.labelCode.Name = "labelCode";
            this.labelCode.Size = new System.Drawing.Size(38, 20);
            this.labelCode.TabIndex = 22;
            this.labelCode.Text = "Код*";
            // 
            // buttonBack
            // 
            this.buttonBack.Location = new System.Drawing.Point(192, 431);
            this.buttonBack.Name = "buttonBack";
            this.buttonBack.Size = new System.Drawing.Size(115, 32);
            this.buttonBack.TabIndex = 7;
            this.buttonBack.Text = "К сотрудникам";
            this.buttonBack.UseVisualStyleBackColor = true;
            this.buttonBack.Click += new System.EventHandler(this.buttonBack_Click);
            // 
            // buttonChange
            // 
            this.buttonChange.Location = new System.Drawing.Point(16, 431);
            this.buttonChange.Name = "buttonChange";
            this.buttonChange.Size = new System.Drawing.Size(92, 32);
            this.buttonChange.TabIndex = 6;
            this.buttonChange.Text = "Добавить";
            this.buttonChange.UseVisualStyleBackColor = true;
            this.buttonChange.Click += new System.EventHandler(this.buttonChange_Click);
            // 
            // labelUser
            // 
            this.labelUser.AutoSize = true;
            this.labelUser.Location = new System.Drawing.Point(12, 13);
            this.labelUser.Name = "labelUser";
            this.labelUser.Size = new System.Drawing.Size(0, 20);
            this.labelUser.TabIndex = 26;
            // 
            // textBoxJob
            // 
            this.textBoxJob.Location = new System.Drawing.Point(107, 201);
            this.textBoxJob.MaxLength = 100;
            this.textBoxJob.Name = "textBoxJob";
            this.textBoxJob.Size = new System.Drawing.Size(200, 26);
            this.textBoxJob.TabIndex = 5;
            this.textBoxJob.Enter += new System.EventHandler(this.textBoxName_Enter);
            this.textBoxJob.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxJob_KeyPress);
            // 
            // labelJob
            // 
            this.labelJob.AutoSize = true;
            this.labelJob.Location = new System.Drawing.Point(12, 204);
            this.labelJob.Name = "labelJob";
            this.labelJob.Size = new System.Drawing.Size(82, 20);
            this.labelJob.TabIndex = 28;
            this.labelJob.Text = "Должность*";
            // 
            // maskedTextBoxCode
            // 
            this.maskedTextBoxCode.Location = new System.Drawing.Point(107, 39);
            this.maskedTextBoxCode.Mask = "000";
            this.maskedTextBoxCode.Name = "maskedTextBoxCode";
            this.maskedTextBoxCode.Size = new System.Drawing.Size(32, 26);
            this.maskedTextBoxCode.TabIndex = 1;
            // 
            // textBoxPatronymic
            // 
            this.textBoxPatronymic.Location = new System.Drawing.Point(107, 157);
            this.textBoxPatronymic.MaxLength = 50;
            this.textBoxPatronymic.Name = "textBoxPatronymic";
            this.textBoxPatronymic.Size = new System.Drawing.Size(200, 26);
            this.textBoxPatronymic.TabIndex = 4;
            this.textBoxPatronymic.Enter += new System.EventHandler(this.textBoxName_Enter);
            this.textBoxPatronymic.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxPersonalData_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 313);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 20);
            this.label1.TabIndex = 29;
            this.label1.Text = "Фото";
            // 
            // pictureBoxImage
            // 
            this.pictureBoxImage.Image = global::Listeners.Properties.Resources.plug;
            this.pictureBoxImage.Location = new System.Drawing.Point(107, 250);
            this.pictureBoxImage.Name = "pictureBoxImage";
            this.pictureBoxImage.Size = new System.Drawing.Size(151, 111);
            this.pictureBoxImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxImage.TabIndex = 30;
            this.pictureBoxImage.TabStop = false;
            // 
            // buttonChangeImage
            // 
            this.buttonChangeImage.Location = new System.Drawing.Point(107, 367);
            this.buttonChangeImage.Name = "buttonChangeImage";
            this.buttonChangeImage.Size = new System.Drawing.Size(82, 32);
            this.buttonChangeImage.TabIndex = 31;
            this.buttonChangeImage.Text = "Изменить";
            this.buttonChangeImage.UseVisualStyleBackColor = true;
            this.buttonChangeImage.Click += new System.EventHandler(this.buttonChangeImage_Click);
            // 
            // buttonClear
            // 
            this.buttonClear.Location = new System.Drawing.Point(195, 367);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(63, 32);
            this.buttonClear.TabIndex = 32;
            this.buttonClear.Text = "Сброс";
            this.buttonClear.UseVisualStyleBackColor = true;
            this.buttonClear.Click += new System.EventHandler(this.buttonClear_Click);
            // 
            // EmployeeChangerView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(354, 475);
            this.ControlBox = false;
            this.Controls.Add(this.buttonClear);
            this.Controls.Add(this.buttonChangeImage);
            this.Controls.Add(this.pictureBoxImage);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxPatronymic);
            this.Controls.Add(this.maskedTextBoxCode);
            this.Controls.Add(this.textBoxJob);
            this.Controls.Add(this.labelJob);
            this.Controls.Add(this.labelUser);
            this.Controls.Add(this.labelPatronymic);
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(this.labelName);
            this.Controls.Add(this.textBoxSurname);
            this.Controls.Add(this.labelSurname);
            this.Controls.Add(this.labelCode);
            this.Controls.Add(this.buttonBack);
            this.Controls.Add(this.buttonChange);
            this.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(617, 514);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(353, 514);
            this.Name = "EmployeeChangerView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Изменение сотрудников";
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.GroupView_KeyPress);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.GroupView_MouseMove);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label labelPatronymic;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.TextBox textBoxSurname;
        private System.Windows.Forms.Label labelSurname;
        private System.Windows.Forms.Label labelCode;
        private System.Windows.Forms.Button buttonBack;
        private System.Windows.Forms.Button buttonChange;
        private System.Windows.Forms.Label labelUser;
        private System.Windows.Forms.TextBox textBoxJob;
        private System.Windows.Forms.Label labelJob;
        private System.Windows.Forms.MaskedTextBox maskedTextBoxCode;
        private System.Windows.Forms.TextBox textBoxPatronymic;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBoxImage;
        private System.Windows.Forms.Button buttonChangeImage;
        private System.Windows.Forms.OpenFileDialog openFileDialogImage;
        private System.Windows.Forms.Button buttonClear;
    }
}