#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace DojoSurveyModel.Models;

public class Survey
{
    [Required(ErrorMessage = "Null makes me nervous!")]
    [MinLength(2)]
    public string Name {get;set;}
    [Required]
    public string Location {get;set;}
    [Required]
    [MinLength(2)]
    public string Language {get;set;}
    [MinLength(20)]
    public string? Comment {get;set;}
}