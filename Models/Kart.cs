using System.ComponentModel.DataAnnotations;

namespace Libary1670.Models
{
    public class Kart
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public int Quantity { get; set; }
        public float Total { get; set; }
        public virtual Products products { get; set; }
    }
}
