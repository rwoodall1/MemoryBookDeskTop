using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BindingModels
{
    public class SchoolNameSearchModel
    {
        public string schcode { get; set; }
        public string schname { get; set; }
        public string schzip { get; set; }
        public string schcity { get; set; }
        public string schstate { get; set; }

    }
    public class SchCheck
    {
        public string Schcode { get; set; }
    }
}
