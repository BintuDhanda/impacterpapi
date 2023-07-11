using System.ComponentModel.DataAnnotations;

namespace ERP.Models
{
    public class AddressType : BaseModel
    {
        [Key]
        public int AddressTypeId { get; set; }
        public string AddressTypeName { get; set; }
    }
}
