using Listeners.DatabaseHelper;
using Listeners.Forms.Roles.Secretary.Group;
using Listeners.Forms.Roles.Secretary.Listener;
using Listeners.Forms.Roles.Secretary.Listener.ListenerCreater;
using Listeners.Forms.Roles.Secretary.Organization;
using Listeners.Forms.Roles.Secretary.Record;
using Listeners.Forms.Roles.Secretary.Representative;
using MySql.Data.MySqlClient;
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

namespace Listeners.Forms.Roles.Secretary.Course.CourseRecording
{
    public partial class CourseRecordingView : Form
    {
        private bool listenerSelected = false;
        private bool courseSelected = false;
        private bool organizationSelected = false;
        private bool groupSelected = false;
        private bool representativeSelected = false;
        private Timer timer;
        private DateTime lastActivityTime;
        private string primaryKeyListener = string.Empty;
        private MySqlClient sqlClient;
        private bool fromRecords;
        public CourseRecordingView(string primaryKey = "", bool fromRecords = false)
        {
            this.primaryKeyListener = primaryKey;
            this.fromRecords = fromRecords;
            InitializeComponent();
            lastActivityTime = DateTime.Now;
            sqlClient = new MySqlClient();
            ShowUser();
            ResetTimer();
            UpdateUserInterface();
            FillComboBox();
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
            comboBoxFrom.Items.AddRange(sqlClient.FillComboBox("SELECT name from customer;"));
        }

        private void UpdateUserInterface()
        {
            if (primaryKeyListener != string.Empty)
            {
                labelAboutListener.Text = sqlClient.GetValue("SELECT CONCAT_WS(' ', surname, name, patronymic) AS 'Слушатель' from listener where id='" + primaryKeyListener + "'");
                listenerSelected = true;
            }

            if (fromRecords)
            {
                buttonBack.Text = "К записям";
            }

            labelDate.Text = "Дата оформления  -  " + DateTime.Now.ToShortDateString().Replace(" 0:00:00", "");
        }

        private void ShowRepresentative(bool needShow)
        {
            labelAboutRepresentative.Text = "Не выбран";
            clearRepresentative.Visible = false;
            buttonGetRepresentative.Visible = needShow;
            labelRepresentative.Visible = needShow;
            labelAboutRepresentative.Visible = needShow;
            labelMaternity.Visible = needShow;
            checkBoxCapital.Visible = needShow;
        }

        private void ControlListenerAge()
        {
            if (!courseSelected || !listenerSelected)
            {
                return;
            }

            string listenerDateBirthday = sqlClient.GetValue("SELECT birthday from listener where id='" + primaryKeyListener + "'");
            int age = GetListenerAge(listenerDateBirthday);

            if (age < 18 && sqlClient.GetValue("SELECT name from qualification where id=" +
                "(SELECT qualification from course where course.id='" + GlobalData.IdCourse + "')") == "подготовительные курсы")
            {
                ShowRepresentative(true);
            }
            else
            {
                ShowRepresentative(false);
                representativeSelected = false;
            }

            listenerSelected = true;
        }

        private int GetListenerAge(string listenerDateBirthday)
        {
            DateTime birthday = DateTime.ParseExact(listenerDateBirthday.Replace(" 0:00:00", ""), "dd.mm.yyyy", null);

            TimeSpan ageDifference = DateTime.Now - birthday;

            int ageInYears = (int)(ageDifference.TotalDays / 365.25);

            return ageInYears;
        }

        private void ShowUser()
        {
            labelUser.Text = GlobalData.Employee.Role + " " + GlobalData.Employee.Surname + " "
                + (GlobalData.Employee.Name.Length > 0 ? GlobalData.Employee.Name[0] + ". " : " ")
                + (GlobalData.Employee.Patronymic.Length > 0 ? GlobalData.Employee.Patronymic[0] + "." : "");
        }

        private void CourseRecordingView_MouseMove(object sender, MouseEventArgs e)
        {
            lastActivityTime = DateTime.Now;
        }

        private void CourseRecordingView_KeyPress(object sender, KeyPressEventArgs e)
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

        private void buttonGetGroup_Click(object sender, EventArgs e)
        {
            timer.Stop();
            GroupView groupView = new GroupView(true);
            groupView.FormClosed += GroupView_FormClosed;
            groupView.ShowDialog();
        }


        private void GroupView_FormClosed(object sender, FormClosedEventArgs e)
        {
            timer.Start();

            if (GlobalData.Group != string.Empty)
            {
                labelAboutGroup.Text = GlobalData.Group;
                groupSelected = true;
                clearGroup.Visible = true;
            }
            else
            {
                groupSelected = false;
                clearGroup.Visible = false;
            }

            clearGroup.Location = new Point(labelAboutGroup.Right + 2, labelAboutGroup.Location.Y);
        }

        private void buttonRecordInCourse_Click(object sender, EventArgs e)
        {
            if (!AllIsFilled())
            {
                MessageBox.Show("Заполните все обязательные поля, отмеченные символом *", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (RecordIsExist())
            {
                MessageBox.Show("Запись с указанным кодом уже существует", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string organization = organizationSelected ? GlobalData.IdOrganization.ToString() : null;
            string group = groupSelected ? GlobalData.IdGroup.ToString() : null;
            string representative = representativeSelected ? GlobalData.IdRepresentative.ToString() : null;

            int maternityCapital = checkBoxCapital.Checked ? 1 : 0;

            bool isExecute = sqlClient.AddRecord(GlobalData.IdListener, textBoxCode.Text.Trim(), organization, group,
                GlobalData.IdCourse, DateTime.Now, maternityCapital, DateTime.Parse(maskedTextBoxStart.Text),
                DateTime.Parse(maskedTextBoxEnd.Text), representative);

            if (!isExecute)
            {
                MessageBox.Show("Не удалось записать на курс", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show("Успешная запись на курс!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            
            if (groupSelected)
            {
                UpdateCountInGroup(GlobalData.Group);
            }

            ClearFields();

            GlobalData.RecordCreated = true;

            

            if (!fromRecords)
            {
                DialogResult confirmationToCourses = MessageBox.Show("Вы желаете перейти на форму просмотра договоров?", "Внимание",
                MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                if (confirmationToCourses == DialogResult.No || confirmationToCourses == DialogResult.Cancel) return;

                this.Hide();
                RecordView recordView = new RecordView();
                recordView.ShowDialog();
            }
        }

        private void UpdateCountInGroup(string group)
        {
            if (group == null) return;

            bool isExecute = sqlClient.ExecuteRequest("UPDATE listeners.group set countPeople=(SELECT COUNT(*) from record where record.group='" + GlobalData.IdGroup + "' and " +
                "creditedStatus IN(select id from creditedStatus where name != 'отчислен')) where listeners.group.name='" + group + "'");

            if (!isExecute)
            {
                MessageBox.Show("Не удалось обновить количество людей в группе", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private bool RecordIsExist()
        {
            string value = sqlClient.GetValue("SELECT id from record where code='" + textBoxCode.Text.Trim() + "'");

            return value.Length != 0;
        }

        private void ClearFields()
        {
            labelAboutListener.Text = "Не выбран";
            labelAboutGroup.Text = "Не выбрана";
            labelAboutCourse.Text = "Не выбран";
            labelAboutRepresentative.Text = "Не выбран";
            labelDate.Text = "Дата оформления";
            labelAboutGroup.Text = "Не выбрана";
            textBoxCode.Text = string.Empty;
            maskedTextBoxEnd.Text = string.Empty;
            maskedTextBoxStart.Text = string.Empty;
            comboBoxFrom.SelectedIndex = -1;
            buttonGetOrganization.Visible = false;
            listenerSelected = false;
            courseSelected = false;
            organizationSelected = false;
            groupSelected = false;
            representativeSelected = false;
            clearRepresentative.Visible = false;
            clearGroup.Visible = false;
            checkBoxCapital.Checked = false;
            ShowRepresentative(false);
            GlobalData.IdListener = 0;
            GlobalData.IdCourse = 0;
            GlobalData.IdRepresentative = 0;
            GlobalData.IdGroup = 0;
            GlobalData.IdOrganization = 0;
        }

        private bool AllIsFilled()
        {
            if (comboBoxFrom.SelectedIndex == -1) return false;

            if (comboBoxFrom.SelectedIndex == 1 && !organizationSelected) return false;

            return listenerSelected && courseSelected && textBoxCode.Text.Length != 0 && maskedTextBoxEnd.MaskCompleted &&
                maskedTextBoxStart.MaskCompleted;
        }

        private void buttonGetListener_Click(object sender, EventArgs e)
        {
            timer.Stop();
            ListenerView listenerView = new ListenerView(true);
            listenerView.FormClosed += ListenerView_FormClosed;
            listenerView.ShowDialog();
        }

        private void ListenerView_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (GlobalData.IdListener != 0)
            {
                primaryKeyListener = Convert.ToString(GlobalData.IdListener);
                listenerSelected = true;
                UpdateUserInterface();
                ControlListenerAge();
            }
            else
            {
                listenerSelected = false;
            }
        }

        private void buttonGetCourse_Click(object sender, EventArgs e)
        {
            timer.Stop();
            CourseView course = new CourseView(true);
            course.FormClosed += Course_FormClosed;
            course.ShowDialog();
        }

        private void Course_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (GlobalData.IdCourse != 0)
            {
                labelAboutCourse.Text = GlobalData.Course;
                courseSelected = true;
                ControlListenerAge();
            }
            else
            {
                courseSelected = false;
            }
        }

        private bool ControlRepresentativeNotExistForListener()
        {
            string value = sqlClient.GetValue("SELECT id from representative where idListener='" + GlobalData.IdListener + "'");

            if (value.Length == 0)
            {
                DialogResult confirmationAdd = MessageBox.Show("У выбранного слушателя отсутствует представитель." +
                    " Желаете перейти сразу к добавлению?",
                    "Внимание", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Stop);

                if (confirmationAdd == DialogResult.Cancel) return false;

                if (confirmationAdd == DialogResult.No) return false;

                GlobalData.IdListenerForRepresentative = GlobalData.IdListener;
                StartCreateFormAdd();
            }

            return false;
        }

        private void StartCreateFormAdd()
        {
            timer.Stop();
            RepresentativeChangerView representativeChanger = new RepresentativeChangerView(fromRecord: true);
            representativeChanger.FormClosed += AddRepresentative_FormClosed;
            representativeChanger.ShowDialog();
        }

        private void AddRepresentative_FormClosed(object sender, FormClosedEventArgs e)
        {
            timer.Start();

            if (!GlobalData.RepresentativeChanged && !GlobalData.RepresentativeCreated)
            {
                return;
            }

            if (GlobalData.RepresentativeCreatedForListener)
            {
                GlobalData.RepresentativeCreatedForListener = false;
                GlobalData.IdListenerForRepresentative = 0;
                OnDestroyForm();
                string representativeFullName = sqlClient.GetValue("SELECT concat_ws(' ', surname, name, patronymic) from representative where " +
                "idlistener='" + GlobalData.IdListener + "'");
                FillRepresentative(representativeFullName);
            }
        }

        private void OnDestroyForm()
        {
            try
            {
                GlobalData.IdRepresentative = Convert.ToInt32(sqlClient.GetValue("SELECT id from representative where idListener='"
                                    + GlobalData.IdListener + "'"));
            }
            catch
            {
                MessageBox.Show("Не удалось получить добавленного представителя", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void buttonGetRepresentative_Click(object sender, EventArgs e)
        {
            string representativeFullName = sqlClient.GetValue("SELECT concat_ws(' ', surname, name, patronymic) from representative where " +
                "idlistener='" + GlobalData.IdListener + "'");

            if (representativeFullName.Length != 0)
            {
                FillRepresentative(representativeFullName);
                return;
            }

            if (!ControlRepresentativeNotExistForListener())
            {
                return;
            }

            timer.Stop();
            RepresentativeView representative = new RepresentativeView(true);
            representative.FormClosed += RepresentativeView_FormClosed;
            representative.ShowDialog();
        }

        private void FillRepresentative(string representative)
        {
            string[] representativePersonalData = representative.Split(' ');
            labelAboutRepresentative.Text = representativePersonalData[0] + " " +
                (representativePersonalData[1].Length > 0 ? representativePersonalData[1][0] + ". " : " ") +
                (representativePersonalData[2].Length > 0 ? representativePersonalData[2][0] + "." : "");
            representativeSelected = true;
            clearRepresentative.Visible = true;
            FillIdentificator();

            clearRepresentative.Location = new Point(labelAboutRepresentative.Right + 2,
                    labelAboutRepresentative.Location.Y);
        }

        private void FillIdentificator()
        {
            try
            {
                GlobalData.IdRepresentative = int.Parse(sqlClient.GetValue("SELECT id from representative where idListener='" + GlobalData.IdListener + "'"));
            }
            catch (Exception)
            {
                MessageBox.Show("Не удалось выбрать законного представителя", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RepresentativeView_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (GlobalData.IdRepresentative != 0)
            {
                string representative = sqlClient.GetValue("SELECT CONCAT_WS(' ', surname, name, patronymic)" +
                    " from representative where id='" + GlobalData.IdRepresentative + "'");
                FillRepresentative(representative);
            }
            else
            {
                representativeSelected = false;
                clearRepresentative.Visible = false;
            }

            clearRepresentative.Location = new Point(labelAboutRepresentative.Right + 2,
                    labelAboutRepresentative.Location.Y);
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            ClearFields();

            timer.Stop();

            if (fromRecords)
            {
                this.Close();
            }
            else
            {
                this.Hide();
                ListenerView listenerView = new ListenerView();
                listenerView.ShowDialog();
            }
        }

        private void comboBoxFrom_SelectedIndexChanged(object sender, EventArgs e)
        {
            buttonGetOrganization.Visible = comboBoxFrom.SelectedIndex == 1;
            labelAboutOrganization.Visible = comboBoxFrom.SelectedIndex == 1;
            organizationSelected = !(comboBoxFrom.SelectedIndex == 0);
        }

        private void buttonGetOrganization_Click(object sender, EventArgs e)
        {
            timer.Stop();
            OrganizationView organization = new OrganizationView(true);
            organization.FormClosed += OrganizationView_FormClosed;
            organization.ShowDialog();
        }

        private void OrganizationView_FormClosed(Object sender, FormClosedEventArgs e)
        {
            if (GlobalData.IdOrganization != 0)
            {
                labelAboutOrganization.Text = "Организация - " + sqlClient.GetValue("SELECT name" +
                    " from organization where id='" + GlobalData.IdOrganization + "'");
                organizationSelected = true;
            }
            else
            {
                organizationSelected = false;
            }
        }

        private void textBoxCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetterOrDigit(e.KeyChar) && e.KeyChar != '-' && e.KeyChar != (char)Keys.Back &&
                e.KeyChar != '.' && e.KeyChar != '/')
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
                if (e.KeyChar == '-' || e.KeyChar == '.' || e.KeyChar == '/')
                {
                    e.Handled = true;
                    return;
                }
            }
        }

        private void maskedTextBoxStart_Click(object sender, EventArgs e)
        {
            MaskedTextBox maskedTextBox = sender as MaskedTextBox;

            maskedTextBox.Select(0, 0);
        }

        private void clearGroup_Click(object sender, EventArgs e)
        {
            labelAboutGroup.Text = "Не выбрана";
            GlobalData.IdGroup = 0;
            GlobalData.Group = string.Empty;
            groupSelected = false;
            clearGroup.Visible = false;
        }

        private void clearRepresentative_Click(object sender, EventArgs e)
        {
            labelAboutRepresentative.Text = "Не выбран";
            GlobalData.IdRepresentative = 0;
            representativeSelected = false;
            clearRepresentative.Visible = false;
        }

        private void maskedTextBoxStart_TextChanged(object sender, EventArgs e)
        {
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

            if (!maskedTextBoxEnd.MaskCompleted) return;

            DateTime end;

            if (!DateTime.TryParse(maskedTextBoxEnd.Text, out end)) return;

            if (start >= end)
            {
                maskedTextBoxEnd.Text = start.AddDays(1).ToString("dd.MM.yyyy");
            }
        }

        private void maskedTextBoxEnd_TextChanged(object sender, EventArgs e)
        {
            if (!maskedTextBoxEnd.MaskCompleted) return;

            DateTime end;

            if (!DateTime.TryParse(maskedTextBoxEnd.Text, out end) || end.Year > DateTime.Now.Year + 1)
            {
                maskedTextBoxEnd.Text = DateTime.Now.AddDays(1).ToString("dd.MM.yyyy");
                return;
            }

            DateTime minDate = DateTime.Now.AddYears(-1);
            DateTime maxDate = DateTime.Now.AddMonths(6);

            if (end < minDate || end > maxDate)
            {
                MessageBox.Show("Некорректно указана дата окончания", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                maskedTextBoxEnd.Text = DateTime.Now.AddDays(1).ToString("dd.MM.yyyy");
                return;
            }

            if (!maskedTextBoxStart.MaskCompleted) return;

            DateTime start;

            if (!DateTime.TryParse(maskedTextBoxStart.Text, out start)) return;

            if (start >= end)
            {
                maskedTextBoxEnd.Text = start.AddDays(1).ToString("dd.MM.yyyy");
            }
        }
    }
}