using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP.Models
{
    public class Users
    {
        [Key]
        public int Id { get; set; }
        public string? UserName { get; set; }
        public string? UserPassword { get; set; }
        public string? PhoneNumber { get; set; }
        public DateTime? CreatedAt { get; set; }
        public bool? IsActive { get; set; }
        
        [NotMapped]
        public int TotalCount { get; set; }
    }
}
