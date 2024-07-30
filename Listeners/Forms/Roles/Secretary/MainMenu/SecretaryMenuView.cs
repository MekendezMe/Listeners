using Listeners.DatabaseHelper;
using Listeners.ExcelHelper;
using Listeners.Forms.MainMenu.Secretary;
using Listeners.Forms.Roles.Secretary.AboutOrganization;
using Listeners.Forms.Roles.Secretary.Course;
using Listeners.Forms.Roles.Secretary.Directories;
using Listeners.Forms.Roles.Secretary.Group;
using Listeners.Forms.Roles.Secretary.Listener;
using Listeners.Forms.Roles.Secretary.Organization;
using Listeners.Forms.Roles.Secretary.Record;
using Listeners.Forms.Roles.Secretary.Representative;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Listeners.MainMenu.Secretary
{
    public partial class SecretaryMenuView : Form
    {
        private Timer timer;
        private DateTime lastActivityTime;
        private SecretaryMenuController secretaryMenuController;
        private MySqlClient sqlClient;
        private ExcelClient excelClient;
        public SecretaryMenuView()
        {
            InitializeComponent();
            secretaryMenuController = new SecretaryMenuController(this);
            lastActivityTime = DateTime.Now;
            sqlClient = new MySqlClient();
            excelClient = new ExcelClient();
            ResetTimer();
            ShowUser();
            FillComboBox();
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

        private void SecretaryMenu_MouseMove(object sender, MouseEventArgs e)
        {
            lastActivityTime = DateTime.Now;
        }

        private void SecretaryMenu_KeyPress(object sender, KeyPressEventArgs e)
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
            secretaryMenuController.ActivityControl(lastActivityTime);
        }

        public void StartLoginForm()
        {
            timer.Stop();
            this.Hide();
            AuthorizationView authorizationView = new AuthorizationView();
            authorizationView.ShowDialog();
        }

        private void buttonListeners_Click(object sender, EventArgs e)
        {
            timer.Stop();
            this.Hide();
            ListenerView listener = new ListenerView();
            listener.ShowDialog();

        }

        private void buttonRecords_Click(object sender, EventArgs e)
        {
            timer.Stop();
            this.Hide();
            RecordView recordView = new RecordView();
            recordView.ShowDialog();
        }

        private void buttonDirectory_Click(object sender, EventArgs e)
        {
            timer.Stop();
            this.Hide();
            SelectDirectory selectDirectory = new SelectDirectory();
            selectDirectory.ShowDialog();
        }

        private void buttonAuthorization_Click(object sender, EventArgs e)
        {
            StartLoginForm();
        }

        private void buttonReportFRDO_Click(object sender, EventArgs e)
        {
            BlockElements(true);
            groupBoxGroup.Visible = true;
        }

        private void BlockElements(bool needBlock)
        {
            foreach (Control control in this.Controls)
            {
                if (control is GroupBox) continue;

                control.Enabled = !needBlock;
            }
        }

        private void comboBoxGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            buttonReport.Enabled = comboBoxGroup.SelectedIndex != 1;
        }

        private void buttonHide_Click(object sender, EventArgs e)
        {
            BlockElements(false);
            groupBoxGroup.Visible = false;
            comboBoxGroup.SelectedIndex = -1;
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
    }
}
