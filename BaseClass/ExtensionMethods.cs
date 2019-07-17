using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace BaseClass
{
    public static class ExtensionMethods
    {
        public static bool IsInOneOfRoles(this Classes.UserPrincipal ApplicationUser,List<string> roles)
        {
            bool retval = false ;
            foreach(string role in roles)
            {
                if (ApplicationUser.IsInRole(role))
                {
                    retval= true;
                    break;
                    
                }
            }
            return retval;
        }
        public static decimal ConvertToDecimal( this TextBox ctrl)
        {
            ctrl.Text.Replace("$", "").Replace(",", "");
            decimal retval=0;
            decimal.TryParse(ctrl.Text, out retval);
                return retval;
        }
        public static int ConvertToInt(this TextBox ctrl)
        {
            int retval = 0;
            int.TryParse(ctrl.Text, out retval);
            return retval;
        }
    }
}
