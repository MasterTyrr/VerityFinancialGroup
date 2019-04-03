using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VerityFinancial.Data
{
    public class Customer
    {
        [Required]
        public Guid CustomerID { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }
        //[Key]
        public int PhoneNumber { get; set; }
        //[Key]
        public string Address { get; set; }
        
    }
}
