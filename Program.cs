using System;
using Telegram.Bot;
using TelegramBot;
using TelegramBot.BotControls;

namespace TelegramBots
{
    public class Program : BotHelper
    {

        [Obsolete]
        public static void Main()
        {
            Configuration configs = new();

            BotClient = new TelegramBotClient(configs.BotKey);
            BotCommands botCommands = new();

            try
            {
                BotClient.OnMessage += botCommands.SendRequestedWeather;
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
