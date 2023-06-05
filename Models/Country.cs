using System.ComponentModel.DataAnnotations;

namespace ERP.Models
{
    public class Country
    {
        [Key]
        public int Id { get; set; }
        public string CountryName { get; set; }
        public bool IsActive { get; set; }
    }
}
