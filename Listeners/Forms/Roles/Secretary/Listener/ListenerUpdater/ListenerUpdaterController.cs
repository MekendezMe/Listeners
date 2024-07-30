using Listeners.Dictionaries;
using Listeners.Dtos;
using Listeners.Enums;
using Listeners.FormCloserHelper;
using Listeners.Forms.Roles.Secretary.Listener.ListenerCreater;
using Listeners.Interfaces;
using Listeners.Messages;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Listeners.Forms.Roles.Secretary.Listener.ListenerUpdater
{
    public class ListenerUpdaterController
    {
        bool listenerIsUpdated = false;
        private ListenerUpdaterService service;
        private ListenerUpdaterView view;

        public ListenerUpdaterController(ListenerUpdaterView view)
        {
            this.view = view;
            service = new ListenerUpdaterService();
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

        public void UpdateListener(IListener listener)
        {
            if (!AllFieldsIsFilled(listener))
            {
                view.ShowMessage(Errors.GetError(Error.EmptyFields), "Ошибка",
                    MessageBoxIcon.Error);
                return;
            }

            listener.BirthdayDate = DateTime.ParseExact(listener.BirthdayDate, "dd.MM.yyyy", CultureInfo.InvariantCulture)
                .ToString("yyyy-MM-dd");

            listener.Document.Passport.IssueDate = DateTime.ParseExact(listener.Document.Passport.IssueDate,
                "dd.MM.yyyy", CultureInfo.InvariantCulture)
                .ToString("yyyy-MM-dd");

            string response = service.UpdateListener(listener);

            if (response.Length != 0)
            {
                view.ShowMessage(response, "Ошибка", MessageBoxIcon.Error);
                return;
            }

            listenerIsUpdated = true;
            view.ShowMessage(PositiveMessages.GetMessage(Enums.Message.ListenerIsUpdated), "Внимание", MessageBoxIcon.Asterisk);
            view.ClearFields();
            view.ShowListeners();
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

        public void GetRowByPrimaryKey(string primaryKey)
        {
            if (!ValidatePrimaryKey(primaryKey))
            {
                view.ShowMessage(Errors.GetError(Enums.Error.NoOneRowFoundByPrimaryKey), "Ошибка", MessageBoxIcon.Error);
                return;
            }

            ListenerDto listener = service.GetRowByPrimaryKey(primaryKey);

            if (listener == null)
            {
                view.ShowMessage(Errors.GetError(Enums.Error.NoOneRowFoundByPrimaryKey), "Ошибка", MessageBoxIcon.Error);
                return;
            }

            view.FillFields(listener);
        }

        private bool ValidatePrimaryKey(string primaryKey)
        {
            int id = 0;

            if (!int.TryParse(primaryKey, out id))
            {
                return false;
            }

            if (id <= 0)
            {
                return false;
            }

            return true;
        }

        public string[] GetAllEmployment()
        {
            return service.GetAllEmployment();
        }

        public string[] GetAllEducation()
        {
            return service.GetAllEducation();
        }

        public void ControlUpdateListener()
        {
            if (listenerIsUpdated)
            {
                GlobalData.ListenerChanged = true;
            }
            else
            {
                GlobalData.ListenerChanged = false;
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
