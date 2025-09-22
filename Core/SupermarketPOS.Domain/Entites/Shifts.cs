using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SupermarketPOS.Domain.Identity;

namespace SupermarketPOS.Domain.Entites
{
    public class Shifts:BaseEntity
    {
        public Guid UserId { get; set; }
        public Guid BranchId { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public decimal OpeningBalance { get; set; }
        public decimal ClosingBalance { get; set; }
        public decimal CashDifference { get; set; }

        public ApplicationUser? User { get; set; }
        public Branch? Branch { get; set; }
    }
}
