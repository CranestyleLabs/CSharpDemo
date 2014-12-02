using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;

namespace WeatherService
{
    [DataContract]
    public class Response
    {
        [DataMember(Name = "base")]
        public string Base { get; set; }
        [DataMember(Name = "clouds")]
        public Clouds Clouds { get; set; }
        [DataMember(Name = "cod")]
        public int StatusCode { get; set; }
        [DataMember(Name = "coord")]
        public Coord Coord { get; set; }
        [DataMember(Name = "id")]
        public int Id { get; set; }
        [DataMember(Name = "main")]
        public Main Main { get; set; }
        [DataMember(Name = "name")]
        public string Name { get; set; }
        [DataMember(Name = "sys")]
        public Sys Sys { get; set; }
        [DataMember(Name = "weather")]
        public List<Weather> Weathers { get; set; }
        [DataMember(Name = "wind")]
        public Wind Wind { get; set; }
        [DataMember(Name = "dt")]
        public int Dt { get; set; }
    }

    [DataContract]
    public class Coord
    {
        [DataMember(Name = "lat")]
        public double Lat { get; set; }
        [DataMember(Name = "lon")]
        public double Lon { get; set; }
    }

    [DataContract]
    public class Main
    {
        [DataMember(Name = "temp")]
        public double Temp { get; set; }
        [DataMember(Name = "pressure")]
        public int Pressure { get; set; }
        [DataMember(Name = "humidity")]
        public int Humidity { get; set; }
        [DataMember(Name = "temp_min")]
        public double Temp_min { get; set; }
        [DataMember(Name = "temp_max")]
        public double Temp_max { get; set; }
    }

    [DataContract]
    public class Sys
    {
        [DataMember(Name = "id")]
        public int Id { get; set; }
        [DataMember(Name = "message")]
        public double Message { get; set; }
        [DataMember(Name = "country")]
        public string Country { get; set; }
        [DataMember(Name = "sunrise")]
        public int Sunrise { get; set; }
        [DataMember(Name = "sunset")]
        public int Sunset { get; set; }
        [DataMember(Name = "type")]
        public int Type { get; set; }

    }

    [DataContract]
    public class Weather
    {
        [DataMember(Name = "description")]
        public string Description { get; set; }
        [DataMember(Name = "icon")]
        public string Icon { get; set; }
        [DataMember(Name = "id")]
        public int Id { get; set; }
        [DataMember(Name = "main")]
        public string Main { get; set; }
    }

    [DataContract]
    public class Wind
    {
        [DataMember(Name = "speed")]
        public double Speed { get; set; }
        [DataMember(Name = "deg")]
        public double Deg { get; set; }
    }

    [DataContract]
    public class Clouds
    {
        [DataMember(Name = "all")]
        public int All { get; set; }
    }

}
