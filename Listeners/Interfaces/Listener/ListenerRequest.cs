using Listeners.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Listeners.Interfaces.Listener
{
    public class ListenerRequest
    {
        public string Search { get; set; }
        public string Filter { get; set; }

        public string Sort { get; set; }

        public Pagination Pagination { get; set; }

        public int CountRowsInPage { get; set; }

        public int CurrentPage { get; set; }
        public bool RowCreated { get; set; }
        public bool RowUpdated { get; set; }
    }
}
