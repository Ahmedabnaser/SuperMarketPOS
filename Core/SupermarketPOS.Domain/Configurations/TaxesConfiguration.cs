using Microsoft.EntityFrameworkCore;
using SupermarketPOS.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupermarketPOS.Domain.Configurations
{
    public class TaxesConfiguration : IEntityTypeConfiguration<Tax>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Tax> builder)
        {
            builder.HasMany(t => t.Sales)                // Tax → many Sales
                .WithOne(s => s.Tax)                  // Sale → one Tax
                .HasForeignKey(s => s.TaxId)          // FK in Sale
                .OnDelete(DeleteBehavior.Restrict);   // avoid deleting sales history
        }
    }
}
