using System.ComponentModel.DataAnnotations.Schema;

namespace ERP.SearchFilters
{
    public class UserLogin
    {
        public string UserPassword { get; set; }
        public string UserMobile { get; set; }
        [NotMapped] 
        public string? Message { get; set;}
    }
}
