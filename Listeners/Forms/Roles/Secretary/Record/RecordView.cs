using Listeners.DatabaseHelper;
using Listeners.ExcelHelper;
using Listeners.Forms.Roles.Secretary.Course.CourseRecording;
using Listeners.MainMenu.Manager;
using Listeners.MainMenu.Secretary;
using Listeners.MainMenu.SysAdmin;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Listeners.Forms.Roles.Secretary.Record
{
    public partial class RecordView : Form
    {
        bool afterChanged = false;
        private string sort = string.Empty;
        private string filter = string.Empty;
        private string search = string.Empty;
        private int currentPage = Constants.START_CURRENT_PAGE;
        private int countRowsInPage = 0;
        private int countPages = 0;
        private ExcelClient excelClient;
        private int countRows = 0;
        private MySqlClient sqlClient;
        private Timer timer;
        private DateTime lastActivityTime;
        public RecordView()
        {
            InitializeComponent();
            lastActivityTime = DateTime.Now;
            ShowUser();
            ResetTimer();
            sqlClient = new MySqlClient();
            FillComboBox();
            LoadData();
            GetCountPages();
            GetCountRows();
            excelClient = new ExcelClient();
            UpdateUserInterface();
            UpdateAfterChanging();
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
            comboBoxCourse.Items.Add(string.Empty);
            comboBoxGroup.Items.Add(string.Empty);
            comboBoxCreditedStatus.Items.Add(string.Empty);
            comboBoxOpenStatus.Items.Add(string.Empty);
            comboBoxPayStatus.Items.Add(string.Empty);
            comboBoxQualification.Items.Add(string.Empty);

            string[] courses = sqlClient.FillComboBox("SELECT DISTINCT name from course;");
            comboBoxCourse.Items.AddRange(courses);

            string[] groups = sqlClient.FillComboBox("SELECT name from listeners.group;");
            comboBoxGroup.Items.AddRange(groups);

            string[] qualifications = sqlClient.FillComboBox("SELECT name from qualification;");
            comboBoxQualification.Items.AddRange(qualifications);

            string[] creditedStatuses = sqlClient.FillComboBox("SELECT name from creditedStatus;");
            comboBoxCreditedStatus.Items.AddRange(creditedStatuses);

            string[] openStatuses = sqlClient.FillComboBox("SELECT name from openStatus;");
            comboBoxOpenStatus.Items.AddRange(openStatuses);

            string[] payStatuses = sqlClient.FillComboBox("SELECT name from paymentStatus;");
            comboBoxPayStatus.Items.AddRange(payStatuses);
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
                countPages = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(sqlClient.GetValue("SELECT COUNT(*) from record " + filter + search + sort)) / 15));
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
                countRows = Convert.ToInt32(sqlClient.GetValue("SELECT COUNT(*) from record " + filter + search + sort));
            }
            catch
            {
                MessageBox.Show("Не удалось произвести работу с базой данных", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void HidePersonalData()
        {
            foreach (DataGridViewColumn column in dataGridViewRecords.Columns)
            {
                if (column.Name == "Код")
                {
                    column.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                    column.Width = 85;
                }
                else if (column.Name == "Группа")
                {
                    column.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                    column.Width = 73;
                }
                else if (column.Name == "Курс")
                {
                    column.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                    column.Width = 140;
                }
                else if (column.Name == "Дата оформления")
                {
                    column.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                    column.Width = 95;
                }
                else if (column.Name == "Начало курса")
                {
                    column.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                    column.Width = 85;
                }
                else if (column.Name == "Окончание курса")
                {
                    column.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                    column.Width = 85;
                }
                else if (column.Name == "Факт. оплата")
                {
                    column.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                    column.Width = 65;
                }
                else if (column.Name == "Статус договора")
                {
                    column.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                    column.Width = 85;
                }
                else if (column.Name == "Статус обучения")
                {
                    column.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                    column.Width = 100;
                }
                else if (column.Name == "Квалификация")
                {
                    column.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                    column.Width = 135;
                }
                else if (column.Name == "Оплата")
                {
                    column.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                    column.Width = 80;
                }
            }

            dataGridViewRecords.Columns[0].Visible = false;
        }

        private void LoadData()
        {
            dataGridViewRecords.DataSource = sqlClient.GetDataTable("SELECT record.id AS 'Номер', CONCAT(" +
                "(SELECT surname from listener where listener.id=record.listener), ' ',  " +
                "LEFT((SELECT name from listener where listener.id=record.listener), 1)," +
                " '.', CASE WHEN LENGTH((SELECT patronymic from listener where listener.id=record.listener)) > 0" +
                " THEN CONCAT(' ', LEFT((SELECT patronymic from listener where listener.id=record.listener), 1), '.')" +
                " ELSE '' END)" +
                " AS 'Слушатель'," +
                "(SELECT phone from listener where listener.id=record.listener) AS 'Телефон'," +
                "code AS 'Код', (SELECT name from listeners.group where record.group=listeners.group.id) AS 'Группа'," +
                "(SELECT name from course where course.id=record.course) AS 'Курс'," +
                " (SELECT name from qualification where id=(SELECT qualification from course where course.id=record.course))" +
                " AS 'Квалификация', decorationDate AS 'Дата оформления'," +
                "startCourse AS 'Начало курса', endCourse as 'Окончание курса'," +
                "(SELECT name from paymentStatus where record.paymentStatus=paymentStatus.id) AS 'Оплата'," +
                "(SELECT name from creditedStatus where record.creditedStatus=creditedStatus.id) AS 'Статус обучения'," +
                "(SELECT name from openStatus where record.openStatus=openStatus.id) AS 'Статус договора'," +
                "actualPayment AS 'Факт. оплата' " +
                " from record INNER JOIN course on record.course = course.id " + filter + search + sort +
                " LIMIT 15 OFFSET " + ((currentPage - 1) * 15));

            if (dataGridViewRecords.Rows.Count > 0)
            {
                dataGridViewRecords.Columns["Номер"].Visible = false;
                dataGridViewRecords.Columns["Телефон"].Visible = false;
                countRowsInPage = dataGridViewRecords.Rows.Count;
                HidePersonalData();
            }
            else
            {
                MessageBox.Show("Не найдено ни одной записи", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void ShowUser()
        {
            labelUser.Text = GlobalData.Employee.Role + " " + GlobalData.Employee.Surname + " "
                + (GlobalData.Employee.Name.Length > 0 ? GlobalData.Employee.Name[0] + ". " : " ")
                + (GlobalData.Employee.Patronymic.Length > 0 ? GlobalData.Employee.Patronymic[0] + "." : "");
        }

        private void RecordView_MouseMove(object sender, MouseEventArgs e)
        {
            lastActivityTime = DateTime.Now;
        }

        private void RecordView_KeyPress(object sender, KeyPressEventArgs e)
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

        private void textBoxSearchListener_Enter(object sender, EventArgs e)
        {
            SwitchToRussianKeyboardLayout();
        }

        private void textBoxSearchListener_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && e.KeyChar != '-' && e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Space
                && e.KeyChar != '.')
            {
                e.Handled = true;
                return;
            }

            if (textBoxSearchListener.Text.Length == 0)
            {
                if (e.KeyChar == '-' || e.KeyChar == '.' || e.KeyChar == (char)Keys.Space)
                {
                    e.Handled = true;
                    return;
                }
            }

            if (textBoxSearchListener.Text.Length == 0 ||
                textBoxSearchListener.Text.Length > 0 && textBoxSearchListener.Text[textBoxSearchListener.Text.Length - 1] == '-' ||
                textBoxSearchListener.Text.Length > 0 && textBoxSearchListener.Text[textBoxSearchListener.Text.Length - 1] == '.')
            {
                e.KeyChar = char.ToUpper(e.KeyChar);
            }
        }

        private void textBoxSearchCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetterOrDigit(e.KeyChar) && e.KeyChar != '-' && e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Space
                && e.KeyChar != '.')
            {
                e.Handled = true;
                return;
            }

            if (textBoxSearchCode.Text.Length == 0)
            {
                if (e.KeyChar == '-' || e.KeyChar == '.' || e.KeyChar == (char)Keys.Space)
                {
                    e.Handled = true;
                    return;
                }
            }
        }

        private void textBoxSearchListener_TextChanged(object sender, EventArgs e)
        {
            if (textBoxSearchListener.Text.Length == 0) return;

            sort = string.Empty;

            currentPage = Constants.START_CURRENT_PAGE;

            if (textBoxSearchCode.Text != string.Empty)
            {
                search = " ORDER BY CASE WHEN listener IN(SELECT id from listener where CONCAT(" +
                    "" + "(SELECT surname from listener where listener.id=record.listener)," +
                    "' ', LEFT((SELECT name from listener where listener.id=record.listener), 1)," +
                    " '.', CASE WHEN LENGTH((SELECT patronymic from listener where listener.id=record.listener)) > 0" +
                    " THEN CONCAT(' ', LEFT((SELECT patronymic from listener where listener.id=record.listener), 1), '.')"
                    + " ELSE '' END)='" + textBoxSearchListener.Text + "') THEN 0 when listener IN (SELECT id from listener where CONCAT(" +
                    "(SELECT surname from listener where listener.id=record.listener),' ', LEFT((select name from listener where" +
                    " listener.id=record.listener), 1), '.', " +
                    "CASE WHEN LENGTH((SELECT patronymic from listener where listener.id=record.listener)) > 0" +
                    " THEN CONCAT (' ', LEFT((SELECT patronymic from listener where listener.id=record.listener), 1), '.') ELSE ''" +
                    " END) LIKE '" + textBoxSearchListener.Text + "%') THEN 1 ELSE 2 END, CASE when code='" + textBoxSearchCode.Text + "' THEN 0 when code LIKE '" +
                    textBoxSearchCode.Text + "%' THEN 1 ELSE 2 END ";
            }
            else
            {
                search = " ORDER BY CASE WHEN listener IN(SELECT id from listener where CONCAT(" +
                    "" + "(SELECT surname from listener where listener.id=record.listener)," +
                    "' ', LEFT((SELECT name from listener where listener.id=record.listener), 1)," +
                    " '.', CASE WHEN LENGTH((SELECT patronymic from listener where listener.id=record.listener)) > 0" +
                    " THEN CONCAT(' ', LEFT((SELECT patronymic from listener where listener.id=record.listener), 1), '.')"
                    + " ELSE '' END)='" + textBoxSearchListener.Text + "') THEN 0 when listener IN (SELECT id from listener where CONCAT(" +
                    "(SELECT surname from listener where listener.id=record.listener),' ', LEFT((select name from listener where" +
                    " listener.id=record.listener), 1), '.', " +
                    "CASE WHEN LENGTH((SELECT patronymic from listener where listener.id=record.listener)) > 0" +
                    " THEN CONCAT (' ', LEFT((SELECT patronymic from listener where listener.id=record.listener), 1), '.') ELSE ''" +
                    " END) LIKE '" + textBoxSearchListener.Text + "%') THEN 1 ELSE 2 END ";
            }

            if (!afterChanged)
            {
                SortDate();
            }

            LoadData();
            UpdateUserInterface();
        }

        private void textBoxSearchCode_TextChanged(object sender, EventArgs e)
        {
            if (textBoxSearchCode.Text.Length == 0) return;

            sort = string.Empty;


            currentPage = Constants.START_CURRENT_PAGE;

            if (textBoxSearchListener.Text != string.Empty)
            {
                search = " ORDER BY CASE WHEN listener in(SELECT id from listener where CONCAT(" +
                    "" + "(SELECT surname from listener where listener.id=record.listener)," +
                    "' ', LEFT((SELECT name from listener where listener.id=record.listener), 1)," +
                    " '.', CASE WHEN LENGTH((SELECT patronymic from listener where listener.id=record.listener)) > 0" +
                    " THEN CONCAT(' ', LEFT((SELECT patronymic from listener where listener.id=record.listener), 1), '.')"
                    + " ELSE '' END)='" + textBoxSearchListener.Text + "') THEN 0 when listener IN (SELECT id from listener where CONCAT(" +
                    "(SELECT surname from listener where listener.id=record.listener),' ', LEFT((select name from listener where" +
                    " listener.id=record.listener), 1), '.', " +
                    "CASE WHEN LENGTH((SELECT patronymic from listener where listener.id=record.listener)) > 0" +
                    " THEN CONCAT (' ', LEFT((SELECT patronymic from listener where listener.id=record.listener), 1), '.') ELSE ''" +
                    " END) LIKE '" + textBoxSearchListener.Text + "%') THEN 1 ELSE 2 END, CASE when code='" + textBoxSearchCode.Text + "' THEN 0 when code LIKE '" +
                    textBoxSearchCode.Text + "%' THEN 1 ELSE 2 END ";
            }
            else
            {
                search = " ORDER BY CASE when code='" + textBoxSearchCode.Text + "' THEN 0 when code LIKE '" +
                    textBoxSearchCode.Text + "%' THEN 1 ELSE 2 END ";
            }

            if (!afterChanged)
            {
                SortDate();
            }

            LoadData();
            UpdateUserInterface();
        }

        private void SortDate()
        {
            sort = string.Empty;

            if (comboBoxSortDate.SelectedIndex == -1) return;


            if (HasSearch())
            {
                sort = ", decorationDate " + (comboBoxSortDate.SelectedIndex == 1 ? " asc " : " desc ");
            }
            else
            {
                sort = " order by decorationDate " + (comboBoxSortDate.SelectedIndex == 1 ? " asc " : " desc ");
            }

            LoadData();
            UpdateUserInterface();
        }

        private void comboBoxSortDate_SelectedIndexChanged(object sender, EventArgs e)
        {
            SortDate();
        }

        private bool HasSearch()
        {
            return search != string.Empty;
        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            ResetConditions();
        }

        private void ResetConditions()
        {
            comboBoxSortDate.SelectedIndex = -1;
            search = string.Empty;
            sort = string.Empty;
            filter = string.Empty;
            comboBoxGroup.SelectedIndex = -1;
            comboBoxCourse.SelectedIndex = -1;
            comboBoxCreditedStatus.SelectedIndex = -1;
            comboBoxPayStatus.SelectedIndex = -1;
            comboBoxQualification.SelectedIndex = -1;
            comboBoxOpenStatus.SelectedIndex = -1;
            textBoxSearchCode.Text = string.Empty;
            textBoxSearchListener.Text = string.Empty;
            maskedTextBoxStart.Text = string.Empty;
            maskedTextBoxEnd.Text = string.Empty;

            FillFilters();
        }

        private void ComboboxFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillFilters();
        }

        private void FillFilters()
        {
            UpdateFilter();
            LoadData();
            UpdateUserInterface();
        }

        private void UpdateFilter()
        {
            filter = string.Empty;
            bool isFirstFilter = true;

            if (!string.IsNullOrEmpty(comboBoxGroup.Text))
            {
                isFirstFilter = IsFirstFilterCheck(isFirstFilter,
                    " record.group=(SELECT id from listeners.group where listeners.group.name='" + comboBoxGroup.Text + "') ");
            }

            if (!string.IsNullOrEmpty(comboBoxCourse.Text) || !string.IsNullOrEmpty(comboBoxQualification.Text))
            {
                string filterQualification = string.Empty;

                if (!string.IsNullOrEmpty(comboBoxCourse.Text) && !string.IsNullOrEmpty(comboBoxQualification.Text))
                {
                    filterQualification = " record.course IN(SELECT id from course " +
                    "where course.qualification=(SELECT id from qualification where name='" + comboBoxQualification.Text + "')" +
                    " and course.name='" + comboBoxCourse.Text + "') ";
                }
                else if (!string.IsNullOrEmpty(comboBoxQualification.Text))
                {
                    filterQualification = " record.course IN(SELECT id from course " +
                    "where course.qualification=(SELECT id from qualification where name='" + comboBoxQualification.Text + "')) ";
                }
                else
                {
                    filterQualification = " record.course IN (SELECT id from listeners.course where course.name='" + comboBoxCourse.Text + "') ";
                }

                isFirstFilter = IsFirstFilterCheck(isFirstFilter,
                    filterQualification);
            }

            if (!string.IsNullOrEmpty(comboBoxCreditedStatus.Text))
            {
                isFirstFilter = IsFirstFilterCheck(isFirstFilter,
                    " record.creditedStatus=(SELECT id from creditedStatus where name='" + comboBoxCreditedStatus.Text + "') ");
            }

            if (!string.IsNullOrEmpty(comboBoxOpenStatus.Text))
            {
                isFirstFilter = IsFirstFilterCheck(isFirstFilter,
                    " record.openStatus=(SELECT id from openStatus where name='" + comboBoxOpenStatus.Text + "') ");
            }

            if (!string.IsNullOrEmpty(comboBoxPayStatus.Text))
            {
                isFirstFilter = IsFirstFilterCheck(isFirstFilter,
                    " record.paymentStatus=(SELECT id from paymentstatus where name='" + comboBoxPayStatus.Text + "') ");
            }

            if (maskedTextBoxStart.MaskCompleted)
            {
                DateTime start;

                if (DateTime.TryParse(maskedTextBoxStart.Text, out start))
                {
                    isFirstFilter = IsFirstFilterCheck(isFirstFilter, " startCourse >= '" + start.ToString("yyyy-MM-dd") + "'");
                }
            }

            if (maskedTextBoxEnd.MaskCompleted)
            {
                DateTime end;

                if (DateTime.TryParse(maskedTextBoxEnd.Text, out end))
                {
                    isFirstFilter = IsFirstFilterCheck(isFirstFilter, " endCourse <= '" + end.ToString("yyyy-MM-dd") + "'");
                }
            }

        }

        private bool IsFirstFilterCheck(bool isFirstFilter, string filterQuery)
        {
            if (isFirstFilter)
            {
                filter += " WHERE ";
                isFirstFilter = false;
            }
            else
            {
                filter += " AND ";
            }
            filter += filterQuery;

            return isFirstFilter;
        }

        private void MaskedTextBox_Click(object sender, EventArgs e)
        {
            MaskedTextBox maskedTextBox = sender as MaskedTextBox;
            maskedTextBox.Select(0, 0);
        }

        private void maskedTextBoxStart_TextChanged(object sender, EventArgs e)
        {
            if (maskedTextBoxStart.Text.Replace(" ", "").Replace(".", "").Length == 0)
            {
                FillFilters();
                return;
            }

            if (!maskedTextBoxStart.MaskCompleted) return;

            DateTime start;

            if (!DateTime.TryParse(maskedTextBoxStart.Text, out start) || start.Year > DateTime.Now.Year + 2)
            {
                MessageBox.Show("Некорректно указана дата начала", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                maskedTextBoxStart.Text = DateTime.Now.AddDays(1).ToString("dd.MM.yyyy");
                return;
            }

            DateTime minDate = DateTime.Now.AddYears(-1);
            DateTime maxDate = DateTime.Now.AddMonths(6);

            if (start < minDate || start > maxDate)
            {
                maskedTextBoxStart.Text = DateTime.Now.AddDays(1).ToString("dd.MM.yyyy");
                return;
            }

            FillFilters();
        }

        private void maskedTextBoxEnd_TextChanged(object sender, EventArgs e)
        {
            bool hasError = false;

            if (maskedTextBoxEnd.Text.Replace(" ", "").Replace(".", "").Length == 0)
            {
                FillFilters();
                return;
            }

            if (!maskedTextBoxEnd.MaskCompleted) return;

            DateTime end;

            if (!DateTime.TryParse(maskedTextBoxEnd.Text, out end) || end.Year > DateTime.Now.Year + 1)
            {
                MessageBox.Show("Некорректно указана дата окончания", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                maskedTextBoxEnd.Text = DateTime.Now.AddDays(1).ToString("dd.MM.yyyy");
                hasError = true;
            }

            if (maskedTextBoxStart.MaskCompleted)
            {
                DateTime start = DateTime.Parse(maskedTextBoxStart.Text);
                if (end <= start)
                {
                    maskedTextBoxEnd.Text = start.AddDays(1).ToString("dd.MM.yyyy");
                    return;
                }
            }

            if (!hasError)
            {
                FillFilters();
            }

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

            if (GlobalData.Employee.Role == Constants.ROLE_MANAGER)
            {
                this.Hide();
                ManagerMenuView managerMenu = new ManagerMenuView();
                managerMenu.ShowDialog();
            }
            else
            {
                this.Hide();
                SecretaryMenuView secretaryMenu = new SecretaryMenuView();
                secretaryMenu.ShowDialog();
            }
        }

        private void buttonCreateRecord_Click(object sender, EventArgs e)
        {
            timer.Stop();
            CourseRecordingView courseRecording = new CourseRecordingView(fromRecords: true);
            courseRecording.FormClosed += CreateRecord_FormClosed;
            courseRecording.ShowDialog();
        }

        private void CreateRecord_FormClosed(object sender, FormClosedEventArgs e)
        {
            UpdateAfterChanging();
        }

        private void dataGridViewRecords_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var hitTestInfo = dataGridViewRecords.HitTest(e.X, e.Y);

                if (hitTestInfo.RowIndex >= 0)
                {
                    dataGridViewRecords.ClearSelection();
                    dataGridViewRecords.Rows[hitTestInfo.RowIndex].Selected = true;
                    Point point = dataGridViewRecords.PointToScreen(new Point(e.X, e.Y));
                    contextMenuStripDgv.Show(point);
                }
            }
        }

        private void изменитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridViewRecords.SelectedRows.Count == 0) return;

            DataGridViewRow selectedRow = dataGridViewRecords.SelectedRows[0];

            timer.Stop();
            RecordChangerView recordChanger = new RecordChangerView(selectedRow.Cells["Номер"].Value.ToString(),
                sqlClient.GetValue("SELECT listener from record where id='" + selectedRow.Cells["Номер"].Value.ToString() + "'"));
            recordChanger.FormClosed += RecordChangerView_FormClosed;
            recordChanger.ShowDialog();
        }

        private void RecordChangerView_FormClosed(Object sender, FormClosedEventArgs e)
        {
            UpdateAfterChanging();
        }

        private void UpdateAfterChanging()
        {
            timer.Start();

            if (!GlobalData.RecordChanged && !GlobalData.RecordCreated)
            {
                return;
            }

            ResetConditions();

            if (GlobalData.RecordChanged)
            {
                sort = " order by record.modifiedBy desc ";
            }

            if (GlobalData.RecordCreated)
            {
                sort = " order by record.id desc ";
            }

            afterChanged = true;

            GlobalData.RecordCreated = false;
            GlobalData.RecordChanged = false;

            LoadData();
            UpdateUserInterface();
        }


        private bool CanDelete(string primaryKey)
        {
            bool canDelete = Convert.ToInt32(sqlClient.GetValue("SELECT COUNT(*) FROM record where id='" + primaryKey + "' and " +
                "paymentStatus=(SELECT id from paymentStatus where name='не оплачен') and creditedStatus=(SELECT id from " +
                "creditedStatus where name='отчислен') and endStatus=(SELECT id from endStatus where name='не освоен')")) > 0;

            bool canDeleteWithOpenStatus = Convert.ToInt32(sqlClient.GetValue("SELECT COUNT(*) FROM record where id='" + primaryKey + "' and " +
                "openStatus=(SELECT id from openStatus where name='закрыт')")) > 0;

            return canDelete || canDeleteWithOpenStatus;
        }

        private void удалитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridViewRecords.SelectedRows.Count == 0) return;

            DataGridViewRow selectedRow = dataGridViewRecords.SelectedRows[0];
            string primaryKey = selectedRow.Cells["Номер"].Value.ToString();

            if (!CanDelete(primaryKey))
            {
                MessageBox.Show("Нельзя удалить данный договор", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult confirmationDeleting = MessageBox.Show("Вы действительно желаете удалить выбранную запись?",
                "Внимание", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);

            if (confirmationDeleting == DialogResult.Cancel || confirmationDeleting == DialogResult.No) return;

            bool isExecute = sqlClient.ExecuteRequest("DELETE FROM record where id='"
                + primaryKey + "'");

            if (!isExecute)
            {
                MessageBox.Show("Не удалось удалить запись", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show("Удаление записи успешно", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

            LoadData();
        }

        private void dataGridViewRecords_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            foreach (DataGridViewRow dataRow in dataGridViewRecords.Rows)
            {
                if (dataRow.Cells["Оплата"].Value.ToString() == "оплачен")
                {
                    dataRow.Cells["Оплата"].Style.BackColor = Color.FromArgb(128, 255, 128);
                }
                else
                {
                    dataRow.Cells["Оплата"].Style.BackColor = Color.FromArgb(255, 189, 136);
                }

                if (dataRow.Cells["Статус договора"].Value.ToString() == "открыт")
                {
                    dataRow.Cells["Статус договора"].Style.BackColor = Color.FromArgb(205, 92, 92);
                }
                else
                {
                    dataRow.Cells["Статус договора"].Style.BackColor = Color.FromArgb(128, 255, 128);
                }
            }
        }

        private void buttonExportExcel_Click(object sender, EventArgs e)
        {
            if (!excelClient.CreateReportAboutRecords())
            {
                MessageBox.Show("Не удалось распечатать отчет", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
    }
}
