using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace TelegramBot
{
    public class OpenWeatherModel
    {
        public Coordinates Coord { get; set; }
        public List<WeatherItem> Weather { get; set; }
        public string Base { get; set; }
        public MainInfo Main { get; set; }
        public int Visibility { get; set; }
        public WindInfo Wind { get; set; }
        public CloudsInfo Clouds { get; set; }
        public int Dt { get; set; }
        public SystemInfo Sys { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public int Cod { get; set; }
                
    }

    public class Coordinates
    {
        public double Lon { get; set; }
        public double Lat { get; set; }
    }

    public class WeatherItem
    {
        public int Id { get; set; }
        public string Main { get; set; }
        public string Description { get; set; }
        public string Icon { get; set; }
    }

    public class MainInfo
    {
        public double Temp { get; set; }

        [JsonPropertyName("feels_like")]
        public double FeelsLike { get; set; }

        [JsonPropertyName("temp_min")]
        public double TempMin { get; set; }

        [JsonPropertyName("temp_max")]
        public double TempMax { get; set; }
        public int Pressure { get; set; }
        public int Humidity { get; set; }

    }
    public class WindInfo
    {
        public double Speed { get; set; }
        public double Deg { get; set; }
    }
    public class CloudsInfo
    {
        public int All { get; set; }
    }
    public class SystemInfo
    {
        public int Type { get; set; }
        public int Id { get; set; }
        public double Message { get; set; }
        public string Country { get; set; }
        public int Sunrise { get; set; }
        public int Sunset { get; set; }

    }

}
