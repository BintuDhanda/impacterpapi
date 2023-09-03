using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP.Models
{
    public class StudentIdentities: BaseModel
    {
        [Key]
        public int StudentIdentitiesId { get; set; }
        public int StudentBatchId { get; set; }
        public int IdentityTypeId { get; set; }
        public bool? Status { get; set; }
        [NotMapped]
        public string? StringStatus { get; set; }
        [NotMapped]
        public string? IdentityTypeName { get; set; }
        [NotMapped]
        public string? StudentBatchName { get; set;}
    }
}
