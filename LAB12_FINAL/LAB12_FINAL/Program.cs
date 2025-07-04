using System;
using System.Threading.Tasks;
using LAB12_FINAL.Services;
using LAB12_FINAL;
using System.Text;

namespace LAB12_FINAL
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            var playerService = new PlayerService();
            var firebase = new FirebaseUploader();

            var players = await playerService.GetPlayersAsync();

            // Bài 1.1: Người chơi không hoạt động + Level thấp
            var inactive = playerService.GetInactiveLowLevel(players);
            Console.WriteLine("\n=== Người chơi không hoạt động + Level < 9 ===");
            foreach (var kv in inactive)
            {
                dynamic p = kv.Value;
                Console.WriteLine($"Tên: {p.Name}, IsActive: {p.IsActive}, Level: {p.Level}, LastLogin: {p.LastLogin}");
            }
            await firebase.PushDataAsync("inactive_lowlevel_players", inactive);

            // Bài 1.2: Người chơi giàu và Level cao
            var rich = playerService.GetHighLevelRich(players);
            Console.WriteLine("\n=== Người chơi cấp cao + Giàu ===");
            foreach (var kv in rich)
            {
               dynamic p = kv.Value;
                Console.WriteLine($"Tên: {p.Name}, Level: {p.Level}, Gold: {p.Gold}");
            }
            await firebase.PushDataAsync("highlevel_rich_players", rich);

            // Bài 2: Top 3 người chơi hoạt động được thưởng
            var top3 = playerService.GetTop3ActiveReward(players);
            Console.WriteLine("\n=== Top 3 người chơi hoạt động tích cực ===");
            foreach (var kv in top3)
            {
                dynamic p = kv.Value;
                Console.WriteLine($"[Hạng {kv.Key}] Tên: {p.Name}, Level: {p.Level}, Coins: {p.Coins}, Thưởng: {p.Reward}");
            }
            await firebase.PushDataAsync("top3_active_coin_awards", top3);
        }
    }
}
