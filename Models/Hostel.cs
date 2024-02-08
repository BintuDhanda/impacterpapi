namespace ERP.Models
{
    public class Hostel : BaseModel
    {
        public int HostelId { get; set; }
        public int AcademyId { get; set; }
        public string? HostelName { get; set; }
    }
}
