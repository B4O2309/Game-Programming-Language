using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Firebase.Database;
using Firebase.Database.Query;
using FirebaseAdmin;
using Google.Apis.Auth.OAuth2;

namespace FirebasePlayerManager
{
    public class Player
    {
        public string PlayerID { get; set; }
        public string Name { get; set; }
        public int Gold { get; set; }
        public int Score { get; set; }
        public string Timestamp { get; set; }
    }

    internal class Program
    {
        static FirebaseClient firebase = new FirebaseClient("https://fir-b415c-default-rtdb.asia-southeast1.firebasedatabase.app/");

        static async Task Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            FirebaseApp.Create(new AppOptions()
            {
                Credential = GoogleCredential.FromFile("serviceAccountKey.json")
            });

            Console.WriteLine("Firebase connected. Starting operations...");

            await AddPlayers();
            await DisplayPlayers();
            await UpdatePlayer("player3", gold: 999);
            await DeletePlayer("player10");
            await ShowTopGoldPlayers();
            await SaveTopScorePlayers();
        }

        public static async Task AddPlayers()
        {
            var players = new List<Player>
            {
                new Player { PlayerID = "player1", Name = "Alice", Gold = 300, Score = 550, Timestamp = DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss") },
                new Player { PlayerID = "player2", Name = "Bob", Gold = 450, Score = 600, Timestamp = DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss") },
                new Player { PlayerID = "player3", Name = "Charlie", Gold = 200, Score = 700, Timestamp = DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss") },
                new Player { PlayerID = "player4", Name = "David", Gold = 700, Score = 300, Timestamp = DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss") },
                new Player { PlayerID = "player5", Name = "Eva", Gold = 1000, Score = 950, Timestamp = DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss") },
                new Player { PlayerID = "player6", Name = "Frank", Gold = 150, Score = 400, Timestamp = DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss") },
                new Player { PlayerID = "player7", Name = "Grace", Gold = 800, Score = 500, Timestamp = DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss") },
                new Player { PlayerID = "player8", Name = "Hannah", Gold = 350, Score = 650, Timestamp = DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss") },
                new Player { PlayerID = "player9", Name = "Ivy", Gold = 900, Score = 750, Timestamp = DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss") },
                new Player { PlayerID = "player10", Name = "Jack", Gold = 100, Score = 200, Timestamp = DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss") }
            };

            foreach (var player in players)
            {
                await firebase.Child("Players").Child(player.PlayerID).PutAsync(player);
            }
            Console.WriteLine("10 players added.\n");
        }

        public static async Task DisplayPlayers()
        {
            var players = await firebase.Child("Players").OnceAsync<Player>();
            Console.WriteLine("All Players:");
            foreach (var p in players)
            {
                var player = p.Object;
                Console.WriteLine($"{player.PlayerID}: {player.Name}, Gold: {player.Gold}, Score: {player.Score}, Timestamp: {player.Timestamp}");
            }
        }

        public static async Task UpdatePlayer(string playerId, int? gold = null, int? score = null)
        {
            var player = await firebase.Child("Players").Child(playerId).OnceSingleAsync<Player>();
            if (player != null)
            {
                if (gold != null) player.Gold = gold.Value;
                if (score != null) player.Score = score.Value;
                player.Timestamp = DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss");
                await firebase.Child("Players").Child(playerId).PutAsync(player);
                Console.WriteLine($"\nUpdated {playerId}\n");
            }
        }

        public static async Task DeletePlayer(string playerId)
        {
            await firebase.Child("Players").Child(playerId).DeleteAsync();
            Console.WriteLine($"Deleted {playerId}\n");
        }

        public static async Task ShowTopGoldPlayers()
        {
            var players = (await firebase.Child("Players").OnceAsync<Player>()).Select(p => p.Object).ToList();
            var topGold = players.OrderByDescending(p => p.Gold).Take(5);
            Console.WriteLine("Top 5 Gold Players:");
            foreach (var p in topGold)
            {
                Console.WriteLine($"{p.Name} - Gold: {p.Gold}");
            }
        }

        public static async Task SaveTopScorePlayers()
        {
            var players = (await firebase.Child("Players").OnceAsync<Player>()).Select(p => p.Object).ToList();
            var topScore = players.OrderByDescending(p => p.Score).Take(5).ToList();
            for (int i = 0; i < topScore.Count; i++)
            {
                topScore[i].Timestamp = DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss");
                await firebase.Child("TopScore").Child((i + 1).ToString()).PutAsync(topScore[i]);
            }
            Console.WriteLine("\nTopScore saved to Firebase.");
        }
    }
}
