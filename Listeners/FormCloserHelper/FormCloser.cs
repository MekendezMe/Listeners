using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Listeners.FormCloserHelper
{
    public static class FormCloser
    {
        public static void ClosedForms()
        {
            for (int i = Application.OpenForms.Count - 1; i >= 0; i--)
            {
                if (Application.OpenForms[i].Name != "AuthorizationView")
                {
                    Application.OpenForms[i].Close();
                    Application.OpenForms[i].Dispose();
                }
            }
        }
    }
}
