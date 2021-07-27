using System;
using System.Threading.Tasks;
using Telegram.Bot;
using TelegramBot;
using TelegramBot.BotControls;

namespace TelegramBots
{
    public class Program : BotHelper
    {
        
        [Obsolete]
        public static async Task Main()
        {
            OpenWeatherService openWeatherService = new OpenWeatherService();
            Configs configs = new Configs();

            BotClient = new TelegramBotClient(configs.BotKey);
            BotCommands botCommands = new BotCommands();

            try
            {
                var model = await openWeatherService.GetWeatherModelAsync();
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
