using Listeners.DatabaseHelper;
using Listeners.Dictionaries;
using Listeners.Dtos;
using Listeners.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Listeners.Forms.Roles.Secretary.Listener.ListenerUpdater
{
    public class ListenerUpdaterService
    {
        private MySqlClient mySqlClient;

        public ListenerUpdaterService()
        {
            mySqlClient = new MySqlClient();
        }

        public string UpdateListener(IListener listener)
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
                {
                string.Format("UPDATE passport SET series = '{0}', number = '{1}', issueDate = '{2}', issuedBy = '{3}', departmentCode = '{4}'" +
                " WHERE id=(SELECT passport from document where document.id=(SELECT document from listener where listener.id='{5}'))",
                listener.Document.Passport.Series, listener.Document.Passport.Number,
                listener.Document.Passport.IssueDate, listener.Document.Passport.IssuedBy,
                listener.Document.Passport.DepartmentCode, listener.Id)
                },
                {
                string.Format("UPDATE document SET insuranceNumber = '{0}', passport=(SELECT id FROM passport WHERE number = '{1}') WHERE document.id=" +
                "(SELECT document FROM listener WHERE listener.id='{2}')",
                listener.Document.InsuranceNumber, listener.Document.Passport.Number, listener.Id)
                },
                {
                string.Format("UPDATE listener SET surname = '{0}', name = '{1}', patronymic = '{2}', address = '{3}', birthday = '{4}', phone = '{5}', " +
                "employment = (SELECT id FROM employment WHERE title = '{6}'), education = (SELECT id FROM education WHERE title = '{7}'), " +
                "document = (SELECT id FROM document WHERE passport = (SELECT id FROM passport WHERE number = '{8}')), " +
                "gender = (SELECT id FROM gender WHERE name = '{9}'), modifiedBy=" +
                "'{10}' WHERE id = '{11}'",
                listener.Surname, listener.Name, listener.Patronymic, listener.Address, listener.BirthdayDate, listener.Phone,
                listener.Employment, listener.Education, listener.Document.Passport.Number, listener.Gender,
                DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), listener.Id)
                }
            };

            bool requestIsExecute = mySqlClient.ExecuteTransaction(queries);

            if (!requestIsExecute)
            {
                return Errors.GetError(Enums.Error.NewListenerNotUpdated);
            }

            return string.Empty;
        }


        public ListenerDto GetRowByPrimaryKey(string primaryKey)
        {
            ListenerDto listener = mySqlClient.FindOne<ListenerDto>(@"
                SELECT Listener.Id, Listener.Surname, Listener.Name, Listener.Patronymic, Listener.Address, 
                Listener.Birthday, Listener.Phone, (select title from employment where Listener.Employment=employment.id) AS 'Employment',
                (SELECT title from education where Listener.Education=education.id) AS 'Education', 
                (SELECT name from gender where Listener.Gender=gender.Id) AS 'Gender',
                Document.InsuranceNumber, Passport.Series, 
                Passport.Number, Passport.IssueDate, Passport.IssuedBy, Passport.DepartmentCode
                FROM Listener
                LEFT JOIN Document ON Listener.Document = Document.Id
                LEFT JOIN Passport ON Document.Passport = Passport.Id
                WHERE Listener.Id='" + primaryKey + "'");

            return listener;
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
