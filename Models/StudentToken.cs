using System.ComponentModel.DataAnnotations;

namespace ERP.Models
{
    public class StudentToken
    {
        [Key]
        public int Id { get; set; }
        public int TokenNumber{ get; set; }
        public DateTime ValidForm { get; set; }
        public DateTime ValidUpto { get; set; }
        public Decimal Amount { get; set; }
        public int UserId { get; set; }
        public int BatchId { get; set; }
    }
}
