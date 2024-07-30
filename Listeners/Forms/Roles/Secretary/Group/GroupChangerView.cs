using Listeners.DatabaseHelper;
using Listeners.FormCloserHelper;
using Listeners.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Listeners.Forms.Roles.Secretary.Group
{
    public partial class GroupChangerView : Form
    {
        private bool isUpdated = false;
        private bool isCreated = false;
        private MySqlClient sqlClient;
        private Timer timer;
        private DateTime lastActivityTime;
        private bool needUpdate;
        private string primaryKey = string.Empty;
        public GroupChangerView(string primaryKey = "", bool needUpdate = false)
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
                IGroup group = sqlClient.FindOne<IGroup>("SELECT name, countPeople from listeners.group where id='" + primaryKey + "'");
                
                if (group == null)
                {
                    MessageBox.Show("Не удалось заполнить данные", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                textBoxCount.Text = group.CountPeople.ToString();
                textBoxName.Text = group.Name;
            } else
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

        private void textBoxCount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
                return;
            }
        }

        private void textBoxName_Enter(object sender, EventArgs e)
        {
            SwitchToRussianKeyboardLayout();
        }

        private void textBoxName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetterOrDigit(e.KeyChar) && e.KeyChar != '-' && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
                return;
            }

            if (e.KeyChar == '-' && textBoxName.Text.Length == 0)
            {
                e.Handled = true;
                return;
            }
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            DisplayChanged();
        }

        private void DisplayChanged()
        {
            timer.Stop();
            GlobalData.GroupChanged = isUpdated;
            GlobalData.GroupCreated = isCreated;
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
                if (GroupIsExist() && textBoxName.Text != sqlClient.GetValue("SELECT name from listeners.group where id='" + primaryKey + "'"))
                {
                    MessageBox.Show("Указанная группа уже существует", "Внимание",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                bool isExecute = sqlClient.ExecuteRequest("UPDATE listeners.group set name='" +
                    textBoxName.Text.Trim() + "', countPeople='" + textBoxCount.Text.Trim() + "', modifiedby='" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "' where id='" + primaryKey + "'");
                
                if (!isExecute)
                {
                    MessageBox.Show("Не удалось изменить группу", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                MessageBox.Show("Изменение группы успешно", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                isUpdated = true;
                DisplayChanged();
            } 
            else
            {
                if (GroupIsExist())
                {
                    MessageBox.Show("Указанная группа уже существует", "Внимание",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                
                }

                bool isExecute = sqlClient.ExecuteRequest("INSERT INTO listeners.group (name, countPeople, modifiedBy) VALUES('" +
                    textBoxName.Text.Trim() + "','" + textBoxCount.Text.Trim() + "', '" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "')");
                
                if (!isExecute)
                {
                    MessageBox.Show("Не удалось добавить группу", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                MessageBox.Show("Добавление новой группы успешно", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                isCreated = true;
            }

            ClearFields();
        }

        private void ClearFields()
        {
            textBoxName.Text = string.Empty;
            textBoxCount.Text = string.Empty;
        }

        private bool GroupIsExist()
        {
            string value = sqlClient.GetValue("SELECT id from listeners.group where name='" + textBoxName.Text.Trim() + "'");

            return value.Length != 0;
        }

        private bool ControlFillFields()
        {
            return textBoxCount.Text.Trim().Length != 0 && textBoxName.Text.Trim().Length != 0;
        }
    }
}
