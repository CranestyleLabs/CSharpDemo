using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Net;
using System.Runtime.Serialization.Json;

namespace WeatherService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "WeatherService" in both code and config file together.
    public class WeatherService : IWeatherService
    {
        public Weather GetWeather(string city)
        {
            string requestUrl = @"http://api.openweathermap.org/data/2.5/weather?q=San%20francisco";
            Weather response = MakeRequest(requestUrl);
            return response;
        }

        public static Weather MakeRequest(string requestUrl)
        {
            try
            {
                HttpWebRequest request = HttpWebRequest.Create(requestUrl) as HttpWebRequest;
                using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
                {
                    if (response.StatusCode != HttpStatusCode.OK)
                        throw new Exception(String.Format("Server error {0}.", response.StatusCode));
                    DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(Weather));
                    object objResponse = jsonSerializer.ReadObject(response.GetResponseStream());
                    Weather jsonResponse = objResponse as Weather;
                    return jsonResponse;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("lalala");
                Console.WriteLine(e.Message);
                return null;
            }
        }
    }
}
