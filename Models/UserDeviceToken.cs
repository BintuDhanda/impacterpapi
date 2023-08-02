using System.ComponentModel.DataAnnotations;

namespace ERP.Models
{
    public class UserDeviceToken
    {
        [Key]
        public int UserDeviceTokenId { get; set; }
        public int UserId { get; set; }
        public string UserToken { get; set;}
        public string DeviceType { get; set;}
    }
}
