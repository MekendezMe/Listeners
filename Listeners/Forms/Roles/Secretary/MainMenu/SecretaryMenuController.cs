using Listeners.MainMenu.Manager;
using Listeners.MainMenu.Secretary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Listeners.Forms.MainMenu.Secretary
{
    public class SecretaryMenuController
    {
        private SecretaryMenuView view;

        public SecretaryMenuController(SecretaryMenuView view)
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
