
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP.Models
{
    public class StudentHostelRoomBadRent : BaseModel
    {
        public int Id { get; set; }
        public int HostelId { get; set; }
        public string? HostelName { get; set; }
        public int RoomId { get; set; }
        public string? RoomNo { get; set; }
        public int BadId { get; set; }
        public string? BadNo { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        public decimal DueAmount { get; set; }
        public string? DisplayMessage { get; set; }
    }
}
