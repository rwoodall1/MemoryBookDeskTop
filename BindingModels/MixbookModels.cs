using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BindingModels
{
    public class RemakeTicketQuery
    {
        public int Invno { get; set; }
        public int ClientOrderId { get; set; }
        public string DSInvno { get; set; }
        public string ShipName { get; set; }
        public DateTime RequestedShipDate { get; set; }
        public string Description { get; set; }
        public int Copies { get; set; }
        public int Pages { get; set; }
        public string Backing { get; set; }
        public DateTime OrderReceivedDate { get; set; }
        public int ProdInOrder { get; set; }
        public string SCBarcode { get; set; }
        public string YBBarcode { get; set; }
        public bool JobTicketPrinted { get; set; }
        public DateTime RemakeDate { get; set; }
        public int RemakeTotal { get; set; }
    }
    public class JobTicketQuery
    {

        public int Invno { get; set; }  
        public int ClientOrderId { get; set; }
        public string DSInvno { get; set; }
        public string ShipName { get; set; }
        public DateTime RequestedShipDate { get; set; }
        public string Description { get; set; }
        public int Copies { get; set; }
        public int Pages { get; set; }
        public string Backing { get; set; }
        public DateTime OrderReceivedDate { get; set; }
        public int ProdInOrder { get; set; }
        public int NumInOrder { get; set; }
        public string SCBarcode { get; set; }
        public string YBBarcode { get; set; }
        public bool JobTicketPrinted { get; set; }
    }
    public class SiblingCheck
    {
        public int ClientOrderId { get; set; }
        public int Invno { get; set; }
        public string MxbLocation { get; set; }
    }
    public class MixbookInvoiceReport
    {
        public int Invno { get; set; }
        public int ClientOrderId { get; set; }
        public DateTime OrderReceivedDate { get; set; }
        public DateTime RequestedShipDate{get;set;}
        public DateTime DateShipped { get; set; }
        public string ItemCode { get; set; }
        public string ItemId { get; set; }
        public string Description { get; set; }
        public int Copies { get; set; }
        public int Pages { get; set; }
        public decimal Weight { get; set; }
        public string ShipMethod { get; set; }
        public string ShipName { get; set; }
        public string ShipState { get; set; }
        public string ShipZip { get; set; }
        public string TrackingNumber { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal UnitTotal { get; set; }
        public decimal PageFee { get; set; }
        public decimal Fulfillment{get;set;}
        public decimal Total { get; set; }
        public string MixbookOrderStatus { get; set; }
    }
    public class BookBlockLabel
    {
        public string Barcode { get; set; }
         public string Location { get; set; }
    }
    public class WipReportModel
    {
        public string Invno { get; set; }  
        public string ShipName { get; set; }
        public string Backing { get; set; }
        public int Copies { get; set; }
        public int Pages { get; set; }
        public string IsBookRemake { get; set; }
        public string IsCoverRemake { get; set; }
        public string CTrimming { get; set;}
        //public string CTrimLoc { get; set; }
        public string PTrimming { get; set; }
        // public string PTrimLoc { get; set; }
        public string OrderReceivedDate { get; set; }
        public string RequestedShipDate { get; set; }
        public string Description { get; set; } 
        public string CPress { get; set; }
        public string OnBoards { get; set; }
        public string CCart { get; set; }
        public string WipPress { get; set; }     
        public string Binding { get; set; }
        public string PCart { get; set; }     
        public string CaseIn { get; set; }      
        public string Quality { get; set; }
        public string SCBarcode { get; set; }
        public string YBBarcode { get; set; }
    }

    public class MixBookBarScanModel
    {
        public string ShipName { get; set; }
        public string ShipMethod { get; set; }
        public string JobId { get; set; }
        public int ClientOrderId { get; set; }
        public int Invno { get; set; }
        public string ProdNo { get; set; }
        public string Specovr { get; set; }
        public string ItemId { get; set; }
        public int Quantity { get; set; }
        public string Backing { get; set; }
        public string BookPreviewUrl { get; set; }
        public string CoverPreviewUrl { get; set; }
        public string BookLocation { get; set; }
        public string PrintergyFile { get; set; }
        public int ProdInOrder { get; set; }
       public int NumProducts{get;set;}
        public string ShippingMethodName { get; set; }
        public string MixbookOrderStatus { get; set; }
        
    }
    public class MixBookItemScanModel
    {
        
        public int ClientOrderId { get; set; }
        public int Invno { get; set; }
        public string ItemId { get; set; }
        public int Quantity { get; set; }
        public string Description { get; set; }
    }
    public class OrderChk
    {
        public string MxbLocation { get; set; }
        public int Invno { get; set; }
    }

    public class MixbookPackingSlip
    {
        public int Invno { get; set; }
        public string ShipName { get; set; }
        public string ShipAddr { get; set; }
        public string ShipAddr2 { get; set; }
        public string ShipCity { get; set; }
        public string ShipState { get; set; }
        public string ShipZip { get; set; }
        public string OrderNumber { get; set; }
        public int ClientOrderId { get; set; }
        public int Copies { get; set; }
        public int Pages { get; set; }
        public string Description { get; set; }
        public string ItemCode { get; set; }
        public string JobId { get; set; }
        public string ItemId { get; set; }
        public string ShipMethod { get; set; }
        public string Carrier { get; set; }
        public string BarCode { get; set; }
        public string CoverLocation { get; set; }
        public string BookLocation { get; set; }
    }
    public class MixbookRemakeTicket
    {

        public int Invno { get; set; }
        public string ShipName { get; set; }
        public string ShipAddr { get; set; }
        public string ShipAddr2 { get; set; }
        public string ShipCity { get; set; }
        public string ShipState { get; set; }
        public string ShipZip { get; set; }
        public string OrderNumber { get; set; }
        public int ClientOrderId { get; set; }
        public int Copies { get; set; }
        public int Pages { get; set; }
        public string Description { get; set; }
        public string ItemCode { get; set; }
        public string JobId { get; set; }
        public string ItemId { get; set; }
        public string ShipMethod { get; set; }
        public string BarCode { get; set; }
        public string Location { get; set; }
        public string Item { get; set; }
        public DateTime RequestedShipDate { get; set; }

    }
    public class ShippingNotificationInfo
    {
        public string JobId { get; set; }
        public string TrackingNumber { get; set; }
        public string ItemId { get; set; }
        public int Qty { get; set; }
        public string ShipMethod { get; set; }
        public decimal Weight { get; set; }

    }
}