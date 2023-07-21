using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP.Models
{
    public class News : BaseModel
    {
        [Key]
        public int NewsId { get; set; }
        public string? NewsText { get; set; }
        public string? NewsImage { get; set; }
        public string? NewsTitle { get; set; }
        [NotMapped] 
        public int? TotalNews { get; set; }
        [NotMapped]
        public int? TotalLikes{ get; set; } = 0;
        [NotMapped]
        public int? TotalComments { get; set; } = 0;
        [NotMapped]
        public bool? IsLiked { get; set; } = false;
        [NotMapped]
        public bool? IsCommented { get; set; } = false;
        [NotMapped]
        public IFormFile? Image { get; set; }
    }
}
