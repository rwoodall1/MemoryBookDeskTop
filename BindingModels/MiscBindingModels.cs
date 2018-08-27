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
    public class ProdutnTicketModel
    {
        public int Invno { get; set; }
        public string Schname { get; set; }
        public string JobNo { get; set; }
        public string Company { get; set; }
        public bool AllClrck { get; set; }
        public string Schcode { get; set; }
        public string VendCd { get; set; }
        public string ContractYear { get; set; }
        public string BookType { get; set; }
        public string ProdNo { get; set; }
        public string BackGround { get; set; }
        public int NoPages { get; set; }
        public int NoCopies { get;set; }
        public string CoilClr { get; set; }
        public string Theme { get; set; }
        public string State { get; set; }
        public bool PerfBind { get; set; }
        public bool Insck { get; set; }
        public bool YirSchool { get; set; }
        public string ColorPageNum { get; set; }
        public string EndsheetNum{ get; set; }
        public string TypeStyle { get; set; }
        public string SpecialInstructions { get; set; }
        public int PersonalCopies { get; set; }
        public bool Personalize { get; set; }
        public string FoilClr { get; set; }
        public int MSstandardQty { get; set; }
        public bool Laminated { get; set; }
        public string CoverType { get; set; }
        public string CoverDesc { get; set; }
        public string BindVend { get; set; }
        public DateTime Prshpdte { get; set; }
        public string SchColors { get; set; }
        public int NumPgs { get; set; }
    }
}