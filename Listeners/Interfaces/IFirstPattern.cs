using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Listeners.Interfaces
{
    public class IFirstPattern
    {
        public string Series { get; set; }
        public string Number { get; set; }

        public string IssueDate { get; set; }

        public string Group { get; set; }

        public string Course { get; set; }

        public string Qualification { get; set; }

        public string StartCourse { get; set; }

        public string EndCourse { get; set; }

        public string Duration { get; set; }

        public string Birthday { get; set; }

        public string Gender { get; set; }

        public string InsuranceNumber { get; set; }

        public string Type { get; set; } = "Свидетельство о профессии рабочего, должности служащего";

        public string Status { get; set; } = "Оригинал";

        public string Surname { get; set; }

        public string Name { get; set; }

        public string Patronymic { get; set; }
    }
}
