#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace MtMDemo.Models;
public class Pokemon
{
    [Key]
    public int PokemonId {get;set;}
    [Required]
    public string Name {get;set;}
    [Required]
    public string Icon {get;set;}

    public DateTime CreatedAt {get;set;} = DateTime.Now;
    public DateTime UpdatedAt {get;set;} = DateTime.Now;

    public List<KnownMove> MovesKnown {get;set;} = new List<KnownMove>(); 
}