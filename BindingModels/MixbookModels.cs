using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BindingModels
{

    public class BookBlockLabel
    {
        public string Barcode { get; set; }
         public string Location { get; set; }
    }
    public class WipReportModel
    {
        public int Invno { get; set; }       
        public int Copies { get; set; }
        public int Pages { get; set; }
        public string Size { get; set; }
        public DateTime OrderReceivedDate { get; set; }
        public int ClientOrderId { get; set; }
        public DateTime RequestedShipDate { get; set; }
        public string Description { get; set; }       
        
        public DateTime OnBoards { get; set; }
        public string Location37 { get; set; }
       
        public DateTime Trimming { get; set; }
        public string Location43 { get; set; }
        
        public DateTime WipPress { get; set; }     
       
        public DateTime Binding { get; set; }
        public string Location39 { get; set; }
      
        public DateTime CaseIn { get; set; }
      
        public DateTime Quality { get; set; }
        public string Location50 { get; set; }
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
        public string BarCode { get; set; }
        public string CoverLocation { get; set; }
    }
    public class ShippingNotificationInfo
    {
        public string JobId { get; set; }
        public string TrackingNumber { get; set; }
        public string ItemId { get; set; }
        public int Qty { get; set; }
        public string ShipMethod { get; set; }
        public int Weight { get; set; }

    }
}