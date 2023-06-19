using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP.Models
{
    public class StudentAddress
    {
        [Key]
        public int Id { get; set; }
        public int AddressTypeId { get; set; }
        public string Address { get; set; }
        public int CountryId { get; set; }
        public int StateId { get; set; }
        public int CityId { get; set; }
        public int Pincode { get; set; }
        public int StudentId { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? CreatedAt { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? UpdatedAt { get;set; }
        public int? UpdatedBy { get; set; }
        [NotMapped]
        public string? AddressType { get; set; }
        [NotMapped]
        public string? City { get; set; }
        [NotMapped]
        public string? Country { get; set; }
        [NotMapped]
        public string? State { get; set; }
    }
}
