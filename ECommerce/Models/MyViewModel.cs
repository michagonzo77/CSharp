#pragma warning disable CS8618

namespace ECommerce.Models;
public class MyViewModel
{
    public Customer Customer {get;set;}
    public List<Customer> AllCustomers {get;set;}
    public Product Product {get;set;}
    public List<Product> AllProducts {get;set;}
    public Order Order {get;set;}
    public List<Order> AllOrders {get;set;}
}