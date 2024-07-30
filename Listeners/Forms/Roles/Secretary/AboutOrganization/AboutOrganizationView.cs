using Listeners.DatabaseHelper;
using Listeners.Forms.Roles.Secretary.Directories;
using Listeners.Interfaces;
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

namespace Listeners.Forms.Roles.Secretary.AboutOrganization
{
    public partial class AboutOrganizationView : Form
    {
        private Timer timer;
        private DateTime lastActivityTime;
        private MySqlClient sqlClient;
        public AboutOrganizationView()
        {
            InitializeComponent();
            lastActivityTime = DateTime.Now;
            sqlClient = new MySqlClient();
            ShowUser();
            ResetTimer();
            UpdateUserInterface();
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

        private void textBoxName_Enter(object sender, EventArgs e)
        {
            SwitchToRussianKeyboardLayout();
        }

        private void UpdateUserInterface()
        {
            IOrganization organization = sqlClient.FindOne<IOrganization>
                    ("SELECT name, littleName, " +
                    "requisites, inn, kpp, bik, personalAccount," +
                    "paymentAccount, onlyTreasureAccount, treasureAccount, " +
                    "director, license, bank from organization where id='" + Constants.ID_ZAMT + "'");

            if (organization == null)
            {
                MessageBox.Show("Не удалось заполнить данные", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            textBoxName.Text = organization.Name;
            textBoxLittleName.Text = organization.LittleName;
            textBoxRequisites.Text = organization.Requisites;
            maskedTextBoxINN.Text = organization.INN;
            maskedTextBoxKPP.Text = organization.KPP;
            maskedTextBoxBIK.Text = organization.BIK;
            textBoxPersonal.Text = organization.PersonalAccount;
            textBoxPayment.Text = organization.PaymentAccount;
            maskedTextBoxOnlyTreasure.Text = organization.OnlyTreasureAccount;
            maskedTextBoxTreasure.Text = organization.TreasureAccount;
            textBoxDirector.Text = organization.Director;
            textBoxLicense.Text = organization.License;
        }

        private void textBoxDirector_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && e.KeyChar != '-' && e.KeyChar != (char)Keys.Back &&
                e.KeyChar != '.' && e.KeyChar != (char)Keys.Space)
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
                if (e.KeyChar == '-' || e.KeyChar == '.' || e.KeyChar == (char)Keys.Space)
                {
                    e.Handled = true;
                    return;
                }
            }

            if (char.IsLower(e.KeyChar))
            {
                if (textBox.SelectionStart == 0
                    || textBox.Text.Length > 0 && textBox.Text[textBox.SelectionStart - 1] == '-' ||
                    textBox.Text.Length > 0 && textBox.Text[textBox.SelectionStart - 1] == '.')
                {
                    e.KeyChar = char.ToUpper(e.KeyChar);
                }
            }
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            if (!ControlFillFields())
            {
                MessageBox.Show("Должны быть заполнены все обязательные поля", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!OrganizationIsExist())
            {
                return;
            }

            bool isExecute = sqlClient.ExecuteRequest("UPDATE organization set name='" +
                textBoxName.Text.Trim() + "', littleName='" + textBoxLittleName.Text.Trim() + "'," +
                "requisites='" + textBoxRequisites.Text + "', inn='" + maskedTextBoxINN.Text + "', kpp='" + maskedTextBoxKPP.Text + "', " +
                "bik='" + maskedTextBoxBIK.Text + "', personalAccount='" + textBoxPersonal.Text + "', paymentAccount='"
                + textBoxPayment.Text + "', onlyTreasureAccount='" + maskedTextBoxOnlyTreasure.Text.Trim()
                + "', treasureAccount='" + maskedTextBoxTreasure.Text.Trim() + "'," +
                " director='" + textBoxDirector.Text + "', license='" + textBoxLicense.Text + "', "
                + " modifiedby='" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "' where id='" + 3 + "'");

            if (!isExecute)
            {
                MessageBox.Show("Не удалось изменить организацию", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            MessageBox.Show("Изменение организации успешно", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        private bool OrganizationIsExist()
        {
            string value = sqlClient.GetValue("SELECT id from organization where inn='" + maskedTextBoxINN.Text + "'");

            return value.Length != 0;
        }

        private bool ControlFillFields()
        {
            if (textBoxName.Text.Trim().Length == 0 || textBoxRequisites.Text.Trim().Length == 0 ||
                (maskedTextBoxINN.Text.Length != 10 && maskedTextBoxINN.Text.Length != 12) ||
                !maskedTextBoxKPP.MaskCompleted || !maskedTextBoxBIK.MaskCompleted || textBoxPayment.Text.Trim().Length == 0 ||
                !maskedTextBoxTreasure.MaskCompleted || !maskedTextBoxOnlyTreasure.MaskCompleted ||
                textBoxPersonal.Text.Trim().Length == 0)
            {
                return false;
            }

            return true;
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            timer.Stop();
            this.Hide();
            SelectDirectory selectDirectory = new SelectDirectory();
            selectDirectory.ShowDialog();
        }
    }
}
