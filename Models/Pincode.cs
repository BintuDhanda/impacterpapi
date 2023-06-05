using System.ComponentModel.DataAnnotations;

namespace ERP.Models
{
    public class Pincode
    {
        [Key]
        public int Id { get; set; }
        public int PinNumber { get; set; }
        public bool IsActive { get; set; }
        public int CityId { get; set; }
    }
}
