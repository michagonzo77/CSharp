#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace DojoSurveyModel.Models;

public class BirthdayAttribute : ValidationAttribute
{    
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)    
    {        
        // You first may want to unbox "value" here and cast to to a DateTime variable!
        if((DateTime)value > DateTime.Now)
        {
            return new ValidationResult("Date must be in the past.");
        } else {
            return ValidationResult.Success;
        }
    }
}