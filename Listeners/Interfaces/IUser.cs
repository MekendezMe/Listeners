﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Listeners.Interfaces
{
    public class IUser
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }
        public string Login { get; set; }

        public string Password { get; set; }

        public int Role { get; set; }

        public string RoleName { get; set; }
    }
}
