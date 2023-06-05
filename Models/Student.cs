using System.ComponentModel.DataAnnotations;

namespace ERP.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }
        public string StudentName { get; set; }
        public string StudentPassword { get; set; }
        public string PhoneNumber { get; set;}
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreatedAt { get; set; }
        public int CreatedBy { get; set; }
    }
}
