using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Listeners.Enums
{
    public enum Error
    {
        EmptyFields,
        EmployeeNotFound,
        UnvalidatePassword,
        IncorrectCaptcha,
        PassportIsExist,
        InsuranceIsExist,
        PhoneNumberIsExist,
        NewListenerNotCreated,
        NoOneRecordFound,
        InputDateIncorrect,
        InputDateTooSmall,
        WithInputSearchDataNotFound,
        NoOneRowFoundByPrimaryKey,
        NewListenerNotUpdated,
        DeleteRowNotCompleted
    }
}
