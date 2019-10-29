using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net.Http.Headers;

using Newtonsoft.Json;

using PASSCloudMobileBot.Helpers;

namespace PASSCloudMobileBot.Services
{
    public static class BotService
    {
        public static async Task<string> GetToken()
        {
            var token = string.Empty;

            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("BotConnector", Constants.WebChatKey);

                var url = new Uri("https://webchat.botframework.com/api/tokens");
                var response = await client.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    token = JsonConvert.DeserializeObject<string>(content);
                }
            }

            return token;
        }
    }
}