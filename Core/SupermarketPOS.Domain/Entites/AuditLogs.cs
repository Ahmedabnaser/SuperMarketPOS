
using SupermarketPOS.Domain.Identity;

namespace SupermarketPOS.Domain.Entites
{
    public class AuditLogs:BaseEntity
    {    
        public Guid UserId { get; set; }
        public string? Action { get; set; }
        public string? TableName { get; set; }
        public Guid RecordId { get; set; }
        public string? OldValues { get; set; }
        public string?  NewValues { get; set; }
        public DateTime Timestamp { get; set; }

        public ApplicationUser? User { get; set; }

    }
}
