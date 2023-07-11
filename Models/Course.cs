using System.ComponentModel.DataAnnotations;

namespace ERP.Models
{
    public class Course : BaseModel
    {
        [Key]
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public int CourseCategoryId { get; set; }
    }
}
