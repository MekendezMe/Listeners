using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Listeners.Interfaces
{
    public class IListener
    {
        public string Id { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        
        public string Patronymic { get; set; }

        public string Address { get; set; }

        public string BirthdayDate { get; set; }

        public string Phone { get; set; }

        public string Employment { get; set; }

        public string Education { get; set; }

        public string Gender { get; set; }

        public IDocument Document { get; set; }
    }
}
