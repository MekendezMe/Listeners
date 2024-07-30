using Listeners.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Listeners.Dictionaries
{
    public static class Errors
    {
        private static Dictionary<Error, string> errors = new Dictionary<Error, string>()
        {
            {Error.EmptyFields, "Должны быть заполнены все обязательные поля, помеченные символом *" },
            {Error.EmployeeNotFound, "Данные введены неверно" },
            {Error.UnvalidatePassword, "Пароль должен состоять минимум из 8 символов" },
            {Error.IncorrectCaptcha, "Капча введена неверно" },
            {Error.InsuranceIsExist, "Данный СНИЛС уже зарегистрирован" },
            {Error.PassportIsExist, "Данный паспорт уже зарегистрирован" },
            {Error.PhoneNumberIsExist, "Данный номер телефона уже зарегистрирован" },
            {Error.NewListenerNotCreated, "Не удалось добавить нового слушателя" },
            {Error.NoOneRecordFound, "Не найдено ни одной записи" },
            {Error.InputDateIncorrect, "Введена некорректная дата" },
            {Error.InputDateTooSmall, "Возраст человека должен быть не менее 14 лет" },
            {Error.WithInputSearchDataNotFound, "При заданном условии поиска данные не найдены" },
            {Error.NoOneRowFoundByPrimaryKey, "Не выбрана запись при попытке редактирования" },
            {Error.NewListenerNotUpdated, "Не удалось изменить выбранного слушателя" },
            {Error.DeleteRowNotCompleted, "Не удалось удалить выбранного слушателя" }
        };

        public static string GetError(Error error)
        {
            return errors[error];
        }
    }
}
