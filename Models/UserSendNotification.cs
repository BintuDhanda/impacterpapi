using System.ComponentModel.DataAnnotations;

namespace ERP.Models
{
    public class UserSendNotification
    {
        [Key]
        public int UserSendNotificationId { get; set; }
        public int UserId { get; set; }
        public int UserNotificationId { get; set; }
        public bool SentStatus { get; set; }
        public DateTime SentAt { get; set; }
    }
}
