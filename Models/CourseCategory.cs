using System.ComponentModel.DataAnnotations;

namespace ERP.Models
{
    public class CourseCategory : BaseModel
    {
        [Key]
        public int CourseCategoryId { get; set; }
        public string CourseCategoryName { get; set; }
    }
}
