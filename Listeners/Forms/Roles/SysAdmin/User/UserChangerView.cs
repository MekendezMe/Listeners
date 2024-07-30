using Listeners.DatabaseHelper;
using Listeners.FormCloserHelper;
using Listeners.Hash;
using Listeners.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Listeners.Forms.Roles.SysAdmin.User
{
    public partial class UserChangerView : Form
    {
        private byte[] defaultPassword;
        private bool isUpdated = false;
        private bool isCreated = false;
        private MySqlClient sqlClient;
        private Timer timer;
        private DateTime lastActivityTime;
        private bool needUpdate;
        private string primaryKey = string.Empty;
        public UserChangerView(string primaryKey = "", bool needUpdate = false)
        {
            InitializeComponent();
            lastActivityTime = DateTime.Now;
            ShowUser();
            ResetTimer();
            this.primaryKey = primaryKey;
            this.needUpdate = needUpdate;
            sqlClient = new MySqlClient();
            FillComboBox();
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
        
        private void FillComboBox()
        {
            comboBoxRole.Items.AddRange(sqlClient.FillComboBox("SELECT title from role"));
        }

        private void UpdateUserInterface()
        {
            if (needUpdate)
            {
                buttonChange.Text = "Изменить";
                IUser user = sqlClient.FindOne<IUser>("SELECT login, password, surname, name, " +
                    "(SELECT title from role where role.id=user.role) AS 'RoleName', patronymic from user where id='" + primaryKey + "'");

                if (user == null)
                {
                    MessageBox.Show("Не удалось заполнить данные", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                textBoxLogin.Text = user.Login;
                defaultPassword = HashHelper.HashExistPassword(user.Password);
                textBoxSurname.Text = user.Surname;
                textBoxName.Text = user.Name;
                textBoxPatronymic.Text = user.Patronymic;
                comboBoxRole.SelectedIndex = comboBoxRole.Items.IndexOf(user.RoleName);
                checkBoxChange.Enabled = true;
                checkBoxChange.Visible = true;
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
            GlobalData.UserChanged = isUpdated;
            GlobalData.UserCreated = isCreated;
            this.Close();
        }

        private void buttonChange_Click(object sender, EventArgs e)
        {
            if (!ControlFillFields())
            {
                MessageBox.Show("Должны быть заполнены все обязательные поля", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (needUpdate)
            {
                if (UserIsExist() && textBoxLogin.Text != sqlClient.GetValue("SELECT login from user where id='" + primaryKey + "'"))
                {
                    MessageBox.Show("Введенный вами логин занят", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                byte[] passwordBytes = defaultPassword;
                string hashPassword = string.Empty;

                if (!checkBoxChange.Checked)
                {
                    passwordBytes = HashHelper.HashInputPassword(textBoxPassword.Text.Trim());
                }

                hashPassword = HashHelper.ByteArrayToHexString(passwordBytes);

                bool isExecute = sqlClient.ExecuteRequest("UPDATE user set login='" + textBoxLogin.Text.Trim() + "'," +
                    "password='" + hashPassword + "', name='" +
                    textBoxName.Text.Trim() + "', role=(SELECT id from role where title='" + comboBoxRole.Text + "')," +
                    " surname='" + textBoxSurname.Text.Trim() + "', " +
                    "patronymic='" + textBoxPatronymic.Text + "'," +
                    " modifiedby='" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "' where id='" + primaryKey + "'");

                if (!isExecute)
                {
                    MessageBox.Show("Не удалось изменить пользователя", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                MessageBox.Show("Изменение пользователя успешно", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                isUpdated = true;
                DisplayChanged();
            }
            else
            {
                if (UserIsExist())
                {
                    MessageBox.Show("Пользователь с указанным логином уже существует", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string hashPassword = HashHelper.ByteArrayToHexString(HashHelper.HashInputPassword(textBoxPassword.Text.Trim()));

                bool isExecute = sqlClient.ExecuteRequest("INSERT INTO user (login, password, role, surname, name, patronymic, modifiedBy) VALUES('" +
                    textBoxLogin.Text.Trim() + "','" + hashPassword + "'," +
                    "(SELECT id from role where title='" + comboBoxRole.Text + "'),'" + textBoxSurname.Text.Trim() + "', '"
                    + textBoxName.Text + "', '" + textBoxPatronymic.Text + "', '"
                    + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "')");

                if (!isExecute)
                {
                    MessageBox.Show("Не удалось добавить пользователя", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                MessageBox.Show("Добавление нового пользователя успешно", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                isCreated = true;
            }

            ClearFields();
        }

        private void ClearFields()
        {
            textBoxName.Text = string.Empty;
            textBoxLogin.Text = string.Empty;
            textBoxPassword.Text = string.Empty;
            textBoxSurname.Text = string.Empty;
            textBoxPatronymic.Text = string.Empty;
            comboBoxRole.SelectedIndex = -1;
        }

        private bool UserIsExist()
        {
            string value = sqlClient.GetValue("SELECT id from user where login='" + textBoxLogin.Text.Trim() + "'");

            return value.Length != 0;
        }

        private bool ControlFillFields()
        {
            return textBoxName.Text.Trim().Length != 0 && textBoxLogin.Text.Trim().Length != 0 &&
                textBoxPassword.Text.Trim().Length != 0 && textBoxSurname.Text.Trim().Length != 0 && comboBoxRole.Text.Trim().Length != 0;
        }

        private void buttonRandom_Click(object sender, EventArgs e)
        {
            textBoxPassword.Text = string.Empty;
            string symbols = "qwertyuiuoopzasfdsghfhjhglb,vm,cxmbnqwmrqw1234567890.,";
            Random random = new Random();

            for (int i = 0; i < 8; i++)
            {
                textBoxPassword.Text += symbols[random.Next(0, symbols.Length - 1)];
            }
        }

        private void buttonShowPassword_Click(object sender, EventArgs e)
        {
            textBoxPassword.UseSystemPasswordChar = !textBoxPassword.UseSystemPasswordChar;
        }
    }
}
