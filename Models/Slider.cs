using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP.Models
{
    public class Slider : BaseModel
    {
        [Key]
        public int SliderId { get; set; }
        public string? SliderImage { get; set; }
        public int? OrderBy { get; set; }
        [NotMapped]
        public IFormFile? Image { get; set; }
    }
}
