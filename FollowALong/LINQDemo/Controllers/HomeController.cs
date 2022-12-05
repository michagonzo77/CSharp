using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using LINQDemo.Models;

namespace LINQDemo.Controllers;

public class HomeController : Controller
{
    public static Game[] AllGames = new Game[]
    {
        new Game {Title="Bobothy's Big Adventure", Price=69.99, Genre="Casual", Rating="M", Platform="PC"},
        new Game {Title="DayZ", Price=44.99, Genre="Survival", Rating="M", Platform="PC"},
        new Game {Title="Eat As Much As You Possibly Can", Price=19.99, Genre="Simulation", Rating="M", Platform="PC"},
        new Game {Title="Max Payne", Price=5.00, Genre="FPS", Rating="M", Platform="Xbox"},
        new Game {Title="Overcooked", Price=29.99, Genre="Simulation", Rating="E", Platform="Nintendo Switch"},
        new Game {Title="Goat Simulator", Price=14.95, Genre="Adventure", Rating="M", Platform="PC"}, 
        new Game {Title="Stardew Valley", Price=14.99, Genre="RPG", Rating="E", Platform="PC"},
        new Game {Title="Super Mario Bros", Price=14.99, Genre="Adventure", Rating="E", Platform="Super Nintendo"},
        new Game {Title="NeedForSpeed-Carbon", Price=19.99, Genre="na", Rating="na", Platform="GameCube"},
        new Game {Title="RuneScape", Price=0.00, Genre="MMORPG", Rating="E", Platform="PC"},
        new Game {Title="Elden Ring", Price=59.99, Genre="RPG", Rating="M", Platform="PC"},
        new Game {Title="Rust", Price=39.99, Genre="Survival", Rating="M", Platform="PC"},
        new Game {Title="League of legends", Price=0.00, Genre="MOBA", Rating="E", Platform="PC"},
        new Game {Title="Apex Legends", Price=0.00, Genre="FPS", Rating="M", Platform="PC"}
    };

    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        // All PC Games
        List<Game> AllPCGames = AllGames.Where(pc => pc.Platform == "PC").ToList();
        ViewBag.AllPCGames = AllPCGames;

        // Get one game
        Game? DayZ = AllGames.FirstOrDefault(d => d.Title == "DayZ");
        ViewBag.DayZ = DayZ;

        // Get the first 3 free games
        List<Game> Top3Free = AllGames.Where(g => g.Price == 0.00).OrderBy(t => t.Title).OrderBy(g => g.Genre).Take(3).ToList();
        ViewBag.FreeGames = Top3Free;

        // Get the price of the most expensive game
        double MostExpensive = AllGames.Max(s => s.Price);
        ViewBag.MostExpensive = MostExpensive;

        // Now use that information to find the game
        Game? MostExpGame = AllGames.FirstOrDefault(a => a.Price == MostExpensive);
        string? MyTitle = MostExpGame.Title;
        ViewBag.MostExpGame = MostExpGame;

        // The sum of all the prices
        double Total = AllGames.Sum(a => a.Price);
        ViewBag.Total = Total;

        // Grab all the titles... just the titles, not the whole Game
        List<string> AllTitles = AllGames.OrderBy(t => t.Title).Select(s => s.Title).ToList();
        ViewBag.AllTitles = AllTitles;

        // We can get back a boolean whether a condition was met
        bool MatchTitle = AllGames.Any(s => s.Title == "fafokafekf");
        ViewBag.MatchTitle = MatchTitle;
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }


    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
