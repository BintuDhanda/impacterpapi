using System.ComponentModel.DataAnnotations;

namespace ERP.Models
{
    public class Batch : BaseModel
    {
        [Key]
        public int BatchId { get; set; }
        public string BatchName { get; set; }
        public int Code { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int CourseId { get; set; }
    }
}
