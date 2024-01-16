using System.ComponentModel.DataAnnotations.Schema;

namespace ERP.Models
{
    public class HostelRoomBadStudent : BaseModel
    {
        public int HostelRoomBadStudentId { get; set; }
        public int HostelId { get; set; }
        public int HostelRoomId { get; set; }
        public int HostelRoomBadId { get; set; }
        public int StudentId { get; set; }
        [NotMapped]
        public string? HostelRoomBad { get; set;}
    }
}
