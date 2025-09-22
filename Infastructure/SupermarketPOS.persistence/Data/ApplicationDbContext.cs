using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SupermarketPOS.Domain.Configurations;
using SupermarketPOS.Domain.Entites;
using SupermarketPOS.Domain.Identity;
using System.Reflection;


namespace SupermarketPOS.persistence.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, Guid>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            
            Assembly domainAssembly = typeof(CustomerConfiguration).Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(domainAssembly);
        }

    public DbSet<AuditLogs> AuditLogs { get; set; }
    public DbSet<Branch> Branches { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Discount> Discounts { get; set; }
    public DbSet<InventoryTransactions> InventoryTransactions { get; set; }
    public DbSet<Payment> Payments { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<ProductSupplier> ProductSuppliers { get; set; }
    public DbSet<PurchaseOrder> PurchaseOrders { get; set; }
    public DbSet<PurchaseOrderItem> PurchaseOrderItems { get; set; }
    public DbSet<Sale> Sales { get; set; }
    public DbSet<SaleItem> SaleItems { get; set; }
    public DbSet<Shifts> Shifts { get; set; }
    public DbSet<Supplier> Suppliers { get; set; }
    public DbSet<Tax> Taxes { get; set; }

        
    }
}