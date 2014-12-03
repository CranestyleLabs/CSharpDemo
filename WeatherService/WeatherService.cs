using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Net;
using System.Runtime.Serialization.Json;
using Newtonsoft.Json;

namespace WeatherService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "WeatherService" in both code and config file together.
    public class WeatherService : IWeatherService
    {
        public Weather GetWeather(string city)
        {
            string requestUrl = CreateRequest(city);
            //Weather response = MakeRequest(requestUrl);
            Weather response = MakeRequestJsonDotNet(requestUrl);
            return response;
        }

        public string CreateRequest(string city)
        {
            return "http://api.openweathermap.org/data/2.5/weather?q=" + city;
        }

        public Weather MakeRequestJsonDotNet(string requestUrl)
        {
            try { 
                using(WebClient client = new WebClient())
                {
                    string jsonStr = client.DownloadString(requestUrl);
                    Weather weather = JsonConvert.DeserializeObject<Weather>(jsonStr);
                    if (weather.StatusCode == 404)
                        throw new FaultException("City Not Found");
                    else
                        return weather;
                }
            }
            catch(WebException e)
            {
                throw new FaultException(e.Message);
            }
        }

        public Weather MakeRequest(string requestUrl)
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

                    if (jsonResponse.StatusCode == 404)
                        throw new Exception(String.Format("City Not Found"));
                    else
                        return jsonResponse;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }
    }
}
