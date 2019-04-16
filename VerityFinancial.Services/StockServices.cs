using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VerityFinancial.Data;
using VerityFinancial.Models;

namespace VerityFinancial.Services
{
    public class StockServices
    {
        private readonly Guid _stockId;

        public StockServices(Guid stockId)
        {
            _stockId = stockId;
        }
        public bool CreateStock(StockCreate model)
        {
            var entity =
                new Stock()
                {
                    StockName = model.StockName,
                    StockAbbev = model.StockAbbev,
                    SCost = model.Cost,
                    SCostCurrent = model.CostCurrent
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Stocks.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<StockListItem> GetStockList()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Stocks
                    .Select(
                        e =>
                            new StockListItem
                            {
                                StockName = e.StockName,
                                StockAbbev = e.StockAbbev,
                                Cost = e.SCost,
                                CostCurrent = e.SCostCurrent
                            }
                    );
                return query.ToArray();
            }
        }
        public StockDetail GetStockById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {

                var entity =
                 ctx
                     .Stocks
                     .Single(e => e.StockID == id);
                return
                    new StockDetail
                    {
                        StockID = entity.StockID,
                        StockName = entity.StockName,
                        StockAbbev = entity.StockAbbev,
                        Cost = entity.SCost,
                        CostCurrent = entity.SCostCurrent
                    };
            }
        }
        public bool UpdateStock(StockTrade model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Stocks
                        .Single(e => e.StockGuid == _stockId);
                //entity.CustomerId = model.CustomerId;
                entity.StockName = model.StockName;
                entity.StockAbbev = model.StockAbbev;
                entity.SCost = model.Cost;
                entity.SCostCurrent = model.CostCurrent;

                return ctx.SaveChanges() == 1;
            }
        }

    }
}
