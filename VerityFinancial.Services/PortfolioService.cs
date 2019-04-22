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
                StockAbbev = model.StockAbbev,
                StockQuantity = model.StockQuantity,
                BondID = model.BondID,
                BondAbbev = model.BondAbbev,
                BondQuantity = model.BondQuantity
            };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.ClientPortfolio.Add(portfolio);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<ClientPortfolioListItem> GetPortfolio()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .ClientPortfolio
                    .Select(e => new ClientPortfolioListItem
                    {
                        PortfolioID = e.PortfolioID,
                        CustomerId = e.CustomerId,
                        //FirstName = e.FirstName,
                        LastName = e.Customer.LastName,
                        StockID = e.StockID,
                        StockAbbev = e.Stock.StockAbbev,
                        //SCost = e.SCost,
                        StockQuantity = e.StockQuantity,
                        BondID = e.BondID,
                        BondAbbev = e.Bond.BondAbbev,
                        //BCost = e.BCost,
                        BondQuantity = e.BondQuantity
                    }).ToArray() ;
                return query;
            }
        }
        public ClientPortfolioDetail GetPortfolioById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.ClientPortfolio.Single(e => e.PortfolioID == id);

                var model = new ClientPortfolioDetail
                {
                    PortfolioID = entity.PortfolioID,
                    CustomerId = entity.CustomerId,
                    StockID = entity.StockID,
                    StockQuantity = entity.StockQuantity,
                    BondID = entity.BondID,
                    BondQuantity = entity.BondQuantity
                };
                return model;
            }
        }

        public bool EditPortfolio(ClientPortfolioTrade model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = 
                    ctx
                    .ClientPortfolio
                    .Single(e => e.PortfolioID == model.PortfolioID);
                entity.CustomerId = model.CustomerId;
                //entity.Lastname = model.Lastname;
                entity.StockID = model.StockID;
                //entity.StockQuantity = model.StockQuantity;
                entity.BondID = model.BondID;
                //entity.BondQuantity = model.BondQuantity;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeletePortfolio(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.ClientPortfolio.Single(e => e.PortfolioID == id);
                ctx.ClientPortfolio.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
