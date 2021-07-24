using System;
using Telegram.Bot.Args;
using TelegramBot.CustomControls;

namespace TelegramBot
{
    public class BotCommands : BotHelper
    {
        [Obsolete]
        public void SendUserLocation(object sender, MessageEventArgs e)
        {

            if (e.Message.Location != null)
            {
                string userLatitude = Convert.ToString(e.Message.Location.Latitude);
                string userLongitude = Convert.ToString(e.Message.Location.Longitude);

                BotClient.SendTextMessageAsync(
                chatId: e.Message.Chat,
                text: $"Your Location is: Latitude:{userLatitude}; Longitude:{userLongitude}"
                );
            }
        }

        [Obsolete]
        public void SendUserFullName(object sender, MessageEventArgs e)
        {
            string userFirstName = e.Message.From.FirstName;
            string userLastName = e.Message.From.LastName;

            if (e.Message.Text != null)
            {
                BotClient.SendTextMessageAsync(
                chatId: e.Message.Chat,
                text: $"Your name is {userFirstName} {userLastName}"
                );
            }
        }

    }
}
