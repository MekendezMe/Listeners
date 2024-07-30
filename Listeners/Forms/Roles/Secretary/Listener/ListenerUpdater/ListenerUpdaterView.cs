using Listeners.Dtos;
using Listeners.Forms.Roles.Secretary.Listener.ListenerCreater;
using Listeners.Interfaces;
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

namespace Listeners.Forms.Roles.Secretary.Listener.ListenerUpdater
{
    public partial class ListenerUpdaterView : Form
    {
        private string primaryKey;
        private Timer timer;
        private DateTime lastActivityTime;
        private ListenerUpdaterController controller;
        public ListenerUpdaterView(string primaryKey)
        {
            InitializeComponent();
            this.primaryKey = primaryKey;
            lastActivityTime = DateTime.Now;
            controller = new ListenerUpdaterController(this);
            FillComboBox();
            GetHighlightedRow();
            ShowUser();
            ResetTimer();
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

        private void textBox_Enter(object sender, EventArgs e)
        {
            SwitchToRussianKeyboardLayout();
        }

        private void GetHighlightedRow()
        {
            controller.GetRowByPrimaryKey(primaryKey);
        }

        public void FillFields(ListenerDto listener)
        {
            textBoxSurname.Text = listener.Surname;
            textBoxName.Text = listener.Name;
            textBoxPatronymic.Text = listener.Patronymic;
            textBoxAddress.Text = listener.Address;
            textBoxIssuedBy.Text = listener.IssuedBy;
            maskedTextBoxBirthday.Text = listener.Birthday;
            maskedTextBoxCode.Text = listener.DepartmentCode;
            maskedTextBoxInsurance.Text = listener.InsuranceNumber;
            maskedTextBoxIssuedDate.Text = listener.IssueDate;
            maskedTextBoxPhone.Text = listener.Phone;
            maskedTextBoxSeries.Text = listener.Series;
            maskedTextBoxNumber.Text = listener.Number;
            comboBoxEducation.SelectedIndex = comboBoxEducation.Items.IndexOf(listener.Education);
            comboBoxEmployment.SelectedIndex = comboBoxEmployment.Items.IndexOf(listener.Employment);
            
            if (listener.Gender == Constants.GENDER_MALE)
            {
                checkBoxMale.Checked = true;
            } else
            {
                checkBoxFemale.Checked = true;
            }

        }

        private void FillComboBox()
        {
            string[] employment = controller.GetAllEmployment();

            for (int i = 0; i < employment.Length; i++)
            {
                comboBoxEmployment.Items.Add(employment[i]);
            }

            string[] education = controller.GetAllEducation();

            for (int i = 0; i < education.Length; i++)
            {
                comboBoxEducation.Items.Add(education[i]);
            }
        }

        private void MaskedTextBox_Enter(object sender, EventArgs e)
        {
            if (sender is MaskedTextBox maskedTextBox)
            {
                maskedTextBox.Select(0, 0);
            }
        }

        private void maskedTextBoxBirthday_Click(object sender, EventArgs e)
        {
            MaskedTextBox maskedTextBox = (MaskedTextBox)sender;

            maskedTextBox.Select(0, 0);
        }

        private void ShowUser()
        {
            labelUser.Text = GlobalData.Employee.Role + " " + GlobalData.Employee.Surname + " "
                + (GlobalData.Employee.Name.Length > 0 ? GlobalData.Employee.Name[0] + ". " : " ")
                + (GlobalData.Employee.Patronymic.Length > 0 ? GlobalData.Employee.Patronymic[0] + "." : "");
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
            controller.ActivityControl(lastActivityTime);
        }

        public void StartLoginForm()
        {
            timer.Stop();
            this.Hide();
            AuthorizationView authorizationView = new AuthorizationView();
            authorizationView.ShowDialog();
        }

        private void checkBoxMale_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxMale.Checked) checkBoxFemale.Checked = false;
        }

        private void checkBoxFemale_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxFemale.Checked) checkBoxMale.Checked = false;
        }

        public void ShowMessage(string message, string title, MessageBoxIcon icon)
        {
            MessageBox.Show(message, title, MessageBoxButtons.OK, icon);
        }


        public void ClearFields()
        {
            textBoxSurname.Text = string.Empty;
            textBoxName.Text = string.Empty;
            textBoxPatronymic.Text = string.Empty;
            textBoxAddress.Text = string.Empty;
            textBoxIssuedBy.Text = string.Empty;
            maskedTextBoxBirthday.Text = string.Empty;
            maskedTextBoxCode.Text = string.Empty;
            maskedTextBoxInsurance.Text = string.Empty;
            maskedTextBoxNumber.Text = string.Empty;
            maskedTextBoxIssuedDate.Text = string.Empty;
            maskedTextBoxPhone.Text = string.Empty;
            maskedTextBoxSeries.Text = string.Empty;
            comboBoxEducation.SelectedIndex = -1;
            comboBoxEmployment.SelectedIndex = -1;
            checkBoxFemale.Checked = false;
            checkBoxMale.Checked = false;
            labelAge.Text = string.Empty;
        }

        private void textBoxPersonalData_KeyPress(object sender, KeyPressEventArgs e)
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

        private void maskedTextBoxBirthday_TextChanged(object sender, EventArgs e)
        {
            if (!maskedTextBoxBirthday.MaskCompleted)
            {
                return;
            }

            controller.ControlBirthdayDate(maskedTextBoxBirthday.Text);
        }

        public void FillAge()
        {
            labelAge.Text = Convert.ToString(Convert.ToInt32(DateTime.Now.Year) - Convert.ToInt32(maskedTextBoxBirthday.Text.Split('.')[2]));
        }

        public void ClearBirthdayDate()
        {
            maskedTextBoxBirthday.Text = string.Empty;
            labelAge.Text = string.Empty;
        }

        public void ClearIssuedDate()
        {
            maskedTextBoxIssuedDate.Text = string.Empty;
        }

        private void maskedTextBoxIssuedDate_TextChanged(object sender, EventArgs e)
        {
            if (!maskedTextBoxIssuedDate.MaskCompleted)
            {
                return;
            }

            controller.ControlIssuedDate(maskedTextBoxIssuedDate.Text);
        }

        public void ShowListeners()
        {
            timer.Stop();
            controller.ControlUpdateListener();
            this.Close();
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            controller.UpdateListener(new IListener()
            {
                Id = primaryKey,
                Surname = textBoxSurname.Text,
                Name = textBoxName.Text,
                Patronymic = textBoxPatronymic.Text,
                Address = textBoxAddress.Text,
                BirthdayDate = maskedTextBoxBirthday.MaskCompleted ? maskedTextBoxBirthday.Text : string.Empty,
                Phone = maskedTextBoxPhone.MaskCompleted ? maskedTextBoxPhone.Text : string.Empty,
                Education = comboBoxEducation.Text,
                Employment = comboBoxEmployment.Text,
                Gender = checkBoxFemale.Checked ? Constants.GENDER_FEMALE :
                checkBoxMale.Checked ? Constants.GENDER_MALE : string.Empty,
                Document = new IDocument()
                {
                    InsuranceNumber = maskedTextBoxInsurance.MaskCompleted ? maskedTextBoxInsurance.Text : string.Empty,
                    Passport = new IPassport()
                    {
                        Series = maskedTextBoxSeries.MaskCompleted ? maskedTextBoxSeries.Text : string.Empty,
                        Number = maskedTextBoxNumber.MaskCompleted ? maskedTextBoxNumber.Text : string.Empty,
                        DepartmentCode = maskedTextBoxCode.MaskCompleted ? maskedTextBoxCode.Text : string.Empty,
                        IssueDate = maskedTextBoxIssuedDate.MaskCompleted ? maskedTextBoxIssuedDate.Text : string.Empty,
                        IssuedBy = textBoxIssuedBy.Text
                    }
                }
            });
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            ShowListeners();
        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void textBoxAddress_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 'a' && e.KeyChar <= 'z') || (e.KeyChar >= 'A' && e.KeyChar <= 'Z'))
            {
                e.Handled = true;
                SwitchToRussianKeyboardLayout();
            }
        }
    }
}
