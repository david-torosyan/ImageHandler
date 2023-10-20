using System.ComponentModel.DataAnnotations;

namespace ImageHandler.Models
{
    public class Effect
    {
        [Key]
        public int EffectId { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
