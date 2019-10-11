using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BindingModels
{
    public class Cancellation {
        public string Schname { get; set; }
        public string Schcode { get; set; }
        public string Schemail { get; set; }
        public DateTime CancelDate { get; set; }
        public string Contemail { get; set; }
        public string Bcontemail { get; set; }
        public DateTime? ShpDate { get; set; }
        public string Contfname { get; set; }
        public string Contlname { get; set; }
        public string Bcontfname { get; set; }
        public string Bcontlname { get; set; }
        public int Invno { get; set; }
        public bool Holdpmt { get; set; }
        public bool ToPrint { get; set; }
        public bool Collections { get; set; }
        public decimal Baldue { get; set; }
        public int Pin { get; set; }  
        public int InvoiceNumber { get; set; }
    }
    public class Invoice {
        public string Schname { get; set; }
        public string Schcode { get; set; }
        public string InvoiceEmail1 { get; set; }
        public string InvoiceEmail2 { get; set; }
        public string InvoiceEmail3 { get; set; }
        public DateTime? ShpDate { get; set; }
        public string Contfname { get; set; }
        public string Contlname { get; set; }
        public string Bcontfname { get; set; }
        public string Bcontlname { get; set; }
        public int Invno { get; set; }
        public bool Holdpmt { get; set; }
        public bool ToPrint { get; set; }
        public bool Collections { get; set; }
        public decimal Baldue { get; set; }
        public int Pin { get; set; }
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
	public class InvoiceDetailBindingModel {
		public string descr { get; set; }
		public decimal? price { get; set; }
		public string discpercent { get; set; }
		public int invno { get; set; }
		public string schoolcode { get; set; }
	}
	public class InvoiceDetails {
		public List<InvoiceDetailBindingModel> detailrec { get; set; }

	}
	public class FullInvoice {
		public int Invno { get; set; }
		public string PoNumber { get; set; }
		public decimal Baldue { get; set; }
		public decimal BeforeTaxTotal { get; set; }
		public decimal SalesTax { get; set; }
		public decimal Invtot { get; set; }
		public DateTime QuoteDate { get; set; }
		public string Description { get; set; }
		public decimal Price { get; set; }
		public string DiscPercent { get; set; }
		public string SchName { get; set; }
		public string SchCode { get; set; }
		public string ContactFirstName { get; set; }
		public string ContactLastName { get; set; }
		public string SchAddress { get; set; }
		public string SchCity { get; set; }
		public string SchState { get; set; }
		public string ZipCode { get; set; }
		public int NumberPages { get; set; }
		public int NumberCopies { get; set; }
		public decimal Payments { get; set; }
		public string ContractYear { get; set; }
		public bool AllColor { get; set; }
		//laminate if for folders that are no longer use not for books
		public string Laminate { get; set; }
		int Freebooks { get; set; }
	}
    public class FullMerInvoice
    {
        public string InvName { get; set; }
        public string SchCode { get; set; }
        public string InvAddr { get; set; }
        public string InvAddr2 { get; set; }
        public string InvCity { get; set; }
        public string InvState { get; set; }
        public string InvZip { get; set; }
        public string ShpName { get; set; }
        public string ShpAddr { get; set; }
        public string ShpAddr2 { get; set; }
        public string ShpCity { get; set; }
        public string ShpState { get; set; }
        public string ShpZip { get; set; }
        public string InvNotes { get; set; }
        public DateTime ShpDate { get; set; }
        public string PoNum { get; set; }
        public string Contryear { get; set; }
        public DateTime QteDate{get;set;}
        public int Invno { get; set; }
        public Decimal FplnPrc { get; set; }
        public Decimal SubTotal { get; set; }
        public Decimal SalesTax { get; set; }
        public Decimal ShpHandling { get; set; }
        public Decimal FplnTot { get; set; }
        public Decimal Payments { get; set; }
        public Decimal BalDue { get; set; }
        public int QtyStudent { get; set; }
        public int QtyTeacher { get; set; }
        public string SchType { get; set; }
        public int NoPages { get; set; }
        public bool Generic { get; set; }
        public decimal BasePrc { get; set; }
        public decimal TeBasePrc { get; set; }
    }
    public class MerInvoiceDetails
    {
        public int Quantity { get; set; }
        public string Descr { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Amount { get; set; }
    }
}