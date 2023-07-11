using System.ComponentModel.DataAnnotations;

namespace ERP.Models
{
    public class City : BaseModel
    {
        [Key]
        public int CityId { get; set; }
        public string CityName { get; set; }
        public int StateId { get; set; }
    }
}
