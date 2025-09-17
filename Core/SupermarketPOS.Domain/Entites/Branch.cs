using SupermarketPOS.Domain.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupermarketPOS.Domain.Entites
{
    public class Branch:BaseEntity
    {

        [Required]
        [MaxLength(200)]   
        public string? Name { get; set; }

        [MaxLength(500)]
        public string? Address { get; set; }

        [MaxLength(50)]
        public string? Phone { get; set; }

        [MaxLength(100)]
        public string? Email { get; set; }

        [MaxLength(100)]
        public string? City { get; set; }

        public ICollection<Sale>? Sales { get; set; }

        public ICollection<ApplicationUser>?Users { get; set; }
        public ICollection<Shifts> shifts {  get; set; }


    }
}
