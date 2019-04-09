﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VerityFinancial.Data
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }
        public Guid CustomerGuid { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }
        
        public string PhoneNumber { get; set; }
       
        public string Address { get; set; }
        
    }
}
