using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BindingModels
{

    public class Invoice {
        public string Schname { get; set; }
        public string Schcode { get; set; }
        public string Schemail { get; set; }
        public string Contemail { get; set; }
        public string Bcontemail { get; set; }
        public DateTime ShpDate { get; set; }
        public string Contfname { get; set; }
        public string Contlname { get; set; }
        public string Bcontfname { get; set; }
        public string Bcontlname { get; set; }
        public int Invno { get; set; }
        public bool Holdpmt { get; set; }
        public bool ToPrint { get; set; }
        public bool Collections { get; set; }
        public decimal Baldue { get; set; }


        public decimal BalDue { get; set; }
        public int InvoiceNumber { get; set; }
    }
    public class InvoiceCheck
    {
        public string InvoiceSchoolName { get; set; }
        public string CustomerSchname { get; set; }
        public string SchoolCode { get; set; }
        public decimal BalDue { get; set; }
        public int InvoiceNumber { get; set; }
    }
}