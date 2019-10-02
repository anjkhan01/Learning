using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherApi
{
    public class AppSettingsManager
    {
        IConfiguration _configuration;

        public AppSettingsManager(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string ExternalWeatherApiName
        {
            get
            {
                return _configuration["ExternalWeatherApiName"];
            }
        }

        public string ApiKey
        {
            get
            {
                return _configuration["ApiKey"];
            }
        }

        public int NumberOfDays
        {
            get
            {
                int noOfDays;
                try
                {
                    noOfDays = int.Parse(_configuration["NumberOfDays"]);

                }
                catch (Exception ex)
                {
                    throw new Exception(string.Format(Constants.APPSETTING_NOOFDAYS_NONINTEGER_ERROR, ex.Message));
                }

                return noOfDays;
            }
        }

        public double HotWeatherThreshold
        {
            get
            {
                double hotWeatherThreshold;
                try
                {
                    hotWeatherThreshold = double.Parse(_configuration["HotWeatherThreshold"]);
                }
                catch (Exception ex)
                {
                    throw new Exception(string.Format(Constants.APPSETTING_HOTWEATHERTHRESHOLD_NONINTEGER_ERROR, ex.Message));
                }
                return hotWeatherThreshold;
            }
        }

        public string MessageForRain
        {
            get
            {
                return _configuration["MessageForRain"];
            }
        }

        public string MessageForHotWeather
        {
            get
            {
                return _configuration["MessageForHotWeather"];
            }
        }

        public string MessageForNormalWeather
        {
            get
            {
                return _configuration["MessageForNormalWeather"];
            }
        }
    }
}
