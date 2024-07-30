using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Listeners.Interfaces
{
    public class IRepresentative
    {
        public string Surname { get; set; }

        public string Name { get; set; }    
        public string Patronymic { get; set; }

        public string Address { get; set; }

        public string Phone { get; set; }

        public string Listener { get; set; }

        public int IdListener { get; set; }
    }
}
