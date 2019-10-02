using WeatherApi.Common;

namespace WeatherApi.Factory
{
    public interface IWeatherApiFactory
    {
        IWeatherApi GetWeatherApi(string externalWeatherApiName, WeatherApiRequest weatherApiRequest);
    }
}
