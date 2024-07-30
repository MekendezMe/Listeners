using Listeners.DatabaseHelper;
using Listeners.Forms.Roles.SysAdmin.Employee;
using Listeners.MainMenu.SysAdmin;
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

namespace Listeners.Forms.Roles.SysAdmin.User
{
    public partial class UserView : Form
    {
        private string search = string.Empty;
        private string sort = string.Empty;
        private Timer timer;
        private DateTime lastActivityTime;
        private MySqlClient sqlClient;
        public UserView()
        {
            InitializeComponent();
            lastActivityTime = DateTime.Now;
            sqlClient = new MySqlClient();
            ShowUser();
            ResetTimer();
            LoadData();
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


        private void ShowUser()
        {
            labelUser.Text = GlobalData.Employee.Role + " " + GlobalData.Employee.Surname + " "
                + (GlobalData.Employee.Name.Length > 0 ? GlobalData.Employee.Name[0] + ". " : " ")
                + (GlobalData.Employee.Patronymic.Length > 0 ? GlobalData.Employee.Patronymic[0] + "." : "");
        }

        private void SelectDirectory_MouseMove(object sender, MouseEventArgs e)
        {
            lastActivityTime = DateTime.Now;
        }

        private void SelectDirectory_KeyPress(object sender, KeyPressEventArgs e)
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

        public void HidePersonalData()
        {

            foreach (DataGridViewColumn column in dataGridViewUsers.Columns)
            {
                if (column.Name == "Логин")
                {
                    column.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                    column.Width = 100;
                }
            }

            foreach (DataGridViewRow row in dataGridViewUsers.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    if (cell.OwningColumn.Name == "Логин")
                    {
                        cell.Value = cell.Value.ToString().Substring(0, 2) + "**" + cell.Value.ToString().Substring(cell.Value.ToString().Length - 1);
                    }
                }
            }

            dataGridViewUsers.Columns[0].Visible = false;
        }

        private void LoadData()
        {
            dataGridViewUsers.DataSource = sqlClient.GetDataTable("SELECT id AS 'Номер', surname AS 'Фамилия', name AS 'Имя'," +
                " patronymic AS 'Отчество'," +
                "(SELECT title from role where role.id=user.role) AS 'Роль', login as 'Логин' " +
                " from user " + search + sort);

            if (dataGridViewUsers.Columns.Count > 0 && dataGridViewUsers.Rows.Count > 0)
            {
                dataGridViewUsers.Columns[0].Visible = false;
                HidePersonalData();
            }

            if (dataGridViewUsers.Rows.Count == 0)
            {
                MessageBox.Show("Записей не найдено", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void buttonCreate_Click(object sender, EventArgs e)
        {
            timer.Stop();
            UserChangerView userChanger = new UserChangerView();
            userChanger.FormClosed += UserChanger_FormClosed;
            userChanger.ShowDialog();
        }

        private void UserChanger_FormClosed(object sender, FormClosedEventArgs e)
        {
            UpdateAfterChanging();
        }

        private void UpdateAfterChanging()
        {
            timer.Start();

            if (!GlobalData.UserChanged && !GlobalData.UserCreated)
            {
                return;
            }

            ResetConditions();

            if (GlobalData.UserChanged)
            {
                sort = " order by modifiedBy desc ";
            }

            if (GlobalData.UserCreated)
            {
                sort = " order by user.id desc ";
            }

            GlobalData.UserChanged = false;
            GlobalData.UserCreated = false;

            LoadData();
        }

        private void ResetConditions()
        {
            search = string.Empty;
            sort = string.Empty;
        }

        private void редактированиеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridViewUsers.SelectedRows.Count == 0) return;

            timer.Stop();
            UserChangerView userChanger =
                new UserChangerView(dataGridViewUsers.SelectedRows[0].Cells["Номер"].Value.ToString(), true);
            userChanger.FormClosed += UserChanger_FormClosed;
            userChanger.ShowDialog();
        }

        private void удалениеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridViewUsers.SelectedRows.Count == 0) return;

            DialogResult confirmationDeleting = MessageBox.Show("Вы действительно желаете удалить выбранную запись?",
                "Внимание", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);

            if (confirmationDeleting == DialogResult.Cancel || confirmationDeleting == DialogResult.No) return;

            DataGridViewRow selectedRow = dataGridViewUsers.SelectedRows[0];

            bool isExecute = sqlClient.ExecuteRequest("DELETE FROM user where id='"
                + selectedRow.Cells["Номер"].Value.ToString() + "'");

            if (!isExecute)
            {
                MessageBox.Show("Не удалось удалить пользователя", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show("Удаление пользователя успешно", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

            LoadData();
        }

        private void dataGridViewUsers_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var hitTestInfo = dataGridViewUsers.HitTest(e.X, e.Y);

                if (hitTestInfo.RowIndex >= 0)
                {
                    dataGridViewUsers.ClearSelection();
                    dataGridViewUsers.Rows[hitTestInfo.RowIndex].Selected = true;
                    Point point = dataGridViewUsers.PointToScreen(new Point(e.X, e.Y));
                    contextMenuStripDgv.Show(point);
                }
            }
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            timer.Stop();
            this.Hide();
            SysAdminMenuView sysAdminMenu = new SysAdminMenuView();
            sysAdminMenu.ShowDialog();
        }

        private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {
            sort = string.Empty;

            search = " order by CASE when surname='" + textBoxSearch.Text.Trim() + "' THEN 0 WHEN surname LIKE '" + textBoxSearch.Text.Trim() +
                "%' then 1 ELSE 2 END";

            LoadData();
        }

        private void textBoxSearch_KeyPress(object sender, KeyPressEventArgs e)
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

        private void textBoxSearch_Enter(object sender, EventArgs e)
        {
            SwitchToRussianKeyboardLayout();
        }
    }
}
