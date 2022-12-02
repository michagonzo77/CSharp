using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using DojoSurveyModel.Models;

namespace DojoSurveyModel.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    static Survey? user;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    [HttpGet("Success")]
    public IActionResult Success()
    {
        return View("Success", user);
    }

    [HttpPost("user/create")]
    public IActionResult Create(Survey newUser)
    {
        if(ModelState.IsValid)
        {
            user = newUser;
            return RedirectToAction("Success");
        } else {
            // Render validation errors
            return View("Index");
        }
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
