using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using System.Collections.Specialized;
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
        public static bool IsInOneOfRoles(this Classes.UserPrincipal ApplicationUser, StringCollection roles)
        {
            bool retval = false;
            foreach (string role in roles)
            {
                if (ApplicationUser.IsInRole(role))
                {
                    retval = true;
                    break;

                }
            }
            return retval;
        }
        public static decimal ConvertToDecimal( this TextBox ctrl)
        {
            ctrl.Text.Replace("$", "").Replace(",", "");
            decimal retval=0;
            if (ctrl.Text.Trim() == "")
            {
                ctrl.Text = "0";
            }
            decimal.TryParse(ctrl.Text, out retval);
                return retval;
        }
        public static int ConvertToInt(this TextBox ctrl)
        {
            ctrl.Text.Replace("$", "").Replace(",", "");
            int retval = 0;
            if (ctrl.Text.Trim() == "")
            {
                ctrl.Text = "0";
            }
            int.TryParse(ctrl.Text, out retval);
            return retval;
        }
        public static decimal ConvertToDecimal(this Label ctrl)
        {
           string newVal = "0";
             newVal=ctrl.Text.Replace("$", "").Replace(",", "");
            decimal retval = 0;
            if (newVal == "")
            {
                newVal = "0";
            }
            decimal.TryParse(newVal, out retval);
            return retval;
        }
        public static int ConvertToInt(this Label ctrl)
        {
            ctrl.Text.Replace("$", "").Replace(",", "");
            int retval = 0;
            if (ctrl.Text.Trim() == "")
            {
                ctrl.Text = "0";
            }
            int.TryParse(ctrl.Text, out retval);
            return retval;
        }
        public static bool IsNumeric(this TextBox ctrl)
        {
            int vnumber = 0;
           return int.TryParse(ctrl.Text, out vnumber);
        }
       
        public static bool IsBetween<T>(this T item, T start, T end)
        {
            return Comparer<T>.Default.Compare(item, start) >= 0
                && Comparer<T>.Default.Compare(item, end) <= 0;
        }
        

    }
}
