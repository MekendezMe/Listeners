using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Listeners.Interfaces.Listener
{
    public class ListenerResponse
    {
        public bool SearchSuccess { get; set; }
        public int CurrentPage { get; set; }

        public DataTable Listeners { get; set; }

        public int CountPages { get; set; }

        public int CountRows { get; set; }
    }
}
