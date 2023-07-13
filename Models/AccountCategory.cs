using System.ComponentModel.DataAnnotations;

namespace ERP.Models
{
    public class AccountCategory : BaseModel
    {
        [Key]
        public int AccountCategoryId { get; set; }
        public string AccCategoryName { get; set; }
    }
}
