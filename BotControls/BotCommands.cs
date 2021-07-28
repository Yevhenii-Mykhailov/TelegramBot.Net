using System;
using Telegram.Bot.Args;
using TelegramBot.BotControls;

namespace TelegramBot
{
    public class BotCommands : BotHelper
    {
        readonly OpenWeatherService openWeatherService = new();

        [Obsolete]
        public async void SendRequestedWeather(object sender, MessageEventArgs e)
        {
            var weatherModel = await openWeatherService.GetWeatherModelAsyncByCityName(e.Message.Text);

            Console.WriteLine(e.Message.Text);

            if (e.Message.Text == "/start")
            {
                await BotClient.SendTextMessageAsync(
                chatId: e.Message.Chat,
                text: $"Hello, I am weather bot. Let's rock! Type city name and I will show you temperature :)"
                );
            }

            else if (weatherModel.Cod == 200)
            {
                
               await BotClient.SendTextMessageAsync(
                chatId: e.Message.Chat,
                text: $"Temperature in {e.Message.Text} is {weatherModel.Main.Temp} in celsius"
                );
            }
            else
            {
                await BotClient.SendTextMessageAsync(
                chatId: e.Message.Chat,
                text: $"Wrong City Name. Try againe"
                );
            }
        }

    }
}
