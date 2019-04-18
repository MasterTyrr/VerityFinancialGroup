using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VerityFinancial.Data;

namespace VerityFinancial.Models
{
    public class ClientPortfolioTrade
    {
        public int PortfolioID { get; set; }

       // public Guid PortfolioGuid { get; set; }

        //Foregin Keys?
        public int CustomerId { get; set; }
        //public string FirstName { get; set; }
//        public string Lastname { get; set; }

        public int StockID { get; set; }
        //public string StockAbbev { get; set; }
        //public decimal SCost { get; set; }
  //      public int StockQuantity { get; set; }

        public int BondID { get; set; }
        //public string BondAbbev { get; set; }
        //public decimal BCost { get; set; }
    //    public int BondQuantity { get; set; }

        public virtual Customer Customer { get; set; }

        public virtual Stock Stock { get; set; }

        public virtual Bond Bond { get; set; }
    }
}
