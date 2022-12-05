#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace FormSubmission.Models;

public class FavoriteAttribute : ValidationAttribute
{    
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)    
    {        
        // You first may want to unbox "value" here and cast to to a DateTime variable!
        int count = 0;
        if((int)value % 2 != 0)
        {
            for(int ii = 1; ii <= (int)value; ii++)
            {
                if((int)value % ii == 0)
                {
                    count++;
                }
            }
            if(count == 2) {
                return ValidationResult.Success;
            } else {
                return new ValidationResult("Must be an odd prime number");
            }
        } else {
            return new ValidationResult("Must be an odd prime number");
        }
    }
}