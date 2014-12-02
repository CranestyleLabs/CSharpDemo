using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherClientDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            string city = "";
            WeatherService.WeatherServiceClient client = new WeatherService.WeatherServiceClient();

            Console.Write("Enter city name for current weather : ");
            city = Console.ReadLine();
            WeatherService.Weather weather = client.GetWeather(city);

            if (weather != null)
            {
                Console.WriteLine("Weather for city : {0}", weather.name);
                Console.WriteLine("Temperature : {0}", weather.main.temp);
                Console.WriteLine("Presure : {0}", weather.main.pressure);
                Console.WriteLine("Humidity : {0}", weather.main.humidity);
            } 
            else
            {
                Console.WriteLine("City Not Found");
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }
}