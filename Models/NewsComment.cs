using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP.Models
{
    public class NewsComment : BaseModel
    {
        [Key]
        public int NewsCommentId { get; set; }
        public string Comment { get; set; }
        public int NewsId { get; set; }
        [NotMapped]
        public string? UserName { get; set; }
        [NotMapped]
        public string? UserMobile { get; set; }
    }
}
