using ImageHandler.Models;

namespace ImageHandler.Services.Interfaces
{
    public interface IPluginManager
    {
        string ApplyEffects(ImageDto imageDto);
        void Resize(ImageDto imageDto);
        void Rotate(ImageDto imageDto);
    }
}
