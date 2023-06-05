using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP.Models
{
    public class DayBook
    {
        [Key]
        public int ID { get; set; }
        public string Particulars { get; set; }
        public decimal Credit { get; set; }
        public decimal Debit { get; set; }
        public DateTime CreatedAt { get; set; }
        public int AccountId { get; set; }
        public bool IsActive { get; set; }
        [NotMapped]
        public string? Account { get; set; }
    }
}
