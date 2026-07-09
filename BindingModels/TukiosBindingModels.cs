using System;

namespace BindingModels
{
    public class TukiosJobTicketQuery
    {

        public int Invno { get; set; }
        public string LastPageLocation { get; set; }
        public string FirstPageLocation { get; set; }
        public string CoverPageLocation { get; set; }

        public string PrintergyFile { get; set; }
        public string BookBlockURL { get; set; }
        public string ClientOrderId { get; set; }
        public string DSInvno { get; set; }
        public string ShipName { get; set; }
        public DateTime RequestedShipDate { get; set; }
        public string Description { get; set; }
        public int Copies { get; set; }
        public int ProdCopies { get; set; }
        public int LargePressQty { get; set; }
        public int SmallPressQty { get; set; }
        public int Pages { get; set; }
        public string Backing { get; set; }
        public DateTime OrderReceivedDate { get; set; }
        public int ProdInOrder { get; set; }
        public int NumInOrder { get; set; }
        public string SCBarcode { get; set; }
        public string YBBarcode { get; set; }
        public bool JobTicketPrinted { get; set; }
        public int NumToShip { get; set; }
        public int JobPrintBatch { get; set; }
        public string CoverURL { get; set; }
        public string BookPreviewUrl { get; set; }
    }

    public class TukiosInvoiceReport
    {
        public int Invno { get; set; }
        public string ClientOrderId { get; set; }
        public DateTime OrderReceivedDate { get; set; }
        public DateTime RequestedShipDate { get; set; }
        public DateTime DateShipped { get; set; }
        public string ItemCode { get; set; }
        public string BookId { get; set; }
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
        public decimal Fulfillment { get; set; }
        public decimal Total { get; set; }
        public string Status { get; set; }
        public decimal Freight { get; set; }

    }
    public class TukiosResponse
    {
        public bool success { get; set; }
        public string message { get; set; }
    }
    public class TukiosRemakeTicketQuery
    {
        public int Invno { get; set; }
        public string LastPageLocation { get; set; } = "";
        public string FirstPageLocation { get; set; } = "";
        public string CoverPageLocation { get; set; } = "";
        public string PrintergyFile { get; set; } = "";
        public string ClientOrderId { get; set; }
        public string DSInvno { get; set; }
        public string ShipName { get; set; }
        public DateTime RequestedShipDate { get; set; }
        public string Description { get; set; }
        public int Copies { get; set; }
        public int ProdCopies { get; set; }
        public int Pages { get; set; }
        public string Backing { get; set; }
        public DateTime OrderReceivedDate { get; set; }
        public int ProdInOrder { get; set; }
        public string SCBarcode { get; set; }
        public string YBBarcode { get; set; }
        public bool JobTicketPrinted { get; set; }
        public DateTime RemakeDate { get; set; }
        public int RemakeTotal { get; set; }
        public int NumToShip { get; set; }
        public string CoverURL { get; set; }
        public string BookBlockURL { get; set; }
        public int LargePressQty { get; set; }
        public int SmallPressQty { get; set; }
    }
    public class TukiosItemScanModel
    {

        public int ClientOrderId { get; set; }
        public int Invno { get; set; }
        public string ItemId { get; set; }
        public int Quantity { get; set; }
        public string Description { get; set; }
    }
    public class TukiosBarScanModel
    {
        public string ShipName { get; set; }
        public string ShipMethod { get; set; }
        public string BookType { get; set; }
        public string ClientOrderId { get; set; }

        public int Invno { get; set; }
        public string ProdNo { get; set; }
        public string Specovr { get; set; }
        public string BookId { get; set; }
        public int Quantity { get; set; }
        public string Backing { get; set; }
        public string BookPreviewUrl { get; set; }
        public string CoverPreviewUrl { get; set; }
        public string BookLocation { get; set; }
        public string PrintergyFile { get; set; }
        public int ProdInOrder { get; set; }
        public int NumProducts { get; set; }
        public string ShippingMethodName { get; set; }
        public string TukiosOrderStatus { get; set; }
        public DateTime RequestedShipDate { get; set; }
    }
}