using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupermarketPOS.Domain.Entites
{
    public class PurchaseOrder:BaseEntity
    {
      
        public string? PhoneNumber { get; set; }
        public Guid SupplierId { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime ExpectedDate { get; set; }
        public int Status { get; set; }
        public decimal TotalAmount { get; set; }
        [MaxLength(500)]
        public string? Notes { get; set; }

        public Supplier? Supplier { get; set; }
        public ICollection<PurchaseOrderItem>? Items { get; set; }
    }
}
