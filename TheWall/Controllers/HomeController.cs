using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TheWall.Models;
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
            return RedirectToAction("Messages");
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
                return RedirectToAction("Messages");
            }
        } else {
            return View("Index");
        }
    }

    [SesssionCheck]
    [HttpGet("messages")]
    public IActionResult Messages()
    {
        MyWallModel MyModel = new MyWallModel
        {
            // AllMessages = _context.Messages
            //                                 .Include(a => a.MessageWithComments)
            //                                 .ToList(),
            // AllComments = _context.Comments
            //                                 .Include(a => a.User)
            //                                 .ThenInclude(a => a.Messages)
            //                                 .ToList(),
            AllMessages = _context.Messages
                                            .OrderByDescending(d => d.CreatedAt)
                                            .Include(c => c.MessageWithComments)
                                            .ThenInclude(u => u.User)
                                            .ToList(),
            AllComments = _context.Comments
                                            .OrderBy(d => d.CreatedAt)
                                            .Include(m => m.Message)
                                            .ToList()
        };
        ViewBag.LoggedInUser = _context.Users.FirstOrDefault(a => a.UserId == HttpContext.Session.GetInt32("UserId"));
        return View("Messages", MyModel);
    }

    [HttpPost("messages/create")]
    public IActionResult CreateMessage(Message newMessage)
    {
        if(ModelState.IsValid)
        {
            _context.Add(newMessage);
            _context.SaveChanges();
            // return RedirectToAction("OneWedding", new {weddingId = newRSVP.WeddingId});
            return RedirectToAction("Messages");
        } else {
            return Messages();
        }
    }

    [HttpPost("comments/create")]
    public IActionResult CreateComment(Comment newComment)
    {
        if(ModelState.IsValid)
        {
            _context.Add(newComment);
            _context.SaveChanges();
            // return RedirectToAction("OneWedding", new {weddingId = newRSVP.WeddingId});
            return RedirectToAction("Messages");
        } else {
            return Messages();
        }
    }

    [HttpPost("comments/{commentId}/destroy")]
    public IActionResult DestroyComment(int commentId)
    {
        if(ModelState.IsValid)
        {
        Comment? CommentToDestroy = _context.Comments.Where(a => a.UserId == HttpContext.Session.GetInt32("UserId")).SingleOrDefault(a => a.CommentId == commentId);
        ViewBag.LoggedInUser = _context.Users.FirstOrDefault(a => a.UserId == HttpContext.Session.GetInt32("UserId"));
        _context.Comments.Remove(CommentToDestroy);
        _context.SaveChanges();
        return RedirectToAction("Messages");
        } else {
            return Messages();
        }
    }

    [HttpPost("messages/{messageId}/destroy")]
    public IActionResult DestroyMessage(int messageId)
    {
        if(ModelState.IsValid)
        {
        Message? MessageToDestroy = _context.Messages.Where(a => a.UserId == HttpContext.Session.GetInt32("UserId")).SingleOrDefault(a => a.MessageId == messageId);
        ViewBag.LoggedInUser = _context.Users.FirstOrDefault(a => a.UserId == HttpContext.Session.GetInt32("UserId"));
        _context.Messages.Remove(MessageToDestroy);
        _context.SaveChanges();
        return RedirectToAction("Messages");
        } else {
            return Messages();
        }
    }

    public IActionResult Privacy()
    {
        return View();
    }
    
    [HttpPost("logout")]
    public IActionResult Logout()
    {
        HttpContext.Session.Clear();
        return RedirectToAction("Index");
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