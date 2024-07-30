using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Listeners.Interfaces
{
    public class IPayment
    {
        public string Record { get; set; }

        public string Date { get; set; }

        public string Paid { get; set; } 
    }
}
