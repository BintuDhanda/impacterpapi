using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP.Models
{
    public class Users
    {
        [Key]
        public int Id { get; set; }
        public string? UserPassword { get; set; }
        public string? UserMobile { get; set; }
        public string? UserEmail { get; set; }
        public bool? IsEmailConfirmed { get; set; }
        public bool? IsMobileConfirmed { get; set; }
        public DateTime? CreatedAt { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }
        
        [NotMapped]
        public int TotalCount { get; set; }
    }
}
