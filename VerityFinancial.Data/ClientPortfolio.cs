using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VerityFinancial.Data
{
    public class ClientPortfolio
    {
        [Key]
        public int PortfolioID { get; set; }

        public Guid PortfolioGuid { get; set; }

        //Foregin Keys?
        public int CustomerId { get; set; }
        public int StockID { get; set; }

        public int BondID { get; set; }


    }
}
