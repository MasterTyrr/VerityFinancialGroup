using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VerityFinancial.Data
{
    public class Stock
    {
        [Key]
        public int StockID { get; set; }

        public Guid StockGuid { get; set; }

        [Required]
        public string StockName { get; set; }
        [Required]
        public string StockAbbev { get; set; }
        public decimal  SCost { get; set; }

        public decimal SCostCurrent { get; set; }



    }
}
