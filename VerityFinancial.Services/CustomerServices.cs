using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VerityFinancial.Data;
using VerityFinancial.Models;

namespace VerityFinancial.Services
{
    public class CustomerServices
    {
        private readonly Guid _userId;

        public CustomerServices(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateCustomer(CustomerCreate model)
        {
            var entity =
                new Customer()
                {
                    CustomerGuid = _userId,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    PhoneNumber = model.PhoneNumber,
                    Address = model.Address
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Customers.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<CustomerListItems> GetCustomerList()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Customers
                        //.Where(e => e.CustomerID == _userId)
                        .Select(
                            e =>
                                new CustomerListItems
                                {
                                    CustomerId = e.CustomerId,
                                    FirstName = e.FirstName,
                                    LastName = e.LastName,
                                    PhoneNumber = e.PhoneNumber,
                                    //Address = e.Address
                                }
                        );

                return query.ToArray();
            }
        }

        public CustomerDetail GetCustomerById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {

                var entity =
                 ctx
                     .Customers
                     .Single(e => e.CustomerId == id);
                return
                    new CustomerDetail
                    {
                        CustomerId = entity.CustomerId,
                        FirstName = entity.FirstName,
                        LastName = entity.LastName,
                        PhoneNumber = entity.PhoneNumber,
                        Address = entity.Address
                    };
            }
        }
        public bool UpdateCustomer(CustomerTrade model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Customers
                        .Single(e => e.CustomerGuid == _userId);
                entity.FirstName = model.FirstName;
                entity.LastName = model.LastName;
                entity.PhoneNumber = model.PhoneNumber;
                entity.Address = model.Address;

                return ctx.SaveChanges() == 1;
            }
        }
    }
}






