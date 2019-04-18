using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VerityFinancial.Data;

namespace VerityFinancial.Models
{
    public class ClientPortfolioDetail
    {
        public virtual ClientPortfolio ClientPortfolio { get; set; }
        public int PortfolioID { get; set; }
        public virtual Customer Customer { get; set; }
        public int CustomerId { get; set; }
        public virtual Stock Stock { get; set; }
        public int StockID { get; set; }
        public int StockQuantity { get; set; }
        public virtual Bond Bond { get; set; }
        public int BondID { get; set; }
        public int BondQuantity { get; set; }
    }
}
