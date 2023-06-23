using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP.Models
{
    public class StudentToken
    {
        [Key]
        public int Id { get; set; }
        public DateTime? ValidFrom { get; set; }
        public DateTime? ValidUpto { get; set; }
        public decimal? TokenFee { get; set; }
        public int? StudentId { get; set; }
        public int? BatchId { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }
        public DateTime? CreatedAt { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set;}
        public int? UpdatedBy { get;set; }
        [NotMapped]
        public string? BatchName { get; set; }
    }
}
