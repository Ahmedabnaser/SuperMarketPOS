using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupermarketPOS.Domain.Entites
{
    public class Tax : BaseEntity
    {
        public required string Name { get; set; }
        public decimal Rate { get; set; } // e.g., 0.07 for 7%
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }
        public bool IsActive { get; set; } = true;
        public ICollection<Sale>Sales { get; set; }

    }
}
