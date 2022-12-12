#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace ECommerce.Models;
public class Product
{
    [Key]
    public int ProductId { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]
    public string Image { get; set; }
    [Required]
    public int Quantity { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;

    public List<Order> OrderedBy = new List<Order>();
}