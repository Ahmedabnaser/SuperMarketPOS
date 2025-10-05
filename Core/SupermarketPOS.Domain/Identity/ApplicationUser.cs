using System;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;
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

        public ICollection<Shifts> shifts { get; set; } = new List<Shifts>();
        public ICollection<AuditLogs> AuditLogs { get; set; } = new List<AuditLogs>();
        public ICollection<InventoryTransactions> InventoryTransactions { get; set; } = new List<InventoryTransactions>();
    }

    public class ApplicationRole : IdentityRole<Guid>
    {
        // Parameterless constructor required by EF Core for materialization
        public ApplicationRole() : base()
        {
        }
    [NotMapped]
    public string? _roleName { get; private set; }
        // Keep a constructor for convenience; call the base IdentityRole constructor
        public ApplicationRole(string role) : base(role)
        {
            // Optionally store the role name locally or use Description to annotate
            // _roleName is not necessary if base.Name is set, but keep for compatibility
            _roleName = role;
        }

   

        public required string Description { get; set; }

    }
}
