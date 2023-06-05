using System.ComponentModel.DataAnnotations;

namespace ERP.Models
{
    public class StudentBatch
    {
        [Key]
        public int Id { get; set; }
        public string DateOfJoin { get; set; }
        public string Validity { get; set; }
        public decimal BatchFees { get; set; }
        public decimal Discount { get; set; }
        public int BatchId { get; set; }
        public int UserId { get; set; }
        public bool IsActive { get; set; }
    }
}
