using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP.Models
{
    public class StudentBatch
    {
        [Key]
        public int Id { get; set; }
        public DateTime? DateOfJoin { get; set; }
        public DateTime BatchStartDate { get; set; }
        public DateTime BatchEndDate { get; set; }
        public int BatchId { get; set; }
        public int StudentId { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? CreatedAt { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set;}
        public int? UpdatedBy { get; set;}
        [NotMapped]
        public string? BatchName { get; set; }
    }
}
