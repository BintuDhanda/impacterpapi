using System.ComponentModel.DataAnnotations;

namespace ERP.Models
{
    public class FeeType
    {
        [Key]
        public int Id { get; set; }
        public string FeeTypeName { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
