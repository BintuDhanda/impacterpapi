namespace ERP.Models
{
    public class HostelRoomStudent : BaseModel
    {
        public int HostelRoomStudentId { get; set; }
        public int RoomId { get; set; }
        public int StudentId { get; set; }
        public DateTime AllocatedFrom { get; set; }
        public DateTime AllocatedTill { get; set; }
        public decimal MonthlyRent { get; set; }
    }
}
