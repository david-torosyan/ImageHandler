using System.ComponentModel.DataAnnotations;

namespace ImageHandler.Models
{
    public class ImageDto
    {

        public int ImageId { get; set; }
        public List<EffectDto> Effects { get; set; }
    }
}
