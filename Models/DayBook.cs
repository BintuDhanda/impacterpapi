using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP.Models
{
    public class DayBook : BaseModel
    {
        [Key]
        public int DayBookId { get; set; }
        public string Particulars { get; set; }
        public decimal Credit { get; set; }
        public decimal Debit { get; set; }
        public int AccountId { get; set; }
        [NotMapped]
        public string? Account { get; set; }
    }
}
