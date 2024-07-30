using Listeners.DatabaseHelper;
using Listeners.Enums;
using Listeners.Forms.MainMenu.Secretary;
using Listeners.Forms.Roles.Secretary.Course.CourseRecording;
using Listeners.Forms.Roles.Secretary.Listener.ListenerCreater;
using Listeners.Forms.Roles.Secretary.Listener.ListenerUpdater;
using Listeners.MainMenu.Secretary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Listeners.Forms.Roles.Secretary.Listener
{
    public partial class ListenerView : Form
    {
        private Timer timer;
        private DateTime lastActivityTime;
        private ListenerController listenerController;
        Pagination pagination = Pagination.None;
        bool fromRecord;
        bool fromRepresentative;
        public ListenerView(bool fromRecord = false, bool fromRepresentative = false)
        {
            InitializeComponent();
            listenerController = new ListenerController(this);
            lastActivityTime = DateTime.Now;
            ResetTimer();
            ShowUser();
            this.fromRecord = fromRecord;
            this.fromRepresentative = fromRepresentative;
            LoadData();
            ControlParent();
            FillComboBox();
            HidePersonalData();
        }

        private void ControlParent()
        {
            if (fromRecord || fromRepresentative)
            {
                buttonTake.Visible = true;
                buttonBack.Text = "Вернуться к записи";
            }
        }

        public void HidePersonalData()
        {

            foreach (DataGridViewColumn column in dataGridViewListeners.Columns)
            {
                if (column.Name == "Серия")
                {
                    column.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                    column.Width = 60;
                }
                else if (column.Name == "Номер")
                {
                    column.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                    column.Width = 60;
                }
                else if (column.Name == "СНИЛС")
                {
                    column.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                    column.Width = 84;
                }
                else if (column.Name == "Дата рождения")
                {
                    column.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                    column.Width = 78;
                }
                else if (column.Name == "Фамилия")
                {
                    column.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                    column.Width = 105;
                }
                else if (column.Name == "Имя")
                {
                    column.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                    column.Width = 105;
                }
                else if (column.Name == "Отчество")
                {
                    column.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                    column.Width = 105;
                }
                else if (column.Name == "Телефон")
                {
                    column.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                    column.Width = 120;
                }
                else if (column.Name == "Пол")
                {
                    column.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                    column.Width = 70;
                }
                else if (column.Name == "Занятость")
                {
                    column.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                    column.Width = 85;
                }
            }

            foreach (DataGridViewRow row in dataGridViewListeners.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    if (cell.OwningColumn.Name == "Телефон")
                    {
                        cell.Value = cell.Value.ToString().Substring(0, 7) + "*******" + cell.Value.ToString().Substring(cell.Value.ToString().Length - 3);
                    }
                    else if (cell.OwningColumn.Name == "Серия")
                    {
                        cell.Value = cell.Value.ToString().Substring(0, 1) + "**" + cell.Value.ToString().Substring(cell.Value.ToString().Length - 1);
                    }
                    else if (cell.OwningColumn.Name == "Номер")
                    {
                        cell.Value = cell.Value.ToString().Substring(0, 2) + "***" + cell.Value.ToString().Substring(cell.Value.ToString().Length - 1);
                    }
                    else if (cell.OwningColumn.Name == "СНИЛС")
                    {
                        cell.Value = cell.Value.ToString().Substring(0, 2) + "*******" + cell.Value.ToString().Substring(cell.Value.ToString().Length - 2);
                    }
                }
            }

            if (dataGridViewListeners.Rows.Count > 0)
            {
                dataGridViewListeners.Columns[0].Visible = false;
            }
        }

        private void FillComboBox()
        {
            string[] groups = listenerController.GetAllGroups();

            for (int i = 0; i < groups.Length; i++)
            {
                comboBoxFilter.Items.Add(groups[i]);
            }
        }

        public void LoadData(bool rowCreated = false, bool rowUpdated = false)
        {
            listenerController.GetListeners(textBoxSearch.Text, comboBoxFilter.Text, comboBoxFilter.SelectedIndex, comboBoxSort.Text,
                comboBoxSort.SelectedIndex, pagination, rowCreated, rowUpdated);
        }

        public void ShowData(DataTable listeners, int countRowsInPage, int countRows, int currentPage, int countPages)
        {
            labelPage.Text = currentPage.ToString() + "/" + (countPages == 0 ? "1" : countPages.ToString());
            labelCountRows.Text = countRowsInPage.ToString() + "/" + countRows.ToString();
            dataGridViewListeners.DataSource = listeners;

            if (dataGridViewListeners.Columns.Count > 0 && dataGridViewListeners.Rows.Count > 0)
            {
                dataGridViewListeners.Columns[0].Visible = false;
            }

            if (dataGridViewListeners.Rows.Count == 0)
            {
                MessageBox.Show("Записей не найдено", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Information);
                BlockNextPagesButton(true);
                BlockPreviousPagesButton(true);
                return;
            }

            HidePersonalData();
        }

        private void ShowUser()
        {
            labelUser.Text = GlobalData.Employee.Role + " " + GlobalData.Employee.Surname + " "
                + (GlobalData.Employee.Name.Length > 0 ? GlobalData.Employee.Name[0] + ". " : " ")
                + (GlobalData.Employee.Patronymic.Length > 0 ? GlobalData.Employee.Patronymic[0] + "." : "");
        }

        private void ListenerView_MouseMove(object sender, MouseEventArgs e)
        {
            lastActivityTime = DateTime.Now;
        }

        private void ListenerView_KeyPress(object sender, KeyPressEventArgs e)
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
            listenerController.ActivityControl(lastActivityTime);
        }

        public void StartLoginForm()
        {
            timer.Stop();
            this.Hide();
            AuthorizationView authorizationView = new AuthorizationView();
            authorizationView.ShowDialog();
        }

        private void buttonFirst_Click(object sender, EventArgs e)
        {
            pagination = Pagination.FirstPage;
            LoadData();
        }

        private void buttonPrevious_Click(object sender, EventArgs e)
        {
            pagination = Pagination.PreviousPage;
            LoadData();
        }

        private void buttonNext_Click(object sender, EventArgs e)
        {
            pagination = Pagination.NextPage;
            LoadData();
        }

        private void buttonLast_Click(object sender, EventArgs e)
        {
            pagination = Pagination.LastPage;
            LoadData();
        }

        public void ShowMessage(string message, string title, MessageBoxIcon icon)
        {
            MessageBox.Show(message, title, MessageBoxButtons.OK, icon);
        }

        public void BlockNextPagesButton(bool needEnabled)
        {
            buttonNext.Enabled = !needEnabled;
            buttonLast.Enabled = !needEnabled;
        }

        public void BlockPreviousPagesButton(bool needEnabled)
        {
            buttonPrevious.Enabled = !needEnabled;
            buttonFirst.Enabled = !needEnabled;
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            timer.Stop();
            if (!fromRecord)
            {
                this.Hide();
                SecretaryMenuView secretaryMenuView = new SecretaryMenuView();
                secretaryMenuView.ShowDialog();
                return;
            }
            this.Close();
        }

        private void buttonCreate_Click(object sender, EventArgs e)
        {
            timer.Stop();
            ListenerCreaterView listenerCreaterView = new ListenerCreaterView();

            listenerCreaterView.FormClosed += ListenerCreaterView_FormClosed;

            listenerCreaterView.ShowDialog();
        }

        private void ListenerUpdaterView_FormClosed(object sender, FormClosedEventArgs e)
        {
            timer.Start();
            if (GlobalData.ListenerChanged)
            {
                ResetConditions(true, rowUpdated: true);
            }
        }

        private void ListenerCreaterView_FormClosed(object sender, FormClosedEventArgs e)
        {
            timer.Start();
            if (GlobalData.ListenerCreated)
            {
                ResetConditions(true, rowCreated: true);
            }
        }

        private void textBoxSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '\b')
            {
                e.Handled = true;
            }
        }

        private void comboBoxFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxFilter.SelectedItem == null) return;

            pagination = Pagination.None;
            LoadData();
        }

        private void comboBoxSort_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxSort.SelectedItem == null) return;

            pagination = Pagination.None;
            LoadData();
        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            ResetConditions(true);
        }

        public void ResetConditions(bool afterCondition, bool rowCreated = false, bool onlySearch = false, bool rowUpdated = false)
        {
            if (onlySearch)
            {
                textBoxSearch.Text = string.Empty;
            }
            else
            {
                comboBoxFilter.SelectedIndex = -1;
                comboBoxSort.SelectedIndex = -1;
                pagination = Pagination.FirstPage;
                textBoxSearch.Text = string.Empty;
            }

            if (afterCondition)
            {
                LoadData(rowCreated, rowUpdated);
            }

        }

        private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {
            if (textBoxSearch.Text.Length < 3) return;

            LoadData();
        }

        private void редактированиеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridViewListeners.SelectedRows.Count <= 0)
            {
                return;
            }

            DataGridViewRow selectedRow = dataGridViewListeners.SelectedRows[0];

            timer.Stop();
            ListenerUpdaterView listenerUpdaterView = new ListenerUpdaterView(selectedRow.Cells[0].Value.ToString());
            listenerUpdaterView.FormClosed += ListenerUpdaterView_FormClosed;
            listenerUpdaterView.ShowDialog();
        }

        private void dataGridViewListeners_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var hitTestInfo = dataGridViewListeners.HitTest(e.X, e.Y);

                if (hitTestInfo.RowIndex >= 0)
                {
                    dataGridViewListeners.ClearSelection();
                    dataGridViewListeners.Rows[hitTestInfo.RowIndex].Selected = true;
                    Point point = dataGridViewListeners.PointToScreen(new Point(e.X, e.Y));
                    contextMenuStripDgv.Show(point);
                }
            }
        }

        private void удалениеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult confirmationDeleting = MessageBox.Show("Вы действительно желаете удалить выделенного слушателя?", "Внимание", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

            if (confirmationDeleting == DialogResult.No || confirmationDeleting == DialogResult.Cancel)
            {
                return;
            }

            if (dataGridViewListeners.SelectedRows.Count <= 0)
            {
                return;
            }

            var selectedRow = dataGridViewListeners.SelectedRows[0];

            string primaryKey = selectedRow.Cells[0].Value.ToString();

            listenerController.DeleteRow(primaryKey);
        }

        private void записьНаКурсToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridViewListeners.SelectedRows.Count <= 0)
            {
                return;
            }

            var selectedRow = dataGridViewListeners.SelectedRows[0];

            string primaryKey = selectedRow.Cells[0].Value.ToString();

            GlobalData.IdListener = Convert.ToInt32(primaryKey);

            timer.Stop();
            this.Hide();
            CourseRecordingView courseRecordingView = new CourseRecordingView(primaryKey);
            courseRecordingView.ShowDialog();
        }

        private void dataGridViewListeners_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewListeners.SelectedRows.Count < 1)
            {
                buttonTake.Enabled = false;
                return;
            }

            if (fromRecord || fromRepresentative)
            {
                buttonTake.Enabled = true;
            }
        }

        private void buttonTake_Click(object sender, EventArgs e)
        {
            var selectedRow = dataGridViewListeners.SelectedRows[0];
            string primaryKey = selectedRow.Cells[0].Value.ToString();

            if (fromRecord)
            {
                GlobalData.IdListener = Convert.ToInt32(primaryKey);
            }
            else if (fromRepresentative)
            {
                GlobalData.IdListenerForRepresentative = Convert.ToInt32(primaryKey);
            }

            timer.Stop();
            this.Close();
            buttonTake.Enabled = false;
        }
    }
}
