using System;
using Telegram.Bot;
using Telegram.Bot.Args;
using TelegramBot.CustomControls;

namespace TelegramBot
{
    public class Program : BotHelper
    {
        
        [Obsolete]
        static void Main()
        {
            BotClient = new TelegramBotClient("940637130:AAF1jHlCTBr3s0_4J9-OG_A6cMboOMHM4BE");

            
            BotClient.OnMessage += GetUserLocation;
            BotClient.OnMessage += SendUserFullName;
                      
            BotClient.StartReceiving();
            Console.ReadLine();
                        
        }

        
        [Obsolete]
        private static async void GetUserLocation(object sender, MessageEventArgs e)
        {

            if (e.Message.Location != null)
            {
                string userLatitude = Convert.ToString(e.Message.Location.Latitude);
                string userLongitude = Convert.ToString(e.Message.Location.Longitude);

                await BotClient.SendTextMessageAsync(
                chatId: e.Message.Chat,
                text: $"Your Location is: Latitude:{userLatitude}; Longitude:{userLongitude}"
                );
            }
        }

        [Obsolete]
        public static async void SendUserFullName(object sender, MessageEventArgs e)
        {
            string userFirstName = e.Message.From.FirstName;
            string userLastName = e.Message.From.LastName;

            if (e.Message.Text != null)
            {
                await BotClient.SendTextMessageAsync(
                chatId: e.Message.Chat,
                text: $"Your name is {userFirstName} {userLastName}"
                );
            }
        }

    }
}
