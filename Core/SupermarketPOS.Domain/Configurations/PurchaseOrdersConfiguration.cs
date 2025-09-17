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
    public class PurchaseOrdersConfiguration : IEntityTypeConfiguration<PurchaseOrder>
    {
       public void Configure(EntityTypeBuilder<PurchaseOrder> builder)
        {
            builder.HasMany(po => po.PurchaseOrderItems)
                .WithOne(poi => poi.PurchaseOrder)
                .HasForeignKey(f => f.PurchaseOrderId);
        }
    }
}
