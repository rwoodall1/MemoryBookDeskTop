﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BindingModels {
    public class InvoiceDetailBindingModel {
        public string descr { get; set; }
        public decimal? price { get; set; }
        public string discpercent { get; set; }
        public int invno{get;set;}
        public string schoolcode { get; set; }
        }
    }