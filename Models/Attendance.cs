using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP.Models
{
    public class Attendance : BaseModel
    {
        [Key]
        public int AttendanceId { get; set; }
        public int StudentBatchId { get; set; }
        public int StudentId { get; set; }
        public string AttendanceType { get; set; }
        public DateTime? PunchTime { get; set; }
        [NotMapped]
        public string? BatchName { get; set; }
        [NotMapped]
        public string? StudentName { get; set; }
        [NotMapped]
        public string? Mobile { get; set; }
        [NotMapped]
        public string? RegistrationNumber { get; set; }
    }
}
