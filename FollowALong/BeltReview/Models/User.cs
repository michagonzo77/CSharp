#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace BeltReview.Models;
public class User
{
    [Key]
    public int UserId {get;set;}

    [Required]
    [MinLength(2, ErrorMessage = "Username must be at least 2 characters in length.")]
    public string Username {get; set;}

    [Required]
    [EmailAddress]
    [UniqueEmail]
    public string Email {get;set;}

    [Required]
    [DataType(DataType.Password)]
    [MinLength(8, ErrorMessage = "Password must be at least 8 characters")]
    public string Password {get;set;}

    // This is for my one to many
    public List<Craft> Listings {get;set;} = new List<Craft>();

    // This is for many to many
    public List<Order> OrdersPlaced {get;set;} = new List<Order>();

    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;

    [NotMapped]
    [DataType(DataType.Password)]
    [Compare("Password")]
    [Display(Name = "Confirm Password")]
    public string Confirm {get;set;}
}

public class UniqueEmailAttribute : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if(value == null)
        {
            return new ValidationResult("Email is required!");
        }
        // This is our connection to the database.
        MyContext _context = (MyContext)validationContext.GetService(typeof(MyContext));
        if(_context.Users.Any(e => e.Email == value.ToString()))
        {
            // If it matches, this is a problem, throw an error
            return new ValidationResult("Email must be unique.");
        } else {
            // We passed validation
            return ValidationResult.Success;
        }
    }
}