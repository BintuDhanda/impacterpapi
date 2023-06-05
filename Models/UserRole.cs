using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP.Models
{
    public class UserRole
    {
        [Key]
        public int Id { get; set; }
        public int UserID { get; set; }
        public int RoleID { get; set; }
        [NotMapped]
        public string? RoleName { get; set; }
    }
}
