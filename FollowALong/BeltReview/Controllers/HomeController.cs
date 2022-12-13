using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using BeltReview.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Filters;

namespace TheWall.Controllers;

public class HomeController : Controller
{
    private MyContext _context;
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger,MyContext context)
    {
        _logger = logger;
        _context = context;
    }

    [HttpGet("")]
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost("users/create")]
    public IActionResult CreateUser(User newUser)
    {
        if(ModelState.IsValid)
        {
            PasswordHasher<User> Hasher = new PasswordHasher<User>();
            newUser.Password = Hasher.HashPassword(newUser, newUser.Password);
            _context.Add(newUser);
            _context.SaveChanges();
            HttpContext.Session.SetInt32("UserId", newUser.UserId);
            return RedirectToAction("Dashboard");
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
                // Set session and head to Dashboard
                HttpContext.Session.SetInt32("UserId", userInDb.UserId);
                return RedirectToAction("Dashboard");
            }
        } else {
            return View("Index");
        }
    }

    [SessionCheck]
    [HttpGet("users/dashboard")]
    public IActionResult Dashboard()
    {
        MyViewModel MyModel = new MyViewModel
        {
            User = _context.Users.Include(a => a.OrdersPlaced).ThenInclude(a => a.Craft).FirstOrDefault(a => a.UserId == (int)HttpContext.Session.GetInt32("UserId")),
            TotalSold = _context.Orders.Include(a => a.Craft).Where(s => s.Craft.UserId == (int)HttpContext.Session.GetInt32("UserId")).Sum(a => a.QuantityOrdered),
            MoneyMade = _context.Orders.Include(a => a.Craft).Where(s => s.Craft.UserId == (int)HttpContext.Session.GetInt32("UserId")).Sum(s => s.Craft.Price * s.QuantityOrdered),
            CraftsBought = _context.Orders.Where(a => a.UserId == (int)HttpContext.Session.GetInt32("UserId")).Sum(a => a.QuantityOrdered)
        };
        return View(MyModel);
    }

    [SessionCheck]
    [HttpGet("crafts")]
    public IActionResult Crafts()
    {
        List<Craft> AllCrafts = _context.Crafts.Include(a => a.Creator).ToList();
        return View(AllCrafts);
    }

    [SessionCheck]
    [HttpGet("crafts/new")]
    public IActionResult NewCraft()
    {
        return View();
    }

    [SessionCheck]
    [HttpPost("crafts/create")]
    public IActionResult CreateCraft(Craft newCraft)
    {
        if(ModelState.IsValid)
        {
            newCraft.UserId = (int)HttpContext.Session.GetInt32("UserId");
            _context.Add(newCraft);
            _context.SaveChanges();
            return RedirectToAction("Crafts");
        } else {
            return View("NewCraft");
        }
    }

    [SessionCheck]
    [HttpGet("crafts/{craftId}")]
    public IActionResult OneCraft(int craftId)
    {
        Craft One = _context.Crafts.Include(s => s.Creator).FirstOrDefault(a => a.CraftId == craftId);
        ViewBag.OneCraft = _context.Crafts.FirstOrDefault(a => a.CraftId == craftId);
        return View(One);
    }

    [SessionCheck]
    [HttpPost("orders/create")]
    public IActionResult CreateOrder(Order newOrder)
    {
        if(ModelState.IsValid)
        {
            newOrder.UserId = (int)HttpContext.Session.GetInt32("UserId");
            Craft? CraftOrdered = _context.Crafts.FirstOrDefault(a => a.CraftId == newOrder.CraftId);
            CraftOrdered.Quantity -= newOrder.QuantityOrdered;
            _context.Add(newOrder);
            _context.SaveChanges();
            return RedirectToAction("Dashboard");
        } else {
            return View("OneCraft", newOrder.CraftId);
        }
    }

    [SessionCheck]
    [HttpGet("orderhistory")]
    public IActionResult OrderHistory()
    {
        MyViewModel MyModel = new MyViewModel
        {
            YourSales = _context.Orders.Include(s => s.User).Include(a => a.Craft).Where(s => s.Craft.UserId == (int)HttpContext.Session.GetInt32("UserId")).ToList(),
            YourOrders = _context.Orders.Include(s => s.Craft).ThenInclude(a => a.Creator).Where(a => a.UserId == (int)HttpContext.Session.GetInt32("UserId")).ToList()
        };
        return View(MyModel);
    }

    [HttpPost("logout")]
    public IActionResult Logout()
    {
        HttpContext.Session.Clear();
        return RedirectToAction("Index");
    }

    [HttpPost("crafts/{craftId}/destroy")]
    public IActionResult DestroyCraft(int craftId)
    {
        Craft? CraftToDestroy = _context.Crafts.SingleOrDefault(a => a.CraftId == craftId);
        if(CraftToDestroy == null)
        {
            return RedirectToAction("Crafts");
        }
        _context.Remove(CraftToDestroy);
        _context.SaveChanges();
        return RedirectToAction("Crafts");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

    public class SessionCheckAttribute : ActionFilterAttribute
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
}

