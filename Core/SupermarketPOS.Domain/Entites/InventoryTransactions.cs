using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SupermarketPOS.Domain.Identity;

namespace SupermarketPOS.Domain.Entites
{
    public class InventoryTransactions : BaseEntity
    {
        public Guid? UserId { get; set; }//Foreign Key to User
        public Guid? ProductId { get; set; }// Foreign key to Product
        public int TransactionType { get; set; }  // 0=PurchaseIn, 1=SaleOut, etc.
        public int Quantity { get; set; }
        public Guid BranchId { get; set; }
        public Guid ReferenceId { get; set; } // SaleId / PurchaseOrderId / ReturnId...
        public Guid ProcessedBy { get; set; }
        public DateTime Timestamp { get; set; }

        public Product? Product { get; set; }
        public Branch? Branch { get; set; }
        public ApplicationUser? User { get; set; }
    }
}
