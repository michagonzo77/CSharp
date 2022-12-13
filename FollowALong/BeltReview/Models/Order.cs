#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace BeltReview.Models;
public class Order
{
    [Key]
    public int OrderId {get;set;}

    // The person who ordered the craft
    public int UserId {get;set;}
    public User? User {get;set;}

    // The craft ordered
    public int CraftId {get;set;}
    public Craft? Craft {get;set;}

    [Required]
    public int QuantityOrdered {get;set;}

    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
}