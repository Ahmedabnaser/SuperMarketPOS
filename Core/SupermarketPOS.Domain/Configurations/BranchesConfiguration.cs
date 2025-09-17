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
    public class BranchesConfiguration : IEntityTypeConfiguration<Branch>
    {
        public void Configure(EntityTypeBuilder<Branch> builder)
        {
            // one to many relationship with branch -> sales
            builder.HasMany(b => b.Sales)
                .WithOne(s => s.Branch)
                .HasForeignKey(b => b.BranchId)
                .OnDelete(DeleteBehavior.NoAction);

            // one to many relationship with branch -> users
            builder.HasMany(b => b.Users)
                .WithOne(u => u.Branches)
                .HasForeignKey(b => b.BranchId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(b => b.shifts)
                 .WithOne(u => u.Branch)
                 .HasForeignKey(b => b.BranchId)
                 .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
