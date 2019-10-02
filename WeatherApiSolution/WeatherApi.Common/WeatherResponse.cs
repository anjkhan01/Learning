using System.Collections.Generic;

namespace WeatherApi.Common
{
    public class WeatherResponse
    {
        public string CityName { get; set; }
        public List<CustomWeatherData> CustomWeatherData { get; set; }

        public WeatherResponse(string cityName)
        {
            CityName = cityName;
            CustomWeatherData = new List<CustomWeatherData>();
        }
    }

    public class CustomWeatherData
    {
        public string Date { get; set; }
        public string Message { get; set; }
    }
}
