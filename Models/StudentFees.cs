using System.ComponentModel.DataAnnotations;

namespace ERP.Models
{
    public class StudentFees
    {
        [Key]
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int BatchId { get; set; }
        public int FetTypeId { get; set; }
        public decimal Fees { get; set; }
        public decimal Discount { get; set; }
        public decimal PreferedFees { get; set; }
        public string RemarksDiscount { get; set; }
        public int ReferBy { get; set; }
        public bool IsActive { get; set;}
        public bool IsDeleted { get; set; }
        public DateTime CreatedAt { get; set; }
        public int CreatedBy { get; set; }
    }
}
