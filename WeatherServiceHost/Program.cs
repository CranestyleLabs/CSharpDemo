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
            using(ServiceHost host = new ServiceHost(typeof(WeatherService.WeatherService)))
            {
                host.Open();
                Console.WriteLine("Host Started at {0}", DateTime.Now);
                Console.ReadKey();
            } 
        }
    }
}
