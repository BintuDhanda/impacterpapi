using System.ComponentModel.DataAnnotations;

namespace ERP.Models
{
    public class State : BaseModel
    {
        [Key]
        public int StateId { get; set; }
        public string StateName { get; set; }
        public int CountryId { get; set; }
    }
}
