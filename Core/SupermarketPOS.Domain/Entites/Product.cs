
namespace SupermarketPOS.Domain.Entites
{
public class Product:BaseEntity
{
    public string Name { get; set; }
    public string? Barcode { get; set; }
    public string? Description { get; set; }
    public decimal Price { get; set; }
    public decimal CostPrice { get; set; }
    public int StockQuantity { get; set; }
    public int MinStockLevel { get; set; }
    public bool IsActive { get; set; }
    public Guid CategoryId { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? ExpiryDate { get; set; }

    public Category? Category { get; set; }
    public ICollection<SaleItem>? SaleItems { get; set; }
    public ICollection<PurchaseOrderItem>? PurchaseOrderItems { get; set; }
    public ICollection<ProductSupplier>? ProductSupplier { get; set; }
    public ICollection<InventoryTransactions>? InventoryTransaction { get; set; }
}

}
