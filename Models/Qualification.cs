using System.ComponentModel.DataAnnotations;

namespace ERP.Models
{
    public class Qualification : BaseModel
    {
        [Key]
        public int QualificationId { get; set; }
        public string QualificationName { get; set; }
    }
}
