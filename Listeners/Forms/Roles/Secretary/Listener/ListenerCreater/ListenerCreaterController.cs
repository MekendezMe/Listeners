using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using Listeners.Dictionaries;
using Listeners.Enums;
using Listeners.FormCloserHelper;
using Listeners.Interfaces;
using Listeners.Messages;

namespace Listeners.Forms.Roles.Secretary.Listener.ListenerCreater
{
    public class ListenerCreaterController
    {
        bool listenerIsCreated = false;
        private ListenerCreaterService listenerCreaterService;
        private ListenerCreaterView view;

        public ListenerCreaterController(ListenerCreaterView view)
        {
            this.view = view;
            listenerCreaterService = new ListenerCreaterService();
        }

        public void ActivityControl(DateTime lastActivityTime)
        {
            TimeSpan inactiveDuration = DateTime.Now - lastActivityTime;

            if (inactiveDuration.TotalSeconds > Constants.MAX_INACTIVE_TIME_SECONDS)
            {
                FormCloser.ClosedForms();
                view.StartLoginForm();
            }
        }

        public void CreateListener(IListener listener)
        {
            if (!AllFieldsIsFilled(listener))
            {
                view.ShowMessage(Errors.GetError(Enums.Error.EmptyFields), "Ошибка",
                    MessageBoxIcon.Error);
                return;
            }

            listener.BirthdayDate = DateTime.ParseExact(listener.BirthdayDate, "dd.MM.yyyy", CultureInfo.InvariantCulture)
                .ToString("yyyy-MM-dd");

            listener.Document.Passport.IssueDate = DateTime.ParseExact(listener.Document.Passport.IssueDate,
                "dd.MM.yyyy", CultureInfo.InvariantCulture)
                .ToString("yyyy-MM-dd");

            string response = listenerCreaterService.CreateListener(listener);

            if (response.Length != 0)
            {
                view.ShowMessage(response, "Ошибка", MessageBoxIcon.Error);
                return;
            }

            listenerIsCreated = true;
            view.ShowMessage(PositiveMessages.GetMessage(Enums.Message.ListenerIsCreated), "Внимание", MessageBoxIcon.Asterisk);
            view.ClearFields();
        }

        public void ControlBirthdayDate(string inputDate)
        {
            DateTime birthday;

            if (!DateTime.TryParseExact(inputDate, "dd.MM.yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out birthday))
            {
                view.ShowMessage(Errors.GetError(Error.InputDateIncorrect), "Ошибка", MessageBoxIcon.Error);
                view.ClearBirthdayDate();
                return;
            }

            TimeSpan ageDifference = DateTime.Now.Date - birthday;
            int ageInYears = (int)(ageDifference.TotalDays / 365.25);

            if (ageInYears < 14)
            {
                view.ShowMessage(Errors.GetError(Error.InputDateTooSmall), "Ошибка", MessageBoxIcon.Error);
                view.ClearBirthdayDate();
                return;
            }

            view.FillAge();
        }

        public string[] GetAllEmployment()
        {
            return listenerCreaterService.GetAllEmployment();
        }

        public string[] GetAllEducation()
        {
            return listenerCreaterService.GetAllEducation();
        }

        public void ControlNewListener()
        {
            if (listenerIsCreated)
            {
                GlobalData.ListenerCreated = true;
            } else
            {
                GlobalData.ListenerCreated = false;
            }
        }
        
        public void ControlIssuedDate(string inputIssuedDate)
        {
            DateTime birthday;

            if (!DateTime.TryParseExact(inputIssuedDate, "dd.MM.yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out birthday))
            {
                view.ShowMessage(Errors.GetError(Error.InputDateIncorrect), "Ошибка", MessageBoxIcon.Error);
                view.ClearIssuedDate();
                return;
            }

            if (DateTime.Now.Date < birthday)
            {
                view.ShowMessage(Errors.GetError(Error.InputDateIncorrect), "Ошибка", MessageBoxIcon.Error);
                view.ClearIssuedDate();
                return;
            }
        }

        private bool AllFieldsIsFilled(IListener listener)
        {
            if (listener == null) return false;

            if (listener.Name.Trim() == string.Empty || listener.Surname.Trim() == string.Empty ||
                listener.BirthdayDate.Trim() == string.Empty ||
                listener.Education.Trim() == string.Empty || listener.Employment.Trim() == string.Empty ||
                listener.Gender.Trim() == string.Empty || listener.Phone.Trim() == string.Empty ||
                listener.Document.InsuranceNumber.Trim() == string.Empty ||
                listener.Document.Passport.Number.Trim() == string.Empty ||
                listener.Document.Passport.Series.Trim() == string.Empty ||
                listener.Document.Passport.IssuedBy.Trim() == string.Empty ||
                listener.Document.Passport.IssueDate.Trim() == string.Empty ||
                listener.Document.Passport.DepartmentCode.Trim() == string.Empty)
            {
                return false;
            }

            return true;
        }
    }
}
