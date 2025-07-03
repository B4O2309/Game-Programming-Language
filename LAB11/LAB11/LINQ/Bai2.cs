using LAB11.Models;
using LAB11.Services;

namespace LAB11.LINQ
{
    public class Bai2
    {
        public async Task Run(List<Player> players, FirebaseService firebase)
        {
            Console.WriteLine("\n=== Tổng số VIP ===");
            Console.WriteLine(players.Count(p => p.VipLevel > 0));

            Console.WriteLine("\n=== Số lượng VIP theo khu vực ===");
            var grouped = players
                .Where(p => p.VipLevel > 0)
                .GroupBy(p => p.Region)
                .Select(g => new { Region = g.Key, Count = g.Count() });

            foreach (var g in grouped)
                Console.WriteLine($"Region: {g.Region} - VIPs: {g.Count}");

            DateTime now = new DateTime(2025, 06, 30);

            var recentVip = players
                .Where(p => p.VipLevel > 0 && (now - p.LastLogin).TotalDays <= 2)
                .Select(p => new { p.Name, p.VipLevel, p.LastLogin })
                .ToList();

            Console.WriteLine("\n=== VIP Đăng nhập gần đây ===");
            foreach (var p in recentVip)
                Console.WriteLine($"{p.Name} - VIP: {p.VipLevel} - LastLogin: {p.LastLogin}");

            await firebase.PushDataAsync(recentVip, "quiz_bai2_recentVipPlayers");
        }
    }
}
