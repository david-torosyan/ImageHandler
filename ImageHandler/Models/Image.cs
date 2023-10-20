using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace ImageHandler.Models
{
    public class Image
    {
        public Image()
        {
            Effects = new List<Effect>();
        }

        [Key]
        public int ImageId { get; set; }
        [Required]
        public string Path { get; set; }

        public float Width { get; set; }
        public float Height { get; set; }    
        public virtual ICollection<Effect> Effects { get; set; }
    }
}
