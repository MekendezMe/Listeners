using Listeners.Forms.Roles.Secretary.AboutOrganization;
using Listeners.Forms.Roles.Secretary.Course;
using Listeners.Forms.Roles.Secretary.Group;
using Listeners.Forms.Roles.Secretary.Organization;
using Listeners.Forms.Roles.Secretary.Representative;
using Listeners.MainMenu.Secretary;
using Listeners.MainMenu.SysAdmin;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Listeners.Forms.Roles.Secretary.Directories
{
    public partial class SelectDirectory : Form
    {
        private Timer timer;
        private DateTime lastActivityTime;
        public SelectDirectory()
        {
            InitializeComponent();
            lastActivityTime = DateTime.Now;
            ShowUser();
            ResetTimer();
        }

        private void ShowUser()
        {
            labelUser.Text = GlobalData.Employee.Role + " " + GlobalData.Employee.Surname + " "
                + (GlobalData.Employee.Name.Length > 0 ? GlobalData.Employee.Name[0] + ". " : " ")
                + (GlobalData.Employee.Patronymic.Length > 0 ? GlobalData.Employee.Patronymic[0] + "." : "");
        }

        private void SelectDirectory_MouseMove(object sender, MouseEventArgs e)
        {
            lastActivityTime = DateTime.Now;
        }

        private void SelectDirectory_KeyPress(object sender, KeyPressEventArgs e)
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

        private void buttonEducation_Click(object sender, EventArgs e)
        {
            timer.Stop();
            this.Hide();
            Education education = new Education();
            education.ShowDialog();
        }

        private void buttonEmployment_Click(object sender, EventArgs e)
        {
            timer.Stop();
            this.Hide();
            Employment employment = new Employment();
            employment.ShowDialog();
        }

        private void buttonQualification_Click(object sender, EventArgs e)
        {
            timer.Stop();
            this.Hide();
            Qualification qualification = new Qualification();
            qualification.ShowDialog();
        }

        private void buttonCustomer_Click(object sender, EventArgs e)
        {
            timer.Stop();
            this.Hide();
            Customer customer = new Customer();
            customer.ShowDialog();
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            timer.Stop();

            if (GlobalData.Employee.Role == Constants.ROLE_ADMINISTRATOR)
            {
                this.Hide();
                SysAdminMenuView sysAdminMenuView = new SysAdminMenuView();
                sysAdminMenuView.ShowDialog();
            }
            else
            {
                this.Hide();
                SecretaryMenuView secretaryMenu = new SecretaryMenuView();
                secretaryMenu.ShowDialog();
            }
        }

        private void buttonGroups_Click(object sender, EventArgs e)
        {
            timer.Stop();
            this.Hide();
            GroupView groupView = new GroupView();
            groupView.ShowDialog();
        }

        private void buttonOrganizations_Click(object sender, EventArgs e)
        {
            timer.Stop();
            this.Hide();
            OrganizationView organization = new OrganizationView();
            organization.ShowDialog();
        }

        private void buttonCourses_Click(object sender, EventArgs e)
        {
            timer.Stop();
            this.Hide();
            CourseView course = new CourseView();
            course.ShowDialog();
        }

        private void buttonGetRepresentatives_Click(object sender, EventArgs e)
        {
            timer.Stop();
            this.Hide();
            RepresentativeView representative = new RepresentativeView();
            representative.ShowDialog();
        }

        private void buttonAboutOrganization_Click(object sender, EventArgs e)
        {
            timer.Stop();
            this.Hide();
            AboutOrganizationView aboutOrganization = new AboutOrganizationView();
            aboutOrganization.ShowDialog();
        }
    }
}
