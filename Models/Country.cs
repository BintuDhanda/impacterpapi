using System.ComponentModel.DataAnnotations;

namespace ERP.Models
{
    public class Country : BaseModel
    {
        [Key]
        public int CountryId { get; set; }
        public string CountryName { get; set; }
    }
}
