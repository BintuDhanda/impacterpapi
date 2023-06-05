using System.ComponentModel.DataAnnotations;

namespace ERP.Models
{
    public class Qualification
    {
        [Key]
        public int Id { get; set; }
        public string QualificationName { get; set; }
        public bool IsActive { get; set; }
    }
}
