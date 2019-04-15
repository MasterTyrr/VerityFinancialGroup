using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VerityFinancial.Models
{
    public class BondTrade
    {
        public int BondId { get; set; }
        public string BondName { get; set; }
        public string BondAbbev { get; set; }
        public decimal Cost { get; set; }
        public decimal CostCurrent { get; set; }
    }
}
