using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using LINQEruption.Models;

namespace LINQEruption.Controllers;

public class HomeController : Controller
{
    public static List<Eruption> eruptions = new List<Eruption>()
    {
    new Eruption("La Palma", 2021, "Canary Is", 2426, "Stratovolcano"),
    new Eruption("Villarrica", 1963, "Chile", 2847, "Stratovolcano"),
    new Eruption("Chaiten", 2008, "Chile", 1122, "Caldera"),
    new Eruption("Kilauea", 2018, "Hawaiian Is", 1122, "Shield Volcano"),
    new Eruption("Hekla", 1206, "Iceland", 1490, "Stratovolcano"),
    new Eruption("Taupo", 1910, "New Zealand", 760, "Caldera"),
    new Eruption("Lengai, Ol Doinyo", 1927, "Tanzania", 2962, "Stratovolcano"),
    new Eruption("Santorini", 46, "Greece", 367, "Shield Volcano"),
    new Eruption("Katla", 950, "Iceland", 1490, "Subglacial Volcano"),
    new Eruption("Aira", 766, "Japan", 1117, "Stratovolcano"),
    new Eruption("Ceboruco", 930, "Mexico", 2280, "Stratovolcano"),
    new Eruption("Etna", 1329, "Italy", 3320, "Stratovolcano"),
    new Eruption("Bardarbunga", 1477, "Iceland", 2000, "Stratovolcano")
    };
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        // Find the first eruption in Chile
        Eruption? FirstChile = eruptions.FirstOrDefault(e => e.Location == "Chile");
        ViewBag.FirstChile = FirstChile;

        // Find first eruption from the "Hawaiian Is" location. If none found print 
        Eruption? FirstHawaii = eruptions.FirstOrDefault(e => e.Location == "Hawaiian Is");
        ViewBag.FirstHawaii = FirstHawaii;

        // Find first eruption from the "Greenland" location. If none found print 
        Eruption? FirstGreenland2 = eruptions.FirstOrDefault(e => e.Location == "Greenland");
        ViewBag.FirstGreenland2 = FirstGreenland2;
        bool FirstGreenland = eruptions.Any(l => l.Location == "Greenland");
        ViewBag.FirstGreenland = FirstGreenland;

        // Find first eruption in New Zealand after 1900
        Eruption? FirstEruption = eruptions.Where(e => e.Location == "New Zealand").FirstOrDefault(e => e.Year > 1900);
        ViewBag.FirstEruption = FirstEruption;

        // Find all eruptions where elevation is over 2000m
        List<Eruption> AllOver2000 = eruptions.Where(e => e.ElevationInMeters > 2000).ToList();
        ViewBag.AllOver2000 = AllOver2000;

        // Find all eruptions that volcano name start with L
        List<Eruption> AllLVolcanos = eruptions.Where(e => e.Volcano.StartsWith("L")).ToList();
        ViewBag.AllLVolcanos = AllLVolcanos;

        // Find the highest elevation
        int? HighestElevation = eruptions.Max(v => v.ElevationInMeters);
        ViewBag.HighestElevation = HighestElevation;

        // Get info of the highest elevation volcano
        Eruption? HighestEleVolcano = eruptions.FirstOrDefault(v => v.ElevationInMeters == HighestElevation);
        ViewBag.HighestEleVolcano = HighestEleVolcano;

        // Get all volcanos and print alphabetically
        List<Eruption> AllEruptions = eruptions.OrderBy(v => v.Volcano).ToList();
        ViewBag.AllEruptions = AllEruptions;

        // Get sum of all elavations
        int Total = eruptions.Sum(v => v.ElevationInMeters);
        ViewBag.Total = Total;

        // Any volanoes erupted in the year 2000?
        bool Any2000 = eruptions.Any(v => v.Year == 2000);
        ViewBag.Any2000 = Any2000;

        // Find all stratovolcanoes and show just three
        List<Eruption> FirstThreeStrat = eruptions.Where(v => v.Type == "Stratovolcano").Take(3).ToList();
        ViewBag.FirstThreeStrat = FirstThreeStrat;

        // Show all eruptions that happened before 1000
        List<Eruption> Before1000 = eruptions.Where(v => v.Year < 1000).OrderBy(v => v.Volcano).ToList();
        ViewBag.Before1000 = Before1000;

        // Show all eruptions that happened before 1000 ONLY NAME
        List<string> Before1000Names = eruptions.OrderBy(v => v.Volcano).Where(v => v.Year < 1000).Select(e => e.Volcano).ToList();
        ViewBag.Before1000Names = Before1000Names;

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
