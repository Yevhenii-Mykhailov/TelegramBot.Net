using System;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Extensions.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using TelegramBot;
using TelegramBot.BotControls;

namespace TelegramBots
{
    public class Program : BotHelper
    {

        public static async Task Main()
        {
            OpenWeatherService openWeatherService = new();
            Configuration configs = new();
            BotClient = new TelegramBotClient(configs.BotKey);
            BotCommands botCommands = new BotCommands();
            using var cts = new CancellationTokenSource();

            var receiverOptions = new ReceiverOptions
            {
                AllowedUpdates = { } // receive all update types
            };

            BotClient.StartReceiving(
                HandleUpdateAsync,
                HandleErrorAsync,
                receiverOptions,
                cancellationToken: cts.Token);

            var me = await BotClient.GetMeAsync();
            Console.ReadLine();

            cts.Cancel();

            async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
            {
                var weatherModel = await openWeatherService.GetWeatherModelAsyncByCityName(update.Message.Text);

                int responceCode = weatherModel.Cod;

                if (update.Type != UpdateType.Message)
                    return;

                if (update.Message!.Type != MessageType.Text)
                    return;

                var chatId = update.Message.Chat.Id;
                var messageText = update.Message.Text;

                // Echo received message text
                Message sentMessage = await botClient.SendTextMessageAsync(
                    chatId: chatId,
                    text: "Requested city: " + messageText,
                    cancellationToken: cancellationToken
                    );

                if (messageText == "/start")
                {
                    await BotClient.SendTextMessageAsync(
                    chatId: chatId,
                    text: $"Hello, I am weather bot. Let's rock! Type city name and I will show you temperature :)"
                    );
                }

                else if (responceCode == 200)
                {
                    double currentTemperature = Math.Round(weatherModel.Main.Temp);
                    string currentClouds = weatherModel.Weather[0].Description;
                    double windSpeed = Math.Round(weatherModel.Wind.Speed);

                    await BotClient.SendTextMessageAsync(
                    chatId: chatId,
                    text: $"Temperature in {messageText} is {currentTemperature}°С \n\n" +
                          $"There is {currentClouds} \n\n" +
                          $"Wind speed is {windSpeed}m/s \n\n"
                    );
                }
                else
                {
                    await BotClient.SendTextMessageAsync(
                    chatId: chatId,
                    text: $"Wrong City Name. Try againe"
                    );
                }
            }

            Task HandleErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
            {
                var ErrorMessage = exception switch
                {
                    ApiRequestException apiRequestException
                        => $"Telegram API Error:\n[{apiRequestException.ErrorCode}]\n{apiRequestException.Message}",
                    _ => exception.ToString()
                };

                Console.WriteLine(ErrorMessage);
                return Task.CompletedTask;
            }
        }
    }
}
