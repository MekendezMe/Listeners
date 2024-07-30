using Listeners.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Listeners.Dtos
{
    public class ListenerDto
    {
        public string Id { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }

        public string Patronymic { get; set; }

        public string Address { get; set; }

        public string Birthday { get; set; }

        public string Phone { get; set; }

        public string Employment { get; set; }

        public string Education { get; set; }

        public string Gender { get; set; }

        public string Group { get; set; }

        public string InsuranceNumber { get; set; }

        public string Series { get; set; }

        public string Number { get; set; }

        public string IssueDate { get; set; }

        public string IssuedBy { get; set; }
        public string DepartmentCode { get; set; }
    }
}
