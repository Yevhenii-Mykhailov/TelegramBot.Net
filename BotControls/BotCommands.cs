using System;
using System.Net.Http;
using System.Net.Http.Headers;
using Telegram.Bot.Args;
using TelegramBot.BotControls;

namespace TelegramBot
{
    public class BotCommands : BotHelper
    {
        readonly OpenWeatherService openWeatherService = new();
        public readonly HttpClient client = new();

        [ObsoleteAttribute("This property is obsolete and will be removed", false)]
        public async void SendRequestedWeather(object sender, MessageEventArgs e)
        {
            var weatherModel = await openWeatherService.GetWeatherModelAsyncByCityName(e.Message.Text);

            string userMessage = e.Message.Text;
            int responceCode = weatherModel.Cod;
            
            Console.WriteLine(userMessage);

            if (userMessage == "/start")
            {
                await BotClient.SendTextMessageAsync(
                chatId: e.Message.Chat,
                text: $"Hello, I am weather bot. Let's rock! Type city name and I will show you temperature :)"
                );
            }

            else if (responceCode == 200)
            {
                double currentTemperature = Math.Round(weatherModel.Main.Temp);
                string currentClouds = weatherModel.Weather[0].Description;
                double windSpeed = Math.Round(weatherModel.Wind.Speed);

                //string iconCode = weatherModel.Weather[0].Icon;
                //string weatherIconUrl = $"http://openweathermap.org/img/wn/{iconCode}.png";

                await BotClient.SendTextMessageAsync(
                chatId: e.Message.Chat,
                text: $"Temperature in {userMessage} is {currentTemperature}°С \n\n" +
                      $"There is {currentClouds} \n\n" +
                      $"Wind speed is {windSpeed}m/s \n\n"
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
