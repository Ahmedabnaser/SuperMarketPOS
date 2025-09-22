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
    public class SupplierConfiguration:IEntityTypeConfiguration<Supplier>
    {
        public void Configure(EntityTypeBuilder<Supplier> Builder)
        {
            Builder.Property(s => s.Name)
                .IsRequired();
            Builder.HasMany(ps => ps.ProductSuppliers)
                .WithOne(s => s.Supplier)
                .HasForeignKey(s => s.SupplierId);
            Builder.HasMany(po=>po.ProductSuppliers)
                .WithOne(po => po.Supplier)
                .HasForeignKey(po=>po.SupplierId);

        }

    }
}
