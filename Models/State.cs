using System.ComponentModel.DataAnnotations;

namespace ERP.Models
{
    public class State
    {
        [Key]
        public int Id { get; set; }
        public string StateName { get; set; }
        public bool IsActive { get; set; }
        public int CountryId { get; set; }
    }
}
