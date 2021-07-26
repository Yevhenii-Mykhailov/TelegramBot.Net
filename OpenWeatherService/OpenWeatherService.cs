using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace TelegramBot
{
    public class OpenWeatherService
    { 

        private const string APIKEY = "19e61cb7f95ce780f94c2f1eeae6f4ec";
        private const string CITY = "Kyiv";

        private readonly HttpClient client = new HttpClient();
        private string URL = $"https://api.openweathermap.org/data/2.5/weather?q={CITY}&appid={APIKEY}";
                
        public async Task<OpenWeatherModel> GetWeatherModelAsync()
        {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));
            client.DefaultRequestHeaders.Add("User-Agent", ".NET Foundation Repository Reporter");
            
            var responce = await client.GetAsync(URL);
            string responceBody = await responce.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<OpenWeatherModel>(responceBody);

        }

    }
}
