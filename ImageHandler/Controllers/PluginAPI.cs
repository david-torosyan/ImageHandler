using ImageHandler.Data;
using ImageHandler.Models;
using ImageHandler.Services;
using ImageHandler.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static System.Net.Mime.MediaTypeNames;

namespace ImageHandler.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PluginAPI : ControllerBase
    {
        private readonly IPluginManager _pluginManager;
        private readonly ILogger<PluginAPI> _logger;

        public PluginAPI(IPluginManager pluginManager, ILogger<PluginAPI> logger)
        {
            _pluginManager = pluginManager;
            _logger = logger;
        }

        [HttpPut]
        [Route("api/UpdateImage")]
        [Authorize(Roles = "ADMIN")]
        public ActionResult Put([FromBody] ImageDto ImageDto)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    string result = _pluginManager.ApplyEffects(ImageDto);
                    _logger.LogInformation("Applied successfully");
                    return Ok(result);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error");
                    return StatusCode(500, "An error while applying");
                }
            }
            else
            {
                _logger.LogWarning("Invalid");
                return BadRequest(ModelState);
            }
        }

    }
}