using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using EFDemo.Models;

namespace EFDemo.Controllers;

public class HomeController : Controller
{
    private MyContext _context;
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger, MyContext context)
    {
        _logger = logger;
        _context = context;
    }

    [HttpGet("")]
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost("songs/create")]
    public IActionResult CreateSong(Song newSong)
    {
        if(ModelState.IsValid){
            // Add the song to our database
            _context.Add(newSong);
            // Save the changes
            _context.SaveChanges();
            // Redirect somewhere
            return RedirectToAction("Songs");
        } else {
            // View the page with the form to display errors
            return View("Index");
        }
    }

    [HttpGet("songs")]
    public IActionResult Songs()
    {
        // I need to grab all the songs
        List<Song> AllSongs = _context.Songs.ToList();
        return View("AllSongs", AllSongs);
    }

    [HttpPost("songs/{songId}/destroy")]
    public IActionResult DestroySong(int songId)
    {
        Song? SongToDestroy = _context.Songs.SingleOrDefault(a => a.SongId == songId);
        _context.Songs.Remove(SongToDestroy);
        _context.SaveChanges();
        return RedirectToAction("Songs");
    }

    [HttpGet("songs/{songId}/edit")]
    public IActionResult EditSong(int songId)
    {
        Song? SongToEdit = _context.Songs.FirstOrDefault(a => a.SongId == songId);
        return View(SongToEdit);
    }

    [HttpPost("songs/{songId}/update")]
    public IActionResult UpdateSong(int songId, Song UpdatedSong)
    {
        Song? SongToUpdate = _context.Songs.FirstOrDefault(a => a.SongId == songId);
        if(SongToUpdate == null){
            return RedirectToAction("Index");
        }
        if(ModelState.IsValid)
        {
            SongToUpdate.Title = UpdatedSong.Title;
            SongToUpdate.Year = UpdatedSong.Year;
            SongToUpdate.Artist = UpdatedSong.Artist;
            SongToUpdate.Genre = UpdatedSong.Genre;
            SongToUpdate.UpdatedAt = DateTime.Now;
            _context.SaveChanges();
            return RedirectToAction("Songs");
        } else {
            return View("EditSong", SongToUpdate);
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
