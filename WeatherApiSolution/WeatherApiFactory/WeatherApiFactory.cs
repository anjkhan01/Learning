using OpenWeatherMapExternalApi;
using System;
using WeatherApi.Common;

namespace WeatherApi.Factory
{
    public class WeatherApiFactory : IWeatherApiFactory
    {
        IWeatherApi _weatherApi;

        public IWeatherApi GetWeatherApi(string externalWeatherApiName, WeatherApiRequest weatherApiRequest)
        {
            if (weatherApiRequest == null)
                throw new ArgumentNullException("weatherApiRequest", "weatherApiRequest is a required parameter.");

            switch (externalWeatherApiName)
            {
                case "OpenWeatherMap":
                    _weatherApi = new OpenWeatherMapApi(weatherApiRequest);
                    break;

                default:
                    throw new Exception(string.Format("External Weather API {0} is not supported.", externalWeatherApiName));

            }
            return _weatherApi;
        }

    }

}
