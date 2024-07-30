using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Listeners.Interfaces
{
    public class IRecordReceipt
    {
        public string Code { get; set; }

        public string DecorationDate { get; set; }

        public string ListenerSurname { get; set; }

        public string ListenerName { get; set; }

        public string ListenerPatronymic { get; set; }

        public string Organization { get; set; }

        public string Course { get; set; }

        public string Qualification { get; set; }

        public string Group { get; set; }

        public string StartCourse { get; set; }

        public string EndCourse { get; set; }

        public string ActualPayment { get; set; }

        public string Price { get; set; }

        public string CreditedStatus { get; set; }

        public string EndStatus { get; set; }

        public string PaymentStatus { get; set; }

        public string OpenStatus { get; set; }

        public string Representative { get; set; }
    }
}
