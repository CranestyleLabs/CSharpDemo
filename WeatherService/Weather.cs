using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace WeatherService
{
    [DataContract]
    public class Weather
    {
        [DataMember(Name = "Base")]
        [JsonProperty(PropertyName = "base")]
        public string Base { get; set; }
        [DataMember(Name = "Cloud")]
        [JsonProperty(PropertyName = "clouds")]
        public Clouds Clouds { get; set; }
        [DataMember(Name = "StatusCode")]
        [JsonProperty(PropertyName = "cod")]
        public int StatusCode { get; set; }
        [DataMember(Name = "Coord")]
        [JsonProperty(PropertyName = "coord")]
        public Coord Coord { get; set; }
        [DataMember(Name = "Dt")]
        [JsonProperty(PropertyName = "dt")]
        public int Dt { get; set; }
        [DataMember(Name = "ID")]
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }
        [DataMember(Name = "Main")]
        [JsonProperty(PropertyName = "main")]
        public Main Main { get; set; }
        [DataMember(Name = "Name")]
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
        [DataMember(Name = "Sys")]
        [JsonProperty(PropertyName = "sys")]
        public Sys Sys { get; set; }
        [DataMember(Name = "Infos")]
        [JsonProperty(PropertyName = "weather")]
        public List<Info> Infos { get; set; }
        [DataMember(Name = "Wind")]
        [JsonProperty(PropertyName = "wind")]
        public Wind Wind { get; set; }
    }

    [DataContract]
    public class Coord
    {
        [DataMember(Name = "Lat")]
        [JsonProperty(PropertyName = "lan")]
        public double Lat { get; set; }
        [DataMember(Name = "Lon")]
        [JsonProperty(PropertyName = "lon")]
        public double Lon { get; set; }
    }

    [DataContract]
    public class Main
    {
        [DataMember(Name = "Temp")]
        [JsonProperty(PropertyName = "temp")]
        public double Temp { get; set; }
        [DataMember(Name = "Pressure")]
        [JsonProperty(PropertyName = "pressure")]
        public int Pressure { get; set; }
        [DataMember(Name = "Humidity")]
        [JsonProperty(PropertyName = "humidity")]
        public int Humidity { get; set; }
        [DataMember(Name = "Temp_min")]
        [JsonProperty(PropertyName = "temp_min")]
        public double Temp_min { get; set; }
        [DataMember(Name = "Temp_max")]
        [JsonProperty(PropertyName = "temp_max")]
        public double Temp_max { get; set; }
    }

    [DataContract]
    public class Sys
    {
        [DataMember(Name = "ID")]
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }
        [DataMember(Name = "Message")]
        [JsonProperty(PropertyName = "message")]
        public double Message { get; set; }
        [DataMember(Name = "Country")]
        [JsonProperty(PropertyName = "country")]
        public string Country { get; set; }
        [DataMember(Name = "Sunrise")]
        [JsonProperty(PropertyName = "sunrise")]
        public int Sunrise { get; set; }
        [DataMember(Name = "Sunset")]
        [JsonProperty(PropertyName = "sunset")]
        public int Sunset { get; set; }
        [DataMember(Name = "Type")]
        [JsonProperty(PropertyName = "type")]
        public int Type { get; set; }
    }

    [DataContract]
    public class Info
    {
        [DataMember(Name = "Description")]
        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }
        [DataMember(Name = "Icon")]
        [JsonProperty(PropertyName = "icon")]
        public string Icon { get; set; }
        [DataMember(Name = "Id")]
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }
        [DataMember(Name = "Main")]
        [JsonProperty(PropertyName = "main")]
        public string Main { get; set; }
    }

    [DataContract]
    public class Wind
    {
        [DataMember(Name = "Speed")]
        [JsonProperty(PropertyName = "speed")]
        public double Speed { get; set; }
        [DataMember(Name = "Deg")]
        [JsonProperty(PropertyName = "deg")]
        public double Deg { get; set; }
    }

    [DataContract]
    public class Clouds
    {
        [DataMember(Name = "All")]
        [JsonProperty(PropertyName = "all")]
        public int All { get; set; }
    }

}
