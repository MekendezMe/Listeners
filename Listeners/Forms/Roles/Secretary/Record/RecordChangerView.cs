using Listeners.DatabaseHelper;
using Listeners.FormCloserHelper;
using Listeners.Forms.Roles.Secretary.Group;
using Listeners.Interfaces;
using Listeners.WordHelper;
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

namespace Listeners.Forms.Roles.Secretary.Record
{
    public partial class RecordChangerView : Form
    {
        private string group = string.Empty;
        private double fullPay = 0.0;
        private double factPay = 0.0;
        private double factPaid = 0.0;
        private MySqlClient sqlClient;
        private WordClient wordClient;
        private Timer timer;
        private DateTime lastActivityTime;
        private string primaryKey = string.Empty;
        private string primaryKeyListener = string.Empty;
        public RecordChangerView(string primaryKey, string primaryKeyListener)
        {
            InitializeComponent();
            lastActivityTime = DateTime.Now;
            ShowUser();
            ResetTimer();
            this.primaryKey = primaryKey;
            this.primaryKeyListener = primaryKeyListener;
            sqlClient = new MySqlClient();
            FillComboBox();
            UpdateUserInterface();
            wordClient = new WordClient();
            HaveMaternityCapital();
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

        private void HaveMaternityCapital()
        {
            buttonPrintAgreement.Enabled = sqlClient.GetValue("SELECT maternityCapital from record where record.id='" + primaryKey + "' and representative IS NOT NULL") == "1";
        }

        private void FillComboBox()
        {
            string[] paymentStatuses = sqlClient.FillComboBox("SELECT name from paymentstatus");
            comboBoxPayment.Items.AddRange(paymentStatuses);

            string[] endStatuses = sqlClient.FillComboBox("SELECT name from endstatus");
            comboBoxEnd.Items.AddRange(endStatuses);

            string[] openStatuses = sqlClient.FillComboBox("SELECT name from openstatus");
            comboBoxContract.Items.AddRange(openStatuses);

            string[] creditedStatuses = sqlClient.FillComboBox("SELECT name from creditedstatus");
            comboBoxCredited.Items.AddRange(creditedStatuses);
        }

        private void UpdateUserInterface()
        {
            IRecord record = sqlClient.FindOne<IRecord>("SELECT code, decorationDate, transferOrder," +
                " dateTransferOrder, expulsionOrder, dateExpulsionOrder, startCourse, endCourse, actualPayment, " +
                "(SELECT name from listeners.group where id=(SELECT record.group from record where id='"
                + primaryKey + "')) AS 'Group', (SELECT name from paymentstatus where id=" +
                "(SELECT paymentStatus from record where record.id='" + primaryKey + "')) AS 'StatusPay'," +
                "(SELECT name from endStatus where id=" +
                "(SELECT endStatus from record where record.id='" + primaryKey +
                "')) AS 'StatusEnd'," +
                "(SELECT name from openStatus where id=(SELECT openStatus from record where record.id='" +
                primaryKey + "')) AS 'StatusOpen', (SELECT name from creditedStatus where id=(SELECT" +
                " creditedStatus from record where record.id='" + primaryKey + "')) AS 'StatusCredited' from record where " +
                "record.id='" + primaryKey + "'");

            if (record == null)
            {
                MessageBox.Show("Не удалось заполнить данные о записи", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            ICourse course = sqlClient.FindOne<ICourse>("SELECT name, duration, price," +
                " (SELECT name from qualification where id=(SELECT qualification from course where course.id=" +
                "(SELECT course from record where record.id='" + primaryKey + "'))) AS 'Qualification' " +
                "from course where course.id=(SELECT course from record where record.id='" + primaryKey + "')");

            if (course == null)
            {
                MessageBox.Show("Не удалось заполнить данные о курсе", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            ListenerRecord listener = sqlClient.FindOne<ListenerRecord>("SELECT surname, name, patronymic, address, " +
                "birthday AS 'BirthdayDate', phone, (SELECT name from gender where id=(SELECT gender from listener where " +
                "listener.id='" + primaryKeyListener + "')) AS 'Gender', (SELECT title from employment " +
                "where id=(SELECT employment from listener where id='" + primaryKeyListener + "')) AS 'Employment', " +
                "(SELECT title from education where id=(SELECT education from listener where id='" +
                primaryKeyListener + "')) AS 'Education', (SELECT insuranceNumber from document where id=" +
                "(SELECT document from listener where id='" + primaryKeyListener + "')) AS 'InsuranceNumber', " +
                "(SELECT series from passport where id=(SELECT passport from document where id=(SELECT " +
                "document from listener where id='" + primaryKeyListener + "'))) AS 'Series', " +
                "(SELECT number from passport where id=(SELECT passport from document where id=(" +
                "SELECT document from listener where id='" + primaryKeyListener + "'))) AS 'Number' from listener " +
                "where id='" + primaryKeyListener + "'");

            if (listener == null)
            {
                MessageBox.Show("Не удалось заполнить данные о слушателе", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string organizationId = sqlClient.GetValue("SELECT organization from record where id='" +
                primaryKey + "'");

            string customer = "Слушатель является заказчиком";

            if (organizationId != string.Empty)
            {
                customer = sqlClient.GetValue("SELECT name from organization where id=(SELECT organization from record where id='" +
                primaryKey + "')"); ;
            }

            labelCodeContract.Text = record.Code;
            labelDate.Text = record.DecorationDate.Replace(" 0:00:00", "");
            textBoxTransferOrder.Text = record.TransferOrder;
            textBoxExpulsion.Text = record.ExpulsionOrder;
            maskedTextBoxExpulsionDate.Text = record.DateExpulsionOrder;
            maskedTextBoxTransferDate.Text = record.DateTransferOrder;
            labelGroup.Text = record.Group;
            group = record.Group;

            if (group != null && group != string.Empty)
            {
                GlobalData.Group = group;
                clearGroup.Visible = true;
                clearGroup.Location = new Point(labelGroup.Right + 2, labelGroup.Location.Y - 3);
            }
            else
            {
                labelGroup.Text = "Не выбрана";
            }

            maskedTextBoxStart.Text = record.StartCourse;
            maskedTextBoxEnd.Text = record.EndCourse;
            comboBoxContract.SelectedIndex = comboBoxContract.Items.IndexOf(record.StatusOpen);
            comboBoxCredited.SelectedIndex = comboBoxCredited.Items.IndexOf(record.StatusCredited);
            comboBoxEnd.SelectedIndex = comboBoxEnd.Items.IndexOf(record.StatusEnd);
            comboBoxPayment.SelectedIndex = comboBoxPayment.Items.IndexOf(record.StatusPay);
            labelNameCourse.Text = course.Name;
            labelPrice.Text = course.Price.ToString() + " р.";
            labelDuration.Text = course.Duration.ToString() + " ч.";
            labelQualification.Text = course.Qualification;
            labelSurname.Text = listener.Surname;
            labelName.Text = listener.Name;
            labelPatronymic.Text = (listener.Patronymic.Length == 0 ? "нет" : listener.Patronymic);
            textBoxAddress.Text = listener.Address;
            labelPhone.Text = listener.Phone;
            labelEducation.Text = listener.Education;
            labelEmployment.Text = listener.Employment;
            labelSnils.Text = listener.InsuranceNumber;
            labelSeries.Text = listener.Series;
            labelNumber.Text = listener.Number;
            labelGender.Text = listener.Gender;
            labelBirthday.Text = listener.BirthdayDate.Replace(" 0:00:00", "");
            textBoxOrganization.Text = customer;
            labelFullPay.Text = record.ActualPayment + " р.";
            LoadData();

            if (dataGridViewPayments.Rows.Count != 0)
            {
                GetFactPaid();
            }

            fullPay = Convert.ToDouble(course.Price.ToString());
            factPay = fullPay - factPaid;
            labelFactPay.Text = factPay.ToString() + " р.";

            if (dataGridViewPayments.Rows.Count != 0 && IsFullPay())
            {
                BlockPayment(true);
                UpdateStatus("оплачен");
            }
            else
            {
                BlockPayment(false);
                UpdateStatus("не оплачен");
            }

            if (dataGridViewPayments.Rows.Count == 0)
            {
                labelFactPay.Text = course.Price.ToString() + " р.";
            }

        }

        private void GetFactPaid()
        {
            try
            {
                factPaid = Convert.ToDouble(sqlClient.GetValue("SELECT SUM(paid) from payment where payment.record='" + primaryKey + "'"));
            }
            catch
            {
                return;
            }
        }

        private void LoadData()
        {
            dataGridViewPayments.DataSource = sqlClient.GetDataTable("SELECT id AS 'Номер', (SELECT code from record where record.id=" +
                "payment.record) AS 'Код договора', date AS 'Дата оплаты', paid AS 'Оплата' from payment where record in('" + primaryKey + "')");

            if (dataGridViewPayments.Columns.Count != 0)
            {
                dataGridViewPayments.Columns[0].Visible = false;
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

        private void maskedTextBoxExpulsionDate_Click(object sender, EventArgs e)
        {
            MaskedTextBox maskedTextBox = sender as MaskedTextBox;
            maskedTextBox.Select(0, 0);
        }

        private void textBoxTransferOrder_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetterOrDigit(e.KeyChar) && e.KeyChar != '-' && e.KeyChar != (char)Keys.Back &&
                e.KeyChar != '.')
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
                if (e.KeyChar == '-' || e.KeyChar == '.')
                {
                    e.Handled = true;
                    return;
                }
            }
        }

        private void maskedTextBoxTransferDate_TextChanged(object sender, EventArgs e)
        {
            if (!maskedTextBoxTransferDate.MaskCompleted) return;

            DateTime start;

            if (!DateTime.TryParse(maskedTextBoxTransferDate.Text, out start))
            {
                MessageBox.Show("Некорректно указана дата приказа о зачислении", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                maskedTextBoxTransferDate.Text = DateTime.Now.ToString("dd.MM.yyyy");
                return;
            }

            DateTime minDate = DateTime.Now.AddYears(-1);
            DateTime maxDate = DateTime.Now.AddMonths(3);

            if (start < minDate || start > maxDate)
            {
                maskedTextBoxTransferDate.Text = DateTime.Now.ToString("dd.MM.yyyy");
                return;
            }
        }

        private void maskedTextBoxExpulsionDate_TextChanged(object sender, EventArgs e)
        {
            if (!maskedTextBoxExpulsionDate.MaskCompleted) return;

            DateTime end;

            if (!DateTime.TryParse(maskedTextBoxExpulsionDate.Text, out end))
            {
                MessageBox.Show("Некорректно указана дата приказа об отчислении", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                maskedTextBoxExpulsionDate.Text = DateTime.Now.ToString("dd.MM.yyyy");
                return;
            }

            DateTime minDate = DateTime.Now.AddYears(-1);
            DateTime maxDate = DateTime.Now.AddMonths(3);

            if (end < minDate || end > maxDate)
            {
                maskedTextBoxExpulsionDate.Text = DateTime.Now.ToString("dd.MM.yyyy");
                return;
            }
        }

        private void maskedTextBoxPayDate_TextChanged(object sender, EventArgs e)
        {
            if (!maskedTextBoxPayDate.MaskCompleted) return;

            DateTime payDate;

            if (!DateTime.TryParse(maskedTextBoxPayDate.Text, out payDate))
            {
                maskedTextBoxPayDate.Text = DateTime.Now.ToString("dd.MM.yyyy");
                return;
            }

            DateTime minDate = DateTime.Now.AddYears(-1);
            DateTime maxDate = DateTime.Now;

            if (payDate < minDate || payDate > maxDate)
            {
                maskedTextBoxPayDate.Text = DateTime.Now.ToString("dd.MM.yyyy");
                return;
            }
        }

        private void textBoxSum_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox textBox = sender as TextBox;

            string currentText = textBox.Text;

            if (e.KeyChar == ',' && currentText.Contains(','))
            {
                e.Handled = true;
                return;
            }

            if (e.KeyChar == ',' && currentText.Length == 0)
            {
                e.Handled = true;
                return;
            }

            if (!char.IsDigit(e.KeyChar) && e.KeyChar != ',' && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
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
                labelGroup.Text = GlobalData.Group;
                clearGroup.Visible = true;
            }
            else if (group != string.Empty)
            {
                GlobalData.Group = group;
                labelGroup.Text = group;
                clearGroup.Visible = true;
            }
            else
            {
                clearGroup.Visible = false;
            }

            clearGroup.Location = new Point(labelGroup.Right + 2, labelGroup.Location.Y - 3);
        }

        private void clearGroup_Click(object sender, EventArgs e)
        {
            ClearInfoAboutGroup();
        }

        private void ClearInfoAboutGroup()
        {
            labelGroup.Text = "Не выбрана";
            GlobalData.IdGroup = 0;
            GlobalData.Group = string.Empty;
            clearGroup.Visible = false;
            group = string.Empty;
        }

        private void buttonAddPayment_Click(object sender, EventArgs e)
        {
            List<string> queries = new List<string>();

            if (!AllPaymentFill())
            {
                MessageBox.Show("Заполните все обязательные поля оплаты", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (buttonAddPayment.Text != "Изменить")
            {
                if (!ControlSum())
                {
                    return;
                }

                queries.Add("INSERT into payment (record, date, paid) VALUES (" +
                    "'" + primaryKey + "', '" + DateTime.Parse(maskedTextBoxPayDate.Text).ToString("yyyy-MM-dd") + "', '"
                    + textBoxSum.Text.Replace(",", ".") + "')");
            }
            else
            {

                if (dataGridViewPayments.SelectedRows.Count == 0) return;

                double sum = Convert.ToDouble(dataGridViewPayments.SelectedRows[0].Cells["Оплата"].Value.ToString());

                if (!ControlSum(sum)) return;

                queries.Add("UPDATE payment set record=" +
                    "'" + primaryKey + "', date='" + DateTime.Parse(maskedTextBoxPayDate.Text).ToString("yyyy-MM-dd") + "', paid='"
                    + textBoxSum.Text.Replace(",", ".") + "' where id='"
                    + dataGridViewPayments.SelectedRows[0].Cells["Номер"].Value.ToString() + "'");

                buttonAddPayment.Text = "Внести оплату";
            }

            string statusPay = string.Empty;

            if (IsFullPay())
            {
                statusPay = ", paymentStatus=(SELECT id from paymentStatus where name='оплачен') ";
            }

            queries.Add("UPDATE record set actualPayment= ROUND((SELECT SUM(paid) from payment where record='" + primaryKey + "'), 2)" +
                statusPay + ", modifiedBy='" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "' where record.id='" + primaryKey + "'");

            bool isExecute = sqlClient.ExecuteTransaction(queries);

            if (!isExecute)
            {
                MessageBox.Show("Не удалось изменить платежи", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (IsFullPay())
            {
                MessageBox.Show("Весь курс оплачен успешно", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Information);
                BlockPayment(true);
                UpdateStatus("оплачен");
            }
            else
            {
                BlockPayment(false);
                UpdateStatus("не оплачен");
                MessageBox.Show("Платежи успешно изменены", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }

            LoadData();
            ClearPaidBoxes();
            UpdateUserInterface();
            GlobalData.RecordChanged = true;
        }

        private void UpdateStatus(string status)
        {
            comboBoxPayment.SelectedIndex = comboBoxPayment.Items.IndexOf(status);
        }

        private void BlockPayment(bool needBlock)
        {
            buttonAddPayment.Enabled = !needBlock;
        }

        private void ClearPaidBoxes()
        {
            textBoxSum.Text = string.Empty;
            maskedTextBoxPayDate.Text = string.Empty;
        }

        private bool IsFullPay()
        {
            GetFactPaid();

            return fullPay - factPaid == 0;
        }

        private bool ControlSum(double sumInUpdate = 0.0)
        {
            bool afterUpdate = false;
            double sum = 0.0;

            try
            {
                sum = Convert.ToDouble(textBoxSum.Text);
            }
            catch
            {
                MessageBox.Show("Некорректные данные введены в значении суммы", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }


            if (sumInUpdate < sum)
            {
                sum -= sumInUpdate;
            }
            else
            {
                afterUpdate = true;
            }

            if (sum > factPay && !afterUpdate)
            {
                MessageBox.Show("Вам осталось заплатить за курс меньше, чем " + sum.ToString(), "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private bool AllPaymentFill()
        {
            return maskedTextBoxPayDate.MaskCompleted && textBoxSum.Text != string.Empty;
        }

        private void buttonChange_Click(object sender, EventArgs e)
        {
            if (!AllFieldsIsFill())
            {
                MessageBox.Show("Заполните все обязательные поля, отмеченные символом *", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string group = GlobalData.Group == string.Empty ? null : GlobalData.Group;
            string transferOrder = textBoxTransferOrder.Text == string.Empty ? null : textBoxTransferOrder.Text;
            string dateTransferOrder = !maskedTextBoxTransferDate.MaskCompleted ? null : maskedTextBoxTransferDate.Text;
            string expulsionOrder = textBoxExpulsion.Text == string.Empty ? null : textBoxExpulsion.Text;
            string dateExpulsionOrder = !maskedTextBoxExpulsionDate.MaskCompleted ? null : maskedTextBoxExpulsionDate.Text;

            bool isExecute = sqlClient.UpdateRecord(Convert.ToInt32(primaryKey), group, transferOrder, expulsionOrder,
                (dateTransferOrder != null ? 
                DateTime.Parse(dateTransferOrder).ToString("yyyy-MM-dd") : dateTransferOrder),
                (dateExpulsionOrder != null ? DateTime.Parse(dateExpulsionOrder).ToString("yyyy-MM-dd") : dateExpulsionOrder),
                comboBoxPayment.Text, comboBoxContract.Text, comboBoxEnd.Text, comboBoxCredited.Text,
                DateTime.Parse(maskedTextBoxStart.Text).ToString("yyyy-MM-dd"), DateTime.Parse(maskedTextBoxEnd.Text).ToString("yyyy-MM-dd"));

            if (!isExecute)
            {
                MessageBox.Show("Не удалось обновить контракт", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show("Контракт успешно обновлен", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            UpdateCountInGroup(group);
            ClearFields();
            GlobalData.RecordChanged = true;

            timer.Stop();
            this.Close();
        }

        private void UpdateCountInGroup(string group)
        {
            if (group == null) return;

            bool isExecute = sqlClient.ExecuteRequest("UPDATE listeners.group set countPeople=(SELECT COUNT(*) from record where record.group=listeners.group.id and " +
                "creditedStatus IN(select id from creditedStatus where name != 'отчислен')) where listeners.group.name='" + group + "'");

            if (!isExecute)
            {
                MessageBox.Show("Не удалось обновить количество людей в группе", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }


        private void ClearFields()
        {
            GlobalData.Group = string.Empty;
            GlobalData.IdGroup = 0;
            textBoxTransferOrder.Text = string.Empty;
            textBoxExpulsion.Text = string.Empty;
            maskedTextBoxEnd.Text = string.Empty;
            maskedTextBoxStart.Text = string.Empty;
            comboBoxContract.SelectedIndex = -1;
            comboBoxCredited.SelectedIndex = -1;
            comboBoxEnd.SelectedIndex = -1;
            comboBoxPayment.SelectedIndex = -1;
            ClearInfoAboutGroup();
            maskedTextBoxTransferDate.Text = string.Empty;
            maskedTextBoxExpulsionDate.Text = string.Empty;
        }

        private bool AllFieldsIsFill()
        {
            return maskedTextBoxStart.MaskCompleted && maskedTextBoxEnd.MaskCompleted
                && comboBoxContract.SelectedIndex != -1 && comboBoxCredited.SelectedIndex != -1 &&
                comboBoxPayment.SelectedIndex != -1 && comboBoxEnd.SelectedIndex != -1;
        }

        private void textBoxTransferOrder_Enter(object sender, EventArgs e)
        {
            SwitchToRussianKeyboardLayout();
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
                MessageBox.Show("Некорректно указана дата окончания", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                maskedTextBoxEnd.Text = DateTime.Now.AddDays(1).ToString("dd.MM.yyyy");
                return;
            }

            DateTime minDate = DateTime.Now.AddYears(-1);
            DateTime maxDate = DateTime.Now.AddMonths(6);

            if (end < minDate || end > maxDate)
            {
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

        private void buttonBack_Click(object sender, EventArgs e)
        {
            timer.Stop();
            ClearFields();
            this.Close();
        }

        private void dataGridViewPayments_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var hitTestInfo = dataGridViewPayments.HitTest(e.X, e.Y);

                if (hitTestInfo.RowIndex >= 0)
                {
                    dataGridViewPayments.ClearSelection();
                    dataGridViewPayments.Rows[hitTestInfo.RowIndex].Selected = true;
                    Point point = dataGridViewPayments.PointToScreen(new Point(e.X, e.Y));
                    contextMenuStripDgv.Show(point);
                }
            }
        }

        private void изменитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridViewPayments.SelectedRows.Count == 0) return;

            DataGridViewRow selectedRow = dataGridViewPayments.SelectedRows[0];

            maskedTextBoxPayDate.Text = selectedRow.Cells["Дата оплаты"].Value.ToString();
            textBoxSum.Text = selectedRow.Cells["Оплата"].Value.ToString();
            buttonAddPayment.Text = "Изменить";
            buttonAddPayment.Enabled = true;
        }

        private void dataGridViewPayments_SelectionChanged(object sender, EventArgs e)
        {
            buttonAddPayment.Text = "Внести оплату";
            ClearPaidBoxes();
        }

        private void удалитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridViewPayments.SelectedRows.Count == 0)
            {
                return;
            }

            DialogResult confirmationDeleting = MessageBox.Show("Вы действительно желаете удалить выбранную запись?",
                "Внимание", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);

            if (confirmationDeleting == DialogResult.Cancel || confirmationDeleting == DialogResult.No) return;

            DataGridViewRow selectedRow = dataGridViewPayments.SelectedRows[0];

            List<string> queries = new List<string>();

            queries.Add("DELETE FROM payment where id='"
                + selectedRow.Cells["Номер"].Value.ToString() + "'");

            string statusPay = string.Empty;

            if (IsFullPay())
            {
                statusPay = ", paymentStatus=(SELECT id from paymentStatus where name='оплачен') ";
            }

            queries.Add("UPDATE record set actualPayment= ROUND(COALESCE((SELECT SUM(paid) from payment where record='" + primaryKey + "'), 0), 2)" +
                statusPay + ", modifiedBy='" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "' where record.id='" + primaryKey + "'");

            bool isExecute = sqlClient.ExecuteTransaction(queries);

            if (!isExecute)
            {
                MessageBox.Show("Не удалось удалить платеж", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (IsFullPay())
            {
                MessageBox.Show("Весь курс оплачен успешно", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Information);
                BlockPayment(true);
                UpdateStatus("оплачен");
            }
            else
            {
                BlockPayment(false);
                UpdateStatus("не оплачен");
                MessageBox.Show("Платеж успешно удален", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }

            GlobalData.RecordChanged = true;
            LoadData();
            ClearPaidBoxes();
            UpdateUserInterface();
        }

        private void buttonPrintPayment_Click(object sender, EventArgs e)
        {
            bool isPrint = wordClient.CreateReceipt(primaryKey, primaryKeyListener);

            if (!isPrint)
            {
                MessageBox.Show("Не удалось распечатать платежный документ", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void buttonPrintContract_Click(object sender, EventArgs e)
        {
            if (HaveOrganization())
            {
                if (!wordClient.CreateReportOrganization(primaryKey, primaryKeyListener))
                {
                    MessageBox.Show("Не удалось распечатать договор", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else if (HaveRepresentative())
            {
                if (!wordClient.CreateReportWithRepresentative(primaryKey, primaryKeyListener))
                {
                    MessageBox.Show("Не удалось распечатать договор", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else
            {
                if (!wordClient.CreateReportListener(primaryKey, primaryKeyListener))
                {
                    MessageBox.Show("Не удалось распечатать договор", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
        }

        private void buttonPrintAgreement_Click(object sender, EventArgs e)
        {
            if (!wordClient.CreateReportAgree(primaryKey, primaryKeyListener))
            {
                MessageBox.Show("Не удалось распечатать договор", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private bool HaveRepresentative()
        {
            return !string.IsNullOrEmpty(sqlClient.GetValue("SELECT representative from record where id='" + primaryKey + "'"));
        }

        private bool HaveOrganization()
        {
            return !string.IsNullOrEmpty(sqlClient.GetValue("SELECT organization from record where id='" + primaryKey + "'"));
        }
    }
}
