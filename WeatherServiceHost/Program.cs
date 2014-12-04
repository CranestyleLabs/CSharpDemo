using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using WeatherService;


namespace WeatherServiceHost
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create Service Host
            using(ServiceHost host = new ServiceHost(typeof(WeatherService.WeatherService)))
            {
                // Start Service
                host.Open();
                Console.WriteLine("Host Started at {0}", DateTime.Now);
                Console.ReadKey();
            } 
        }
    }
}
