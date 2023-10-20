using ImageHandler.Data;
using ImageHandler.Models;
using ImageHandler.Services.Interfaces;

namespace ImageHandler.Services
{
    public class PluginManager : IPluginManager
    {

        private readonly AppDbContext _db;
        private readonly ILogger<PluginManager> _logger;

        public PluginManager(AppDbContext db, ILogger<PluginManager> logger)
        {
            _db = db;
            _logger = logger;
        }

        public string ApplyEffects(ImageDto imageDto)
        {
            Image existingImage = _db.Images.FirstOrDefault(i => i.ImageId == imageDto.ImageId);

            if (existingImage != null)
            {
                try
                {
                    List<Effect> effects = new List<Effect>();

                    foreach (var item in imageDto.Effects)
                    {

                        switch (item.Name)
                        {
                            case "Resize":
                                Resize(imageDto);
                                break;
                            case "Rotate":
                                Rotate(imageDto);
                                break;
                            // TODO: new functions
                            default:
                                continue;
                        }

                        effects.Add(new Effect()
                        {
                            Name = item.Name,
                        });
                    }

                    existingImage.Effects = effects;
                    _db.SaveChanges();
                    return "Changed";
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error while applying effects");
                    return ex.Message;
                }
            }
            else
            {
                _logger.LogError("Null Refference");
                return "Error";
            }
        }

        public void Resize(ImageDto imageDto)
        {

            // TODO:Resize code...
        }


        public void Rotate(ImageDto imageDto)
        {
            // TODO:Rotate code...
        }

    }
}
