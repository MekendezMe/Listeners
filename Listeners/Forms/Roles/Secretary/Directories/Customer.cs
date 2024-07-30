﻿using Listeners.Csv;
using Listeners.DatabaseHelper;
using Microsoft.Win32;
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

namespace Listeners.Forms.Roles.Secretary.Directories
{
    public partial class Customer : Form
    {
        private string search = string.Empty;
        private string sort = string.Empty;
        private Timer timer;
        private DateTime lastActivityTime;
        private MySqlClient sqlClient;
        private CsvHelper csvHelper;
        public Customer()
        {
            InitializeComponent();
            lastActivityTime = DateTime.Now;
            sqlClient = new MySqlClient();
            csvHelper = new CsvHelper();
            sort = " order by name ASC ";
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

        private void LoadData()
        {
            dataGridViewEducations.DataSource = sqlClient.GetDataTable("SELECT id AS 'Номер', name AS 'Направление' from customer " + search + sort);

            if (dataGridViewEducations.Columns.Count > 0 && dataGridViewEducations.Rows.Count > 0)
            {
                dataGridViewEducations.Columns[0].Visible = false;
            }

            if (dataGridViewEducations.Rows.Count == 0)
            {
                MessageBox.Show("Записей не найдено", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void textBoxSearchTitle_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && e.KeyChar != '-' && e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Space &&
                e.KeyChar != '(' && e.KeyChar != ')')
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

            if (textBox.Text.Length == 0)
            {
                if (e.KeyChar == '-' || e.KeyChar == (char)Keys.Space || e.KeyChar == ')')
                {
                    e.Handled = true;
                    return;
                }
            }
        }

        private void textBoxSearchTitle_TextChanged(object sender, EventArgs e)
        {
            search = " order by CASE when name='" + textBoxSearchTitle.Text.Trim() + "' THEN 0 WHEN name LIKE '" + textBoxSearchTitle.Text.Trim() +
                "%' then 1 ELSE 2 END";

            sort = ", name ASC ";

            LoadData();
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            timer.Stop();
            this.Hide();
            SelectDirectory selectDirectory = new SelectDirectory();
            selectDirectory.ShowDialog();
        }

        private void buttonCreate_Click(object sender, EventArgs e)
        {
            if (textBoxEducation.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Заполните поле вида направления", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (EmploymentIsExist() != string.Empty)
            {
                MessageBox.Show("Данный вид направления уже существует", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            bool isExecute = sqlClient.ExecuteRequest("INSERT INTO customer (name)" +
                " VALUES ('" + textBoxEducation.Text.Trim() + "')");

            if (!isExecute)
            {
                MessageBox.Show("Не удалось добавить вид направления", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show("Успешно добавлен новый вид направления", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ClearFields();
            ResetCondition();
            sort = " order by customer.id desc ";
            LoadData();
        }

        private void ResetCondition()
        {
            textBoxSearchTitle.Text = string.Empty;
            search = string.Empty;
        }

        private void ClearFields()
        {
            textBoxEducation.Text = string.Empty;
        }

        private string EmploymentIsExist()
        {
            string value = sqlClient.GetValue("SELECT id from customer where name='" + textBoxEducation.Text + "'");

            return value;
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            if (textBoxEducation.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Заполните поле вида направления", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DataGridViewRow selectedRow = dataGridViewEducations.SelectedRows[0];

            string primaryKey = selectedRow.Cells["Номер"].Value.ToString();

            string employment = EmploymentIsExist();

            if (employment != string.Empty && employment != primaryKey)
            {
                MessageBox.Show("Данный вид направления уже существует", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            bool isExecute = sqlClient.ExecuteRequest("UPDATE customer set name=" +
                "'" + textBoxEducation.Text.Trim() + "' where id='" +
                primaryKey + "'");

            if (!isExecute)
            {
                MessageBox.Show("Не удалось изменить вид направления", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show("Успешно изменен вид направления", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ClearFields();
            LoadData();
            buttonUpdate.Enabled = false;
        }

        private void dataGridViewEmployments_SelectionChanged(object sender, EventArgs e)
        {
            buttonUpdate.Enabled = false;
            ClearFields();
        }

        private void dataGridViewEmployments_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var hitTestInfo = dataGridViewEducations.HitTest(e.X, e.Y);

                if (hitTestInfo.RowIndex >= 0)
                {
                    dataGridViewEducations.ClearSelection();
                    dataGridViewEducations.Rows[hitTestInfo.RowIndex].Selected = true;
                    Point point = dataGridViewEducations.PointToScreen(new Point(e.X, e.Y));
                    contextMenuStripDgv.Show(point);
                }
            }
        }

        private void textBoxSearchTitle_Enter(object sender, EventArgs e)
        {
            SwitchToRussianKeyboardLayout();
        }

        private void dataGridViewEmployments_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            FillAfterClick();
        }

        private void FillAfterClick()
        {
            if (dataGridViewEducations.SelectedRows.Count == 0) return;
            buttonUpdate.Enabled = true;
            textBoxEducation.Text = dataGridViewEducations.SelectedRows[0].Cells["Направление"].Value.ToString();
        }

        private void textBoxEmployment_TextChanged(object sender, EventArgs e)
        {
            if (textBoxEducation.Text == string.Empty)
            {
                buttonUpdate.Enabled = false;
            }
        }

        private bool CanDelete()
        {
            return sqlClient.GetValue("SELECT COUNT(*) from record") == "0";
        }

        private void удалениеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridViewEducations.SelectedRows.Count == 0) return;

            if (!CanDelete())
            {
                MessageBox.Show("Нельзя удалить данную запись", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult confirmationDelete = MessageBox.Show("Вы действительно желаете удалить выбранную запись?", "Внимание",
                MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);

            if (confirmationDelete == DialogResult.Cancel || confirmationDelete == DialogResult.No)
            {
                return;
            }

            DataGridViewRow selectedRow = dataGridViewEducations.SelectedRows[0];

            bool isExecute = sqlClient.ExecuteRequest("DELETE FROM customer where id='" + selectedRow.Cells["Номер"].Value.ToString() + "'");

            if (!isExecute)
            {
                MessageBox.Show("Не удалось удалить вид направления", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show("Успешно удален вид направления", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ClearFields();
            LoadData();
            buttonUpdate.Enabled = false;
        }

        private void buttonExport_Click(object sender, EventArgs e)
        {

            if (folderBrowserDialogCsv.ShowDialog() == DialogResult.OK)
            {
                string selectedDirectory = folderBrowserDialogCsv.SelectedPath;
                if (!csvHelper.ExportData(selectedDirectory, "customer.csv"))
                {
                    MessageBox.Show("Не удалось экспортировать данные", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                MessageBox.Show("Данные успешно экспортированы в: " + Path.Combine(selectedDirectory, "customer.csv"), "Внимание",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void buttonImport_Click(object sender, EventArgs e)
        {
            openFileDialogCsv.InitialDirectory = "c:\\";
            openFileDialogCsv.Filter = "CSV Files (*.csv)|*.csv";

            if (openFileDialogCsv.ShowDialog() == DialogResult.OK)
            {
                string selectedFileName = openFileDialogCsv.FileName;

                if (!csvHelper.ImportCustomerData(selectedFileName))
                {
                    MessageBox.Show("Не удалось импортировать данные", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                MessageBox.Show("Данные успешно импортированы", "Внимание",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();
            }
        }
    }
}
