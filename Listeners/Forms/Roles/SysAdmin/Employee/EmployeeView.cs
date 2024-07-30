using Listeners.DatabaseHelper;
using Listeners.Forms.Roles.Secretary.Course;
using Listeners.MainMenu.SysAdmin;
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
    public partial class EmployeeView : Form
    {
        private bool afterChanged = false;
        private string search = string.Empty;
        private string sort = string.Empty;
        private Timer timer;
        private DateTime lastActivityTime;
        private MySqlClient sqlClient;
        public EmployeeView()
        {
            InitializeComponent();
            lastActivityTime = DateTime.Now;
            sqlClient = new MySqlClient();
            ShowUser();
            ResetTimer();
            LoadData();
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

        private void LoadData()
        {
            try
            {
                dataGridViewUsers.Rows.Clear();
                DataTable employees = sqlClient.GetDataTable("SELECT id AS 'Номер', code AS 'Код', surname AS 'Фамилия', name AS 'Имя'," +
               "patronymic AS 'Отчество', job AS 'Должность', image AS 'Картинка' from employee " + search + sort);

                for (int i = 0; i < employees.Rows.Count; i++)
                {
                    string pathInDatabase = employees.Rows[i]["Картинка"].ToString();
                    string imageFolder = Path.Combine(Path.GetDirectoryName(System.Windows.Forms.Application.ExecutablePath), "images");
                    string probableImage = Path.Combine(imageFolder, pathInDatabase);
                    string imagePath = Path.Combine(imageFolder, "plug.jpg");

                    if (File.Exists(probableImage))
                    {
                        imagePath = probableImage;
                    }

                    Image currentImage = Image.FromFile(imagePath);

                    dataGridViewUsers.Rows.Add(employees.Rows[i][0].ToString(),
                                        employees.Rows[i][1].ToString(), employees.Rows[i][2].ToString(), employees.Rows[i][3].ToString(),
                                        employees.Rows[i][4].ToString(), employees.Rows[i][5].ToString(), employees.Rows[i][6].ToString(), currentImage);
                }

                if (dataGridViewUsers.Columns.Count > 0 && dataGridViewUsers.Rows.Count > 0)
                {
                    dataGridViewUsers.Columns[0].Visible = false;
                    dataGridViewUsers.Columns["Картинка"].Visible = false;
                }

                if (dataGridViewUsers.Rows.Count == 0)
                {
                    MessageBox.Show("Записей не найдено", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Не удалось отобразить данные", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void maskedTextBoxSearch_TextChanged(object sender, EventArgs e)
        {
            if (afterChanged)
            {
                sort = string.Empty;
                afterChanged = false;
            }

            search = " order by CASE when code='" + maskedTextBoxSearch.Text.Trim() + "' THEN 0 WHEN code LIKE '" + maskedTextBoxSearch.Text.Trim() +
                "%' then 1 ELSE 2 END";

            if (sort != string.Empty)
            {
                FillSort();
            }

            LoadData();
        }

        private void FillSort()
        {
            if (comboBoxSort.SelectedIndex == -1 || comboBoxSort.SelectedIndex == 0)
            {
                sort = string.Empty;
            }

            string condition = comboBoxSort.SelectedIndex == 1 ? " asc " : " desc ";


            if (search != string.Empty)
            {
                sort = ", surname " + condition;
            }
            else
            {
                sort = " order by surname " + condition;
            }

            LoadData();
        }

        private void comboBoxSort_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillSort();
        }

        private void buttonCreate_Click(object sender, EventArgs e)
        {
            timer.Stop();
            EmployeeChangerView employeeChanger = new EmployeeChangerView();
            employeeChanger.FormClosed += EmployeeChanger_FormClosed;
            employeeChanger.ShowDialog();
        }

        private void EmployeeChanger_FormClosed(object sender, FormClosedEventArgs e)
        {
            UpdateAfterChanging();
        }

        private void UpdateAfterChanging()
        {
            timer.Start();

            if (!GlobalData.EmployeeChanged && !GlobalData.EmployeeCreated)
            {
                return;
            }

            ResetConditions();

            if (GlobalData.EmployeeChanged)
            {
                sort = " order by modifiedBy desc ";
            }

            if (GlobalData.EmployeeCreated)
            {
                sort = " order by employee.id desc ";
            }

            GlobalData.EmployeeChanged = false;
            GlobalData.EmployeeCreated = false;

            afterChanged = true;

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
            EmployeeChangerView employeeChanger =
                new EmployeeChangerView(dataGridViewUsers.SelectedRows[0].Cells["Номер"].Value.ToString(), true);
            employeeChanger.FormClosed += EmployeeChanger_FormClosed;
            employeeChanger.ShowDialog();
        }

        private void удалениеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridViewUsers.SelectedRows.Count == 0) return;

            DialogResult confirmationDeleting = MessageBox.Show("Вы действительно желаете удалить выбранную запись?",
                "Внимание", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);

            if (confirmationDeleting == DialogResult.Cancel || confirmationDeleting == DialogResult.No) return;

            DataGridViewRow selectedRow = dataGridViewUsers.SelectedRows[0];

            bool isExecute = sqlClient.ExecuteRequest("DELETE FROM employee where id='"
                + selectedRow.Cells["Номер"].Value.ToString() + "'");

            if (!isExecute)
            {
                MessageBox.Show("Не удалось удалить сотрудника", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show("Удаление сотрудника успешно", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

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
    }
}
