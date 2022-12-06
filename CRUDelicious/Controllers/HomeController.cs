using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CRUDelicious.Models;

namespace CRUDelicious.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private MyContext _context;  
    public HomeController(ILogger<HomeController> logger, MyContext context)
    {
        _logger = logger;
        _context = context;  
    }

    [HttpGet("")]    
    public IActionResult Index()    
    {   
        List<Dish> AllDishes = _context.Dishes.OrderByDescending(d => d.CreatedAt).ToList();
        return View(AllDishes);
    }

    [HttpGet("dishes/new")]    
    public IActionResult NewDish()    
    {   
        return View();
    }

    // Inside HomeController
    [HttpPost("dishes/create")]
    public IActionResult CreateDish(Dish newDish)
    {    
    if(ModelState.IsValid)
        {
            // We can take the Monster object created from a form submission
            // and pass the object through the .Add() method  
            // Remember that _context is our database  
            _context.Add(newDish);    
            // OR _context.Monsters.Add(newMon); if we want to specify the table
            // EF Core will be able to figure out which table you meant based on the model  
            // VERY IMPORTANT: save your changes at the end! 
            _context.SaveChanges();
            return RedirectToAction("Index");
        } else {
            // Handle unsuccessful validations
            return View("NewDish");
        }
    }

    [HttpGet("dishes/{id}")]    
    public IActionResult ShowDish(int id)    
    {   
        Dish? OneDish = _context.Dishes.FirstOrDefault(a => a.DishId == id);
        return View(OneDish);
    }

    [HttpGet("dishes/{DishId}/edit")]
    public IActionResult EditDish(int DishId)
    {
        Dish? DishToEdit = _context.Dishes.FirstOrDefault(i => i.DishId == DishId);
        // Tip: it would be good to add a check here to ensure what you are grabbing will not return a null item
        return View(DishToEdit);
    }

    [HttpPost("dishes/{DishId}/update")]
    public IActionResult UpdateDish(Dish newDish, int DishId)
    {
    // 2. Verify that the new instance passes validations
    if(ModelState.IsValid)
        {
    	// 3. If it does, find the old version of the instance in your database
        Dish? OldDish = _context.Dishes.FirstOrDefault(i => i.DishId == DishId);
        // 4. Overwrite the old version with the new version
    	// Yes, this has to be done one attribute at a time
        OldDish.Name = newDish.Name;
        OldDish.Chef = newDish.Chef;
        OldDish.Calories = newDish.Calories;
        OldDish.Tastiness = newDish.Tastiness;
        OldDish.Description = newDish.Description;
    	// You updated it, so update the UpdatedAt field!
        OldDish.UpdatedAt = DateTime.Now;
    	// 5. Save your changes
        _context.SaveChanges();
    	// 6. Redirect to an appropriate page
        // return RedirectToAction("ShowDish", new {DishId});
        return Redirect($"/dishes/{DishId}");
        } else {
    	// 3.5. If it does not pass validations, show error messages
    	// Be sure to pass the form back in so you don't lose your changes
        return View("EditDish", newDish);
        }
    }

    [HttpPost("dishes/{DishId}/destroy")]
    public IActionResult DestroyDish(int DishId)
    {
    Dish? DishToDelete = _context.Dishes.SingleOrDefault(i => i.DishId == DishId);
    // Once again, it could be a good idea to verify the monster exists before deleting
    _context.Dishes.Remove(DishToDelete);
    _context.SaveChanges();
    return RedirectToAction("Index");
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
