using log4net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using WeatherApi.Common;
using WeatherApi.Factory;

namespace WeatherApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeatherController : ControllerBase
    {
        AppSettingsManager _appsettingsManager;
        ILog _logger;
        IWeatherApi _weatherApi;

        public WeatherController(IConfiguration configuration, ILog logger)
        {
            _appsettingsManager = new AppSettingsManager(configuration);
            _logger = logger;
            _weatherApi = GetWeatherApi();
        }

        private IWeatherApi GetWeatherApi()
        {
            WeatherApiRequest weatherApiRequest = new WeatherApiRequest()
            {
                ApiKey = _appsettingsManager.ApiKey,
                NoOfDays = _appsettingsManager.NumberOfDays,
                HotWeatherThreshold = _appsettingsManager.HotWeatherThreshold,
                MessageForRain = _appsettingsManager.MessageForRain,
                MessageForHotWeather = _appsettingsManager.MessageForHotWeather,
                MessageForNormalWeather = _appsettingsManager.MessageForNormalWeather
            };

            return new WeatherApiFactory().GetWeatherApi(_appsettingsManager.ExternalWeatherApiName, weatherApiRequest);
        }

        [HttpGet("{cityName}", Name = "Get")]
        public WeatherResponse Get(string cityName)
        {
            return _weatherApi.GetWeatherByCityName(cityName);
        }

    }
}
