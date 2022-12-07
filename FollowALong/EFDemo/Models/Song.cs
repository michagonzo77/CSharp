#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace EFDemo.Models;
public class Song
{
    [Key]
    public int SongId {get;set;}
    [Required]
    public string Title {get;set;}
    [Required]
    [Range(0,2023)]
    public int? Year {get;set;}
    // public int Year {get;set;} = 0;
    [Required]
    public string Genre {get;set;}
    [Required]
    public string Artist {get;set;}
    public DateTime CreatedAt {get;set;} = DateTime.Now;
    public DateTime UpdatedAt {get;set;} = DateTime.Now;
}