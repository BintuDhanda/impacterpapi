using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP.Models
{
    public class Attendance
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime PunchTime { get; set; }
        [NotMapped]
        public string UserName { get; set; }
    }
}
