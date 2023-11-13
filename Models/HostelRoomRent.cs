namespace ERP.Models
{
    public class HostelRoomRent : BaseModel
    {
        public Int64 HostelRoomRentId { get; set; }
        public int HostelRoomId { get; set; }
        public decimal AmountReceived { get; set; }
        public decimal AmountRefunded { get; set; }
    }
}
