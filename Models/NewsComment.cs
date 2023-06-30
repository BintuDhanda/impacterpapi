using System.ComponentModel.DataAnnotations;

namespace ERP.Models
{
    public class NewsComment : BaseModel
    {
        [Key]
        public int NewsCommentId { get; set; }
        public string Comment { get; set; }
        public int NewsId { get; set; }
    }
}
