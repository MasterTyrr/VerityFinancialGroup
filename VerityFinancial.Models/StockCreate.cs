using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VerityFinancial.Models
{
    public class StockCreate
    {
        [Required]
        public string StockName { get; set; }
        [Required]
        public string StockAbbev { get; set; }
        public decimal Cost { get; set; }

        public decimal CostCurrent { get; set; }
    }
}
