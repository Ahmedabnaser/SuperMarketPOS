using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SupermarketPOS.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupermarketPOS.Domain.Configurations
{
    public class DiscountConfiguration:IEntityTypeConfiguration<Discount>
    {
        public void Configure(EntityTypeBuilder<Discount> builder)
        {
            builder.HasMany(d => d.Sales)             // Discount → many SaleItems
                   .WithOne(si => si.Discount)            // SaleItem → one Discount
                   .HasForeignKey(si => si.DiscountId)    // FK in SaleItem
                   .OnDelete(DeleteBehavior.Restrict);    // safer than cascade
        }
    }
}
