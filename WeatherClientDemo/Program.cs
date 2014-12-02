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
            ServiceReference1.WeatherServiceClient client = new ServiceReference1.WeatherServiceClient();
            ServiceReference1.Weather weather = client.GetWeather("test");
            
            Console.WriteLine("Weather for city : {0}", weather.name);
            Console.WriteLine("Temperature : {0}", weather.main.temp);
            Console.WriteLine("Presure : {0}", weather.main.pressure);
            Console.WriteLine("Humidity : {0}", weather.main.humidity);
            Console.ReadKey();
        }
    }
}