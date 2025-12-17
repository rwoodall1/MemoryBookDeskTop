using System;

namespace BindingModels
{
    public class JPIXWipReportModel
    {
        public string ShipToCustomerName { get; set; }
        public int Invno { get; set; }
        public int Quantity { get; set; }
        public string NeedByDate { get; set; }
        public string ProjectedShipDate { get; set; }
        public string Description { get; set; }
        public string OracleCode { get; set; }
        public string OrderReceivedDate { get; set; }
        public string WipPress { get; set; }
        public DateTime Kitrecvd { get; set; }
        public string OrderStatus { get; set; }
    }
    public class JPIXFlyerInvoiceReport
    {
        public int Invno { get; set; }
        public int Quantity { get; set; }
        public string OrderStatus { get; set; }
        public DateTime DateReceived { get; set; }
        public DateTime NeedsByDate { get; set; }
        public DateTime DateShipped { get; set; }
        public DateTime ProjectedShipDate { get; set; }
        public string TrackingNumber { get; set; }
        public string OracleCode { get; set; }
        public string ProductType { get; set; }
        public string RequestId { get; set; }
        public int Reference { get; set; }
        public string ShipToCustomerName { get; set; }
        public string ShipToContact { get; set; }
        public string ShipToAddress1 { get; set; }
        public string ShipToAddress2 { get; set; }
        public string ShipToCity { get; set; }
        public string ShipToStateOrProvince { get; set; }
        public string ShipToPostalCode { get; set; }
        public string ShipToCountry { get; set; }
        public string ShipToGroup { get; set; }
        public string ShipMethod { get; set; }
        public decimal ShipCost { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal LineItemTotal { get; set; }
        public decimal Total { get; set; }


    }
}