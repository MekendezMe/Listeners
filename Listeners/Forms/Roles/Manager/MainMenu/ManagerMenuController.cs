using Listeners.MainMenu.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Listeners.Forms.MainMenu.Manager
{
    public class ManagerMenuController
    {
        private ManagerMenuView view;

        public ManagerMenuController(ManagerMenuView view)
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
