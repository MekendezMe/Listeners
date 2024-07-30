using Listeners.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Listeners.Messages
{
    public static class PositiveMessages
    {
        private static Dictionary<Message, string> messages = new Dictionary<Message, string>()
        {
            {Message.ListenerIsCreated, "Добавление нового слушателя прошло успешно" },
            {Message.ListenerIsUpdated, "Изменение нового слушателя прошло успешно" }
        };

        public static string GetMessage(Message message)
        {
            return messages[message];
        }
    }
}
