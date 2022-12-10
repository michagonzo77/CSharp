using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OtMDemo.Models;

namespace OtMDemo.Controllers;

public class HomeController : Controller
{
    private MyContext _context; 
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger, MyContext context)
    {
        _logger = logger;
        _context = context;
    }

    public IActionResult Index()
    {
        MyViewModel MyModel = new MyViewModel
        {
            AllMakers = _context.Makers.Include(a => a.AllVehicles).ToList()
        };
        return View("Index",MyModel);
    }

    [HttpPost("makers/create")]
    public IActionResult CreateMaker(Maker newMaker)
    {
        if(ModelState.IsValid)
        {
            _context.Add(newMaker);
            _context.SaveChanges();
            return RedirectToAction("Index");
        } else {
            // MyViewModel MyModel = new MyViewModel
            // {
            //     AllMakers = _context.Makers.ToList()
            // };
            // return View("Index", MyModel);
            return Index();
        }
    }

    [HttpGet("vehicles")]
    public IActionResult Vehicles()
    {
        MyViewModel MyModel = new MyViewModel
        {
            AllVehicles = _context.Vehicles.Include(a => a.Maker).ToList()
        };
        ViewBag.AllMakers = _context.Makers.ToList();
        return View("vehicles",MyModel);
    }

    [HttpPost("vehicles/create")]
    public IActionResult CreateVehicle(Vehicle newVehicle)
    {
        if(ModelState.IsValid)
        {
            _context.Add(newVehicle);
            _context.SaveChanges();
            return RedirectToAction("Vehicles");
        } else {
            return Vehicles();
        }
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
