using System.ComponentModel.DataAnnotations;

namespace ERP.Models
{
    public class Account : BaseModel
    {
        [Key]
        public int AccountId { get; set; }
        public string AccountName { get; set; }
        public int AccCategoryId { get; set; }
    }
}
