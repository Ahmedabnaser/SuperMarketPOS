using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SupermarketPOS.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupermarketPOS.Domain.Configurations
{
    public class ProductConfiguration:IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasMany(s => s.SaleItems)
                .WithOne(p => p.Product)
                .HasForeignKey(p => p.ProductId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasMany(po => po.PurchaseOrderItems)
                .WithOne(p => p.Product)
                .HasForeignKey(p => p.ProductId);
            builder.HasMany(p => p.ProductSuppliers)
                .WithOne(ps => ps.Product)
                .HasForeignKey(ps => ps.ProductId);
            builder.HasMany(i => i.InventoryTransactions)
                .WithOne(p => p.Product)
                .HasForeignKey(p => p.ProductId)
                .OnDelete(DeleteBehavior.Restrict);
        }   
    }
}
