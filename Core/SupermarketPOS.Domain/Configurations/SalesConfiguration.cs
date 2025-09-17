using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SupermarketPOS.Domain.Entites;


namespace SupermarketPOS.Domain.Configurations
{
    public class SalesConfiguration : IEntityTypeConfiguration<Sale>
    {
        public void Configure(EntityTypeBuilder<Sale> builder)
        {
            builder.HasMany(s => s.SaleItems)
                .WithOne(s => s.Sale)
                .HasForeignKey(s => s.SaleId);

            builder.HasMany(s => s.Payments)
                .WithOne(p => p.Sale)
                .HasForeignKey(s => s.SaleId);

        }

    }
}
