using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Listeners.Interfaces
{
    public class IDocument
    {
        public string InsuranceNumber { get; set; }

        public IPassport Passport { get; set; }
    }
}
