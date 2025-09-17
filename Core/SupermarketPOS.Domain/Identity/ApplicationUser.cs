using System;
using Microsoft.AspNetCore.Identity;
using SupermarketPOS.Domain.Entites;
namespace SupermarketPOS.Domain.Identity
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public bool IsActive { get; set; } = true;
        public Guid? BranchId { get; set; }
        public Branch? Branches { get; set; }

        public ICollection<Shifts>shifts { get; set; }
        public ICollection<AuditLogs> AuditLogs { get; set; }
        public ICollection<InventoryTransactions> InventoryTransactions { get; set; }
    }

    public class ApplicationRole : IdentityRole<Guid>
    {
        public required string Description { get; set; }

    }
}
