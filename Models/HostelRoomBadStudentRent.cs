using System.ComponentModel.DataAnnotations.Schema;

namespace ERP.Models
{
    public class HostelRoomBadStudentRent : BaseModel
    {
        public int HostelRoomBadStudentRentId { get; set; }
        public int HostelRoomBadStudentId { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        public string? PaymentMode { get; set; }
        public string? PaymentType { get; set; }
        public DateTime PaymentDate { get; set; }
        public decimal ReceivedAmount { get; set; }
        public decimal RefundAmount { get; set; }
        public string? Remarks { get; set; }
    }
}
