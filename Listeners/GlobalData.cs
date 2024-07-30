using Listeners.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Listeners
{
    public static class GlobalData
    {
        public static UserDto Employee;
        public static bool ListenerChanged = false;
        public static bool ListenerCreated = false;
        public static bool GroupChanged = false;
        public static bool GroupCreated = false;
        public static int IdGroup = 0;
        public static string Group = string.Empty;
        public static int IdListener = 0;
        public static int IdCourse = 0;
        public static string Course = string.Empty;
        public static bool CourseChanged = false;
        public static bool CourseCreated = false;
        public static bool RepresentativeChanged = false;
        public static bool RepresentativeCreated = false;
        public static int IdRepresentative = 0;
        public static bool OrganizationChanged = false;
        public static bool OrganizationCreated = false;
        public static int IdOrganization = 0;
        public static int IdListenerForRepresentative = 0;
        public static bool RepresentativeCreatedForListener = false;
        public static bool RecordChanged = false;
        public static bool RecordCreated = false;
        public static bool EmployeeChanged = false;
        public static bool EmployeeCreated = false;
        public static bool UserCreated = false;
        public static bool UserChanged = false;
    }
}
