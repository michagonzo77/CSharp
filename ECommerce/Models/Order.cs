#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ECommerce.Models;
public class Order
{
    [Key]
    public int OrderId { get; set; }
    [Required]
    public int Quantity {get;set;}
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
    public int CustomerId {get;set;}
    public int ProductId {get;set;}

    public Product? Product { get; set; }
    public Customer? Customer { get; set; }

    [NotMapped]
    public int DaysSinceOrder
    {
        get
        {
            // DateTime now = DateTime.Today;
            // int daysSinceJoin = now - CreatedAt;
            //     return daysSinceJoin;
            int daysSinceOrder = (DateTime.Now.Date - CreatedAt.Date).Days;
            return daysSinceOrder;
        }
    }
}