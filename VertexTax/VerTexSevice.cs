using System;
using System.Threading.Tasks;
using System.Configuration;
using System.Collections.Generic;
using BindingModels;
using System.Text.Json;
using Core;
using NLog;
using VerTex.VerTexWebService;
using System.Linq;
namespace Vertex
{
    public class VertexService 
    {
        public VertexService()
        {
            this.WebServiceClient = new CalculateTaxWS60Client();
            Log = LogManager.GetLogger(GetType().FullName);

        }
        protected CalculateTaxWS60Client WebServiceClient { get; set; }
        protected Logger Log { get; set; }
        public async Task<ApiProcessingResult<decimal>> GetTaxAmount(TaxRequest model)
        {

            var processingResult = new ApiProcessingResult<decimal>();

            var request = await BuildModel(model);
            if (request.IsError)
            {
                processingResult.IsError = true;
                processingResult.Errors = request.Errors;
                return processingResult;

            }
            var xml = request.Data;


            try
            {
                calculateTaxResponse result = await this.WebServiceClient.calculateTax60Async(xml);
                var item = (QuotationResponseType)result.VertexEnvelope.Item;
                //string responsexml = JsonSerializer.Serialize(item);
                // EventLogger.AddEvent(new EventModel("VertexCall", "VertexService", "CalculateTaxReturn", responsexml, model.OracleCode, ""));
                var tax = item.TotalTax.Value;
                processingResult.Data = tax;
                return processingResult;

            }
            catch (Exception ex)
            {
                //Log.Error("Failed to get tax for " + JsonSerializer.Serialize(model) + ": " + ex.Message);

                processingResult.IsError = true;
                processingResult.Errors.Add(new ApiProcessingError(ex.Message, ex.Message, ""));
                return processingResult;



            };


        }
        private async Task<ApiProcessingResult<calculateTaxRequest>> BuildModel(TaxRequest model)
        {
            var processingResult = new ApiProcessingResult<calculateTaxRequest>();
            try
            {
                var verTexEnvelope = new VertexEnvelope();
                var taxRequest = new calculateTaxRequest(verTexEnvelope);
                var _login = new LoginType();
                taxRequest.VertexEnvelope.Login = _login;
                taxRequest.VertexEnvelope.Login.UserName = "JostensWeb";

                taxRequest.VertexEnvelope.Login.Password = ConfigurationManager.AppSettings["VerTexPassWord"];
                var requestType = new QuotationRequestType();
                requestType.documentDate = DateTime.Now;
                requestType.documentNumber = "Display Tax Screen BADEM";
                requestType.returnAssistedParametersIndicator = true;
                requestType.transactionType = SaleTransactionType.SALE;
                var _seller = new SellerType();
                requestType.Seller = _seller;
                requestType.Seller.Company = "1000";
                requestType.Seller.Division = "10";
                var _physicalOrigin = new LocationType();
                requestType.Seller.PhysicalOrigin = _physicalOrigin;
                requestType.Seller.PhysicalOrigin.StreetAddress1 = "JOSTENS, INC.";
                requestType.Seller.PhysicalOrigin.StreetAddress2 = "148 E. BROADWAY";
                requestType.Seller.PhysicalOrigin.City = "OWATONNA";
                requestType.Seller.PhysicalOrigin.MainDivision = "MN";
                requestType.Seller.PhysicalOrigin.SubDivision = "";
                requestType.Seller.PhysicalOrigin.PostalCode = "55060";
                requestType.Seller.PhysicalOrigin.Country = "US";
                var _administrativeOrigin = new LocationType();
                requestType.Seller.AdministrativeOrigin = _administrativeOrigin;
                requestType.Seller.AdministrativeOrigin.City = "OWATONNA";
                requestType.Seller.AdministrativeOrigin.MainDivision = "MN";
                requestType.Seller.AdministrativeOrigin.SubDivision = "STEELE";
                requestType.Seller.AdministrativeOrigin.PostalCode = "55060";
                requestType.Seller.AdministrativeOrigin.Country = "US";
                var _customer = new CustomerType();
                requestType.Customer = _customer;
                var _customerCode = new CustomerCodeType();
                requestType.Customer.CustomerCode = _customerCode;
                requestType.Customer.CustomerCode.Value = model.OracleCode;
                var _destination = new LocationType();
                requestType.Customer.Destination = _destination;
                requestType.Customer.Destination.StreetAddress1 = model.StreetAddress1;
                requestType.Customer.Destination.StreetAddress2 = model.StreetAddress2;
                requestType.Customer.Destination.City = model.City;
                requestType.Customer.Destination.MainDivision = model.MainDivision;
                requestType.Customer.Destination.SubDivision = model.SubDivision;
                requestType.Customer.Destination.PostalCode = model.PostalCode;
                requestType.Customer.Destination.Country = model.Country;
                var itemList = new List<LineItemQSIType>();
                foreach (var item in model.ListItems)
                {
                    var newItem = new LineItemQSIType();
                    newItem.transactionType = SaleTransactionType.SALE;
                    var _product = new Product();
                    newItem.Product = _product;
                    newItem.Product.productClass = "PRINT";
                    var qty = new MeasureType() { unitOfMeasure = "INT", Value = item.Quantity };
                    newItem.Quantity = qty;
                    var up = new AmountType() { Value = item.UnitPrice };
                    newItem.UnitPrice = up;
                    itemList.Add(newItem);
                }
                //var newItem1 = new LineItemQSIType();
                //newItem1.transactionType = SaleTransactionType.SALE;
                //var _product1 = new Product();
                //newItem1.Product = _product1;
                //newItem1.Product.productClass = "OTHRSVC";
                //var qty1 = new MeasureType() { unitOfMeasure = "INT", Value = 1 };
                //newItem1.Quantity = qty1;
                //var up1 = new AmountType() { Value = .99m };
                //newItem1.UnitPrice = up1;
                //itemList.Add(newItem1);
                requestType.LineItem = itemList.ToArray<LineItemQSIType>();


                taxRequest.VertexEnvelope.Item = requestType;
                processingResult.Data = taxRequest;
                return processingResult;

            }
            catch (Exception ex)
            {
                Log.Error("Build Model VertexService:" + ex.Message);
                processingResult.IsError = true;
                processingResult.Errors.Add(new ApiProcessingError("Build Model VertexService:" + ex.Message, "Build Model VertexService:" + ex.Message, ""));
                return processingResult;

            }

        }




    }

}