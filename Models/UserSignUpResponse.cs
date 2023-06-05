namespace ERP.Models
{
    public class UserSignUpResponse
    {
        public int UserId { get; set; }
        public string? Token { get; set; }
        public string? Message { get; set; }
    }
}
