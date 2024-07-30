using Listeners.Csv;
using Listeners.DatabaseHelper;
using Listeners.Forms.MainMenu.SysAdmin;
using Listeners.Forms.Roles.Secretary.Directories;
using Listeners.Forms.Roles.SysAdmin.Employee;
using Listeners.Forms.Roles.SysAdmin.User;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Listeners.MainMenu.SysAdmin
{
    public partial class SysAdminMenuView : Form
    {
        private Timer timer;
        private DateTime lastActivityTime;
        private SysAdminMenuController sysAdminMenuController;
        private MySqlClient sqlClient;
        public SysAdminMenuView()
        {
            InitializeComponent();
            sysAdminMenuController = new SysAdminMenuController(this);
            sqlClient = new MySqlClient();
            lastActivityTime = DateTime.Now;
            ResetTimer();
            ShowUser();
        }

        private void ShowUser()
        {
            labelUser.Text = GlobalData.Employee.Role + " " + GlobalData.Employee.Surname + " "
                + (GlobalData.Employee.Name.Length > 0 ? GlobalData.Employee.Name[0] + ". " : " ")
                + (GlobalData.Employee.Patronymic.Length > 0 ? GlobalData.Employee.Patronymic[0] + "." : "");
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
            sysAdminMenuController.ActivityControl(lastActivityTime);
        }

        public void StartLoginForm()
        {
            timer.Stop();
            this.Hide();
            AuthorizationView authorizationView = new AuthorizationView();
            authorizationView.ShowDialog();
        }

        private void SysAdminMenuView_MouseMove(object sender, MouseEventArgs e)
        {
            lastActivityTime = DateTime.Now;
        }

        private void SysAdminMenuView_KeyPress(object sender, KeyPressEventArgs e)
        {
            lastActivityTime = DateTime.Now;
        }

        private void buttonDirectory_Click(object sender, EventArgs e)
        {
            timer.Stop();
            this.Hide();
            SelectDirectory selectDirectory = new SelectDirectory();
            selectDirectory.ShowDialog();
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            StartLoginForm();
        }

        private void buttonEmployees_Click(object sender, EventArgs e)
        {
            timer.Stop();
            this.Hide();
            EmployeeView employeeView = new EmployeeView();
            employeeView.ShowDialog();
        }

        private void buttonUsers_Click(object sender, EventArgs e)
        {
            timer.Stop();
            this.Hide();
            UserView userView = new UserView();
            userView.ShowDialog();
        }

        private void buttonExportDatabase_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialogDatabase.ShowDialog() == DialogResult.OK)
            {
                string selectedDirectory = folderBrowserDialogDatabase.SelectedPath;
                string fileName = "script-" + DateTime.Now.ToShortDateString() + "-" + DateTime.Now.ToShortTimeString().Replace(":", "-") + ".sql";
                if (!sqlClient.ExportDatabase(selectedDirectory, fileName))
                {
                    MessageBox.Show("Не удалось экспортировать скрипт базы данных", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                MessageBox.Show("Скрипт базы данных успешно экспортирован в: " + Path.Combine(selectedDirectory, fileName), "Внимание",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void buttonImportDatabase_Click(object sender, EventArgs e)
        {
            openFileDialogDatabase.InitialDirectory = "c:\\";
            openFileDialogDatabase.Filter = "SQL Files (*.sql)|*.sql";

            if (openFileDialogDatabase.ShowDialog() == DialogResult.OK)
            {
                string selectedFileName = openFileDialogDatabase.FileName;

                if (!sqlClient.ImportDatabase(selectedFileName))
                {
                    MessageBox.Show("Не удалось импортировать скрипт базы данных", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                MessageBox.Show("Скрипт базы данных успешно импортирован", "Внимание",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
