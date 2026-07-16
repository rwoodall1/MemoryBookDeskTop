using System;
using System.Collections.Generic;

namespace BindingModels
{

    public class TukiosNotification
    {
        public class Rootobject
        {
            public TukiosNotification Notification { get; set; }
        }
        public TukiosNotification()
        {
            Header = new Header()
            {
                From = new From()
                {
                    Credential = new Credential()
                    {
                        Identity = "Jostens",
                        Domain = "jostens.com"
                    }
                },
                To = new To()
                {
                    Credential = new Credential()
                    {
                        Identity = "Tukios",
                        Domain = "tukios.com"
                    }
                }


            };
            Request = new TukiosNotificationRequest()
            {
                Status = new Status()
                {

                },


            };
            TimeStamp = DateTime.UtcNow;
        }
        public Header Header { get; set; }
        public TukiosNotificationRequest Request { get; set; }

        public DateTime TimeStamp { get; set; }
    }

    public class Header
    {
        public From From { get; set; }
        public To To { get; set; }
    }

    public class From
    {
        public Credential Credential { get; set; }
    }
    public class To
    {
        public Credential Credential { get; set; }
    }


    public class Credential
    {
        public string Identity { get; set; }
        public string Domain { get; set; }
    }

    public class TukiosNotificationRequest
    {
        public Status Status { get; set; }
        public Shipment Shipment { get; set; }
        public string Identifier { get; set; }
    }

    public class Status
    {
        public DateTime OccurredAt { get; set; }
        public string Message { get; set; }
        public string ProjectedShipDate { get; set; }
        public string StatusText { get; set; }
    }

    public class Shipment
    {
        public List<Package> Packages { get; set; }
        public DateTime ShippedAt { get; set; }
        public string Method { get; set; }

    }

    public class Package  //each item or book
    {
        public List<TItem> Items { get; set; }
        public decimal Weight { get; set; }
        public string TrackingNumber { get; set; }
    }

    public class TItem
    {
        public int Invno { get; set; }
        public string BookType { get; set; }
        public string Identifier { get; set; }
        public string ClientOrderId { get; set; }
        public int Quantity { get; set; }
        public string Description { get; set; }

    }
}



