using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VerityFinancial.Models
{
    public class ClientPortfolioCreate
    {
        public int PortfolioID { get; set; }

        //Foregin Keys
        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        
        public int StockID { get; set; }
        public string StockName { get; set; }
        public string StockAbbev { get; set; }
        public decimal SCost { get; set; }
        public decimal SCostCurrent { get; set; }
        public int StockQuantity { get; set; }

        public int BondID { get; set; }
        public string BondName { get; set; }
        public string BondAbbev { get; set; }
        public decimal BCost { get; set; }
        public decimal BCostCurrent { get; set; }
        public int BondQuantity { get; set; }
    }
}
