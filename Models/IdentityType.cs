using System.ComponentModel.DataAnnotations;

namespace ERP.Models
{
    public class IdentityType: BaseModel
    {
        [Key]
        public int IdentityTypeId { get; set; }
        public string Name { get; set; }
    }
}
