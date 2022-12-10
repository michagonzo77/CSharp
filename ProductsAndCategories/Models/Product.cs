#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace ProductsAndCategories.Models;
public class Product
{
    [Key]
    public int ProductId { get; set; }
    [Required]
    [MinLength(2, ErrorMessage = "Name must be at least 2 characters")]
    public string Name { get; set; }
    [Required]
    [MinLength(2, ErrorMessage = "Description must be at least 2 characters")]
    public string Description { get; set; }
    [Required]
    public double? Price { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
    public List<Association> Attributes { get; set; } = new List<Association>();
}