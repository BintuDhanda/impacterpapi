using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP.Models
{
    public class StudentBatch : BaseModel
    {
        [Key]
        public int StudentBatchId { get; set; }
        public DateTime? DateOfJoin { get; set; }
        public DateTime BatchStartDate { get; set; }
        public DateTime BatchEndDate { get; set; }
        public int BatchId { get; set; }
        public int StudentId { get; set; }
        public string RegistrationNumber { get; set; }
        [NotMapped]
        public string? BatchName { get; set; }
    }
}
