using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Listeners.Interfaces
{
    public class IRecord
    {
        public string Code { get; set; }

        public string DecorationDate { get; set; }

        public string TransferOrder { get; set; }

        public string DateTransferOrder { get; set; }

        public string ExpulsionOrder { get; set; }

        public string DateExpulsionOrder { get; set; }

        public string Group { get; set; }

        public string StartCourse { get; set; }

        public string EndCourse { get; set; }

        public string StatusPay { get; set; }

        public string StatusOpen { get; set; }

        public string StatusCredited { get; set; }

        public string StatusEnd { get; set; }

        public string ActualPayment { get; set; }
    }
}
