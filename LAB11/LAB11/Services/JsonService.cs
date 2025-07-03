using System.Net.Http;
using Newtonsoft.Json;
using LAB11.Models;

namespace LAB11.Services
{
    public class JsonService
    {
        public async Task<List<Player>> LoadPlayersAsync(string url)
        {
            using HttpClient client = new HttpClient();
            string json = await client.GetStringAsync(url);
            return JsonConvert.DeserializeObject<List<Player>>(json);
        }
    }
}
