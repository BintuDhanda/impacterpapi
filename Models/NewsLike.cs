using System.ComponentModel.DataAnnotations;

namespace ERP.Models
{
    public class NewsLike : BaseModel
    {
        [Key] 
        public int NewsLikeId { get; set; }
        public int NewsId { get; set; }
    }
}
