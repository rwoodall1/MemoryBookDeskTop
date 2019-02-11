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
        public string PerfBind { get; set; }
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
    public class ProductionCheckList
    {
        public string Schname { get; set; }
        public string Schcode { get; set; }
        public string SchState { get; set; }
        public string SchCity { get; set; }
        public string SchAddr { get; set; }
        public string SchZip { get; set; }
        public string SchPhone { get; set; }
        public bool Vcrsent { get; set; }
        public string Spcinst { get; set; }
        public bool Magic { get; set; }
        public int Enrollment { get; set; }
        public bool AllColor { get; set; }
        public string ContFname { get; set; }
        public string ContLname { get; set; }
        public string ContAddr { get; set; }
        public string ContAddr2{ get; set; }
        public string ContCity { get; set; }
        public string ContState { get; set; }
        public string ContZip { get; set; }
        public string ShipToCont { get; set; }
        public string Sal { get; set; }
        public string ShipMemo { get; set; }
        public int NoPages { get; set; }
        public int NoCopies { get; set; }
        public string Contphnhom { get; set; }
        public bool Glspaper { get; set; }
        public bool Insck { get; set; }
        public bool Dc1 { get; set; }
        public string BookType { get; set; }
        public bool Allclrck { get; set; }
        public int Invno { get; set; }
        public string Prodno { get; set; }
        public string Covertype { get; set; }
        public bool Diecut { get; set; }
        public bool Laminated { get; set; }
        public bool Contrecvd { get; set; }
        public DateTime Screcv { get; set; }
        public string Perfbind { get; set; }
        public bool Speccover { get; set; }
        public DateTime Kitrecvd { get; set; }
        public DateTime Dedayin { get; set; }
        public DateTime Dedayout { get; set; }
        public DateTime Shpdate { get; set; }
        public string Coilclr { get; set; }
        public string Cstat { get; set; }
        public decimal Invtot { get; set; }
        public decimal Payments { get; set; }
        public decimal BalDue { get; set; }
        public string Hndred { get; set; }
        public DateTime Schout { get; set; }

    }
	public class WipUpdateCheck
	{
		public int QuoteInvno { get; set; }
		public string Schcode { get; set; }
		public int? ProdutnInvno { get; set; }
		public int? CoversInvno { get; set; }
		public int? WipInvno { get; set; }
	}
	public class OutlookAttachemt
	{
		public string Path { get; set; }
		public string Name { get; set; }
	}
	public class CoverDescriptions
	{
		public string CoverType { get; set; }
		public string CoverDescription { get; set; }
	}
}