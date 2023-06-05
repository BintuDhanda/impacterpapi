using System.ComponentModel.DataAnnotations;

namespace ERP.Models
{
    public class Batch
    {
        [Key]
        public int Id { get; set; }
        public string BatchName { get; set; }
        public int Code { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime? CreatedAt { get; set; }
        public bool IsActive { get; set; }
        public int CourseId { get; set; }
    }
}
