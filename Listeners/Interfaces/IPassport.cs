using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Listeners.Interfaces
{
    public class IPassport
    {
        public string Series { get; set; }

        public string Number { get; set; }

        public string IssueDate { get; set; }

        public string IssuedBy { get; set; }
        public string DepartmentCode { get; set; }
    }
}
