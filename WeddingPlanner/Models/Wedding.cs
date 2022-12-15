#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace WeddingPlanner.Models;
public class Wedding
{
    [Key]
    public int WeddingId { get; set; }
    [Required]
    public string WedderOne {get;set;}
    [Required]
    public string WedderTwo {get;set;}
    [Required]
    [DataType(DataType.Date)]
    [WeddingDate]
    public DateTime WeddingDate {get;set;}
    [Required]
    public string Address {get;set;}
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
    public List<Reservation> Guests { get; set; } = new List<Reservation>();
    public int UserId {get;set;}

    public bool HasBeenRespondedToBy(int UserId)
    {
        foreach(Reservation guest in Guests)
        {
            if(guest.UserId == UserId)
            {
                return true;
            }
        }
        return false;
    }
}

public class WeddingDateAttribute : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if(value == null)
        {
            return new ValidationResult("Date must be entered");
        }
        if ((DateTime) value < DateTime.Now)
        {
            return new ValidationResult("Date must be in the future.");
        } else {
            return ValidationResult.Success;
        }
    }
}