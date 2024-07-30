using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Listeners.Interfaces.Authorization
{
    public class AuthorizationResponse
    {
        public IUser Employee { get; set; }

        public string Error { get; set; }
    }
}
