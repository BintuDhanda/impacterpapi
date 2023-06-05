using System.ComponentModel.DataAnnotations;

namespace ERP.Models
{
    public class Account
    {
        [Key]
        public int Id { get; set; }
        public string AccountName { get; set; }
        public bool IsActive { get; set; }
        public int AccCategoryId { get; set; }
    }
}
