using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VerityFinancial.Data;
using VerityFinancial.Models;

namespace VerityFinancial.Services
{
    public class PortfolioService
    {
        private readonly Guid _portfolioId;

        public PortfolioService(Guid portfolioId)
        {
            _portfolioId = portfolioId;
        }

        public bool CreatePortfolio(ClientPortfolioCreate model)
        {
            var portfolio = new ClientPortfolio
            {
                PortfolioID = model.PortfolioID,
                CustomerId = model.CustomerId,
                StockID = model.StockID,
                BondID = model.BondID,
            };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.ClientPortfolio.Add(portfolio);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<ClientPortfolioListItem> GetPortfolio(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .ClientPortfolio
                    .Where(e => e.CustomerId == id)
                    .Select(e => new ClientPortfolioListItem
                    {
                        
                    }).ToArray();
                return query;
            }
        }
    }
}
