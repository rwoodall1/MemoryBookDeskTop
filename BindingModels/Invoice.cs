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
        public string Schemail { get; set; }
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
}