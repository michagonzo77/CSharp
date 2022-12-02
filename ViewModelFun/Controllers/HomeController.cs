using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ViewModelFun.Models;

namespace ViewModelFun.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    [HttpGet("")]
    public IActionResult Index()
    {
        ViewBag.Message = "I'm a dog.";
        return View();
    }

    [HttpGet("Numbers")]
    public IActionResult Numbers()
    {
        int[] numsArray = new int[] {1,2,3,4,5};
        return View(numsArray);
    }

    [HttpGet("User")]
    public IActionResult OneUser()
    {
        List<string> User = new List<string> {"Sandra", "Bullock"};
        return View(User);
    }

    [HttpGet("AllUsers")]
    public IActionResult AllUsers()
    {
        List<string> Users = new List<string> {"Sandra Bullock", "Keanu Reaves", "Jimmy Butler", "Alonzo Mourning"};
        return View(Users);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
