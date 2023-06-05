using System.ComponentModel.DataAnnotations;

namespace ERP.Models
{
    public class Roles
    {
        [Key]
        public int Id { get; set; }
        public string RoleName { get; set; }
        public bool? IsActive { get; set; }
    }
}
