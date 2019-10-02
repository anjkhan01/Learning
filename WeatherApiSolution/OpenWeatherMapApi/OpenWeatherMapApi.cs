using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Xml.Serialization;
using WeatherApi.Common;

namespace OpenWeatherMapExternalApi
{

    public class OpenWeatherMapApi : IWeatherApi
    {
        const string ApiName = "OpenWeatherMap";

        WeatherApiRequest _weatherApiRequest;

        public OpenWeatherMapApi(WeatherApiRequest weatherApiRequest)
        {
            _weatherApiRequest = weatherApiRequest;

            if (_weatherApiRequest.NoOfDays < 0 || _weatherApiRequest.NoOfDays > 5)
                throw new Exception(Constants.MAX_NUMBER_OF_DAYS_SUPPORTED_ERROR);
        }

        public WeatherResponse GetWeatherByCityName(string cityName)
        {
            string openWeatherApi = String.Format(Constants.OPEN_WEATHER_MAP_URI, cityName, _weatherApiRequest.ApiKey);
            HttpWebRequest apiRequest = WebRequest.Create(openWeatherApi) as HttpWebRequest;

            WebResponse webResponse;
            try
            {
                webResponse = apiRequest.GetResponse();
            }
            catch (WebException ex)
            {
                throw new Exception(string.Format(Constants.OPEN_WEATHER_MAP_ERROR, ApiName, ex.Message));
            }

            string apiResponse = "";
            using (HttpWebResponse response = webResponse as HttpWebResponse)
            {
                StreamReader reader = new StreamReader(response.GetResponseStream());
                apiResponse = reader.ReadToEnd();
            }

            Weatherdata weatherdata;
            var serializer = new XmlSerializer(typeof(Weatherdata));
            using (TextReader reader = new StringReader(apiResponse))
            {
                weatherdata = (Weatherdata)serializer.Deserialize(reader);
            }

            return GetWeatherResponse(cityName, weatherdata);
        }

        private WeatherResponse GetWeatherResponse(string cityName, Weatherdata weatherdata)
        {
            WeatherResponse weatherResponse = new WeatherResponse(cityName);

            List<List<Time>> groupedWeatherByDateList = weatherdata.Forecast.Time.GroupBy(t => DateTime.Parse(t.From).ToShortDateString()).Select(grp => grp.ToList()).ToList();

            for (int i = 0; i < _weatherApiRequest.NoOfDays; i++)
            {
                List<Time> weatherDetails = groupedWeatherByDateList[i];

                CustomWeatherData customWeatherData = new CustomWeatherData();
                customWeatherData.Date = DateTime.Parse(weatherDetails[0].From).ToShortDateString();
                if (weatherDetails.Any(t => t.Symbol.Name.Contains("rain")))
                    customWeatherData.Message = _weatherApiRequest.MessageForRain;
                else if (weatherDetails.Any(t => double.Parse(t.Temperature.Value) > _weatherApiRequest.HotWeatherThreshold))
                    customWeatherData.Message = _weatherApiRequest.MessageForHotWeather;
                else
                    customWeatherData.Message = _weatherApiRequest.MessageForNormalWeather;
                weatherResponse.CustomWeatherData.Add(customWeatherData);
            }

            return weatherResponse;
        }

    }


}
