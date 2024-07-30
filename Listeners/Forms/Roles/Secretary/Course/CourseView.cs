using Listeners.DatabaseHelper;
using Listeners.Forms.MainMenu.Secretary;
using Listeners.Forms.Roles.Secretary.Directories;
using Listeners.MainMenu.Secretary;
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

namespace Listeners.Forms.Roles.Secretary.Course
{
    public partial class CourseView : Form
    {
        private bool haveFilter = false;
        private string sort = string.Empty;
        private string filter = string.Empty;
        private string search = string.Empty;
        private int currentPage = Constants.START_CURRENT_PAGE;
        private int countRowsInPage = 0;
        private int countPages = 0;
        private int countRows = 0;
        private MySqlClient sqlClient;
        private Timer timer;
        private DateTime lastActivityTime;
        bool fromRecord = false;
        public CourseView(bool fromRecord = false)
        {
            InitializeComponent();
            lastActivityTime = DateTime.Now;
            ShowUser();
            ResetTimer();
            this.fromRecord = fromRecord;
            sort = " order by name ASC ";
            sqlClient = new MySqlClient();
            FillComboBox();
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
                buttonBack.Text = "Вернуться к записи";
                buttonTake.Visible = true;
            }
        }

        private void FillComboBox()
        {
            comboBoxQualification.Items.Add(string.Empty);
            string[] qualifications = sqlClient.FillComboBox("SELECT name from qualification;");

            for (int i = 0; i < qualifications.Length; i++)
            {
                comboBoxQualification.Items.Add(qualifications[i]);
            }
        }
        private void UpdateUserInterface()
        {
            buttonPrevious.Enabled = true;
            buttonNext.Enabled = true;
            GetCountRows();
            GetCountPages();

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
                countPages = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(sqlClient.GetValue("SELECT COUNT(*) from course " + filter + search + sort)) / 7));
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
                countRows = Convert.ToInt32(sqlClient.GetValue("SELECT COUNT(*) from course " + filter + search + sort));
            }
            catch
            {
                MessageBox.Show("Не удалось произвести работу с базой данных", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadData()
        {
            dataGridViewCourses.DataSource = sqlClient.GetDataTable("SELECT id AS 'Номер', name AS 'Курс'," +
                " duration AS 'Длительность', price AS 'Цена'," +
                " (SELECT name from qualification where qualification.id=course.qualification) AS 'Квалификация' " +
                " from course " + filter + search + sort +
                " LIMIT 7 OFFSET " + ((currentPage - 1) * Constants.COUNT_ROWS_IN_PAGE));

            if (dataGridViewCourses.Rows.Count > 0)
            {
                dataGridViewCourses.Columns["Номер"].Visible = false;
                countRowsInPage = dataGridViewCourses.Rows.Count;
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
            if (!char.IsLetterOrDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back && e.KeyChar != ':'
                && e.KeyChar != '-' && e.KeyChar != (char)Keys.Space)
            {
                e.Handled = true;
                return;
            }

            if (textBoxSearch.Text.Length == 0)
            {
                if (e.KeyChar == ':' || e.KeyChar == '-' || e.KeyChar == (char)Keys.Space)
                {
                    e.Handled = true;
                    return;
                }
            }
        }

        private void textBoxSearch_Enter(object sender, EventArgs e)
        {
            SwitchToRussianKeyboardLayout();
        }

        private void comboBoxQualification_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool previousFilter = haveFilter;
            haveFilter = !string.IsNullOrEmpty(comboBoxQualification.Text);

            if (!haveFilter && !previousFilter)
            {
                return;
            }

            if (!haveFilter)
            {
                filter = string.Empty;
            }
            else
            {
                filter = " WHERE qualification = (SELECT id FROM qualification WHERE name = '" + comboBoxQualification.Text + "') ";
            }

            currentPage = 1;
            LoadData();
            UpdateUserInterface();

            if (!SearchHaveResult())
            {
                ClearSearch();
            }
        }

        private void ClearSearch()
        {
            textBoxSearch.Text = string.Empty;
        }

        private bool SearchHaveResult()
        {
            if (textBoxSearch.Text == string.Empty)
            {
                return true;
            }

            string customFilterForCheck = string.Empty;

            if (filter != string.Empty)
            {
                int index = filter.IndexOf("WHERE");

                if (index >= 0)
                {
                    customFilterForCheck = " AND " + filter.Substring(0, index) + filter.Substring(index + "WHERE".Length);
                }
            }

            string rowsAfterAllConditions = sqlClient.GetValue(@"
                SELECT COUNT(*) 
                FROM course WHERE name like '" + textBoxSearch.Text + "%' " + customFilterForCheck);

            int countRowsAfterConditions = 0;

            if (!int.TryParse(rowsAfterAllConditions, out countRowsAfterConditions))
            {
                return false;
            }

            if (countRowsAfterConditions <= 0)
            {
                return false;
            }

            return true;
        }

        private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {
            sort = string.Empty;

            search = " ORDER BY CASE WHEN name='" + textBoxSearch.Text + "' THEN 0 when name LIKE '" + textBoxSearch.Text + "%' THEN 1 ELSE 2 END ";

            FillSort();

            currentPage = Constants.START_CURRENT_PAGE;

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

        private void buttonTake_Click(object sender, EventArgs e)
        {
            if (dataGridViewCourses.SelectedRows.Count < 1) return;

            GlobalData.IdCourse = Convert.ToInt32(dataGridViewCourses.SelectedRows[0].Cells["Номер"].Value.ToString());
            GlobalData.Course = dataGridViewCourses.SelectedRows[0].Cells["Курс"].Value.ToString();
            buttonTake.Enabled = false;
            timer.Stop();
            this.Close();
        }

        private void dataGridViewCourses_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewCourses.SelectedRows.Count < 1)
            {
                buttonTake.Enabled = false;
                return;
            }

            if (fromRecord)
            {
                buttonTake.Enabled = true;
            }
        }

        private void buttonCreateCourse_Click(object sender, EventArgs e)
        {
            timer.Stop();
            CourseChangerView courseChanger = new CourseChangerView();
            courseChanger.FormClosed += CourseChanger_FormClosed;
            courseChanger.ShowDialog();
        }

        private void CourseChanger_FormClosed(object sender, FormClosedEventArgs e)
        {
            UpdateAfterChanging();
        }

        private void UpdateAfterChanging()
        {
            timer.Start();

            if (!GlobalData.CourseChanged && !GlobalData.CourseCreated)
            {
                return;
            }

            ResetConditions();

            if (GlobalData.CourseChanged)
            {
                sort = " order by modifiedBy desc ";
            }

            if (GlobalData.CourseCreated)
            {
                sort = " order by course.id desc ";
            }

            GlobalData.CourseCreated = false;
            GlobalData.CourseChanged = false;

            LoadData();
            UpdateUserInterface();
        }

        private void ResetConditions()
        {
            search = string.Empty;
            filter = string.Empty;
            currentPage = 1;
            LoadData();
            UpdateUserInterface();
        }

        private void редактированиеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridViewCourses.SelectedRows.Count == 0) return;

            timer.Stop();
            CourseChangerView courseChanger =
                new CourseChangerView(dataGridViewCourses.SelectedRows[0].Cells["Номер"].Value.ToString(), true);
            courseChanger.FormClosed += CourseChanger_FormClosed;
            courseChanger.ShowDialog();
        }

        private bool CanDelete(string primaryKey)
        {
            return Convert.ToInt32(sqlClient.GetValue("SELECT COUNT(*) from record where record.course IN('" + primaryKey + "')")) > 0;
        }

        private void удалениеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridViewCourses.SelectedRows.Count == 0) return;

            DataGridViewRow selectedRow = dataGridViewCourses.SelectedRows[0];
            string primaryKey = selectedRow.Cells["Номер"].Value.ToString();

            if (CanDelete(primaryKey))
            {
                MessageBox.Show("Невозможно удалить курс, который содержится в договорах", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult confirmationDeleting = MessageBox.Show("Вы действительно желаете удалить выбранную запись?",
                "Внимание", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);

            if (confirmationDeleting == DialogResult.Cancel || confirmationDeleting == DialogResult.No) return;



            bool isExecute = sqlClient.ExecuteRequest("DELETE FROM course where id='"
                + primaryKey + "'");

            if (!isExecute)
            {
                MessageBox.Show("Не удалось удалить курс", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show("Удаление курса успешно", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

            LoadData();
            UpdateUserInterface();

        }

        private void dataGridViewCourses_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var hitTestInfo = dataGridViewCourses.HitTest(e.X, e.Y);

                if (hitTestInfo.RowIndex >= 0)
                {
                    dataGridViewCourses.ClearSelection();
                    dataGridViewCourses.Rows[hitTestInfo.RowIndex].Selected = true;
                    Point point = dataGridViewCourses.PointToScreen(new Point(e.X, e.Y));
                    contextMenuStripDgv.Show(point);
                }
            }
        }

        private void comboBoxSort_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillSort();
        }

        private void FillSort()
        {
            if (comboBoxSort.SelectedIndex == -1 || comboBoxSort.SelectedIndex == 0)
            {
                if (search != string.Empty)
                {
                    sort = ", name ASC ";
                }
                else
                {
                    sort = " order by name ASC ";
                }
                
            }
            else
            {
                string condition = comboBoxSort.SelectedIndex == 1 ? " asc " : " desc ";

                if (search != string.Empty)
                {
                    sort = ", (SELECT qualification.name from qualification where course.qualification=qualification.id)" + condition;
                }
                else
                {
                    sort = " order by (SELECT qualification.name from qualification where course.qualification=qualification.id)" + condition;
                }
            }

            

            LoadData();
            UpdateUserInterface();
        }
    }
}
