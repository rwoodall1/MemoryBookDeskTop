using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Avalara.AvaTax.RestClient;
using BaseClass;
using Exceptionless;
using BindingModels;
namespace Mbc5.Classes {
    //https://www.avalara.com
    //randy@woodalldevelopment.com
    //Briggitte1
    //account#2000137568
    //Lic#D63249718021B761
    //https://www.avalara.com/us/en/blog/2017/03/avatax-free-trial.html
    public static class TaxService {
        
        public static decimal CaclulateTax(AvaSalesTaxingInfo TaxingInfo)
        {
            AvaTaxClient client = new AvaTaxClient("MyApp", "1.0", Environment.MachineName, AvaTaxEnvironment.Production)
                .WithSecurity("2000137568", "D63249718021B761");
            Avalara.AvaTax.RestClient.TransactionModel vTaxInfo = new TransactionModel() ;
            decimal totalTax = 0;
            try
            {
                vTaxInfo = new TransactionBuilder(client, "DEFAULT", DocumentType.SalesInvoice, "ABC")
            .WithAddress(TransactionAddressType.SingleLocation, TaxingInfo.CompanyName, TaxingInfo.Address, TaxingInfo.Address2
                , TaxingInfo.City, TaxingInfo.State
             , TaxingInfo.ZipCode, "US")
             .WithLine(TaxingInfo.TaxableAmount)
              .Create();
                //testing
                //vTaxInfo = new TransactionBuilder(client, "DEFAULT", DocumentType.SalesInvoice, "ABC")
                //.WithAddress(TransactionAddressType.SingleLocation, "Mbc5", "403 E Webster", ""
                //    , "Smithton", "MO"
                // , "65350", "US")
                // .WithLine(125m)
                //  .Create();
            }
            catch(AvaException ex)
            {
                ex.ToExceptionless()
                      .AddObject(ex)
                      .AddTags("TaxRate")
                      .MarkAsCritical()
                      .Submit();
                MbcMessageBox.Error(ex.error.message);
              
            }

            //vTaxInfo.totalTax is nullable so get default
            totalTax = vTaxInfo.totalTax.GetValueOrDefault();
           return totalTax;
            
        }
    }
    
}
