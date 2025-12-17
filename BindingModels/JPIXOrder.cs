using System;
namespace BindingModels
{

    // NOTE: Generated code may require at least .NET Framework 4.5 or .NET Core/Standard 2.0.
    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class JostensPIXFulfillmentRequests
    {

        private string requestIdField;

        private JostensPIXFulfillmentRequestsJostensPIXOrderItem[] jostensPIXOrderField;

        /// <remarks/>
        public string RequestId
        {
            get
            {
                return this.requestIdField;
            }
            set
            {
                this.requestIdField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("JostensPIXOrderItem", IsNullable = false)]
        public JostensPIXFulfillmentRequestsJostensPIXOrderItem[] JostensPIXOrder
        {
            get
            {
                return this.jostensPIXOrderField;
            }
            set
            {
                this.jostensPIXOrderField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class JostensPIXFulfillmentRequestsJostensPIXOrderItem
    {

        private string referenceField;

        private string documentField;

        private string productTypeField;

        private int quantityField;

        private string shipToContactField;

        private string shipToCustomerNameField;

        private string shipToAddress1Field;

        private string shipToAddress2Field;

        private string shipToCityField;

        private string shipToStateOrProvinceField;

        private string shipToPostalCodeField;

        private string shipToCountryField;

        private uint shipToGroupField;

        private string needsByDateField;

        private DateTime dateNeedsByDateField;

        private string schoolNameField;

        private string schoolCodeField;

        private string eventCodeField;

        /// <remarks/>
        public string Reference
        {
            get
            {
                return this.referenceField;
            }
            set
            {
                this.referenceField = value;
            }
        }

        /// <remarks/>
        public string Document
        {
            get
            {
                return this.documentField;
            }
            set
            {
                this.documentField = value;
            }
        }

        /// <remarks/>
        public string ProductType
        {
            get
            {
                return this.productTypeField;
            }
            set
            {
                this.productTypeField = value;
            }
        }

        /// <remarks/>
        public int Quantity
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

        /// <remarks/>
        public string ShipToContact
        {
            get
            {
                return this.shipToContactField;
            }
            set
            {
                this.shipToContactField = value;
            }
        }

        /// <remarks/>
        public string ShipToCustomerName
        {
            get
            {
                return this.shipToCustomerNameField;
            }
            set
            {
                this.shipToCustomerNameField = value;
            }
        }

        /// <remarks/>
        public string ShipToAddress1
        {
            get
            {
                return this.shipToAddress1Field;
            }
            set
            {
                this.shipToAddress1Field = value;
            }
        }

        /// <remarks/>
        public string ShipToAddress2
        {
            get
            {
                return this.shipToAddress2Field;
            }
            set
            {
                this.shipToAddress2Field = value;
            }
        }

        /// <remarks/>
        public string ShipToCity
        {
            get
            {
                return this.shipToCityField;
            }
            set
            {
                this.shipToCityField = value;
            }
        }

        /// <remarks/>
        public string ShipToStateOrProvince
        {
            get
            {
                return this.shipToStateOrProvinceField;
            }
            set
            {
                this.shipToStateOrProvinceField = value;
            }
        }

        /// <remarks/>
        public string ShipToPostalCode
        {
            get
            {
                return this.shipToPostalCodeField;
            }
            set
            {
                this.shipToPostalCodeField = value;
            }
        }

        /// <remarks/>
        public string ShipToCountry
        {
            get
            {
                return this.shipToCountryField;
            }
            set
            {
                this.shipToCountryField = value;
            }
        }

        /// <remarks/>
        public uint ShipToGroup
        {
            get
            {
                return this.shipToGroupField;
            }
            set
            {
                this.shipToGroupField = value;
            }
        }

        /// <remarks/>

        public string NeedsByDate
        {
            get
            {

                return this.needsByDateField;
            }
            set
            {
                this.DateNeedsByDate = DateTime.Parse(value.Substring(0, 4) + "-" + value.Substring(4, 2) + "-" + value.Substring(6));
                this.needsByDateField = value;
            }
        }
        public DateTime DateNeedsByDate
        {
            get
            {

                return this.dateNeedsByDateField;
            }
            set
            {
                this.dateNeedsByDateField = value;
            }
        }


        /// <remarks/>
        public string SchoolName
        {
            get
            {
                return this.schoolNameField;
            }
            set
            {
                this.schoolNameField = value;
            }
        }

        /// <remarks/>
        public string SchoolCode
        {
            get
            {
                return this.schoolCodeField;
            }
            set
            {
                this.schoolCodeField = value;
            }
        }

        /// <remarks/>
        public string EventCode
        {
            get
            {
                return this.eventCodeField;
            }
            set
            {
                this.eventCodeField = value;
            }
        }
    }























    //// NOTE: Generated code may require at least .NET Framework 4.5 or .NET Core/Standard 2.0.
    ///// <remarks/>
    //[System.SerializableAttribute()]
    //[System.ComponentModel.DesignerCategoryAttribute("code")]
    //[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    //[System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    //public partial class JostensPIXFulfillmentRequests
    //{

    //    private string requestIdField;

    //    private JostensPIXFulfillmentRequestsJostensPIXOrder[] jostensPIXOrderField;

    //    /// <remarks/>
    //    public string RequestId
    //    {
    //        get
    //        {
    //            return this.requestIdField;
    //        }
    //        set
    //        {
    //            this.requestIdField = value;
    //        }
    //    }

    //    /// <remarks/>
    //    [System.Xml.Serialization.XmlElementAttribute("JostensPIXOrder")]
    //    public JostensPIXFulfillmentRequestsJostensPIXOrder[] JostensPIXOrder
    //    {
    //        get
    //        {
    //            return this.jostensPIXOrderField;
    //        }
    //        set
    //        {
    //            this.jostensPIXOrderField = value;
    //        }
    //    }
    //}

    ///// <remarks/>
    //[System.SerializableAttribute()]
    //[System.ComponentModel.DesignerCategoryAttribute("code")]
    //[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    //public partial class JostensPIXFulfillmentRequestsJostensPIXOrder
    //{

    //    private JostensPIXFulfillmentRequestsJostensPIXOrderJostensPIXOrderItem jostensPIXOrderItemField;

    //    /// <remarks/>
    //    public JostensPIXFulfillmentRequestsJostensPIXOrderJostensPIXOrderItem JostensPIXOrderItem
    //    {
    //        get
    //        {
    //            return this.jostensPIXOrderItemField;
    //        }
    //        set
    //        {
    //            this.jostensPIXOrderItemField = value;
    //        }
    //    }
    //}

    ///// <remarks/>
    //[System.SerializableAttribute()]
    //[System.ComponentModel.DesignerCategoryAttribute("code")]
    //[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    //public partial class JostensPIXFulfillmentRequestsJostensPIXOrderJostensPIXOrderItem
    //{

    //    private string referenceField;

    //    private string documentField;

    //    private string productTypeField;

    //    private int quantityField;

    //    private string shipToContactField;

    //    private string shipToCustomerNameField;

    //    private string shipToAddress1Field;

    //    private string shipToAddress2Field;

    //    private string shipToCityField;

    //    private string shipToStateOrProvinceField;

    //    private string shipToPostalCodeField;

    //    private string shipToCountryField;

    //    private string shipToGroupField;

    //    private string needsByDateField;
    //    private DateTime dateNeedsByDateField;

    //    private string schoolNameField;

    //    private string schoolCodeField;

    //    /// <remarks/>
    //    public string Reference
    //    {
    //        get
    //        {
    //            return this.referenceField;
    //        }
    //        set
    //        {
    //            this.referenceField = value;
    //        }
    //    }

    //    /// <remarks/>
    //    public string Document
    //    {
    //        get
    //        {
    //            return this.documentField;
    //        }
    //        set
    //        {
    //            this.documentField = value;
    //        }
    //    }

    //    /// <remarks/>
    //    public string ProductType
    //    {
    //        get
    //        {
    //            return this.productTypeField;
    //        }
    //        set
    //        {
    //            this.productTypeField = value;
    //        }
    //    }

    //    /// <remarks/>
    //    public int Quantity
    //    {
    //        get
    //        {
    //            return this.quantityField;
    //        }
    //        set
    //        {
    //            this.quantityField = value;
    //        }
    //    }

    //    /// <remarks/>
    //    public string ShipToContact
    //    {
    //        get
    //        {
    //            return this.shipToContactField;
    //        }
    //        set
    //        {
    //            this.shipToContactField = value;
    //        }
    //    }

    //    /// <remarks/>
    //    public string ShipToCustomerName
    //    {
    //        get
    //        {
    //            return this.shipToCustomerNameField;
    //        }
    //        set
    //        {
    //            this.shipToCustomerNameField = value;
    //        }
    //    }

    //    /// <remarks/>
    //    public string ShipToAddress1
    //    {
    //        get
    //        {
    //            return this.shipToAddress1Field;
    //        }
    //        set
    //        {
    //            this.shipToAddress1Field = value;
    //        }
    //    }

    //    /// <remarks/>
    //    public string ShipToAddress2
    //    {
    //        get
    //        {
    //            return this.shipToAddress2Field;
    //        }
    //        set
    //        {
    //            this.shipToAddress2Field = value;
    //        }
    //    }

    //    /// <remarks/>
    //    public string ShipToCity
    //    {
    //        get
    //        {
    //            return this.shipToCityField;
    //        }
    //        set
    //        {
    //            this.shipToCityField = value;
    //        }
    //    }

    //    /// <remarks/>
    //    public string ShipToStateOrProvince
    //    {
    //        get
    //        {
    //            return this.shipToStateOrProvinceField;
    //        }
    //        set
    //        {
    //            this.shipToStateOrProvinceField = value;
    //        }
    //    }

    //    /// <remarks/>
    //    public string ShipToPostalCode
    //    {
    //        get
    //        {
    //            return this.shipToPostalCodeField;
    //        }
    //        set
    //        {
    //            this.shipToPostalCodeField = value;
    //        }
    //    }

    //    /// <remarks/>
    //    public string ShipToCountry
    //    {
    //        get
    //        {
    //            return this.shipToCountryField;
    //        }
    //        set
    //        {
    //            this.shipToCountryField = value;
    //        }
    //    }

    //    /// <remarks/>
    //    public string ShipToGroup
    //    {
    //        get
    //        {
    //            return this.shipToGroupField;
    //        }
    //        set
    //        {
    //            this.shipToGroupField = value;
    //        }
    //    }

    //    /// <remarks/>
    //public string NeedsByDate
    //{
    //    get
    //    {

    //        return this.needsByDateField;
    //    }
    //    set
    //    {
    //        this.DateNeedsByDate = DateTime.Parse(value.Substring(0, 4) + "-" + value.Substring(4, 2) + "-" + value.Substring(6));
    //        this.needsByDateField = value;
    //    }
    //}
    //public DateTime DateNeedsByDate
    //{
    //    get
    //    {

    //        return this.dateNeedsByDateField;
    //    }
    //    set
    //    {
    //        this.dateNeedsByDateField = value;
    //    }
    //}
    //    /// <remarks/>
    //    public string SchoolName
    //    {
    //        get
    //        {
    //            return this.schoolNameField;
    //        }
    //        set
    //        {
    //            this.schoolNameField = value;
    //        }
    //    }

    //    /// <remarks/>
    //    public string SchoolCode
    //    {
    //        get
    //        {
    //            return this.schoolCodeField;
    //        }
    //        set
    //        {
    //            this.schoolCodeField = value;
    //        }
    //    }
    //}
}
