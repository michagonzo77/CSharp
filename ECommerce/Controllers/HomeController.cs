using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ECommerce.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ECommerce.Controllers;

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
    public IActionResult Dashboard()
    {
        MyViewModel MyModel = new MyViewModel
        {
            AllProducts = _context.Products.Take(5).ToList(),
            AllCustomers = _context.Customers
                                            .Include(a => a.Order)
                                            .ThenInclude(a => a.Product)
                                            .Take(3).ToList(),
            AllOrders = _context.Orders.Include(a => a.Customer).Take(3).ToList()
        };
        return View("Dashboard", MyModel);
    }

    [HttpGet("customers")]
    public IActionResult Customers()
    {
        MyViewModel MyModel = new MyViewModel
        {
            AllCustomers = _context.Customers.ToList()
        };
        return View("Customers", MyModel);
    }

    [HttpPost("customers/create")]
    public IActionResult CreateCustomer(Customer newCustomer)
    {
        if(ModelState.IsValid)
        {
            _context.Add(newCustomer);
            _context.SaveChanges();
            return RedirectToAction("Customers");
        } else {
            return View("Customers");
        }
    }
    
    [HttpGet("products")]
    public IActionResult Products()
    {
        MyViewModel MyModel = new MyViewModel
        {
            AllProducts = _context.Products.ToList()
        };
        return View("Products", MyModel);
    }

    [HttpPost("products/create")]
    public IActionResult CreateProduct(Product newProduct)
    {
        if(ModelState.IsValid)
        {
            _context.Add(newProduct);
            _context.SaveChanges();
            return RedirectToAction("Products");
        } else {
            return View("Products");
        }
    }

    [HttpGet("orders")]
    public IActionResult Orders()
    {   
        ViewBag.AllCustomers = _context.Customers.ToList();
        ViewBag.AllProducts = _context.Products.ToList();
        MyViewModel MyModel = new MyViewModel 
        {
            AllOrders = _context.Orders.ToList()
        };
        return View("Orders", MyModel);
    }

    [HttpPost("orders/create")]
    public IActionResult CreateOrder(Order newOrder)
    {
        if(ModelState.IsValid)
        {
            _context.Add(newOrder);
            _context.SaveChanges();
            return RedirectToAction("Orders");
        } else {
            return Orders();
        }
    }

    [HttpPost("customers/{customerId}/destroy")]
    public IActionResult DestroyCustomer(int customerId)
    {
        if(ModelState.IsValid)
        {
        Customer? CustomerToDestroy = _context.Customers.SingleOrDefault(a => a.CustomerId == customerId);
        _context.Customers.Remove(CustomerToDestroy);
        _context.SaveChanges();
        return RedirectToAction("Customers");
        } else {
            return Customers();
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
