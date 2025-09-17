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

        [Required(ErrorMessage ="The Name Field Is Required")]
        
        public string Name { get; set; }
        public string? Email { get; set; }
        [Required(ErrorMessage ="The phone number field is Required")]
        [MaxLength(11), MinLength(11)]
        
        public string Phone { get; set; }
        public string? Address { get; set; }

        public ICollection<ProductSupplier>? ProductSuppliers { get; set; }
        public ICollection<PurchaseOrder>? PurchaseOrders { get; set; }
    }
}
