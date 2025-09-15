using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SupermarketPOS.Domain.Identity;

namespace SupermarketPOS.Domain.Entites
{
    public class Sale:BaseEntity
    {
       
        public string? SaleNumber { get; set; }
        public DateTime SaleDate { get; set; }
        public Guid CashierId { get; set; }
        public Guid? CustomerId { get; set; }
        public decimal SubTotal { get; set; }
        public decimal TaxAmount { get; set; }
        public decimal DiscountAmount { get; set; }
        public decimal TotalAmount { get; set; }
        public int PaymentStatus { get; set; }
        public Guid BranchId { get; set; }

        public ApplicationUser? Cashier { get; set; }
        public Customer? Customer { get; set; }
        public Branch? Branch { get; set; }
        public ICollection<SaleItem>? SaleItems { get; set; }
        public ICollection<Payment>? Payments { get; set; }
    }
}
