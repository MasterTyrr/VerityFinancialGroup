using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VerityFinancial.Data;
using VerityFinancial.Models;

namespace VerityFinancial.Services
{
    public class BondServices
    {
        private readonly Guid _bondId;

        public BondServices(Guid bondId)
        {
            _bondId = bondId;
        }
        public bool CreateBond(BondCreate model)
        {
            var entity =
                new Bond()
                {
                    BondName = model.BondName,
                    BondAbbev = model.BondAbbev,
                    Cost = model.Cost,
                    CostCurrent = model.CostCurrent
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Bonds.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<BondListItem> GetBondList()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Bonds
                    .Select(
                        e =>
                            new BondListItem
                            {
                                BondName = e.BondName,
                                BondAbbev = e.BondAbbev,
                                Cost = e.Cost,
                                CostCurrent = e.CostCurrent
                            }
                    );
                return query.ToArray();
            }
        }
        public BondDetail GetBondById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {

                var entity =
                 ctx
                     .Bonds
                     .Single(e => e.BondID == id);
                return
                    new BondDetail
                    {
                        BondID = entity.BondID,
                        BondName = entity.BondName,
                        BondAbbev = entity.BondAbbev,
                        Cost = entity.Cost,
                        CostCurrent = entity.CostCurrent
                    };
            }
        }
        public bool UpdateBond(BondTrade model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Bonds
                        .Single(e => e.BondGuid == _bondId);
                //entity.CustomerId = model.CustomerId;
                entity.BondName = model.BondName;
                entity.BondAbbev = model.BondAbbev;
                entity.Cost = model.Cost;
                entity.CostCurrent = model.CostCurrent;

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
