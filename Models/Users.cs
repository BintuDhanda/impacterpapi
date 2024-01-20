using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP.Models
{
    public class Users : BaseModel
    {
        [Key]
        public int UsersId { get; set; }
        public string? UserPassword { get; set; }
        public string? UserMobile { get; set; }
        public string? UserEmail { get; set; }
        public bool? IsEmailConfirmed { get; set; }
        public bool? IsMobileConfirmed { get; set; }
        
        [NotMapped]
        public int? TotalCount { get; set; }
        [NotMapped]
        public bool? IsStudentCreated { get; set; }
        [NotMapped]
        public int? TotalUser { get; set; }
    }
}
