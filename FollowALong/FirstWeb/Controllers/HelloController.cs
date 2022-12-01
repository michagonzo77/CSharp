using Microsoft.AspNetCore.Mvc;
namespace FirstWeb.Controllers;
public class HelloController : Controller
{
    // Routing
    // This tells our controller we have a web page we want to see (or GET)
    [HttpGet]
    // What is the url?
    // this goes to localhost:5xxx/
    [Route("")]
    public ViewResult Index()
    {
        // ViewBag allows us to pass data from our controller to our view
        // Think of a viewbag as a dictionary, it has keys and values
        ViewBag.Name = "Nichole";
        ViewBag.Number = 7;
        return View("Index");
    }

    // localhost:5XXX/user/more
    [HttpGet("user/more")]
    public ViewResult AUser()
    {
        // If it's empty it assumes the name of the actions as the name of the cshtml file
        return View();
    }
    [HttpGet("user/{id}")]
    public string OneUser(int id)
    {
        return $"This is user {id}";
    }

    [HttpPost("process")]
    public IActionResult Process(string FavoriteAnimal)
    {
        if(FavoriteAnimal == "dog")
        {
            ViewBag.Name = "Nichole";
            ViewBag.Number = 7;
            ViewBag.Error = "Dogs are great but pick something else.";
            return View("Index");
        }
        Console.WriteLine(FavoriteAnimal);
        return RedirectToAction("Index");
    }
}