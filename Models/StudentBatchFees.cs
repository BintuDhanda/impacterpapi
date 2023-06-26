using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP.Models
{
    public class StudentBatchFees
    {
        [Key]
        public int StudentBatchFeesId { get; set; }
        public int StudentId { get; set; }
        public int StudentBatchId { get; set; }
        public decimal Deposit { get; set; }
        public decimal Refund { get; set; }
        public string Particulars { get; set; }
        public bool IsActive { get; set;}
        public bool IsDeleted { get; set; }
        public DateTime? CreatedAt { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int? UpdatedBy { get; set;}
        [NotMapped]
        public string? RegistrationNumber { get; set; }
        [NotMapped]
        public string? StudentName { get; set; }
        [NotMapped]
        public string? Mobile { get; set; }
        [NotMapped]
        public string? BatchName { get; set; }
    }
}
