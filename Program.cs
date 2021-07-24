using System;
using Telegram.Bot;
using TelegramBot.CustomControls;

namespace TelegramBot
{
    class Program : BotHelper
    {

        [Obsolete]
        static void Main()
        {
            BotClient = new TelegramBotClient("940637130:AAF1jHlCTBr3s0_4J9-OG_A6cMboOMHM4BE");
            BotCommands botCommands = new BotCommands();

            try
            {
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
