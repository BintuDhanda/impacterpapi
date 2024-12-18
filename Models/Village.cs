using System.ComponentModel.DataAnnotations;

namespace ERP.Models
{
    public class Village : BaseModel
    {
        [Key]
        public int VillageId { get; set; }
        public string VillageName { get; set; }
        public int CityId { get; set; }
    }
}
