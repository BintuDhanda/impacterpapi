using System.ComponentModel.DataAnnotations;

namespace ERP.Models
{
    public class TokenValidity
    {
        [Key]
        public int Id { get; set; }
        public int BatchId { get; set; }
        public int Validity { get; set; }
        public decimal Amount { get; set; }
    }
}
