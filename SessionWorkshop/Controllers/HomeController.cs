using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SessionWorkshop.Models;

namespace SessionWorkshop.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    [HttpPost("login")]
    public IActionResult Login(string NewName)
    {
        HttpContext.Session.SetString("Username", NewName);
        HttpContext.Session.SetInt32("MyNum", 1);
        return RedirectToAction("Dashboard");
    }

    public IActionResult Dashboard()
    {
        if(HttpContext.Session.GetString("Username") == null)
        {
            return RedirectToAction("Index");
        }
        int? Number = HttpContext.Session.GetInt32("MyNum");
        return View();
    }

    [HttpPost("logout")]
    public IActionResult Logout()
    {
        HttpContext.Session.Clear();
        return RedirectToAction("Index");
    }

    [HttpPost("tester")]
    public IActionResult Tester(string Action)
    {
        Console.WriteLine(Action);
        return RedirectToAction("Index");
    }

    // Condensed all actions into 1 action.
    // Used IFormCollection to have access to FormData in a Dictionary.
    // Use .First() to grab the first and only key/value pair coming in.
    // Check key of key/value pair for Logic.
    [HttpPost("changenum")]
    public IActionResult ChangeNum(IFormCollection collection)
    {
        string result = collection.First().Key;
        int? numNum = HttpContext.Session.GetInt32("MyNum");
        if (result == "plusone"){
            numNum += 1;
        } else if (result == "minusone"){
            numNum -= 1;
        } else if (result == "timestwo"){
            numNum *= 2;
        } else if (result == "random"){
            Random rand = new Random();
            int randNum = rand.Next(1,11);
            numNum += randNum;
        }
        HttpContext.Session.SetInt32("MyNum", (int)numNum);
        return RedirectToAction("Dashboard");
    }

    [HttpPost("plusone")]
    public IActionResult PlusOne()
    {
        int? Number = HttpContext.Session.GetInt32("MyNum");
        Number += 1;
        HttpContext.Session.SetInt32("MyNum", (int)Number);
        return RedirectToAction("Dashboard");
    }

    [HttpPost("minusone")]
    public IActionResult MinusOne()
    {
        int? Number = HttpContext.Session.GetInt32("MyNum");
        Number -= 1;
        HttpContext.Session.SetInt32("MyNum", (int)Number);
        return RedirectToAction("Dashboard");
    }

    [HttpPost("timestwo")]
    public IActionResult TimesTwo()
    {
        int? Number = HttpContext.Session.GetInt32("MyNum");
        Number *= 2;
        HttpContext.Session.SetInt32("MyNum", (int)Number);
        return RedirectToAction("Dashboard");
    }

    [HttpPost("random")]
    public IActionResult Random()
    {
        Random rand = new Random();
        int? Number = HttpContext.Session.GetInt32("MyNum");
        Number += rand.Next(1,11);
        HttpContext.Session.SetInt32("MyNum", (int)Number);
        return RedirectToAction("Dashboard");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
