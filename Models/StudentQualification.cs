using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP.Models
{
    public class StudentQualification
    {
        [Key]
        public int Id { get; set; }
        public string Subject { get; set; }
        public decimal MarksObtain { get; set; }
        public decimal MaximumMark { get; set; }
        public decimal Percentage { get; set; }
        public string Grade { get; set;}
        public int StudentId { get; set; }
        public int QualificationId { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? CreatedAt { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int? UpdatedBy { get; set; }
        [NotMapped]
        public string? QualificationName { get; set; }
    }
}
