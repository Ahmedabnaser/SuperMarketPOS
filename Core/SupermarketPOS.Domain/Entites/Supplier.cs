using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupermarketPOS.Domain.Entites
{
    public class Supplier:BaseEntity
    {
      
        public string Name { get; set; }
        public string? Email { get; set; }
        [Required]
        [MaxLength(11), MinLength(11)]
        public string Phone { get; set; }
        public string? Address { get; set; }

        public ICollection<ProductSupplier>? ProductSupplier { get; set; }
        public ICollection<PurchaseOrder>? PurchaseOrder { get; set; }
    }
}
