using System.ComponentModel.DataAnnotations;

namespace ERP.Models
{
    public class CourseCategory
    {
        [Key]
        public int Id { get; set; }
        public string CourseCategoryName { get; set; }
        public bool IsActive { get; set; }
    }
}
