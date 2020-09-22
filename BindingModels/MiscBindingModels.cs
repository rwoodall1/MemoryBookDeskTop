using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BindingModels
{
   
    public class LogMetadata
    {
        public string RequestContentType { get; set; }
        public string RequestUri { get; set; }
        public string RequestMethod { get; set; }
        public string RequestContent { get; set; }
        public DateTime? RequestTimestamp { get; set; }
        public string ResponseContentType { get; set; }
        public string ResponseContent { get; set; }
        public System.Net.HttpStatusCode ResponseStatusCode { get; set; }
        public DateTime? ResponseTimestamp { get; set; }
        public string Source { get; set; }
    }
    public class XtraInvoiceGrid
    {
        public int XtraInvno { get; set; }
        public int SalesInvno { get; set; }
        public DateTime InvoiceDate { get; set; }
        public int Quantity { get; set; }
        public decimal Total { get; set; }
    }
    public class InqCountModel
    {
        public string CSNAME { get; set; }
        public string SCHSTATE { get; set; }
        public string SCHCODE { get; set; }
        public string OracleCode { get; set; }
        public string SOURDATE { get; set; }
        public string INITCONT { get; set; }
        public string SCHNAME { get; set; }
        public string Contname { get; set; }
        public string Email1 { get; set; }
        public string Email2 { get; set; }
        public string CONTRYEAR { get; set; }
        public string Stage { get; set; }      
        public string QTEDATE { get; set; }
        public decimal ADJBEF { get; set; }
        public string INITIAL { get; set; }
        public string DATECONT { get; set; }
        public string REASON { get; set; }
    }
    public class MInqCountModel
    {
        public string CSNAME { get; set; }
        public string SCHSTATE { get; set; }
        public string SCHCODE { get; set; }
        public string OracleCode { get; set; }
        public string SOURDATE { get; set; }
        public string INITCONT { get; set; }
        public string SCHNAME { get; set; }
        public string Contname { get; set; }
        public string Email1 { get; set; }
        public string Email2 { get; set; }
        public string CONTRYEAR { get; set; }
        public string Stage { get; set; }
        public string QTEDATE { get; set; }
        public string Category { get; set; }
        public decimal FplnTot { get; set; }
        public string INITIAL { get; set; }
        public string DATECONT { get; set; }
        public string REASON { get; set; }
    }
    public class OnlineFlyer {
        public string SchName { get; set; }
        public string SchCode { get; set; }
        public string BasicPrice { get; set; }
        public bool HasPersonalized { get; set; }
        public string PersonalizedPrice { get; set; }
        public bool HasLoveLine { get; set; }
        public string LoveLineAmt { get; set; }
        public bool HasAds { get; set; }
        public string EighthAdAmt { get; set; }
        public string QuarterAdAmt { get; set; }
        public string HalfAdAmt { get; set; }
        public string FullAdAmt { get; set; }
        public DateTime? OnlineCutoff { get; set; }
        public DateTime? AdCutoff { get; set; }
    }
    public class OnlineAgreementHeader {
        public int Invno { get; set; }
        public string PoNumber { get; set; }
        public decimal BeforeTaxTotal { get; set; }
        public decimal SalesTax { get; set; }
        public decimal Invtot { get; set; }
        public DateTime? QuoteDate { get; set; }
        public string SchName { get; set; }
        public string SchCode { get; set; }
        public string ContactFirstName { get; set; }
        public string ContactLastName { get; set; }
        public string SchAddress { get; set; }
        public string SchAddress2 { get; set; }
        public string SchCity { get; set; }
        public string SchState { get; set; }
        public string SchZipCode { get; set; }
        public string NoCopies { get; set; }
     }
    
    public class TaxRate
    {
        public decimal Rate { get; set; }
    }
    public class DepartmentLabel
    {
        public int Id { get; set; }
        public string Description { get; set; }
    }
    public class MktInfo
    {
        public int Id { get; set; }
        public string Schname { get; set; }
        public string Schcode { get; set; }
        public DateTime Ddate { get; set; }
        public string Initial { get; set; }
        public string Note { get; set; }
        public string Promo { get; set; }
        public string Refered { get; set; }
        public string Company { get; set; }
        public int ProspectId { get; set; }
        
    }
    public class MbcBarScanModel
    {
        public string SchCode { get; set; }
        public string Schname { get; set; }
        public string Specovr { get; set; }
        public string ProdNo { get; set; }
        public string CpNum { get; set; }
        public string SchEmail { get; set; }
        public string BContEmail { get; set; }
        public string CContEmail{get;set;}
        public string ContEmail { get; set; }
        public int Invno { get; set; }
    }
   
    public class MerBarScanModel
    {
        public string SchCode { get; set; }
        public string Schname { get; set; }
        public string Specovr { get; set; }
        public string ProdNo { get; set; }
      
        public string SchEmail { get; set; }
        public string BContEmail { get; set; }
        public string CContEmail { get; set; }
        public string ContEmail { get; set; }
        public int Invno { get; set; }
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
    public class TelephonLogRecord
    {
        public string Schname { get; set; }
        public string Schcode { get; set; }
        public DateTime Datecont { get; set; }
        public string Reason { get; set; }
        public string Initial { get; set; }
        public string Contact { get; set; }
        public string TypeCont { get; set; }
        public int NxtDays { get; set; }
        public DateTime NxtDate { get; set; }
        public bool CallCont { get; set; }
        public decimal CallTime { get; set; }
        public int Priority { get; set; }
        public string Company { get; set; }
        public bool TechCall { get; set; }
        public int Id { get; set; }



    }
    public class PaymentQuery
    {
        public int Invno { get; set; }
        public DateTime PmtDate { get; set; }
        public decimal Payment { get; set; }
        public string SchName { get; set; }
        public string SchEmail { get; set; }
        public string ContEmail { get; set; }
        public string Schcode { get; set; }
        public bool Print { get; set; }
    }
}