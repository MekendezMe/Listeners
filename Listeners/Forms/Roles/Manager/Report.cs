using Listeners.DatabaseHelper;
using Listeners.ExcelHelper;
using Listeners.MainMenu.Manager;
using Listeners.MainMenu.Secretary;
using Microsoft.Office.Interop.Word;
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

namespace Listeners.Forms.Roles.Manager
{
    public partial class Report : Form
    {
        private Timer timer;
        private DateTime lastActivityTime;
        private MySqlClient sqlClient;
        private ExcelClient excel;
        public Report()
        {
            InitializeComponent();
            lastActivityTime = DateTime.Now;
            sqlClient = new MySqlClient();
            ShowUser();
            ResetTimer();
            excel = new ExcelClient();
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

        private void buttonBack_Click(object sender, EventArgs e)
        {
            timer.Stop();
            this.Hide();
            ManagerMenuView managerMenu = new ManagerMenuView();
            managerMenu.ShowDialog();
        }

        private void buttonPayment_Click(object sender, EventArgs e)
        {
            if (!excel.CreatePaymentReport())
            {
                MessageBox.Show("Не удалось отобразить статистику", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void buttonStat_Click(object sender, EventArgs e)
        {
            if (!excel.CreateStatReport())
            {
                MessageBox.Show("Не удалось отобразить статистику", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
    }
}
