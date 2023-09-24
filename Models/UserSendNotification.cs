using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP.Models
{
    public class UserSendNotification : BaseModel
    {
        [Key]
        public int UserSendNotificationId { get; set; }
        public int UserId { get; set; }
        public int UserNotificationId { get; set; }
        public bool SentStatus { get; set; }
        public DateTime SentAt { get; set; }
        [NotMapped] 
        public string? Title { get; set; }
        [NotMapped]
        public string? Body { get; set; }
    }
}
