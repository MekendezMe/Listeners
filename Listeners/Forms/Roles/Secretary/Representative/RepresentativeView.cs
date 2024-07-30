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

namespace Listeners.Forms.Roles.Secretary.Representative
{
    public partial class RepresentativeView : Form
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
        public RepresentativeView(bool fromRecord = false)
        {
            InitializeComponent();
            lastActivityTime = DateTime.Now;
            ShowUser();
            ResetTimer();
            this.fromRecord = fromRecord;
            sqlClient = new MySqlClient();
            sort = " order by surname ASC ";
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
                countPages = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(sqlClient.GetValue("SELECT COUNT(*) from representative " + search + sort)) / 7));
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
                countRows = Convert.ToInt32(sqlClient.GetValue("SELECT COUNT(*) from representative " + search + sort));
            }
            catch
            {
                MessageBox.Show("Не удалось произвести работу с базой данных", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadData()
        {
            dataGridViewRepresentatives.DataSource = sqlClient.GetDataTable("SELECT id AS 'Номер', surname AS 'Фамилия'," +
                "name AS 'Имя', patronymic AS 'Отчество', address AS 'Адрес', phone AS 'Телефон'," +
                " (SELECT concat_ws(' ', surname, name, patronymic) from listener where listener.id=representative.idListener) AS 'Слушатель' " +
                " from representative " + search + sort +
                " LIMIT 7 OFFSET " + ((currentPage - 1) * Constants.COUNT_ROWS_IN_PAGE));

            if (dataGridViewRepresentatives.Rows.Count > 0)
            {
                dataGridViewRepresentatives.Columns["Номер"].Visible = false;
                countRowsInPage = dataGridViewRepresentatives.Rows.Count;
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
            if (!char.IsLetter(e.KeyChar) && e.KeyChar != '-' && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
                return;
            }

            TextBox textBox = sender as TextBox;

            if (e.KeyChar == '-' && textBox.Text.Length == 0)
            {
                e.Handled = true;
                return;
            }

            if (textBox.Text.Length == 0 ||
                textBox.Text.Length > 0 && textBox.Text[textBox.Text.Length - 1] == '-')
            {
                e.KeyChar = char.ToUpper(e.KeyChar);
            }
        }

        private void textBoxSearch_Enter(object sender, EventArgs e)
        {
            SwitchToRussianKeyboardLayout();
        }

        private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {
            currentPage = Constants.START_CURRENT_PAGE;

            if (textBoxSearchListener.Text != string.Empty)
            {
                search = " ORDER BY CASE WHEN surname='"
                    + textBoxSearch.Text + "' THEN 0 when surname LIKE '" + textBoxSearch.Text + "%' THEN 1 ELSE 2 END, " +
                    "CASE WHEN idListener IN(SELECT id from listener where concat_ws(' ', surname, name, patronymic)='"
                    + textBoxSearchListener.Text + "') THEN 0 WHEN idListener IN(SELECT id from listener where concat_ws" +
                    "(' ', surname, name, patronymic) LIKE '" + textBoxSearchListener.Text + "%') THEN 1 ELSE 2 END";
            }
            else
            {
                search = " ORDER BY CASE WHEN surname='" + textBoxSearch.Text + "'" +
                    " THEN 0 when surname LIKE '" + textBoxSearch.Text + "%' THEN 1 ELSE 2 END";
            }

            sort = ", surname ASC ";

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
                var hitTestInfo = dataGridViewRepresentatives.HitTest(e.X, e.Y);

                if (hitTestInfo.RowIndex >= 0)
                {
                    dataGridViewRepresentatives.ClearSelection();
                    dataGridViewRepresentatives.Rows[hitTestInfo.RowIndex].Selected = true;
                    Point point = dataGridViewRepresentatives.PointToScreen(new Point(e.X, e.Y));
                    contextMenuStripDgv.Show(point);
                }
            }
        }

        private void редактированиеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridViewRepresentatives.SelectedRows.Count == 0)
            {
                return;
            }

            DataGridViewRow selectedRow = dataGridViewRepresentatives.SelectedRows[0];

            timer.Stop();
            RepresentativeChangerView representativeChanger =
                new RepresentativeChangerView(selectedRow.Cells["Номер"].Value.ToString(), true);
            representativeChanger.FormClosed += RepresentativeChangerView_FormClosed;
            representativeChanger.ShowDialog();
        }

        private void ResetConditions()
        {
            sort = string.Empty;
            search = string.Empty;
            currentPage = 1;
            LoadData();
            UpdateUserInterface();
        }

        private void RepresentativeChangerView_FormClosed(object sender, FormClosedEventArgs e)
        {
            UpdateAfterChanging();
        }

        private void UpdateAfterChanging()
        {
            timer.Start();

            if (!GlobalData.RepresentativeChanged && !GlobalData.RepresentativeCreated)
            {
                return;
            }

            ResetConditions();

            if (GlobalData.RepresentativeChanged)
            {
                sort = " order by modifiedBy desc ";
            }

            if (GlobalData.RepresentativeCreated)
            {
                sort = " order by representative.id desc ";
            }

            GlobalData.RepresentativeChanged = false;
            GlobalData.RepresentativeCreated = false;

            LoadData();
            UpdateUserInterface();
        }

        private void StartCreateForm(bool fromRecord = false)
        {
            timer.Stop();
            RepresentativeChangerView representativeChanger = new RepresentativeChangerView(fromRecord: fromRecord);
            representativeChanger.FormClosed += RepresentativeChangerView_FormClosed;
            representativeChanger.ShowDialog();
        }

        private void buttonCreateGroup_Click(object sender, EventArgs e)
        {
            StartCreateForm();
        }

        private bool CanDelete(string primaryKey)
        {
            return Convert.ToInt32(sqlClient.GetValue("SELECT COUNT(*) from record where record.representative IN('" + primaryKey + "')")) > 0;
        }

        private void удалениеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridViewRepresentatives.SelectedRows.Count == 0)
            {
                return;
            }

            DataGridViewRow selectedRow = dataGridViewRepresentatives.SelectedRows[0];
            string primaryKey = selectedRow.Cells["Номер"].Value.ToString();

            if (CanDelete(primaryKey))
            {
                MessageBox.Show("Невозможно удалить законного представителя, который содержится в договорах", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult confirmationDeleting = MessageBox.Show("Вы действительно желаете удалить выбранную запись?",
                "Внимание", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);

            if (confirmationDeleting == DialogResult.Cancel || confirmationDeleting == DialogResult.No) return;



            bool isExecute = sqlClient.ExecuteRequest("DELETE FROM representative where id='"
                + primaryKey + "'");

            if (!isExecute)
            {
                MessageBox.Show("Не удалось удалить законного представителя", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show("Удаление законного представителя успешно", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

            LoadData();
            UpdateUserInterface();
        }

        private void buttonTake_Click(object sender, EventArgs e)
        {
            if (dataGridViewRepresentatives.SelectedRows.Count == 0) return;

            string value = sqlClient.GetValue("SELECT surname from representative where idListener='" + GlobalData.IdListener + "' and " +
                "id='" + dataGridViewRepresentatives.SelectedRows[0].Cells["Номер"].Value.ToString() + "'");

            if (value.Length == 0)
            {
                MessageBox.Show("Данный представитель относится к другому слушателю", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            OnDestroyForm();
        }

        private void OnDestroyForm()
        {
            try
            {
                GlobalData.IdRepresentative = Convert.ToInt32(dataGridViewRepresentatives.SelectedRows[0].Cells["Номер"].Value.ToString());
            }
            catch
            {
                MessageBox.Show("Не удалось получить представителя", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
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
            if (dataGridViewRepresentatives.SelectedRows.Count < 1)
            {
                buttonTake.Enabled = false;
                return;
            }

            if (fromRecord)
            {
                buttonTake.Enabled = true;
            }
        }

        private void textBoxSearchListener_TextChanged(object sender, EventArgs e)
        {
            sort = string.Empty;
            currentPage = Constants.START_CURRENT_PAGE;

            if (textBoxSearch.Text != string.Empty)
            {
                search = " ORDER BY CASE WHEN surname='"
                    + textBoxSearch.Text + "' THEN 0 when surname LIKE '" + textBoxSearch.Text + "%' THEN 1 ELSE 2 END, " +
                    "CASE WHEN idListener IN(SELECT id from listener where concat_ws(' ', surname, name, patronymic)='"
                    + textBoxSearchListener.Text + "') THEN 0 WHEN idListener IN(SELECT id from listener where concat_ws" +
                    "(' ', surname, name, patronymic) LIKE '" + textBoxSearchListener.Text + "%') THEN 1 ELSE 2 END";
            }
            else
            {
                search = " ORDER BY CASE WHEN idListener IN(SELECT id from listener where concat_ws(' ', surname, name, patronymic)='"
                    + textBoxSearchListener.Text + "') THEN 0 WHEN idListener IN(SELECT id from listener where concat_ws" +
                    "(' ', surname, name, patronymic) LIKE '" + textBoxSearchListener.Text + "%') THEN 1 ELSE 2 END";
            }

            sort = ", surname ASC ";

            LoadData();
            UpdateUserInterface();
        }
    }
}
