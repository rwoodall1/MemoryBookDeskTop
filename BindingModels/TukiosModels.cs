using System;

namespace BindingModels
{
    public class TukiosJobTicketQuery
    {

        public int Invno { get; set; }
        public string LastPageLocation { get; set; }
        public string PrintergyFile { get; set; }
        public string BookBlockUrl { get; set; }
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
        public string CoverPreviewUrl { get; set; }
        public string BookPreviewUrl { get; set; }
    }
}