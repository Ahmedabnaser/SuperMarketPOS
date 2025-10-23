using System;

namespace SupermarketPOS.Domain.Identity
{
    public class RefreshToken
    {

        public Guid RefreshTokenId { get; set; }
        public string Token { get; set; } = string.Empty;
        
        public DateTime CreatedOn { get; set; }
        
        public DateTime ExpiresOn { get; set; }
        
        public bool IsExpired => DateTime.UtcNow >= ExpiresOn;
        
        public DateTime? RevokedOn { get; set; }// any date not null
        
        public bool IsRevoked => RevokedOn is not null;// this means have a date
        
        public bool IsActive => !IsRevoked && !IsExpired;
        
        public string? CreatedByIp { get; set; }
        
        public string? RevokedByIp { get; set; }
        
        public string? ReplacedByToken { get; set; }
        
        // Reference to the user this token belongs to
        public Guid UserId { get; set; } 
    }
}
