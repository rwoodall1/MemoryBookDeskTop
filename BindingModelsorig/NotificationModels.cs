
// NOTE: Generated code may require at least .NET Framework 4.5 or .NET Core/Standard 2.0.
using System;
using System.Collections.Generic;
namespace BindingModels
{
    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class MixbookNotification
    {
        public MixbookNotification()
        {
            try
            {
                this.Request = new MixbookNotificationRequest
                {
                    Status = new MixbookNotificationRequestStatus(),
                    
                    Shipment = new List<MixbookNotificationRequestShipment>()
                   
                };

                this.Request.Shipment.Add(new MixbookNotificationRequestShipment());
                this.Request.Shipment[0].Package = new List<MixbookNotificationRequestShipmentPackage>();
               // this.Request.Shipment[0].Package[0].Item.identifier = new MixbookNotificationRequestShipmentPackageItem();
                this.Request.Shipment[0].Package.Add(new MixbookNotificationRequestShipmentPackage());
                this.Request.Shipment[0].Package[0].Item = new MixbookNotificationRequestShipmentPackageItem();

                this.Header = new MixbookNotificationHeader
                {
                    From = new MixbookNotificationHeaderFrom()
                };
                this.timeStamp = DateTime.Now;
                this.Header.From.Credential = new MixbookNotificationHeaderFromCredential();
                this.Header.From.Credential.domain = "jostens.com";
                this.Header.From.Credential.Identity = System.Configuration.ConfigurationManager.AppSettings["Printer"].ToString();
            }catch(Exception ex) { }


        }

        private MixbookNotificationHeader headerField;

        private MixbookNotificationRequest requestField;

        private decimal versionField;

        private System.DateTime timeStampField;

        /// <remarks/>
        public MixbookNotificationHeader Header
        {
            get
            {
                return this.headerField;
            }
            set
            {
                this.headerField = value;
            }
        }

        /// <remarks/>
        public MixbookNotificationRequest Request
        {
            get
            {
                return this.requestField;
            }
            set
            {
                this.requestField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public decimal version
        {
            get
            {
                return this.versionField;
            }
            set
            {
                this.versionField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public System.DateTime timeStamp
        {
            get
            {
                return this.timeStampField;
            }
            set
            {
                this.timeStampField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class MixbookNotificationHeader
    {

        private MixbookNotificationHeaderFrom fromField;

        /// <remarks/>
        public MixbookNotificationHeaderFrom From
        {
            get
            {
                return this.fromField;
            }
            set
            {
                this.fromField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class MixbookNotificationHeaderFrom
    {

        private MixbookNotificationHeaderFromCredential credentialField;

        /// <remarks/>
        public MixbookNotificationHeaderFromCredential Credential
        {
            get
            {
                return this.credentialField;
            }
            set
            {
                this.credentialField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class MixbookNotificationHeaderFromCredential
    {

        private string identityField;

        private string domainField;

        /// <remarks/>
        public string Identity
        {
            get
            {
                return this.identityField;
            }
            set
            {
                this.identityField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string domain
        {
            get
            {
                return this.domainField;
            }
            set
            {
                this.domainField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class MixbookNotificationRequest
    {

        private MixbookNotificationRequestStatus statusField;

        private List<MixbookNotificationRequestShipment> shipmentField;

        private string identifierField;

        /// <remarks/>
        public MixbookNotificationRequestStatus Status
        {
            get
            {
                return this.statusField;
            }
            set
            {
                this.statusField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Shipment")]
        public List<MixbookNotificationRequestShipment> Shipment
        {
            get
            {
                return this.shipmentField;
            }
            set
            {
                this.shipmentField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string identifier
        {
            get
            {
                return this.identifierField;
            }
            set
            {
                this.identifierField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class MixbookNotificationRequestStatus
    {

        private System.DateTime occurredAtField;

        private string valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public System.DateTime occurredAt
        {
            get
            {
                return this.occurredAtField;
            }
            set
            {
                this.occurredAtField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class MixbookNotificationRequestShipment
    {

        private List<MixbookNotificationRequestShipmentPackage> packageField;

        private string trackingNumberField;

        private System.DateTime shippedAtField;

        private string methodField;

        private decimal weightField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Package")]
        public List<MixbookNotificationRequestShipmentPackage> Package
        {
            get
            {
                return this.packageField;
            }
            set
            {
                this.packageField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string trackingNumber
        {
            get
            {
                return this.trackingNumberField;
            }
            set
            {
                this.trackingNumberField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public System.DateTime shippedAt
        {
            get
            {
                return this.shippedAtField;
            }
            set
            {
                this.shippedAtField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string method
        {
            get
            {
                return this.methodField;
            }
            set
            {
                this.methodField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public decimal weight
        {
            get
            {
                return this.weightField;
            }
            set
            {
                this.weightField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class MixbookNotificationRequestShipmentPackage
    {

        private MixbookNotificationRequestShipmentPackageItem itemField;

        /// <remarks/>
        public MixbookNotificationRequestShipmentPackageItem Item
        {
            get
            {
                return this.itemField;
            }
            set
            {
                this.itemField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class MixbookNotificationRequestShipmentPackageItem
    {

        private string identifierField;

        private int quantityField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string identifier
        {
            get
            {
                return this.identifierField;
            }
            set
            {
                this.identifierField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int quantity
        {
            get
            {
                return this.quantityField;
            }
            set
            {
                this.quantityField = value;
            }
        }
    }
}
