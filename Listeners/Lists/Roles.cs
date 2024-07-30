using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Listeners.Lists
{
    public static class Roles
    {
        private static Dictionary<int, string> _roles = new Dictionary<int, string>()
        {
            {1, Constants.ROLE_ADMINISTRATOR },
            {2, Constants.ROLE_SECRETARY },
            {3, Constants.ROLE_MANAGER }
        };

        public static string GetRole(int role)
        {
            if (!_roles.ContainsKey(role)) return string.Empty;

            return _roles[role];
        }
    }
}
