using System.ComponentModel.DataAnnotations;

namespace ERP.Models
{
    public class Registration
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        public int BatchId { get; set; }
        public int RegistrationNum { get; set; }
    }
}
