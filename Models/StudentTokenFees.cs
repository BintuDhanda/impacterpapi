using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP.Models
{
    public class StudentTokenFees : BaseModel
    {
        [Key]
        public int StudentTokenFeesId { get; set; }
        public int? StudentId { get; set; }
        public int StudentTokenId { get; set; }
        public decimal Deposit { get; set; }
        public decimal Refund { get; set; }
        public string Particulars { get; set; }
        [NotMapped]
        public int? TokenNumber { get; set; }
        [NotMapped]
        public string? StudentName { get; set; }
        [NotMapped]
        public string? Mobile { get; set; }
        [NotMapped]
        public string? BatchName { get; set; }
    }
}
