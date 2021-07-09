using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BindingModels
{
    public class UsPsBarScanReturn
    {

        public string ShipName { get; set; }
        public string ShipAddr { get; set; }
        public string ShipAddr2 { get; set; }
        public string ShipCity { get; set; }
        public string ShipState { get; set; }
        public string ShipZip { get; set; }
        public string MixbookOrderStatus { get; set; }
        public string JobId { get; set; }
        public int ClientOrderId { get; set; }
        public string ShipMethod { get; set; }
        public string ShippingMethodName { get; set; }
        public int ProdInOrder { get; set; }
        public string Carrier { get; set; }
        public string ServiceId { get; set; }
        public string PkgType { get; set; }
    }
    public class Parameter
    {
        public Parameter(string name = default(string), string value = default(string))
        {
            // to ensure "name" is required (not null)
            if (name == null)
            {
                throw new Exception("name is a required property for Parameter and cannot be null");
            }
            else
            {
                this.Name = name;
            }

            // to ensure "value" is required (not null)
            if (value == null)
            {
                throw new Exception("value is a required property for Parameter and cannot be null");
            }
            else
            {
                this.Value = value;
            }

        }
        public string Name { get; set; }
        public string Value { get; set; }
    }
    public class Tax
    {
        public Tax(string displayName = default(string), string name = default(string), decimal taxAmount = default(decimal), decimal taxRate = default(decimal))
        {
            this.DisplayName = displayName;
            this.Name = name;
            this.TaxAmount = taxAmount;
            this.TaxRate = taxRate;
        }
        public string DisplayName { get; set; }
        public string Name { get; set; }
        public decimal TaxAmount { get; set; }
        public decimal TaxRate { get; set; }
    }
    public partial class Discount
    {
        public Discount(decimal discountAmount = default(decimal), string name = default(string))
        {
            this.DiscountAmount = discountAmount;
            this.Name = name;
        }
        public decimal DiscountAmount { get; set; }
        public string Name { get; set; }

    }
    public partial class Surcharge
    {
        public Surcharge(decimal fee = default(decimal), string name = default(string))
        {
            this.Fee = fee;
            this.Name = name;
        }
        public decimal Fee { get; set; }
        public string Name { get; set; }
    }
    public partial class DeliveryCommitment
    {
        public DeliveryCommitment(string additionalDetails = default(string), string estimatedDeliveryDateTime = default(string), string guarantee = default(string), string maxEstimatedNumberOfDays = default(string), string minEstimatedNumberOfDays = default(string))
        {
            this.AdditionalDetails = additionalDetails;
            this.EstimatedDeliveryDateTime = estimatedDeliveryDateTime;
            this.Guarantee = guarantee;
            this.MaxEstimatedNumberOfDays = maxEstimatedNumberOfDays;
            this.MinEstimatedNumberOfDays = minEstimatedNumberOfDays;
        }
        public string AdditionalDetails { get; set; }
        public string EstimatedDeliveryDateTime { get; set; }
        public string Guarantee { get; set; }
        public string MaxEstimatedNumberOfDays { get; set; }
        public string MinEstimatedNumberOfDays { get; set; }
    }
    public partial class Rate
    {
        public Rate(decimal alternateBaseCharge = default(decimal), decimal alternateTotalCharge = default(decimal), decimal baseCharge = default(decimal), List<Tax> baseChargeTaxes = default(List<Tax>), string carrier = default(string), string currencyCode = default(string), DeliveryCommitment deliveryCommitment = default(DeliveryCommitment), decimal destinationZone = default(decimal), ParcelWeight dimensionalWeight = default(ParcelWeight), List<Discount> discounts = default(List<Discount>), string inductionPostalCode = default(string), string parcelType = default(string), string rateTypeId = default(string), string serviceId = default(string), List<SpecialService> specialServices = default(List<SpecialService>), List<Surcharge> surcharges = default(List<Surcharge>), decimal totalCarrierCharge = default(decimal), decimal totalTaxAmount = default(decimal))
        {
            // to ensure "carrier" is required (not null)
            if (carrier == null)
            {
                throw new Exception("carrier is a required property for Rate and cannot be null");
            }
            else
            {
                this.Carrier = carrier;
            }

            //    // to ensure "parcelType" is required (not null)
            if (parcelType == null)
            {
                throw new Exception("parcelType is a required property for Rate and cannot be null");
            }
            else
            {
                this.ParcelType = parcelType;
            }

            this.AlternateBaseCharge = alternateBaseCharge;
            this.AlternateTotalCharge = alternateTotalCharge;
            this.BaseCharge = baseCharge;
            this.BaseChargeTaxes = baseChargeTaxes;
            this.CurrencyCode = currencyCode;
            this.DeliveryCommitment = deliveryCommitment;
            this.DestinationZone = destinationZone;
            this.DimensionalWeight = dimensionalWeight;
            this.Discounts = discounts;
            this.InductionPostalCode = inductionPostalCode;
            this.RateTypeId = rateTypeId;
            this.ServiceId = serviceId;
            this.SpecialServices = specialServices;
            this.Surcharges = surcharges;
            this.TotalCarrierCharge = totalCarrierCharge;
            this.TotalTaxAmount = totalTaxAmount;
        }
        public List<Surcharge> Surcharges { get; set; }
        public List<SpecialService> SpecialServices { get; set; }
        public DeliveryCommitment DeliveryCommitment { get; set; }
        public ParcelWeight DimensionalWeight { get; set; }
        public List<Discount> Discounts { get; set; }
        public List<Tax> BaseChargeTaxes { get; set; }
        public decimal AlternateBaseCharge { get; set; }
        public decimal AlternateTotalCharge { get; set; }
        public decimal BaseCharge { get; set; }
        public string CurrencyCode { get; set; }
        public decimal DestinationZone { get; set; }
        public string InductionPostalCode { get; set; }
        public string RateTypeId { get; set; }
        public decimal TotalCarrierCharge { get; set; }
        public decimal TotalTaxAmount { get; set; }
        public string Carrier { get; set; }
        public string ParcelType { get; set; }
        public string ServiceId { get; set; }//"PM","FCM","STDPOST",ect.

    }
    public partial class SpecialService
    {
        public SpecialService(decimal fee = default(decimal), List<Parameter> inputParameters = default(List<Parameter>), string specialServiceId = default(string))
        {
            // to ensure "specialServiceId" is required (not null)
            if (specialServiceId == null)
            {
                throw new Exception("specialServiceId is a required property for SpecialService and cannot be null");
            }
            else
            {
                this.SpecialServiceId = specialServiceId;
            }

            this.Fee = fee;
            this.InputParameters = inputParameters;
        }
        public decimal Fee { get; set; }
        public List<Parameter> InputParameters { get; set; }
        public string SpecialServiceId { get; set; }
    }
    public class Address
    {
        public Address(List<string> addressLines = default(List<string>), string carrierRoute = default(string), string cityTown = default(string), string company = default(string), string countryCode = default(string), string deliveryPoint = default(string), string email = default(string), string name = default(string), string phone = default(string), string postalCode = default(string), bool residential = default(bool), string stateProvince = default(string), string status = "", string taxId = default(string), string taxIdType = "")
        {
            // to ensure "countryCode" is required (not null)
            if (countryCode == null)
            {
                throw new Exception("countryCode is a required property for Address and cannot be null");
            }
            else
            {
                this.CountryCode = countryCode;
            }

            this.AddressLines = addressLines;
            this.CarrierRoute = carrierRoute;
            this.CityTown = cityTown;
            this.Company = company;
            this.DeliveryPoint = deliveryPoint;
            this.Email = email;
            this.Name = name;
            this.Phone = phone;
            this.PostalCode = postalCode;
            this.Residential = residential;
            this.StateProvince = stateProvince;
            this.Status = status;
            this.TaxId = taxId;
            this.TaxIdType = taxIdType;
        }
        public List<string> AddressLines { get; set; }
        public string CarrierRoute { get; set; }
        public string CityTown { get; set; }
        public string Company { get; set; }
        public string DeliveryPoint { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string PostalCode { get; set; }
        public bool Residential { get; set; }
        public string StateProvince { get; set; }
        public string Status { get; set; }
        public string TaxId { get; set; }
        public string TaxIdType { get; set; }
        public string CountryCode { get; set; }

    }
    public partial class Parcel
    {
        public Parcel(ParcelDimension dimension = default(ParcelDimension), ParcelWeight weight = default(ParcelWeight), decimal valueOfGoods = default(decimal), string currencyCode = default(string))
        {
            this.Dimension = dimension;
            this.Weight = weight;
            this.ValueOfGoods = valueOfGoods;
            this.CurrencyCode = currencyCode;
        }
        public ParcelDimension Dimension { get; set; }
        public ParcelWeight Weight { get; set; }
        public decimal ValueOfGoods { get; set; }
        public string CurrencyCode { get; set; }
    }
    public class ParcelDimension
    {

        public string UnitOfMeasurement { get; set; } //either "CM" or "IN"
        public decimal Length { get; set; }
        public decimal Height { get; set; }
        public decimal Width { get; set; }
        public decimal IrregularParcelGirth { get; set; }
    }
    public class ParcelWeight
    {
        public ParcelWeight(decimal weight = default(decimal), string unitOfMeasurement = "")
        {
            this.Weight = weight;
            this.UnitOfMeasurement = unitOfMeasurement;
        }
        public string UnitOfMeasurement { get; set; }//either "GM","OZ","LB","KG"
        public decimal Weight { get; set; }
    }
    public partial class Document
    {
        public enum ContentTypeEnum
        {
            
            URL = 1,
            BASE64 = 2

        }
        public string ContentType { get; set; }
        public enum FileFormatEnum
        {
           
            PDF = 1,

            PNG = 2,

            GIF = 3,

            ZPL = 4,

            ZPL2 = 5

        }
        public FileFormatEnum? FileFormat { get; set; }
        public enum PrintDialogOptionEnum
        {
         
            NO_PRINT_DIALOG = 1,

          
            EMBED_PRINT_DIALOG = 2

        }
        public PrintDialogOptionEnum? PrintDialogOption { get; set; }
        public enum ResolutionEnum
        {
           
            DPI_300 = 1,

            
            DPI_203 = 2,

            DPI_150 = 3

        }
        public ResolutionEnum? Resolution { get; set; }
        public enum SizeEnum
        {
            DOC_2X7 = 1,
            DOC_4X1 = 2,
            DOC_4X3 = 3,
            DOC_4X6 = 4,
            DOC_4X8 = 5,
            DOC_6X4 = 6,
            DOC_8X11 = 7,
            DOC_9X4 = 8,
            DOC_4X5 = 9,
            DOC_85X55 = 10

        }
        public SizeEnum? Size { get; set; }
        protected Document() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="Document" /> class.
        /// </summary>
        /// <param name="contentType">contentType.</param>
        /// <param name="contents">contents.</param>
        /// <param name="docTab">docTab.</param>
        /// <param name="fileFormat">fileFormat.</param>
        /// <param name="pages">pages.</param>
        /// <param name="printDialogOption">printDialogOption.</param>
        /// <param name="resolution">resolution.</param>
        /// <param name="size">size.</param>
        /// <param name="type">type (required).</param>
        public Document(string contentType = default(string), string contents = default(string), List<DocTabItem> docTab = default(List<DocTabItem>), FileFormatEnum? fileFormat = default(FileFormatEnum?), List<DocumentPage> pages = default(List<DocumentPage>), PrintDialogOptionEnum? printDialogOption = default(PrintDialogOptionEnum?), ResolutionEnum? resolution = default(ResolutionEnum?), SizeEnum? size = default(SizeEnum?), string type = default(string))
        {
            // to ensure "type" is required (not null)
            if (type == null)
            {
                throw new Exception("type is a required property for Document and cannot be null");
            }
            else
            {
                this.Type = type;
            }

            this.ContentType = contentType;
            this.Contents = contents;
            this.DocTab = docTab;
            this.FileFormat = fileFormat;
            this.Pages = pages;
            this.PrintDialogOption = printDialogOption;
            this.Resolution = resolution;
            this.Size = size;
        }
        public string Contents { get; set; }
        public List<DocTabItem> DocTab { get; set; }
        public List<DocumentPage> Pages { get; set; }
        public string Type { get; set; }
    }
    public class DocTabItem
    {

        public DocTabItem(string displayName = default(string), string name = default(string), string value = default(string))
        {
            this.DisplayName = displayName;
            this.Name = name;
            this.Value = value;
        }
        public string DisplayName { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }

    }
    public partial class DocumentPage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DocumentPage" /> class.
        /// </summary>
        /// <param name="contents">base64.</param>
        public DocumentPage(string contents = default(string))
        {
            this.Contents = contents;
        }
        public string Contents { get; set; }
    }
    public partial class Shipment
    {

        public enum ShipmentTypeEnum
        {
            OUTBOUND = 1,
            RETURN = 2
        }
        public ShipmentTypeEnum? ShipmentType { get; set; }

        protected Shipment() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="Shipment" /> class.
        /// </summary>
        /// <param name="additionalAddresses">additionalAddresses.</param>
        /// <param name="altReturnAddress">altReturnAddress.</param>
        /// <param name="carrierPayments">carrierPayments.</param>
        /// <param name="customs">customs.</param>
        /// <param name="documents">documents.</param>
        /// <param name="fromAddress">fromAddress (required).</param>
        /// <param name="hazmatDetails">hazmatDetails.</param>
        /// <param name="parcel">parcel (required).</param>
        /// <param name="parcelTrackingNumber">parcelTrackingNumber.</param>
        /// <param name="rates">rates (required).</param>
        /// <param name="references">references.</param>
        /// <param name="shipmentId">shipmentId.</param>
        /// <param name="shipmentOptions">shipmentOptions.</param>
        /// <param name="shipmentType">shipmentType.</param>
        /// <param name="soldToAddress">soldToAddress.</param>
        /// <param name="toAddress">toAddress (required).</param>
        public Shipment( List<Document> documents = default(List<Document>), Address fromAddress = default(Address),  Parcel parcel = default(Parcel), string parcelTrackingNumber = default(string), List<Rate> rates = default(List<Rate>), List<Parameter> references = default(List<Parameter>), string shipmentId = default(string), List<Parameter> shipmentOptions = default(List<Parameter>), ShipmentTypeEnum? shipmentType = default(ShipmentTypeEnum?), Address soldToAddress = default(Address), Address toAddress = default(Address))
        {
            // to ensure "fromAddress" is required (not null)
            if (fromAddress == null)
            {
                throw new Exception("fromAddress is a required property for Shipment and cannot be null");
            }
            else
            {
                this.FromAddress = fromAddress;
            }

            // to ensure "parcel" is required (not null)
            if (parcel == null)
            {
                throw new Exception("parcel is a required property for Shipment and cannot be null");
            }
            else
            {
                this.Parcel = parcel;
            }

            // to ensure "rates" is required (not null)
            if (rates == null)
            {
                throw new Exception("rates is a required property for Shipment and cannot be null");
            }
            else
            {
                this.Rates = rates;
            }

            // to ensure "toAddress" is required (not null)
            if (toAddress == null)
            {
                throw new Exception("toAddress is a required property for Shipment and cannot be null");
            }
            else
            {
                this.ToAddress = toAddress;
            }

                this.Documents = documents;
                this.ParcelTrackingNumber = parcelTrackingNumber;
                this.References = references;
                this.ShipmentId = shipmentId;
                this.ShipmentOptions = shipmentOptions;
                this.ShipmentType = shipmentType;
                this.SoldToAddress = soldToAddress;
        }
        public Address AltReturnAddress { get; set; }
        public List<Document> Documents { get; set; }
        public Address FromAddress { get; set; }
        public Parcel Parcel { get; set; }
        public string ParcelTrackingNumber { get; set; }
        public List<Rate> Rates { get; set; }
        public List<Parameter> References { get; set; }
        public string ShipmentId { get; set; }
        public List<Parameter> ShipmentOptions { get; set; }
        public Address SoldToAddress { get; set; }
        public Address ToAddress { get; set; }

    }
}