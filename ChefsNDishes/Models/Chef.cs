#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ChefsNDishes.Models;
public class Chef
{
    [Key]
    public int ChefId {get;set;}
    [Required (ErrorMessage = "First Name must be at least 2 characters")]
    [MinLength(2, ErrorMessage = "First Name must be at least 2 characters")]
    public string? FirstName {get;set;}
    [Required (ErrorMessage = "Last Name must be at least 2 characters")]
    [MinLength(2, ErrorMessage = "Last Name must be at least 2 characters")]
    public string LastName {get;set;}
    [Required (ErrorMessage = "Date is required.")]
    [Birthday]
    // [DataType(DataType.Date, ErrorMessage = "Yo You Too Old To Be Cooking")]
    public DateTime? Birthday {get;set;}
    public DateTime CreatedAt {get;set;} = DateTime.Now;
    public DateTime UpdatedAt {get;set;} = DateTime.Now;
    public List<Dish> Dishes { get; set; } = new List<Dish>();

    [NotMapped]
    public int Age 
    { 
        get
        {
            if (Birthday == null)
            {
                return -1;
            }
            DateTime DOB = (DateTime)Birthday;
            DateTime now = DateTime.Today;
            int age = now.Year - DOB.Year;
            if (Birthday > now.AddYears(-age)) age--;
                return age;
        }
    }
}

public class BirthdayAttribute : ValidationAttribute
{    
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)    
    {        
        if(value == null){
            return new ValidationResult("Date must be in the past.");
        }
        // You first may want to unbox "value" here and cast to to a DateTime variable!
        if((DateTime)value > DateTime.Now)
        {
            return new ValidationResult("Date must be in the past.");
        } else {
            return ValidationResult.Success;
        }
    }
}