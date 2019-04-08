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
                    CustomerID = _userId,
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
                                    FirstName = e.FirstName,
                                    LastName = e.LastName,
                                    PhoneNumber = e.PhoneNumber,
                                    //Address = e.Address
                                }
                        );

                return query.ToArray();
            }
        }
    }
}
    


        
        
  
