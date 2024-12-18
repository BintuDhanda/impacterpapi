using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP.Models
{
    public class Batch : BaseModel
    {
        [Key]
        public int BatchId { get; set; }
        public string BatchName { get; set; }
        public decimal Fees { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int CourseId { get; set; }
        [NotMapped] 
        public string? Duration { get; set; }
    }
}
