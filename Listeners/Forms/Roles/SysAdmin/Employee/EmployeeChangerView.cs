using Listeners.DatabaseHelper;
using Listeners.FormCloserHelper;
using Listeners.Interfaces;
using Listeners.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Listeners.Forms.Roles.SysAdmin.Employee
{
    public partial class EmployeeChangerView : Form
    {
        private bool isUpdated = false;
        private bool isCreated = false;
        private MySqlClient sqlClient;
        private Timer timer;
        private DateTime lastActivityTime;
        private bool needUpdate;
        private string primaryKey = string.Empty;
        public EmployeeChangerView(string primaryKey = "", bool needUpdate = false)
        {
            InitializeComponent();
            lastActivityTime = DateTime.Now;
            ShowUser();
            ResetTimer();
            this.primaryKey = primaryKey;
            this.needUpdate = needUpdate;
            sqlClient = new MySqlClient();
            UpdateUserInterface();
        }

        private const int WM_INPUTLANGCHANGEREQUEST = 0x0050;

        [DllImport("user32.dll")]
        private static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll")]
        private static extern IntPtr LoadKeyboardLayout(string pwszKLID, uint Flags);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern IntPtr SendMessage(IntPtr hWnd, int Msg, IntPtr wParam, IntPtr lParam);

        private void SwitchToRussianKeyboardLayout()
        {
            IntPtr hWnd = GetForegroundWindow();

            LoadKeyboardLayout("00000419", 1);

            SendMessage(hWnd, WM_INPUTLANGCHANGEREQUEST, IntPtr.Zero, LoadKeyboardLayout("00000419", 1));
        }

        private void UpdateUserInterface()
        {
            if (needUpdate)
            {
                buttonChange.Text = "Изменить";
                IEmployee employee = sqlClient.FindOne<IEmployee>("SELECT code, surname, name, patronymic, job, image from employee where id='" + primaryKey + "'");

                if (employee == null)
                {
                    MessageBox.Show("Не удалось заполнить данные", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                maskedTextBoxCode.Text = employee.Code;
                textBoxSurname.Text = employee.Surname;
                textBoxName.Text = employee.Name;
                textBoxPatronymic.Text = employee.Patronymic;
                textBoxJob.Text = employee.Job;
                FillPictureBox(Path.Combine(Path.GetDirectoryName(System.Windows.Forms.Application.ExecutablePath), "images", employee.Image));
                openFileDialogImage.FileName = Path.Combine(Path.GetDirectoryName(System.Windows.Forms.Application.ExecutablePath), "images", employee.Image);
            }
            else
            {
                buttonChange.Text = "Добавить";
            }
        }

        private void ShowUser()
        {
            labelUser.Text = GlobalData.Employee.Role + " " + GlobalData.Employee.Surname + " "
                + (GlobalData.Employee.Name.Length > 0 ? GlobalData.Employee.Name[0] + ". " : " ")
                + (GlobalData.Employee.Patronymic.Length > 0 ? GlobalData.Employee.Patronymic[0] + "." : "");
        }

        private void GroupView_MouseMove(object sender, MouseEventArgs e)
        {
            lastActivityTime = DateTime.Now;
        }

        private void GroupView_KeyPress(object sender, KeyPressEventArgs e)
        {
            lastActivityTime = DateTime.Now;
        }

        private void ResetTimer()
        {
            timer = new Timer();
            timer.Interval = 1000;
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            ActivityControl(lastActivityTime);
        }

        public void ActivityControl(DateTime lastActivityTime)
        {
            TimeSpan inactiveDuration = DateTime.Now - lastActivityTime;

            if (inactiveDuration.TotalSeconds > Constants.MAX_INACTIVE_TIME_SECONDS)
            {
                FormCloser.ClosedForms();
                StartLoginForm();
            }
        }

        public void StartLoginForm()
        {
            timer.Stop();
            this.Hide();
            AuthorizationView authorizationView = new AuthorizationView();
            authorizationView.ShowDialog();
        }

        private void textBoxName_Enter(object sender, EventArgs e)
        {
            SwitchToRussianKeyboardLayout();
        }

        private void textBoxPersonalData_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && e.KeyChar != '-' && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
                return;
            }

            if ((e.KeyChar >= 'a' && e.KeyChar <= 'z') || (e.KeyChar >= 'A' && e.KeyChar <= 'Z'))
            {
                e.Handled = true;
                SwitchToRussianKeyboardLayout();
                return;
            }

            TextBox textBox = sender as TextBox;

            if (e.KeyChar == '-' && textBox.Text.Length == 0)
            {
                e.Handled = true;
                return;
            }

            if (char.IsLower(e.KeyChar))
            {
                if (textBox.SelectionStart == 0 || textBox.Text.Length > 0 && textBox.Text[textBox.SelectionStart - 1] == '-')
                {
                    e.KeyChar = char.ToUpper(e.KeyChar);
                }
            }
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            DisplayChanged();
        }

        private void DisplayChanged()
        {
            timer.Stop();
            GlobalData.EmployeeChanged = isUpdated;
            GlobalData.EmployeeCreated = isCreated;
            this.Close();
        }

        private void ControlExistDirectory()
        {
            if (!Directory.Exists(Path.Combine(Path.GetDirectoryName(System.Windows.Forms.Application.ExecutablePath), "images")))
            {
                Directory.CreateDirectory(Path.Combine(Path.GetDirectoryName(System.Windows.Forms.Application.ExecutablePath), "images"));
            }
        }

        private void buttonChange_Click(object sender, EventArgs e)
        {
            if (!ControlFillFields())
            {
                MessageBox.Show("Должны быть заполнены все обязательные поля", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            ControlExistDirectory();

            bool needUpdateImage = openFileDialogImage.FileName != string.Empty;

            string imagePath = openFileDialogImage.FileName == string.Empty ? "plug.jpg" : Path.GetFileName(openFileDialogImage.FileName);

            if (needUpdateImage && !CopyFile(openFileDialogImage.FileName, Path.Combine(
                Path.GetDirectoryName(System.Windows.Forms.Application.ExecutablePath), "images",
            Path.GetFileName(openFileDialogImage.FileName))))
            {
                MessageBox.Show("Не удалось скопировать файл. Назначена заглушка", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                imagePath = "plug.jpg";
            }

            if (needUpdate)
            {
                if (EmployeeIsExist() && maskedTextBoxCode.Text != sqlClient.GetValue("SELECT code from employee where id='" + primaryKey + "'"))
                {
                    MessageBox.Show("Введенный вами код занят", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                bool isExecute = sqlClient.ExecuteRequest("UPDATE employee set name='" +
                    textBoxName.Text.Trim() + "', code='" + maskedTextBoxCode.Text.Trim() + "', surname='" + textBoxSurname.Text.Trim() + "', " +
                    "patronymic='" + textBoxPatronymic.Text + "', job='" + textBoxJob.Text + "', image='" + imagePath + "', " +
                    " modifiedby='" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "' where id='" + primaryKey + "'");

                if (!isExecute)
                {
                    MessageBox.Show("Не удалось изменить сотрудника", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                MessageBox.Show("Изменение сотрудника успешно", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                isUpdated = true;
                DisplayChanged();
            }
            else
            {
                if (EmployeeIsExist())
                {
                    MessageBox.Show("Сотрудник с указанным кодом уже существует", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                bool isExecute = sqlClient.ExecuteRequest("INSERT INTO employee (code, surname, name, patronymic, job, image, modifiedBy) VALUES('" +
                    maskedTextBoxCode.Text.Trim() + "','" + textBoxSurname.Text.Trim() + "', '" + textBoxName.Text.Trim() + "', '"
                    + textBoxPatronymic.Text + "', '" + textBoxJob.Text + "','" + imagePath + "','"
                    + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "')");

                if (!isExecute)
                {
                    MessageBox.Show("Не удалось добавить сотрудника", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                MessageBox.Show("Добавление нового сотрудника успешно", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                isCreated = true;
            }

            ClearFields();
        }

        private bool CopyFile(string source, string dest)
        {
            if (File.Exists(dest)) return true;

            try
            {
                File.Copy(source, dest, false);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private void ClearFields()
        {
            textBoxName.Text = string.Empty;
            maskedTextBoxCode.Text = string.Empty;
            textBoxJob.Text = string.Empty;
            textBoxSurname.Text = string.Empty;
            textBoxPatronymic.Text = string.Empty;
            ClearPictureBox();
        }

        private bool EmployeeIsExist()
        {
            string value = sqlClient.GetValue("SELECT id from employee where code='" + maskedTextBoxCode.Text.Trim() + "'");

            return value.Length != 0;
        }

        private bool ControlFillFields()
        {
            return textBoxName.Text.Trim().Length != 0 && maskedTextBoxCode.Text.Trim().Length != 0 &&
                textBoxJob.Text.Trim().Length != 0 && textBoxSurname.Text.Trim().Length != 0;
        }

        private void textBoxJob_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && e.KeyChar != '-' && e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Space)
            {
                e.Handled = true;
                return;
            }

            if ((e.KeyChar >= 'a' && e.KeyChar <= 'z') || (e.KeyChar >= 'A' && e.KeyChar <= 'Z'))
            {
                e.Handled = true;
                SwitchToRussianKeyboardLayout();
                return;
            }

            if (textBoxName.Text.Length == 0)
            {
                if (e.KeyChar == '-' || e.KeyChar == (char)Keys.Space)
                {
                    e.Handled = true;
                    return;
                }
            }

            TextBox textBox = sender as TextBox;

            if (char.IsLower(e.KeyChar))
            {
                if (textBox.SelectionStart == 0)
                {
                    e.KeyChar = char.ToUpper(e.KeyChar);
                }
            }
        }

        private void buttonChangeImage_Click(object sender, EventArgs e)
        {
            openFileDialogImage.Filter = "Image Files (*.png;*.jpeg;*.jpg)|*.png;*.jpeg;*.jpg|All files (*.*)|*.*";
            openFileDialogImage.InitialDirectory = Path.GetDirectoryName(System.Windows.Forms.Application.ExecutablePath);
            if (openFileDialogImage.ShowDialog() == DialogResult.OK)
            {
                if (GetFileSize(openFileDialogImage.FileName) > 3)
                {
                    MessageBox.Show("Выберите файл до 3 мегабайт", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ClearPictureBox();
                    return;
                }
                FillPictureBox(openFileDialogImage.FileName);
            }
        }

        private double GetFileSize(string picturePath)
        {
            if (!File.Exists(picturePath)) return 0.0;

            long fileSize = 0;

            try
            {
                fileSize = new FileInfo(picturePath).Length;
            }
            catch (Exception)
            {
                MessageBox.Show("Не удалось узнать размер выбранного файла", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0.0;
            }
            
            double fileSizeInMB = (double)fileSize / (1024 * 1024);

            return fileSizeInMB;
        }


        private void FillPictureBox(string imagePath)
        {
            try
            {
                pictureBoxImage.Image = Image.FromFile(imagePath);
            }
            catch (Exception)
            {
                MessageBox.Show("Не удалось назначить выбранное фото", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            ClearPictureBox();
        }

        private void ClearPictureBox()
        {
            openFileDialogImage.FileName = string.Empty;
            FillPictureBox(Path.Combine(Path.GetDirectoryName(System.Windows.Forms.Application.ExecutablePath), "images", "plug.jpg"));
        }
    }
}
