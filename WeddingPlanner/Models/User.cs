#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace WeddingPlanner.Models;
public class User
{
    [Key]
    public int UserId { get; set; }
    [Required]
    [MinLength(2, ErrorMessage = "First Name must be at least 2 characters")]
    public string FirstName {get;set;}
    [Required]
    [MinLength(2, ErrorMessage = "Last Name must be at least 2 characters")]
    public string LastName {get;set;}
    [Required]
    [EmailAddress]
    [UniqueEmail]
    public string Email {get;set;}
    [Required]
    [MinLength(8, ErrorMessage = "Password must be at least 8 characters")]
    [DataType(DataType.Password)]
    public string Password {get;set;}
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
    public List<Reservation> RSVP { get; set; } = new List<Reservation>();
    public List<Wedding> PlannedWeddings {get;set;} = new List<Wedding>();

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


// // include this using statement at the top of your controller file
// using Microsoft.AspNetCore.Mvc.ModelBinding;

// // this snippet can go in any of your create methods
// foreach (KeyValuePair<string, ModelStateEntry> error in ModelState)
// {
//     Console.WriteLine("********** ERROR ********");
//     Console.WriteLine($"Field: {error.Key}");
//     foreach (ModelError err in error.Value.Errors)
//     {
//         Console.WriteLine($"Error: {err.ErrorMessage}");
//     }
// }