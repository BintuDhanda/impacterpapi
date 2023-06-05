using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP.Models
{
    public class StudentQualification
    {
        [Key]
        public int Id { get; set; }
        public string Subjects { get; set; }
        public int MarksObtain { get; set; }
        public int MaximumMarks { get; set; }
        public int Percentage { get; set; }
        public string Grade { get; set;}
        public int UserId { get; set; }
        public int QualificationId { get; set; }
        public bool IsActive { get; set; }
        [NotMapped]
        public string? QualificationName { get; set; }
    }
}
