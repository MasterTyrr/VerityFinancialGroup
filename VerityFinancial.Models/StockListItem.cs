﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VerityFinancial.Models
{
    public class StockListItem
    {
        public int StockID { get; set; }
        public string StockName { get; set; }

        public string StockAbbev { get; set; }
        public decimal Cost { get; set; }

        public decimal CostCurrent { get; set; }
    }
}
