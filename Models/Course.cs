using System.ComponentModel.DataAnnotations;

namespace ERP.Models
{
    public class Course
    {
        [Key]
        public int Id { get; set; }
        public string CourseName { get; set; }
        public decimal Fees { get; set; }
        public string Duration { get; set; }
        public int CourseCategoryId { get; set; }
        public bool IsActive { get; set; }
    }
}
