#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ECommerce.Models;
public class Customer
{
    [Key]
    public int CustomerId { get; set; }
    [Required]
    public string Name { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;

    public Order? Order {get; set;}

    [NotMapped]
    public int DaysSinceJoin
    {
        get
        {
            // DateTime now = DateTime.Today;
            // int daysSinceJoin = now - CreatedAt;
            //     return daysSinceJoin;
            int daysSinceJoin = (DateTime.Now.Date - CreatedAt.Date).Days;
            return daysSinceJoin;
        }
    }
}