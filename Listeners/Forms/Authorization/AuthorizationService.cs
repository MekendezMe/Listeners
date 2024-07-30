using Listeners.DatabaseHelper;
using Listeners.Dictionaries;
using Listeners.Interfaces.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Listeners.Hash;
using Listeners.Interfaces;

namespace Listeners.Forms.Authorization
{
    public class AuthorizationService
    {
        private MySqlClient mySqlClient = new MySqlClient();

        public AuthorizationResponse Login(AuthorizationRequest candidate)
        {
            IUser employee = mySqlClient.FindOne<IUser>(
                "SELECT surname, name, patronymic, password, role" +
                "  from user  where login='" + candidate.Login + "'");

            if (employee == null)
            {
                return new AuthorizationResponse()
                {
                    Error = Errors.GetError(Enums.Error.EmployeeNotFound)
                };
            }

            string hashDatabasePassword = employee.Password;
            string hashCandidatePassword = HashHelper.HashInputPasswordToString(candidate.Password);

            if (hashCandidatePassword != hashDatabasePassword)
            {
                return new AuthorizationResponse()
                {
                    Error = Errors.GetError(Enums.Error.EmployeeNotFound)
                };
            }

            return new AuthorizationResponse()
            {
                Employee = employee
            };
        }
    }
}
