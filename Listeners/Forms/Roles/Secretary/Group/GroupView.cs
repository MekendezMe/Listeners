using Listeners.Csv;
using Listeners.DatabaseHelper;
using Listeners.Forms.MainMenu.Secretary;
using Listeners.Forms.Roles.Secretary.Directories;
using Listeners.MainMenu.Secretary;
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

namespace Listeners.Forms.Roles.Secretary.Group
{
    public partial class GroupView : Form
    {
        private string sort = string.Empty;
        private string search = string.Empty;
        private int currentPage = Constants.START_CURRENT_PAGE;
        private int countRowsInPage = 0;
        private int countPages = 0;
        private int countRows = 0;
        private MySqlClient sqlClient;
        private Timer timer;
        private CsvHelper csvHelper;
        private DateTime lastActivityTime;
        bool fromRecord = false;
        public GroupView(bool fromRecord = false)
        {
            InitializeComponent();
            lastActivityTime = DateTime.Now;
            ShowUser();
            ResetTimer();
            this.fromRecord = fromRecord;
            sqlClient = new MySqlClient();
            csvHelper = new CsvHelper();
            sort = " order by group.name ASC ";
            LoadData();
            GetCountPages();
            GetCountRows();
            UpdateUserInterface();
            ControlParent();
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

        private void ControlParent()
        {
            if (fromRecord)
            {
                buttonTake.Visible = true;
                buttonBack.Text = "Вернуться к записи";
            }
        }
        private void UpdateUserInterface()
        {
            GetCountRows();
            GetCountPages();
            buttonPrevious.Enabled = true;
            buttonNext.Enabled = true;

            if (currentPage == Constants.START_CURRENT_PAGE)
            {
                buttonPrevious.Enabled = false;
            }

            if (currentPage == countPages || countPages == 0)
            {
                buttonNext.Enabled = false;
            }

            labelPage.Text = currentPage.ToString() + "/" + (countPages == 0 ? "1" : countPages.ToString());
            labelCountRows.Text = countRowsInPage.ToString() + "/" + countRows.ToString();
        }

        public void GetCountPages()
        {
            try
            {
                countPages = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(sqlClient.GetValue("SELECT COUNT(*) from listeners.group " + search + sort)) / 7));
            }
            catch
            {
                MessageBox.Show("Не удалось произвести работу с базой данных", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void GetCountRows()
        {
            try
            {
                countRows = Convert.ToInt32(sqlClient.GetValue("SELECT COUNT(*) from listeners.group " + search + sort));
            }
            catch
            {
                MessageBox.Show("Не удалось произвести работу с базой данных", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadData()
        {
            dataGridViewGroups.DataSource = sqlClient.GetDataTable("SELECT id AS 'Номер', name AS 'Группа'," +
                " countPeople AS 'Кол-во человек' from listeners.group " + search + sort +
                " LIMIT 7 OFFSET " + ((currentPage - 1) * Constants.COUNT_ROWS_IN_PAGE));

            if (dataGridViewGroups.Rows.Count > 0)
            {
                dataGridViewGroups.Columns["Номер"].Visible = false;
                countRowsInPage = dataGridViewGroups.Rows.Count;
            }
            else
            {
                MessageBox.Show("Записей не найдено", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void textBoxSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetterOrDigit(e.KeyChar) && e.KeyChar != '-' && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
                return;
            }

            if (e.KeyChar == '-' && textBoxSearch.Text.Length == 0)
            {
                e.Handled = true;
                return;
            }
        }

        private void textBoxSearch_Enter(object sender, EventArgs e)
        {
            SwitchToRussianKeyboardLayout();
        }

        private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {
            currentPage = Constants.START_CURRENT_PAGE;
            search = " ORDER BY CASE WHEN name='" + textBoxSearch.Text + "' THEN 0 when name LIKE '" + textBoxSearch.Text + "%' THEN 1 ELSE 2 END ";
            sort = ", name ASC ";

            LoadData();
            UpdateUserInterface();
        }

        private void buttonPrevious_Click(object sender, EventArgs e)
        {
            currentPage--;
            LoadData();
            UpdateUserInterface();
        }

        private void buttonNext_Click(object sender, EventArgs e)
        {
            currentPage++;
            LoadData();
            UpdateUserInterface();
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            timer.Stop();

            if (!fromRecord)
            {
                this.Hide();
                SelectDirectory selectDirectory = new SelectDirectory();
                selectDirectory.ShowDialog();
            }
            this.Close();
        }

        private void dataGridViewGroups_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var hitTestInfo = dataGridViewGroups.HitTest(e.X, e.Y);

                if (hitTestInfo.RowIndex >= 0)
                {
                    dataGridViewGroups.ClearSelection();
                    dataGridViewGroups.Rows[hitTestInfo.RowIndex].Selected = true;
                    Point point = dataGridViewGroups.PointToScreen(new Point(e.X, e.Y));
                    contextMenuStripDgv.Show(point);
                }
            }
        }

        private void редактированиеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridViewGroups.SelectedRows.Count == 0)
            {
                return;
            }

            DataGridViewRow selectedRow = dataGridViewGroups.SelectedRows[0];

            timer.Stop();
            GroupChangerView groupChangerView = new GroupChangerView(selectedRow.Cells["Номер"].Value.ToString(), true);
            groupChangerView.FormClosed += GroupChangerView_FormClosed;
            groupChangerView.ShowDialog();
        }

        private void ResetConditions()
        {
            sort = string.Empty;
            search = string.Empty;
            currentPage = 1;
            LoadData();
            UpdateUserInterface();
        }

        private void GroupChangerView_FormClosed(object sender, FormClosedEventArgs e)
        {
            UpdateAfterChanging();
        }

        private void UpdateAfterChanging()
        {
            timer.Start();

            if (!GlobalData.GroupChanged && !GlobalData.GroupCreated)
            {
                return;
            }

            ResetConditions();

            if (GlobalData.GroupChanged)
            {
                sort = " order by modifiedBy desc ";
            }

            if (GlobalData.GroupCreated)
            {
                sort = " order by listeners.group.id desc ";
            }

            GlobalData.GroupChanged = false;
            GlobalData.GroupCreated = false;

            LoadData();
            UpdateUserInterface();
        }

        private void buttonCreateGroup_Click(object sender, EventArgs e)
        {
            timer.Stop();
            GroupChangerView groupChangerView = new GroupChangerView();
            groupChangerView.FormClosed += GroupChangerView_FormClosed;
            groupChangerView.ShowDialog();
        }

        private bool CanDelete(string primaryKey)
        {
            return Convert.ToInt32(sqlClient.GetValue("SELECT COUNT(*) from record where record.group IN('" + primaryKey + "')")) > 0;
        }

        private void удалениеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridViewGroups.SelectedRows.Count == 0)
            {
                return;
            }

            DataGridViewRow selectedRow = dataGridViewGroups.SelectedRows[0];
            string primaryKey = selectedRow.Cells["Номер"].Value.ToString();

            if (CanDelete(primaryKey))
            {
                MessageBox.Show("Невозможно удалить группу, которая содержится в договорах", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult confirmationDeleting = MessageBox.Show("Вы действительно желаете удалить выбранную запись?",
                "Внимание", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);

            if (confirmationDeleting == DialogResult.Cancel || confirmationDeleting == DialogResult.No) return;



            bool isExecute = sqlClient.ExecuteRequest("DELETE FROM listeners.group where id='"
                + primaryKey + "'");

            if (!isExecute)
            {
                MessageBox.Show("Не удалось удалить группу", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show("Удаление группы успешно", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

            LoadData();
            UpdateUserInterface();
        }

        private void buttonTake_Click(object sender, EventArgs e)
        {
            GlobalData.IdGroup = Convert.ToInt32(dataGridViewGroups.SelectedRows[0].Cells["Номер"].Value.ToString());
            GlobalData.Group = dataGridViewGroups.SelectedRows[0].Cells["Группа"].Value.ToString();
            timer.Stop();
            this.Close();
            buttonTake.Enabled = false;
        }

        private void dataGridViewGroups_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            if (fromRecord)
            {
                buttonTake.Enabled = true;
            }
        }

        private void dataGridViewGroups_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewGroups.SelectedRows.Count < 1)
            {
                buttonTake.Enabled = false;
                return;
            }

            if (fromRecord)
            {
                buttonTake.Enabled = true;
            }
        }

        private void buttonExport_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialogCsv.ShowDialog() == DialogResult.OK)
            {
                string selectedDirectory = folderBrowserDialogCsv.SelectedPath;
                if (!csvHelper.ExportData(selectedDirectory, "group.csv"))
                {
                    MessageBox.Show("Не удалось экспортировать данные", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                MessageBox.Show("Данные успешно экспортированы в: " + Path.Combine(selectedDirectory, "group.csv"), "Внимание",
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

                if (!csvHelper.ImportGroupData(selectedFileName))
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
