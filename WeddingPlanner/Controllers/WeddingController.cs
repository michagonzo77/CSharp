using Microsoft.AspNetCore.Mvc;
using WeddingPlanner.Models;
using Microsoft.EntityFrameworkCore;

namespace WeddingPlanner.Controllers;

public class WeddingController : Controller
{
    private MyContext _context;
    private readonly ILogger<WeddingController> _logger;

    public WeddingController(ILogger<WeddingController> logger,MyContext context)
    {
        _logger = logger;
        _context = context;
    }

    [SesssionCheck]
    [HttpGet("weddings")]
    public IActionResult Weddings()
    {
        ShowWeddingViewModel MyModel = new ShowWeddingViewModel
        {
            AllWeddings = _context.Weddings
                                            .Include(a => a.Guests)
                                            .ToList(),
            PlannedWeddings = _context.Reservations
                                            .Include(a => a.Wedding)
                                            .ToList()
        };
        ViewBag.AllWeddings = _context.Weddings.Include(a => a.Guests).ToList();
        ViewBag.LoggedInUser = _context.Users.FirstOrDefault(a => a.UserId == HttpContext.Session.GetInt32("UserId"));
        ViewBag.RSVPS = _context.Reservations.Include(w => w.Wedding).Where(u => u.UserId == HttpContext.Session.GetInt32("UserId"));
        return View();
    }

    [SesssionCheck]
    [HttpGet("weddings/new")]
    public IActionResult NewWedding()
    {
        ViewBag.LoggedInUser = _context.Users.FirstOrDefault(a => a.UserId == HttpContext.Session.GetInt32("UserId"));
        return View();
    }

    [HttpPost("weddings/create")]
    public IActionResult CreateWedding(Wedding newWedding)
    {
        if(ModelState.IsValid)
        {
            _context.Add(newWedding);
            _context.SaveChanges();
            return RedirectToAction("Weddings");
        } else {
            return View("NewWedding");
        }
    }

    [SesssionCheck]
    [HttpGet("weddings/{weddingId}")]
    public IActionResult OneWedding(int weddingId)
    {
        ShowWeddingViewModel MyModel = new ShowWeddingViewModel
        {
            Wedding = _context.Weddings
                                        .Include(a => a.Guests)
                                        .ThenInclude(u => u.User)
                                        .FirstOrDefault(a => a.WeddingId == weddingId),
        };
        ViewBag.LoggedInUser = _context.Users.FirstOrDefault(a => a.UserId == HttpContext.Session.GetInt32("UserId"));
        return View(MyModel);
    }

    [HttpPost("weddings/rsvp")]
    public IActionResult RSVPWedding(int weddingId, Reservation newRSVP)
    {
        if(ModelState.IsValid)
        {
            _context.Add(newRSVP);
            _context.SaveChanges();
            // return RedirectToAction("OneWedding", new {weddingId = newRSVP.WeddingId});
            return RedirectToAction("Weddings");
        } else {
            return View("Weddings");
        }
    }

    [HttpPost("weddings/{weddingId}/destroy")]
    public IActionResult DestroyWedding(int weddingId)
    {
        Wedding? WeddingToDestroy = _context.Weddings.SingleOrDefault(a => a.WeddingId == weddingId);
        _context.Weddings.Remove(WeddingToDestroy);
        _context.SaveChanges();
        return RedirectToAction("Weddings");
    }

    [HttpPost("reservations/{weddingId}/destroy")]
    public IActionResult UnRSVPWedding(int weddingId)
    {
        if(ModelState.IsValid)
        {
        Reservation? RSVPToDestroy = _context.Reservations.Where(a => a.UserId == HttpContext.Session.GetInt32("UserId")).SingleOrDefault(a => a.WeddingId == weddingId);
        ViewBag.LoggedInUser = _context.Users.FirstOrDefault(a => a.UserId == HttpContext.Session.GetInt32("UserId"));
        _context.Reservations.Remove(RSVPToDestroy);
        _context.SaveChanges();
        return RedirectToAction("Weddings");
        } else {
            return View("Weddings");
        }
    }

}