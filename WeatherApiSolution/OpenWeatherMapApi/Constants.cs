using System;
using System.Collections.Generic;
using System.Text;

namespace OpenWeatherMapExternalApi
{
    public static class Constants
    {
        public const string OPEN_WEATHER_MAP_URI = "https://api.openweathermap.org/data/2.5/forecast?q={0}&mode=xml&units=metric&appid={1}";

        public const string OPEN_WEATHER_MAP_ERROR = "External API {0} call returned error. City name may not be valid or You may not be authorized. {1}";

        public const string MAX_NUMBER_OF_DAYS_SUPPORTED_ERROR = "OpenWeatherMapApi supports maximum 5 days of data. Please check appsettings 'NumberOfDays'.";
    }
}
