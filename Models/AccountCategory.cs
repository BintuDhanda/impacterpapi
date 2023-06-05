using System.ComponentModel.DataAnnotations;

namespace ERP.Models
{
    public class AccountCategory
    {
        [Key]
        public int Id { get; set; }
        public string AccCategoryName { get; set; }
        public bool IsActive { get; set; }
    }
}
