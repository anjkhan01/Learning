namespace WeatherApi.Common
{

    public class WeatherApiRequest
    {
        public string ApiKey { get; set; }
        public int NoOfDays { get; set; }
        public double HotWeatherThreshold { get; set; }
        public string MessageForRain { get; set; }
        public string MessageForHotWeather { get; set; }
        public string MessageForNormalWeather { get; set; }
    }
}
