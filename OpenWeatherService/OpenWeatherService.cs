using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace TelegramBot
{
    public class OpenWeatherService : Configs
    {
        private const string CITY = "Kobrin";

        private readonly HttpClient client = new HttpClient();
        
        public async Task<OpenWeatherModel> GetWeatherModelAsync()
        {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));
            client.DefaultRequestHeaders.Add("User-Agent", ".NET Foundation Repository Reporter");
            
            var responce = await client.GetAsync(getOpenWeatherUrl(CITY, ApiKey));
            string responceBody = await responce.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<OpenWeatherModel>(responceBody);

        }


    }
}
