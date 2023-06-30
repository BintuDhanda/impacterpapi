using System.ComponentModel.DataAnnotations;

namespace ERP.Models
{
    public class News : BaseModel
    {
        [Key]
        public int NewsId { get; set; }
        public string NewsText { get; set; }
        public string NewsTitle { get; set; }
    }
}
