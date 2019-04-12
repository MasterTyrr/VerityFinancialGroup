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
                    Cost = model.Cost,
                    CostCurrent = model.CostCurrent
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
                    .select(e => new StockListItem
                    {
                        StockName = e.StockName,
                        StockAbbev = e.StockAbbev,
                        Cost = e.Cost,
                        CostCurrent = e.CostCurrent
                    }
                    );
                return query.ToArray();
            }
        }
    }
}
