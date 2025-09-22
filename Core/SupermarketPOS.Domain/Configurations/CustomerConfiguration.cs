using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SupermarketPOS.Domain.Entites;
namespace SupermarketPOS.Domain.Configurations
{
    public class CustomerConfiguration:IEntityTypeConfiguration<Customer>
    {
        public void  Configure(EntityTypeBuilder<Customer> builder) {

            builder.Property(b=>b.FirstName)
                .IsRequired()
                .HasColumnOrder(1);
            builder.HasMany(s => s.Sales)
                .WithOne(c => c.Customer)
                .HasForeignKey(c => c.CustomerId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
