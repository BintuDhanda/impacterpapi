using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP.Models
{
    public class UserRole 
    {
        [Key]
        public int UserRoleId { get; set; }
        public int UserID { get; set; }
        public int RoleID { get; set; }
        public DateTime? CreatedAt { get; set; }
        public int? CreatedBy { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }
        [NotMapped]
        public string? RoleName { get; set; }
    }
}
