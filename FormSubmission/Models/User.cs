#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace FormSubmission.Models;

public class User
{
    [Required(ErrorMessage = "Null makes me nervous!")]
    [MinLength(2)]
    public string Name {get;set;}
    [Required]
    [MinLength(2)]
    [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$")]
    public string Email {get;set;}
    [Required]
    [Birthday]
    public DateTime Date {get;set;}
    [Required]
    [MinLength(8)]
    public string Password {get;set;}
    [Required]
    [Favorite]
    public int? Favorite {get;set;}
}