using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupermarketPOS.Domain.Entites
{
    public class ProductSupplier:BaseEntity
    {

        public Guid ProductId { get; set; }
        public Guid SupplierId { get; set; }
        public string? SupplierProductCode { get; set; }
        public decimal CostPrice { get; set; }

        public Product? Product { get; set; }
        public Supplier? Supplier { get; set; }

    }
}
