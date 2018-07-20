using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BindingModels
{
    public class TaxRate
    {
        public decimal Rate { get; set; }
    }
    public class MbcBarScanModel
    {
        public string SchCode { get; set; }
        public string Schname { get; set; }
        public string Specovr { get; set; }
        public string ProdNo { get; set; }
        public string CpNum { get; set; }
        public string SchEmail { get; set; }
        public string ContEmail { get; set; }
        public int Invno { get; set; }
    }
}