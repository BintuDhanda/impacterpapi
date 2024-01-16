using System.ComponentModel.DataAnnotations;

namespace ERP.Models
{
    public class Roles : BaseModel
    {
        [Key]
        public int RolesId { get; set; }
        public string RoleName { get; set; }
        public bool IsStatic { get; set; }
    }
}
