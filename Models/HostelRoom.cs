namespace ERP.Models
{
    public class HostelRoom : BaseModel
    {
        public int HostelRoomId { get; set; }
        public int HostelId { get; set; }
        public string? HostelRoomNo { get; set; }
    }
}
