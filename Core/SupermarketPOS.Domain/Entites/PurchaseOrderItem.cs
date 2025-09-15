

namespace SupermarketPOS.Domain.Entites
{
    public class PurchaseOrderItem:BaseEntity
    {
        public Guid PurchaseOrderId { get; set; }
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitCost { get; set; }
        public decimal LineTotal { get; set; }

        public PurchaseOrder? PurchaseOrder { get; set; }
        public Product? Product { get; set; }
    }
}
