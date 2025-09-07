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
    public Branches? Branches { get; set; }
    }

    public class ApplicationRole : IdentityRole<Guid>
    {
    public required string Description { get; set; }

    }
}
