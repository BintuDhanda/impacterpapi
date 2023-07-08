using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP.Models
{
    public class NewsLike : BaseModel
    {
        [Key] 
        public int NewsLikeId { get; set; }
        public int NewsId { get; set; }
        [NotMapped]
        public string? UserName { get; set; }
        [NotMapped]
        public string? UserMobile { get; set; }
    }
}
