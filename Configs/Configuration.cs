﻿namespace TelegramBot
{
    public class Configuration
    {
        public string BotKey = "940637130:AAF1jHlCTBr3s0_4J9-OG_A6cMboOMHM4BE";
        public string ApiKey = "19e61cb7f95ce780f94c2f1eeae6f4ec";

        public static string GetOpenWeatherUrl(string city, string apiKey)
        {
            return $"https://api.openweathermap.org/data/2.5/weather?q={city}&appid={apiKey}&units=metric";
        }
    }
}
