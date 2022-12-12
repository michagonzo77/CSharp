#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace BeltReview.Models;
public class LogUser
{

    [EmailAddress]
    [Required(ErrorMessage = "Email is required")]
    [Display(Name = "Email")]
    public string LEmail {get;set;}
    [DataType(DataType.Password)]
    [Required(ErrorMessage = "Password is required")]
    [Display(Name = "Password")]
    public string LPassword {get;set;}

}

