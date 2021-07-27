using System;
using System.Threading.Tasks;
using Telegram.Bot;
using TelegramBot.CustomControls;

namespace TelegramBot
{
    public class Program : BotHelper
    {
        private const string APIKEY = "19e61cb7f95ce780f94c2f1eeae6f4ec";
        private const string CITY = "Kobrin";
        private string URL = $"https://api.openweathermap.org/data/2.5/weather?q={CITY}&appid={APIKEY}";

        [Obsolete]
        public static async Task Main()
        {
            OpenWeatherService openWeatherService = new OpenWeatherService();

            BotClient = new TelegramBotClient("940637130:AAF1jHlCTBr3s0_4J9-OG_A6cMboOMHM4BE");
            BotCommands botCommands = new BotCommands();

            try
            {
                var model = await openWeatherService.GetWeatherModelAsync(URL);
                Console.WriteLine(model);
                BotClient.OnMessage += botCommands.SendUserLocation;
                BotClient.OnMessage += botCommands.SendUserFullName;
                BotClient.StartReceiving();
                Console.ReadLine();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

        }   

    }

}
