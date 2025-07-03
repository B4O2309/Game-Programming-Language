using LAB11.Models;
using LAB11.Services;

namespace LAB11.LINQ
{
    public class Bai1
    {
        public async Task Run(List<Player> players, FirebaseService firebase)
        {
            var richPlayers = players
                .Where(p => p.Gold > 1000 && p.Coins > 100)
                .OrderByDescending(p => p.Gold)
                .Select(p => new { p.Name, p.Gold, p.Coins })
                .ToList();

            Console.WriteLine("\n=== Rich Players ===");
            foreach (var p in richPlayers)
                Console.WriteLine($"{p.Name} - Gold: {p.Gold}, Coins: {p.Coins}");

            await firebase.PushDataAsync(richPlayers, "quiz_bai1_richPlayers");
        }
    }
}
