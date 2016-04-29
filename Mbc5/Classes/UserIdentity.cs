using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Principal;
namespace Mbc5.Classes
{
    public class UserIdentity : GenericIdentity
    {
        public string id{ get;set;}
        public UserIdentity(string vname) : base(vname)
        {

        }

    }
}

