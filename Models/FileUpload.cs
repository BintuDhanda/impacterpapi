namespace ERP.Models
{
    public class FileUpload
    {
        public string? UserMobile { get; set; }
        public string? UserPassword { get; set; }
        public IFormFile? UploadFile { get; set; }
    }
}
