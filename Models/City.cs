using System.ComponentModel.DataAnnotations;

namespace ERP.Models
{
    public class City
    {
        [Key]
        public int ID { get; set; }
        public string CityName { get; set; }
        public bool IsActive { get; set; }
        public int StateId { get; set; }
    }
}
