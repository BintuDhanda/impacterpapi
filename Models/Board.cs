using System.ComponentModel.DataAnnotations;

namespace ERP.Models
{
    public class Board
    {
        [Key]
        public int Id { get; set; }
        public string BoardName { get; set; }
        public bool IsAcitve { get; set; }
    }
}
