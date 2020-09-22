using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BindingModels {
    public class AvaException : Exception {
        public AvaError error { get; set; }
    }
    public class AvaError {
        public string message { get; set; }
        public string code { get; set; }
        public AvaDetails details { get; set; }
    }
    public class AvaDetails {
        public string code { get; set; }
        public string description { get; set; }
        public string helplink { get; set; }
        public string message { get; set; }
        public int number { get; set; }
    }
    public class AvaSalesTaxingInfo {
        public string CompanyName { get; set; }
        public string Address { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public decimal TaxableAmount { get; set; }
    }
   
}