#pragma warning disable CS8618

namespace ProductsAndCategories.Models;
public class ShowCategoryViewModel
{
    public Category Category {get;set;}
    public List<Association> Attributes {get;set;}
    public Association Association {get;set;}
}