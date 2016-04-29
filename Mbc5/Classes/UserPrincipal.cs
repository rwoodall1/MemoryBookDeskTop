using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Principal;
namespace Mbc5.Classes
{
    public class UserPrincipal : GenericPrincipal
    {
        public string id { get; set; }
        public UserPrincipal(GenericIdentity User,string[] roles):base(User,roles)
        {

        }
    }
}
