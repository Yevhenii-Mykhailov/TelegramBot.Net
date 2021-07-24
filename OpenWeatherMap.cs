using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace TelegramBot
{
    public class OpenWeatherMap
    {
        private const string APIKEY = "19e61cb7f95ce780f94c2f1eeae6f4ec";
        private const string CITY = "Kyiv";

        private static readonly HttpClient client = new HttpClient();
        private static string URL = $"https://api.openweathermap.org/data/2.5/weather?q={CITY}&appid={APIKEY}";

        static async Task Main(string[] args)
        {
            await ProcessRepositories();
        }

        private static async Task ProcessRepositories()
        {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));
            client.DefaultRequestHeaders.Add("User-Agent", ".NET Foundation Repository Reporter");

            var stringTask = client.GetStringAsync(URL);
            

            var msg = await stringTask;
            
            Console.Write(msg);
        }
    }
}
