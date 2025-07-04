using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using LAB12_FINAL;

namespace LAB12_FINAL.Services
{
    public class PlayerService
    {
        private readonly string dataUrl = "https://raw.githubusercontent.com/NTH-VTC/OnlineDemoC-/refs/heads/main/lab12_players.json";
        private readonly DateTime now = new DateTime(2025, 07, 01, 0, 0, 0, DateTimeKind.Utc);

        public async Task<List<Player>> GetPlayersAsync()
        {
            using HttpClient client = new HttpClient();
            string json = await client.GetStringAsync(dataUrl);
            return JsonConvert.DeserializeObject<List<Player>>(json);
        }

        public Dictionary<int, Player> GetInactiveLowLevel(List<Player> players)
        {
            return players
                .Where(p => (!p.IsActive || (now - p.LastLogin).TotalDays > 10) && p.Level <= 8)
                .Select((p, index) => new KeyValuePair<int, Player>(index + 1, p))
                .ToDictionary(kv => kv.Key, kv => kv.Value);
        }

        public Dictionary<int, Player> GetHighLevelRich(List<Player> players)
        {
            return players
                .Where(p => p.Level >= 12 && p.Gold > 2000)
                .Select((p, index) => new KeyValuePair<int, Player>(index + 1, p))
                .ToDictionary(kv => kv.Key, kv => kv.Value);
        }

        public Dictionary<int, object> GetTop3ActiveReward(List<Player> players)
        {
            return players
                .Where(p => p.IsActive && (now - p.LastLogin).TotalDays <= 3)
                .OrderByDescending(p => p.Coins)
                .Take(3)
                .Select((p, index) => new
                {
                    p.Name,
                    p.Level,
                    p.Coins,
                    Rank = index + 1,
                    Reward = (index + 1) switch
                    {
                        1 => 3000,
                        2 => 2000,
                        3 => 1000,
                        _ => 0
                    }
                })
                .Select(p => new KeyValuePair<int, object>(p.Rank, p))
                .ToDictionary(kv => kv.Key, kv => kv.Value);
        }

    }
}
