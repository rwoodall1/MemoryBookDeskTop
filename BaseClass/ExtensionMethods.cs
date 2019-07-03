using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
