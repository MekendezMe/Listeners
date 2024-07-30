using Listeners.DatabaseHelper;
using Listeners.Dtos;
using Listeners.Forms.Authorization;
using Listeners.MainMenu.Manager;
using Listeners.MainMenu.Secretary;
using Listeners.MainMenu.SysAdmin;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Listeners
{
    public partial class AuthorizationView : Form
    {
        int remainingSeconds = 10;
        private AuthorizationController authorizationController;
        private MySqlClient sqlClient;
        public AuthorizationView()
        {
            InitializeComponent();
            authorizationController = new AuthorizationController(this);
            sqlClient = new MySqlClient();
        }

        private const int WM_INPUTLANGCHANGEREQUEST = 0x0050;

        [DllImport("user32.dll")]
        private static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll")]
        private static extern IntPtr LoadKeyboardLayout(string pwszKLID, uint Flags);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern IntPtr SendMessage(IntPtr hWnd, int Msg, IntPtr wParam, IntPtr lParam);

        private void SwitchToEnglishKeyboardLayout()
        {
            IntPtr hWnd = GetForegroundWindow();

            LoadKeyboardLayout("00000409", 1); 

            SendMessage(hWnd, WM_INPUTLANGCHANGEREQUEST, IntPtr.Zero, LoadKeyboardLayout("00000409", 1));
        }

        private void buttonShowPassword_Click(object sender, EventArgs e)
        {
            textBoxPassword.UseSystemPasswordChar = !textBoxPassword.UseSystemPasswordChar;
        }

        public void ShowError(string message)
        {
            MessageBox.Show(message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void buttonEntry_Click(object sender, EventArgs e)
        {
            authorizationController.Login(
                new Interfaces.Authorization.AuthorizationRequest()
                { Login = textBoxLogin.Text, Password = textBoxPassword.Text, Captcha = textBoxCaptcha.Text });
        }

        public void StartNewForm()
        {
            if (GlobalData.Employee.Role == Constants.ROLE_ADMINISTRATOR)
            {
                this.Hide();
                SysAdminMenuView sysAdminMenu = new SysAdminMenuView();
                sysAdminMenu.ShowDialog();
            }
            else if (GlobalData.Employee.Role == Constants.ROLE_SECRETARY)
            {
                this.Hide();
                SecretaryMenuView secretaryMenu = new SecretaryMenuView();
                secretaryMenu.ShowDialog();
            }
            else
            {
                this.Hide();
                ManagerMenuView managerMenu = new ManagerMenuView();
                managerMenu.ShowDialog();
            }
        }

        public void ShowCaptcha()
        {
            textBoxCaptcha.Visible = true;
            textBoxCaptchaEnter.Visible = true;
        }

        public void UpdateCaptcha(string captcha)
        {
            textBoxCaptchaEnter.Text = captcha;
        }

        public void BlockElements(bool needBlock)
        {
            foreach (Control control in this.Controls)
            {
                control.Enabled = !needBlock;
            }

            if (needBlock)
            {
                textBoxTimer.Visible = true;
                blockTimer.Start();
            }
        }

        private void blockTimer_Tick(object sender, EventArgs e)
        {
            textBoxTimer.Text = remainingSeconds.ToString();

            if (remainingSeconds == 0)
            {
                textBoxCaptcha.Text = string.Empty;
                textBoxTimer.Visible = false;
                remainingSeconds = 10;
                textBoxTimer.Text = remainingSeconds.ToString();
                blockTimer.Stop();
                BlockElements(false);
            }

            remainingSeconds--;
        }

        private void buttonOut_Click(object sender, EventArgs e)
        {
            DialogResult confirmationOut = MessageBox.Show("Вы действительно хотите выйти из приложения?", "Внимание", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);

            if (confirmationOut == DialogResult.Yes)
            {
                string path = Path.Combine(Path.GetDirectoryName(System.Windows.Forms.Application.ExecutablePath), "backups");
                string fileName = "script-" + DateTime.Now.ToShortDateString() + "-" + DateTime.Now.ToShortTimeString().Replace(":", "-") + ".sql";
                if (!sqlClient.ExportDatabase(path, fileName))
                {
                    MessageBox.Show("Не удалось экспортировать скрипт базы данных", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                Application.Exit();
            }
        }

        private void textBoxCaptcha_Enter(object sender, EventArgs e)
        {
            SwitchToEnglishKeyboardLayout();
        }

        private void textBoxPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 'а' && e.KeyChar <= 'я') || (e.KeyChar >= 'а' && e.KeyChar <= 'я') || e.KeyChar == (char)Keys.Space)
            {
                SwitchToEnglishKeyboardLayout();
                e.Handled = true;
            }
        }
    }
}
