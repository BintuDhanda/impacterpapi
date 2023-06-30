using System.ComponentModel.DataAnnotations;

namespace ERP.Models
{
    public class Student : BaseModel
    {
        [Key]
        public int Id { get; set; } = 0;
        public string StudentName { get; set; } = string.Empty;
        public string StudentPassword { get; set; } = string.Empty;
        public string PhoneNumber { get; set;}  = string.Empty;
        
    }
}
