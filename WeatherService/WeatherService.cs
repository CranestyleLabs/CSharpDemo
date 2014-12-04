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
        /// <summary>
        ///   Gets a Weather object for current weather based on the search location.  
        ///   Search query can be city, city + state or zipcode.
        ///   Example for search location:
        ///     Oakland, CA
        ///     94105
        ///     san francisco
        /// </summary>
        /// <param name="location">The query to be search in the API</param>
        /// <returns>The Weather Object</returns>
        public Weather GetWeather(string location)
        {
            string requestUrl = CreateRequest(location);
            Weather response = MakeRequestJsonDotNet(requestUrl);
            return response;
        }

        /// <summary>
        ///   Create the request URL for a specified location by combining the base API URL and search query.
        /// </summary>
        /// <param name="city">Any city name or city name + state or zipcode</param>
        /// <returns>Request Url to the API</returns>
        public string CreateRequest(string city)
        {
            return "http://api.openweathermap.org/data/2.5/weather?q=" + city;
        }

        /// <summary>
        ///   Returns a Weather object of the specified request API URL.
        /// </summary>
        /// <param name="requestUrl">Request URL to the API</param>
        /// <returns>Weather Object</returns>

        public Weather MakeRequestJsonDotNet(string requestUrl)
        {
            try 
            {
                using(WebClient client = new WebClient())
                {
                    // get json string from api url
                    string jsonStr = client.DownloadString(requestUrl);

                    // Deserialize json string to Weather object.
                    Weather weather = JsonConvert.DeserializeObject<Weather>(jsonStr);

                    // check status code 404 for invalid city
                    if (weather.StatusCode == 404)
                        return null;
                    else
                        return weather;
                }
            }
            catch(WebException e)
            {
                throw new FaultException(e.Message);
            }
        }


        /// <summary>
        ///   Returns a Weather object of the specified request API URL.
        /// </summary>
        /// <param name="requestUrl">Request URL to the API</param>
        /// <returns>Weather Object</returns>


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
