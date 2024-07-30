using Listeners.DatabaseHelper;
using Listeners.ExcelHelper;
using Listeners.Forms.MainMenu.Manager;
using Listeners.Forms.Roles.Manager;
using Listeners.Forms.Roles.Secretary.Record;
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

namespace Listeners.MainMenu.Manager
{
    public partial class ManagerMenuView : Form
    {
        private Timer timer;
        private DateTime lastActivityTime;
        private ManagerMenuController managerMenuController;
        private MySqlClient sqlClient;
        private ExcelClient excelClient;
        public ManagerMenuView()
        {
            InitializeComponent();
            managerMenuController = new ManagerMenuController(this);
            lastActivityTime = DateTime.Now;
            ResetTimer();
            ShowUser();
            sqlClient = new MySqlClient();
            FillComboBox();
            excelClient = new ExcelClient();
        }
        private void ShowUser()
        {
            labelUser.Text = GlobalData.Employee.Role + " " + GlobalData.Employee.Surname + " "
                + (GlobalData.Employee.Name.Length > 0 ? GlobalData.Employee.Name[0] + ". " : " ")
                + (GlobalData.Employee.Patronymic.Length > 0 ? GlobalData.Employee.Patronymic[0] + "." : "");
        }

        private void FillComboBox()
        {
            comboBoxGroup.Items.AddRange(sqlClient.FillComboBox("SELECT listeners.group.name from listeners.group"));
        }

        private void ManagerMenu_MouseMove(object sender, MouseEventArgs e)
        {
            lastActivityTime = DateTime.Now;
        }

        private void ManagerMenu_KeyPress(object sender, KeyPressEventArgs e)
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
            managerMenuController.ActivityControl(lastActivityTime);
        }

        public void StartLoginForm()
        {
            timer.Stop();
            this.Hide();
            AuthorizationView authorizationView = new AuthorizationView();
            authorizationView.ShowDialog();
        }

        private void buttonContracts_Click(object sender, EventArgs e)
        {
            timer.Stop();
            this.Hide();
            RecordView recordView = new RecordView();
            recordView.ShowDialog();
        }

        private void buttonReports_Click(object sender, EventArgs e)
        {
            timer.Stop();
            this.Hide();
            Report report = new Report();
            report.ShowDialog();
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            StartLoginForm();
        }

        private void buttonReportFRDO_Click(object sender, EventArgs e)
        {
            BlockElements(true);
            groupBoxGroup.Visible = true;
        }

        private void buttonReport_Click(object sender, EventArgs e)
        {
            string course = sqlClient.GetValue("SELECT qualification.name from record join course on record.course = course.id join qualification" +
                " on course.qualification=qualification.id where record.group=" +
                "(select id from listeners.group where name='" + comboBoxGroup.Text + "')");

            if (course == "курсы по профессиям")
            {
                if (!excelClient.CreatePatternDpo(comboBoxGroup.Text))
                {
                    MessageBox.Show("Не удалось распечатать отчет", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else
            {
                if (!excelClient.CreatePatternPo(comboBoxGroup.Text))
                {
                    MessageBox.Show("Не удалось распечатать отчет", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
        }

        private void BlockElements(bool needBlock)
        {
            foreach (Control control in this.Controls)
            {
                if (control is GroupBox) continue;

                control.Enabled = !needBlock;
            }
        }

        private void buttonHide_Click(object sender, EventArgs e)
        {
            BlockElements(false);
            groupBoxGroup.Visible = false;
            comboBoxGroup.SelectedIndex = -1;
        }

        private void comboBoxGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            buttonReport.Enabled = comboBoxGroup.SelectedIndex != 1;
        }
    }
}
