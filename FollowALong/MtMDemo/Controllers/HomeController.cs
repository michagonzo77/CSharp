using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MtMDemo.Models;

namespace MtMDemo.Controllers;

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
        MyViewModel MyModels = new MyViewModel
        {
            AllPokemon = _context.Pokemon.ToList()
        };
        return View(MyModels);
    }

    [HttpPost("pokemon/create")]
    public IActionResult CreatePokemon(Pokemon newPokemon)
    {
        if(ModelState.IsValid)
        {
            _context.Add(newPokemon);
            _context.SaveChanges();
            return RedirectToAction("Index");
        } else {
            MyViewModel MyModels = new MyViewModel
            {
                AllPokemon = _context.Pokemon.ToList()
            };
            return View("Index", MyModels);
        }
    }

    [HttpGet("pokemon/{id}")]
    public IActionResult OnePokemon(int id)
    {
        Pokemon? OnePoke = _context.Pokemon
                                            .Include(a => a.MovesKnown)
                                            .ThenInclude(s => s.Move)
                                            .FirstOrDefault(a => a.PokemonId == id);
        return View(OnePoke);
    }

    [HttpGet("moves")]
    public IActionResult Moves()
    {
        MyViewModel MyModels = new MyViewModel
        {
            AllMoves = _context.Moves.ToList()
        };
        ViewBag.AllMoves = new List<string>() {"Bug", "Dark", "Dragon", "Electric", "Fairy", "Fighting", "Fire", "Flying", "Ghost", "Grass", "Ground", "Ice", "Normal", "Poison", "Psychic", "Rock", "Steel", "Water"};
        return View(MyModels);
    }

    [HttpPost("moves/create")]
    public IActionResult CreateMove(Move newMove)
    {
        if(ModelState.IsValid)
        {
            _context.Add(newMove);
            _context.SaveChanges();
            return RedirectToAction("Moves");
        } else {
            MyViewModel MyModels = new MyViewModel
            {
                AllMoves = _context.Moves.ToList()
            };
            ViewBag.AllMoves = new List<string>() {"Bug", "Dark", "Dragon", "Electric", "Fairy", "Fighting", "Fire", "Flying", "Ghost", "Grass", "Ground", "Ice", "Normal", "Poison", "Psychic", "Rock", "Steel", "Water"};
            return View("Index", MyModels);
        }
    }

    [HttpGet("knownmoves/new")]
    public IActionResult NewMoveKnown()
    {
        ViewBag.AllPokemon = _context.Pokemon.OrderBy(s => s.Name).ToList();
        ViewBag.AllMoves = _context.Moves.OrderBy(s => s.Name).ToList();
        return View("AddAssociation");
    }

    [HttpPost("knownmoves/create")]
    public IActionResult CreateKnownMove(KnownMove newKnownMove)
    {
        if(ModelState.IsValid)
        {
            _context.Add(newKnownMove);
            _context.SaveChanges();
            return RedirectToAction("NewMoveKnown");
        } else {
            ViewBag.AllPokemon = _context.Pokemon.OrderBy(s => s.Name).ToList();
            ViewBag.AllMoves = _context.Moves.OrderBy(s => s.Name).ToList();
            return View("NewMoveKnown");
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
