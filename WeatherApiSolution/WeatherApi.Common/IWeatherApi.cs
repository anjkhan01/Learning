namespace WeatherApi.Common
{
    public interface IWeatherApi
    {
        WeatherResponse GetWeatherByCityName(string cityName);
    }

}
