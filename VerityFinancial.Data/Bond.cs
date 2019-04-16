using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VerityFinancial.Data
{
    public class Bond
    {
        [Key]
        public int BondID { get; set; }
        public Guid BondGuid { get; set; }
        [Required]
        public string BondName { get; set; }
        [Required]
        public string BondAbbev { get; set; }
        public decimal BCost { get; set; }
        public decimal BCostCurrent { get; set; }
    }
}
