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
                    BCost = model.Cost,
                    BCostCurrent = model.CostCurrent
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
                                Cost = e.BCost,
                                CostCurrent = e.BCostCurrent
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
                        Cost = entity.BCost,
                        CostCurrent = entity.BCostCurrent
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
                entity.BCost = model.Cost;
                entity.BCostCurrent = model.CostCurrent;

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
