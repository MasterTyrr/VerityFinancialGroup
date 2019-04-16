using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VerityFinancial.Data
{
    public class ClientPortfolioListItem
    {

        public virtual Customer Customer { get; set; }
        public virtual Stock Stock { get; set; }
        public virtual Bond Bond { get; set; }
    }
}
