using LAB11.Models;
using LAB11.Services;
using LAB11.LINQ;
using System.Text;

class Program
{
    static async Task Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;
        var jsonUrl = "https://raw.githubusercontent.com/NTH-VTC/OnlineDemoC-/main/simple_players.json";
        var firebaseUrl = "https://lab11-linq-default-rtdb.asia-southeast1.firebasedatabase.app/";

        JsonService jsonService = new JsonService();
        FirebaseService firebaseService = new FirebaseService(firebaseUrl);

        List<Player> players = await jsonService.LoadPlayersAsync(jsonUrl);

        Bai1 bai1 = new Bai1();
        await bai1.Run(players, firebaseService);

        Bai2 bai2 = new Bai2();
        await bai2.Run(players, firebaseService);
    }
}
