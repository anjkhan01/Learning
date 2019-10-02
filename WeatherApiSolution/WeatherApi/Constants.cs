using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherApi
{
    public static class Constants
    {
        public const string APPSETTING_NOOFDAYS_NONINTEGER_ERROR = "The value for appsettings key 'NumberOfDays' must be integer. {0}";
        public const string APPSETTING_HOTWEATHERTHRESHOLD_NONINTEGER_ERROR = "The value for appsettings key 'HotWeatherThreshold' must be integer or double. {0}";

    }
}
