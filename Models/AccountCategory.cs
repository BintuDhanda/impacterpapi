using System.ComponentModel.DataAnnotations;

namespace ERP.Models
{
    public class AccountCategory
    {
        [Key]
        public int AccountCategoryId { get; set; }
        public string AccCategoryName { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? CreatedAt { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int? UpdatedBy { get; set; }
    }
}
