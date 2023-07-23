using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP.Models
{
    public class StudentToken : BaseModel
    {
        [Key]
        public int StudentTokenId { get; set; }
        public DateTime? ValidFrom { get; set; }
        public DateTime? ValidUpto { get; set; }
        public decimal? TokenFee { get; set; }
        public int? StudentId { get; set; }
        public int? BatchId { get; set; }
        public bool? IsValidForAdmission { get; set;} = false;
        [NotMapped]
        public string? BatchName { get; set; }
        [NotMapped]
        public bool? TokenStatus { get; set;}
        [NotMapped]
        public string? IsValidForAdmissionNonMapped { get; set;}
        [NotMapped]
        public string? TotalDeposit { get; set;}
        [NotMapped]
        public string? TotalRefund { get; set;}
        [NotMapped]
        public string? Message { get; set; } = string.Empty;
    }
}
