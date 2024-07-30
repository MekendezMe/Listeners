using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Listeners.Interfaces.Authorization
{
    public class AuthorizationRequest
    {
        public string Login { get; set; }

        public string Password { get; set; }

        public string Captcha { get; set; }
    }
}
