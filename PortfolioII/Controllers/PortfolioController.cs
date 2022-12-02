using Microsoft.AspNetCore.Mvc;
namespace PortfolioI.Controllers;
public class PortfolioController : Controller
{
    // Routing
    // This tells our controller we have a web page we want to see (or GET)
    [HttpGet]
    // What is the url?
    // this goes to localhost:5xxx/
    [Route("")]
    public ViewResult Index()
    {
        return View("Index");
    }

    [HttpGet("projects")]
    public ViewResult Projects()
    {
        return View("Projects");
    }

    [HttpGet("contact")]
    public ViewResult Contact()
    {
        return View("Contact");
    }
}