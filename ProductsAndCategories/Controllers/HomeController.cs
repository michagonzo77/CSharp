using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductsAndCategories.Models;

namespace ProductsAndCategories.Controllers;

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
    public IActionResult Products()
    {
        MyViewModel MyModel = new MyViewModel
        {
            AllProducts = _context.Products.ToList()
        };
        return View("Products", MyModel);
    }

    [HttpGet("products/{productId}")]
    public IActionResult ShowProduct(int productId)
    {
        ViewBag.AllCategories = _context.Categories
                                                    .Include(a => a.Items)
                                                    .Where(a => a.Items
                                                    .All(b => b.ProductId != productId)).ToList();
        // ViewBag.AllCategoriesSelected = _context.Categories
        //                                             .Include(a => a.Items)
        //                                             .Where(a => a.Items
        //                                             .Any(b => b.ProductId == productId)).ToList();
        Product? TheProduct = _context.Products
                                                    .Include(a => a.Attributes)
                                                    .ThenInclude(a => a.Category)
                                                    .FirstOrDefault(p => p.ProductId == productId);
        Association? TheAssociation = new Association();
        TheAssociation.ProductId = TheProduct.ProductId;                                            
        ShowProductViewModel MyModel = new ShowProductViewModel
        {
            Product = TheProduct,
            Attributes = _context.Associations
                                                    .Include(a => a.Category)
                                                    .Where(a => a.ProductId == productId).ToList(),
            Association = TheAssociation
        };
        return View("ShowProduct", MyModel);
    }

    [HttpGet("categories/{categoryId}")]
    public IActionResult ShowCategory(int categoryId)
    {
        ViewBag.AllProducts = _context.Products
                                                .Include(a => a.Attributes)
                                                .Where(a => a.Attributes
                                                .All(b => b.CategoryId != categoryId)).ToList();
        Category? TheCategory = _context.Categories
                                                .Include(a => a.Items)
                                                .ThenInclude(a => a.Product)
                                                .FirstOrDefault(c => c.CategoryId == categoryId);
        Association? TheAssociation = new Association();
        TheAssociation.CategoryId = TheCategory.CategoryId;
        ShowCategoryViewModel MyModel = new ShowCategoryViewModel
        {
            Category = TheCategory,
            Attributes = _context.Associations
                                                    .Include(a => a.Product)
                                                    .Where(a => a.CategoryId == categoryId).ToList(),
            Association = TheAssociation
        };
        return View("ShowCategory", MyModel);
    }

    [HttpPost("associations/create")]
    public IActionResult CreateAssociation(Association newAssociation)
    {
        if(ModelState.IsValid)
        {
            _context.Add(newAssociation);
            _context.SaveChanges();
            return RedirectToAction("ShowProduct", new {productId = newAssociation.ProductId});
        } else {
            return View("products", newAssociation.ProductId);
        }
    }

    [HttpPost("items/create")]
    public IActionResult CreateItem(Association newItem)
    {
        if(ModelState.IsValid)
        {
            _context.Add(newItem);
            _context.SaveChanges();
            return RedirectToAction("ShowCategory", new {categoryId = newItem.CategoryId});
        } else {
            return View("categories", newItem.CategoryId);
        }
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

    [HttpGet("categories")]
    public IActionResult Categories()
    {
        MyViewModel MyModel = new MyViewModel
        {
            AllCategories = _context.Categories.ToList()
        };
        return View("Categories", MyModel);
    }

    [HttpPost("categories/create")]
    public IActionResult CreateCategory(Category newCategory)
    {
        if(ModelState.IsValid){
            _context.Add(newCategory);
            _context.SaveChanges();
            return RedirectToAction("Categories");
        } else {
            return View("Categories");
        }
    }

    [HttpPost("categories/{associationId}/destroy")]
    public IActionResult DestroyItem(int associationId)
    {
        Association? ItemToDestroy = _context.Associations.SingleOrDefault(a => a.AssociationId == associationId);
        _context.Associations.Remove(ItemToDestroy);
        _context.SaveChanges();
        return RedirectToAction("ShowCategory", new{categoryId = ItemToDestroy.CategoryId});
    }

    [HttpPost("products/{associationId}/destroy")]
    public IActionResult DestroyAttribute(int associationId)
    {
        Association? AttributeToDestroy = _context.Associations.SingleOrDefault(a => a.AssociationId == associationId);
        _context.Associations.Remove(AttributeToDestroy);
        _context.SaveChanges();
        return RedirectToAction("ShowCategory", new{categoryId = AttributeToDestroy.CategoryId});
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
