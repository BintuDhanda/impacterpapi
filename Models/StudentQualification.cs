using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP.Models
{
    public class StudentQualification : BaseModel
    {
        [Key]
        public int StudentQualificationId { get; set; }
        public string Subject { get; set; }
        public decimal MarksObtain { get; set; }
        public decimal MaximumMark { get; set; }
        public decimal Percentage { get; set; }
        public string Grade { get; set;}
        public int StudentId { get; set; }
        public int QualificationId { get; set; }
        [NotMapped]
        public string? QualificationName { get; set; }
    }
}
