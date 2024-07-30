using Listeners.DatabaseHelper;
using Listeners.Forms.Roles.Secretary.Directories;
using Listeners.Forms.Roles.Secretary.Group;
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

namespace Listeners.Forms.Roles.Secretary.Organization
{
    public partial class OrganizationView : Form
    {
        private string sort = string.Empty;
        private string search = string.Empty;
        private int currentPage = Constants.START_CURRENT_PAGE;
        private int countRowsInPage = 0;
        private int countPages = 0;
        private int countRows = 0;
        private MySqlClient sqlClient;
        private Timer timer;
        private DateTime lastActivityTime;
        bool fromRecord = false;
        public OrganizationView(bool fromRecord = false)
        {
            InitializeComponent();
            lastActivityTime = DateTime.Now;
            ShowUser();
            ResetTimer();
            this.fromRecord = fromRecord;
            sqlClient = new MySqlClient();
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
                countPages = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(sqlClient.GetValue("SELECT COUNT(*) from organization " + search + sort)) / 7));
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
                countRows = Convert.ToInt32(sqlClient.GetValue("SELECT COUNT(*) from organization " + search + sort));
            }
            catch
            {
                MessageBox.Show("Не удалось произвести работу с базой данных", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void HidePersonalData()
        {
            foreach (DataGridViewColumn column in dataGridViewOrganizations.Columns)
            {
                if (column.Name == "ИНН")
                {
                    column.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                    column.Width = 84;
                }
                else if (column.Name == "КПП")
                {
                    column.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                    column.Width = 70;
                }
                else if (column.Name == "БИК")
                {
                    column.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                    column.Width = 70;
                }
                else if (column.Name == "Ответственное лицо")
                {
                    column.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                    column.Width = 95;
                }
                else if (column.Name == "Лиц. счет")
                {
                    column.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                    column.Width = 200;
                }
                else if (column.Name == "Расс. счет")
                {
                    column.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                    column.Width = 200;
                }
                else if (column.Name == "Название")
                {
                    column.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                    column.Width = 100;
                }
                else if (column.Name == "Реквизиты")
                {
                    column.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                    column.Width = 200;
                }
            }

            foreach (DataGridViewRow row in dataGridViewOrganizations.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    if (cell.OwningColumn.Name == "ИНН")
                    {
                        cell.Value = cell.Value.ToString().Substring(0, 4) + "******" + cell.Value.ToString().Substring(cell.Value.ToString().Length - 2);
                    }
                    else if (cell.OwningColumn.Name == "КПП")
                    {
                        cell.Value = cell.Value.ToString().Substring(0, 3) + "****" + cell.Value.ToString().Substring(cell.Value.ToString().Length - 2);
                    }
                    else if (cell.OwningColumn.Name == "БИК")
                    {
                        cell.Value = cell.Value.ToString().Substring(0, 3) + "****" + cell.Value.ToString().Substring(cell.Value.ToString().Length - 2);
                    }
                }
            }

            dataGridViewOrganizations.Columns[0].Visible = false;
        }

        private void LoadData()
        {
            dataGridViewOrganizations.DataSource = sqlClient.GetDataTable("SELECT id AS 'Номер', name AS 'Название'," +
                "requisites AS 'Реквизиты', inn AS 'ИНН', kpp AS 'КПП', bik AS 'БИК', personalAccount AS 'Лиц. счет'," +
                "paymentAccount AS 'Расс. счет', " +
                "director AS 'Ответственное лицо', bank AS 'Банк' " +
                " from organization " + search + sort +
                " LIMIT 7 OFFSET " + ((currentPage - 1) * Constants.COUNT_ROWS_IN_PAGE));

            if (dataGridViewOrganizations.Rows.Count > 0 && dataGridViewOrganizations.Rows.Count > 0)
            {
                dataGridViewOrganizations.Columns["Номер"].Visible = false;
                countRowsInPage = dataGridViewOrganizations.Rows.Count;
            }

            if (dataGridViewOrganizations.Rows.Count == 0)
            {
                MessageBox.Show("Записей не найдено", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            HidePersonalData();
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

        private void maskedTextBoxINN_Click(object sender, EventArgs e)
        {
            MaskedTextBox maskedTextBox = (MaskedTextBox)sender;

            maskedTextBox.Select(0, 0);
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

        private void dataGridViewOrganizations_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var hitTestInfo = dataGridViewOrganizations.HitTest(e.X, e.Y);

                if (hitTestInfo.RowIndex >= 0)
                {
                    dataGridViewOrganizations.ClearSelection();
                    dataGridViewOrganizations.Rows[hitTestInfo.RowIndex].Selected = true;
                    Point point = dataGridViewOrganizations.PointToScreen(new Point(e.X, e.Y));
                    contextMenuStripDgv.Show(point);
                }
            }
        }

        private void UpdateAfterChanging()
        {
            timer.Start();

            if (!GlobalData.OrganizationChanged && !GlobalData.OrganizationCreated)
            {
                return;
            }

            ResetConditions();

            if (GlobalData.OrganizationChanged)
            {
                sort = " order by modifiedBy desc ";
            }

            if (GlobalData.OrganizationCreated)
            {
                sort = " order by organization.id desc ";
            }
            GlobalData.OrganizationChanged = false;
            GlobalData.OrganizationCreated = false;

            LoadData();
            UpdateUserInterface();
        }

        private void dataGridViewOrganizations_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewOrganizations.SelectedRows.Count < 1)
            {
                buttonTake.Enabled = false;
                return;
            }

            if (fromRecord)
            {
                buttonTake.Enabled = true;
            }
        }

        private void ResetConditions()
        {
            search = string.Empty;
            currentPage = 1;
            LoadData();
            UpdateUserInterface();
        }

        private void textBoxSearchTitle_TextChanged(object sender, EventArgs e)
        {
            sort = string.Empty;
            currentPage = Constants.START_CURRENT_PAGE;

            if (maskedTextBoxINN.Text != string.Empty)
            {
                search = " ORDER BY CASE WHEN name='" + textBoxSearchTitle.Text + "' THEN 0 when name LIKE '%"
                    + textBoxSearchTitle.Text + "%' THEN 1 ELSE 2 END, CASE when inn='" + maskedTextBoxINN.Text + "' THEN 0 when inn LIKE '" +
                    maskedTextBoxINN.Text + "%' THEN 1 ELSE 2 END";
            }
            else
            {
                search = " ORDER BY CASE WHEN name='" + textBoxSearchTitle.Text + "' THEN 0 when name LIKE '%"
                    + textBoxSearchTitle.Text + "%' THEN 1 ELSE 2 END ";
            }

            LoadData();
            UpdateUserInterface();
        }

        private void textBoxSearchTitle_Enter(object sender, EventArgs e)
        {
            SwitchToRussianKeyboardLayout();
        }

        private void textBoxSearchTitle_KeyPress(object sender, KeyPressEventArgs e)
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

        private void maskedTextBoxINN_TextChanged(object sender, EventArgs e)
        {
            sort = string.Empty;
            currentPage = Constants.START_CURRENT_PAGE;

            if (textBoxSearchTitle.Text != string.Empty)
            {
                search = " ORDER BY CASE WHEN name='" + textBoxSearchTitle.Text + "' THEN 0 when name LIKE '%"
                    + textBoxSearchTitle.Text + "%' THEN 1 ELSE 2 END, CASE when inn='" + maskedTextBoxINN.Text + "' THEN 0 when inn LIKE '" +
                    maskedTextBoxINN.Text + "%' THEN 1 ELSE 2 END";
            }
            else
            {
                search = " ORDER BY CASE WHEN inn='" + maskedTextBoxINN.Text + "' THEN 0 when inn LIKE '"
                    + maskedTextBoxINN.Text + "%' THEN 1 ELSE 2 END ";
            }

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

        private void редактированиеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridViewOrganizations.SelectedRows.Count == 0)
            {
                return;
            }

            DataGridViewRow selectedRow = dataGridViewOrganizations.SelectedRows[0];

            timer.Stop();
            OrganizationChangerView organizationChanger = new OrganizationChangerView(selectedRow.Cells["Номер"].Value.ToString(), true);
            organizationChanger.FormClosed += OrganizationChanger_FormClosed;
            organizationChanger.ShowDialog();
        }

        private bool CanDelete(string primaryKey)
        {
            return Convert.ToInt32(sqlClient.GetValue("SELECT COUNT(*) from record where record.organization IN('" + primaryKey + "')")) > 0;
        }

        private void удалениеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridViewOrganizations.SelectedRows.Count == 0)
            {
                return;
            }

            DataGridViewRow selectedRow = dataGridViewOrganizations.SelectedRows[0];
            string primaryKey = selectedRow.Cells["Номер"].Value.ToString();

            if (CanDelete(primaryKey) || int.Parse(primaryKey) == Constants.ID_ZAMT)
            {
                MessageBox.Show("Невозможно удалить организацию, которая содержится в договорах", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult confirmationDeleting = MessageBox.Show("Вы действительно желаете удалить выбранную запись?",
                "Внимание", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);

            if (confirmationDeleting == DialogResult.Cancel || confirmationDeleting == DialogResult.No) return;

            

            bool isExecute = sqlClient.ExecuteRequest("DELETE FROM organization where id='"
                + primaryKey + "'");

            if (!isExecute)
            {
                MessageBox.Show("Не удалось удалить организацию", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show("Удаление организации успешно", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

            LoadData();
            UpdateUserInterface();
        }

        private void buttonCreateOrganization_Click(object sender, EventArgs e)
        {
            timer.Stop();
            OrganizationChangerView organizationChanger = new OrganizationChangerView();
            organizationChanger.FormClosed += OrganizationChanger_FormClosed;
            organizationChanger.ShowDialog();
        }

        private void OrganizationChanger_FormClosed(object sender, FormClosedEventArgs e)
        {
            UpdateAfterChanging();
        }

        private void buttonTake_Click(object sender, EventArgs e)
        {
            GlobalData.IdOrganization = Convert.ToInt32(dataGridViewOrganizations.SelectedRows[0].Cells["Номер"].Value.ToString());
            timer.Stop();
            this.Close();
            buttonTake.Enabled = false;
        }
    }
}
