﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BindingModels
{
    public class BidInvoiceDetail
    {
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string DiscountPercentage { get; set; }
    }
}