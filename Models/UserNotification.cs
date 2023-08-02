using System.ComponentModel.DataAnnotations;

namespace ERP.Models
{
    public class UserNotification : BaseModel
    {
        [Key]
        public int UserNotificationId { get; set; }
        public string? Title { get; set; }
        public string? Body { get; set; }
        public string? SendToType { get; set; }
        public int? SendToId { get; set; }
        public bool? IsProcessed { get; set; }
    }
}
