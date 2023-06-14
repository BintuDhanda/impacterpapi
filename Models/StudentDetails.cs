using System.ComponentModel.DataAnnotations;

namespace ERP.Models
{
    public class StudentDetails
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FatherName { get; set; }
        public string MotherName { get; set; }
        public string Gender { get; set; }
        public int StudentHeight { get; set; }
        public int StudentWeight { get; set; }
        public string BodyRemark { get; set; }
        public int UserId { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set;}
        public DateTime CreatedAt { get; set; }
    }
}
