using Listeners.MainMenu.Secretary;
using Listeners.MainMenu.SysAdmin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Listeners.Forms.MainMenu.SysAdmin
{
    public class SysAdminMenuController
    {
        private SysAdminMenuView view;

        public SysAdminMenuController(SysAdminMenuView view)
        {
            this.view = view;
        }

        public void ActivityControl(DateTime lastActivityTime)
        {
            TimeSpan inactiveDuration = DateTime.Now - lastActivityTime;

            if (inactiveDuration.TotalSeconds > Constants.MAX_INACTIVE_TIME_SECONDS)
            {
                view.StartLoginForm();
            }
        }
    }
}
