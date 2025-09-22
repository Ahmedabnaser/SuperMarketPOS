using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SupermarketPOS.Domain.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupermarketPOS.Domain.Configurations
{
    public class ApplicationUserConfiguration : IEntityTypeConfiguration<ApplicationUser>//IEntityTypeConfiguration
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
                builder.HasMany(u => u.shifts)
                    .WithOne(s => s.User)
                    .HasForeignKey(u => u.UserId)
                    .OnDelete(DeleteBehavior.NoAction);

                builder.HasMany(u => u.InventoryTransactions)
                    .WithOne(s => s.User)
                    .HasForeignKey(u=>u.UserId)
                    .OnDelete(DeleteBehavior.NoAction);


                builder.HasMany(u => u.AuditLogs)
                    .WithOne(s => s.User)
                    .HasForeignKey(u => u.UserId)
                    .OnDelete(DeleteBehavior.NoAction);

        }
    }
}
