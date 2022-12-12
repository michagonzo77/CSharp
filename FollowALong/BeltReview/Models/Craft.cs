#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace BeltReview.Models;
public class Craft
{
    [Key]
    public int CraftId {get;set;}

    [Required]
    public string Image {get;set;}

    [Required]
    public string Title {get;set;}

    [Required]
    [Range(0.01, double.MaxValue)]
    public double Price {get;set;}

    [Required]
    [Range(1, int.MaxValue)]
    public int Quantity {get;set;}

    [Required]
    [MinLength(20, ErrorMessage = "Be more descriptive!")]
    public string Description {get;set;}

    // This is for my one to many
    public int UserId {get;set;}
    public User? Creator {get;set;}

    // This is for my many to many
    public List<Order> OrdersPlaced {get;set;} = new List<Order>();

    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
}