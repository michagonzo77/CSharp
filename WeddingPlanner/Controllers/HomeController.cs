using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WeddingPlanner.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Filters;

namespace WeddingPlanner.Controllers;

public class HomeController : Controller
{
    private MyContext _context;
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger,MyContext context)
    {
        _logger = logger;
        _context = context;
    }

    public IActionResult Index()
    {
        return View();
    }

    [HttpPost("users/create")]
    public IActionResult CreateUser(User newUser)
    {
        if(ModelState.IsValid)
        {
            // Hash our password
            PasswordHasher<User> Hasher = new PasswordHasher<User>();
            newUser.Password = Hasher.HashPassword(newUser, newUser.Password);
            _context.Add(newUser);
            _context.SaveChanges();
            HttpContext.Session.SetInt32("UserId", newUser.UserId);
            return RedirectToAction("Weddings");
        } else {
            return View("Index");
        }
    }

    [HttpPost("users/login")]
    public IActionResult LoginUser(LogUser loginUser)
    {
        if(ModelState.IsValid)
        {
            // Look up our user in the database
            User? userInDb = _context.Users.FirstOrDefault(u => u.Email == loginUser.LEmail);
            // We need to verify this is a user who exists
            if(userInDb == null)
            {
                ModelState.AddModelError("LEmail", "Invalid Email/Password");
                return View("Index");
            }
            // Verify the password matches what's in the database
            PasswordHasher<LogUser> hasher = new PasswordHasher<LogUser>();
            var result = hasher.VerifyHashedPassword(loginUser, userInDb.Password, loginUser.LPassword);
            if(result == 0)
            {
                // A failure, we did not use the right password
                ModelState.AddModelError("LPassword", "Invalid Email/Password");
                return View("Index");
            } else {
                // Set session and head to Weddings
                HttpContext.Session.SetInt32("UserId", userInDb.UserId);
                return RedirectToAction("Weddings");
            }
        } else {
            return View("Index");
        }
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
        // int? TerrancesDong = HttpContext.Session.GetInt32("UserId");
        // ViewBag.Terrance = _context.Users.FirstOrDefault(u => u.UserId == TerrancesDong);
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

    [HttpPost("logout")]
    public IActionResult Logout()
    {
        HttpContext.Session.Clear();
        return RedirectToAction("Index");
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

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

}

public class SesssionCheckAttribute : ActionFilterAttribute
{
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        int? userId = context.HttpContext.Session.GetInt32("UserId");
        if(userId == null)
        {
            context.Result = new RedirectToActionResult("Index", "Home", null);
        }
    }
}