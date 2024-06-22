using Microsoft.AspNetCore.Mvc;

namespace SharedLanguageResources.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ColorController : ControllerBase
    {
        private static readonly List<Color> RainbowColors = new List<Color> { 
            new Color 
            {
                TranslateKey = "RED",
                RgbValue = "#FF0000"
            },
            new Color
            {
                TranslateKey = "ORANGE",
                RgbValue = "#FFA500"
            },
            new Color
            {
                TranslateKey = "YELLOW",
                RgbValue = "#FFFF00"
            },
            new Color
            {
                TranslateKey = "GREEN",
                RgbValue = "#008000"
            },
            new Color
            {
                TranslateKey = "BLUE",
                RgbValue = "#0000FF"
            },
            new Color
            {
                TranslateKey = "INDIGO",
                RgbValue = "#4B0082"
            },
            new Color
            {
                TranslateKey = "VIOLET",
                RgbValue = "#EE82EE"
            }
        };

        private readonly ILogger<ColorController> _logger;
        private readonly ILanguageService _languageService;

        public ColorController(ILogger<ColorController> logger, ILanguageService languageService)
        {
            _logger = logger;
            _languageService = languageService;
        }

        [HttpGet()]
        public ActionResult<IEnumerable<Color>> GetRainbowColors()
        {
            return Ok(RainbowColors);
        }
    }
}
