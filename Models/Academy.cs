using System.ComponentModel.DataAnnotations;

namespace ERP.Models
{
    public class Academy : BaseModel
    {
        [Key]
        public int AcademyId { get; set; }
        public string AcademyName { get; set; }
    }
}
