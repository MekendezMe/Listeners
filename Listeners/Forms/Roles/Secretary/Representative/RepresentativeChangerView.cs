using Listeners.DatabaseHelper;
using Listeners.FormCloserHelper;
using Listeners.Forms.Roles.Secretary.Listener;
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
using System.Windows.Forms.VisualStyles;

namespace Listeners.Forms.Roles.Secretary.Representative
{
    public partial class RepresentativeChangerView : Form
    {
        private bool listenerSelected = false;
        private int idCurrentRepresentative = 0;
        private bool isUpdated = false;
        private bool isCreated = false;
        private MySqlClient sqlClient;
        private Timer timer;
        private DateTime lastActivityTime;
        private bool needUpdate;
        private string primaryKey = string.Empty;
        private bool fromRecord;
        public RepresentativeChangerView(string primaryKey = "", bool needUpdate = false, bool fromRecord = false)
        {
            InitializeComponent();
            lastActivityTime = DateTime.Now;
            ShowUser();
            ResetTimer();
            this.primaryKey = primaryKey;
            this.needUpdate = needUpdate;
            sqlClient = new MySqlClient();
            this.fromRecord = fromRecord;
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

        private void UpdateUserInterface()
        {
            if (needUpdate)
            {
                buttonChange.Text = "Изменить";
                IRepresentative representative = sqlClient.FindOne<IRepresentative>("SELECT surname, name, patronymic, " +
                "address, phone, (SELECT concat_ws(' ', surname, name, patronymic) from " +
                "listener where listener.id=(SELECT idListener from representative" +
                " where representative.id='" + primaryKey + "')) AS 'Listener'," +
                "(SELECT idListener from representative where representative.id=" +
                "'" + primaryKey + "') AS 'IdListener' from representative where id='" + primaryKey + "'");

                if (representative == null)
                {
                    MessageBox.Show("Не удалось заполнить данные", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                textBoxName.Text = representative.Name;
                textBoxSurname.Text = representative.Surname;
                textBoxPatronymic.Text = representative.Patronymic;
                textBoxAddress.Text = representative.Address;
                maskedTextBoxPhone.Text = representative.Phone;
                labelAboutListener.Text = representative.Listener;
                idCurrentRepresentative = representative.IdListener;
                listenerSelected = true;
                GlobalData.IdListenerForRepresentative = representative.IdListener;
            }
            else
            {
                buttonChange.Text = "Добавить";
            }

            if (fromRecord)
            {
                FillListener();
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
                FormCloser.ClosedForms();
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

        private void buttonBack_Click(object sender, EventArgs e)
        {
            DisplayChanged();
        }

        private void DisplayChanged()
        {
            timer.Stop();
            GlobalData.RepresentativeChanged = isUpdated;
            GlobalData.RepresentativeCreated = isCreated;
            this.Close();
        }

        private void buttonChange_Click(object sender, EventArgs e)
        {
            if (!ControlFillFields())
            {
                MessageBox.Show("Должны быть заполнены все обязательные поля", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (needUpdate)
            {
                if (ListenerHaveRepresentative() && idCurrentRepresentative != GlobalData.IdListenerForRepresentative)
                {
                    MessageBox.Show("У выбранного слушателя уже назначен представитель", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                bool isExecute = sqlClient.ExecuteRequest("UPDATE representative set surname='" +
                    textBoxSurname.Text.Trim() + "', name='" + textBoxName.Text.Trim() + "', patronymic='" + textBoxPatronymic.Text.Trim() + "', " +
                    "address='" + textBoxAddress.Text + "', phone='" + maskedTextBoxPhone.Text + "', idListener='"
                    + GlobalData.IdListenerForRepresentative + "'," + 
                    " modifiedby='" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "' where id='" + primaryKey + "'");

                if (!isExecute)
                {
                    MessageBox.Show("Не удалось изменить законного представителя", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                MessageBox.Show("Изменение законного представителя успешно", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                isUpdated = true;
                DisplayChanged();
            }
            else
            {
                if (RepresentativeIsExist())
                {
                    MessageBox.Show("Законный представитель с указанным номером телефона уже существует", "Внимание",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (ListenerHaveRepresentative())
                {
                    MessageBox.Show("У выбранного слушателя уже назначен представитель", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                bool isExecute = sqlClient.ExecuteRequest("INSERT INTO representative (surname, name, patronymic, address, phone, idListener, modifiedBy)" +
                    " VALUES('" +
                    textBoxSurname.Text.Trim() + "','" + textBoxName.Text.Trim() + "', '" + textBoxPatronymic.Text.Trim() + "', "
                    + "'" + textBoxAddress.Text + "', '" + maskedTextBoxPhone.Text + "', '" + GlobalData.IdListenerForRepresentative + "', '"
                    + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "')");

                if (!isExecute)
                {
                    MessageBox.Show("Не удалось добавить законного представителя", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                MessageBox.Show("Добавление нового законного представителя успешно", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                isCreated = true;
            }

            if (fromRecord && GlobalData.IdListenerForRepresentative == GlobalData.IdListener)
            {
                GlobalData.RepresentativeCreatedForListener = true;
                buttonBack.Text = "К записи на курс";
            }

            ClearFields();
        }

        private bool ListenerHaveRepresentative()
        {
            string value = sqlClient.GetValue("SELECT id from representative where idListener='" + GlobalData.IdListenerForRepresentative + "'");

            return value.Length != 0;
        }

        private void ClearFields()
        {
            foreach (TextBox textBox in this.Controls.OfType<TextBox>())
            {
                textBox.Clear();
            }

            maskedTextBoxPhone.Clear();
            labelAboutListener.Text = "Не выбран";
            listenerSelected = false;
            GlobalData.IdListenerForRepresentative = 0;
        }

        private bool RepresentativeIsExist()
        {
            string value = sqlClient.GetValue("SELECT id from representative where phone='"
                + maskedTextBoxPhone.Text.Trim() + "'");

            return value.Length != 0;
        }

        private bool ControlFillFields()
        {
            return textBoxName.Text.Trim().Length != 0 && textBoxSurname.Text.Trim().Length != 0 &&
                textBoxPatronymic.Text.Trim().Length != 0 && textBoxAddress.Text.Trim().Length != 0 &&
                maskedTextBoxPhone.MaskCompleted && listenerSelected;
        }

        private void maskedTextBoxPhone_Click(object sender, EventArgs e)
        {
            MaskedTextBox maskedTextBox = (MaskedTextBox)sender;

            maskedTextBox.Select(0, 0);
        }

        private void buttonGetListener_Click(object sender, EventArgs e)
        {
            ListenerView listenerView = new ListenerView(fromRepresentative: true);
            listenerView.FormClosed += GetListener_FormClosed;
            listenerView.ShowDialog();
        }

        private void GetListener_FormClosed(object sender, FormClosedEventArgs e)
        {
            FillListener();
        }

        private void FillListener()
        {
            if (GlobalData.IdListenerForRepresentative != 0)
            {
                labelAboutListener.Text = sqlClient.GetValue("SELECT concat_ws(' ', surname, name, patronymic) from listener where id=" +
                    "'" + GlobalData.IdListenerForRepresentative.ToString() + "'");
                listenerSelected = true;
            }
            else
            {
                listenerSelected = false;
            }
        }
    }
}
