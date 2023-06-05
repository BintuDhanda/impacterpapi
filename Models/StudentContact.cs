using System.ComponentModel.DataAnnotations;

namespace ERP.Models
{
    public class StudentContact
    {
        [Key]
        public int ID { get; set; }
        public string ContactType { get; set; }
        public string Contact { get; set; }
        public bool IsActive { get; set; }
        public int UserId { get; set; }
    }
}
