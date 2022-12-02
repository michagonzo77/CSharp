using Microsoft.AspNetCore.Mvc;
namespace Dojo.Controllers;
public class DojoController : Controller
{

    [HttpGet("")]
    public ViewResult Index()
    {
        return View("Index");
    }

    [HttpGet("Success")]
    public ViewResult Success(string Name, string Location, string Language, string Comment)
    {
        ViewBag.Name = Name;
        ViewBag.Location = Location;
        ViewBag.Language = Language;
        ViewBag.Comment = Comment;
        return View("Success");
    }


    [HttpPost("process")]
    public IActionResult Process(string Name, string Location, string Language, string Comment)
    {
        return RedirectToAction("Success", new {Name = Name, Location = Location, Language= Language, Comment = Comment});
    }
}