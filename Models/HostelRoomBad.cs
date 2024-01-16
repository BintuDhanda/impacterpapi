namespace ERP.Models
{
    public class HostelRoomBad : BaseModel
    {
        public int HostelRoomBadId { get; set; }
        public int HostelRoomId { get; set; }
        public string? HostelRoomBadNo { get; set; }
        public decimal HostelRoomBadSecurity { get; set; }
        public decimal HostelRoomBadAmount { get; set; }
        public bool IsAllocated { get; set; }
    }
}
