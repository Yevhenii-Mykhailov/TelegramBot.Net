using System;
using System.Threading.Tasks;
using Telegram.Bot;
using TelegramBot.CustomControls;

namespace TelegramBot
{
    public class Program : BotHelper
    {
        
        [Obsolete]
        public static async Task Main()
        {
            OpenWeatherService openWeatherService = new OpenWeatherService();

            BotClient = new TelegramBotClient("940637130:AAF1jHlCTBr3s0_4J9-OG_A6cMboOMHM4BE");
            BotCommands botCommands = new BotCommands();

            try
            {
                var model = await openWeatherService.GetWeatherModelAsync();
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
