using System.ComponentModel.DataAnnotations;

namespace ERP.Models
{
    public class Account
    {
        [Key]
        public int AccountId { get; set; }
        public string AccountName { get; set; }
        public int AccCategoryId { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? CreatedAt { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int? UpdatedBy { get; set; }
    }
}
