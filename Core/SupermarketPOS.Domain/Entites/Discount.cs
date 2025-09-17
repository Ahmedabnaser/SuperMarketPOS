using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupermarketPOS.Domain.Entites
{
    public class Discount:BaseEntity
    {
        public required string Name { get; set; }
        public decimal Percentage { get; set; } // e.g., 0.10 for 10%
        public DateTime StartDate { get; set; } = DateTime.UtcNow;
        public DateTime? EndDate { get; set; }
        public bool IsActive { get; set; } = true;

        public ICollection<Sale> Sales { get; set; }
    }
}
