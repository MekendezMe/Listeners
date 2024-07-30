using Listeners.DatabaseHelper;
using Listeners.Dictionaries;
using Listeners.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Listeners.Forms.Roles.Secretary.Listener.ListenerCreater
{
    public class ListenerCreaterService
    {
        private MySqlClient mySqlClient;

        public ListenerCreaterService()
        {
            mySqlClient = new MySqlClient();
        }
        public string CreateListener(IListener listener)
        {
            if (PassportIsExist(listener.Document.Passport.Number))
            {
                return Errors.GetError(Enums.Error.PassportIsExist);
            }

            if (InsuranceIsExist(listener.Document.InsuranceNumber))
            {
                return Errors.GetError(Enums.Error.InsuranceIsExist);
            }

            if (MobilePhoneIsExist(listener.Phone))
            {
                return Errors.GetError(Enums.Error.PhoneNumberIsExist);
            }

            List<string> queries = new List<string>()
            {
                {string.Format("INSERT INTO passport (series, number, issueDate, issuedBy, departmentCode) VALUES (" +
                "'{0}', '{1}', '{2}', '{3}', '{4}')", listener.Document.Passport.Series, listener.Document.Passport.Number,
                listener.Document.Passport.IssueDate, listener.Document.Passport.IssuedBy,
                listener.Document.Passport.DepartmentCode) },
                {string.Format("INSERT INTO document (insuranceNumber, passport) values ('{0}', " +
                "(SELECT id from passport where number='{1}'))", listener.Document.InsuranceNumber,
                listener.Document.Passport.Number) },
                {string.Format("INSERT INTO listener (surname, name, patronymic, address, birthday, phone, " +
                "employment, education, document, gender, modifiedBy) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', " +
                "(SELECT id from employment where title='{6}'), (SELECT id from education where title='{7}'), " +
                "(SELECT id from document where passport=(SELECT id from passport where number='{8}'))," +
                " (SELECT id from gender where name='{9}'), '{10}')",
                listener.Surname, listener.Name, listener.Patronymic, listener.Address, listener.BirthdayDate, listener.Phone,
                listener.Employment, listener.Education, listener.Document.Passport.Number, listener.Gender,
                DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))}
            };

            bool requestIsExecute = mySqlClient.ExecuteTransaction(queries);

            if (!requestIsExecute)
            {
                return Errors.GetError(Enums.Error.NewListenerNotCreated);
            }

            return string.Empty;
        }

        private bool PassportIsExist(string number)
        {
            return mySqlClient.ExecuteRequest("SELECT * from passport where number=" + "'" +
                number + "'");
        }

        private bool InsuranceIsExist(string insurance)
        {
            return mySqlClient.ExecuteRequest("SELECT * from document where insuranceNumber=" + "'" +
                insurance + "'");
        }

        private bool MobilePhoneIsExist(string phone)
        {
            return mySqlClient.ExecuteRequest("SELECT * from listener where phone=" + "'" +
                phone + "'");
        }

        public string[] GetAllEmployment()
        {
            return mySqlClient.FillComboBox("SELECT title from employment;");
        }

        public string[] GetAllEducation()
        {
            return mySqlClient.FillComboBox("SELECT title from education;");
        }
    }
}
