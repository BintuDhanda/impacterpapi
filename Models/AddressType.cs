using System.ComponentModel.DataAnnotations;

namespace ERP.Models
{
    public class AddressType
    {
        [Key]
        public int Id { get; set; }
        public string AddressTypeName { get; set; }
        public bool IsActive { get; set; }
    }
}
