using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace SharedLanguageResources.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LanguageController : ControllerBase
    {
        private readonly ILogger<LanguageController> _logger;
        private readonly ILanguageService _languageService;

        public LanguageController(
            ILogger<LanguageController> logger,
            ILanguageService languageService)
        {
            _logger = logger;
            _languageService = languageService;

        }

        [HttpGet("")]
        public ActionResult<string> GetLanguageResources()  
        {
            try
            {
                var strings = _languageService.GetAllStrings();
                var dictionary = strings.ToDictionary(s => s.Name, s => s.Value);
                var json = JsonSerializer.Serialize(dictionary);
                return Ok(json);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error calling GetLanguageResources");
                return StatusCode(
                   StatusCodes.Status500InternalServerError,
                   _languageService.GetString("ERROR_OCCURRED_CONTACT_SUPPORT"));
            }
        }
    }
}
