#pragma warning disable CS8618

namespace ProductsAndCategories.Models;
public class ShowProductViewModel
{
    public Product Product {get;set;}
    public List<Association> Attributes {get;set;}
    public Association Association {get;set;}
}