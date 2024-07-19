using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Web;

namespace BindingModels
{
    public class OpyBindingModels
    {
        public class  SchoolPayment
        {
            public int Id { get; set; }
            public string Schname { get; set; }
            public string Schcode { get; set; }
            public string PONumber { get; set; }
            public DateTime  PayDate{ get; set; }
            public decimal Amount{ get; set; }
            public string OrderHeaderGuid{ get; set; }
            public string CardHolderName { get; set; }
            public string CardType { get; set; }
            public string CardNumber { get; set; }
            public string PaymentToken { get; set; }    
            public bool Reconciled { get; set; }
            public bool PaymentCompleteded{ get; set; }
            public DateTime PaymentCompletetdDate { get; set; }
            public string EmailAddress { get; set; }
        }
    }
}