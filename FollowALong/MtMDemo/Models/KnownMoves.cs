#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace MtMDemo.Models;
public class KnownMove
{
    [Key]
    public int KnownMoveId {get;set;}
    // Track the IDs of our joining models
    public int PokemonId {get;set;}
    public int MoveId {get;set;}
    
    // Navigation property
    public Pokemon? Pokemon {get;set;}
    public Move? Move {get;set;}
    
    public DateTime CreatedAt {get;set;} = DateTime.Now;
    public DateTime UpdatedAt {get;set;} = DateTime.Now;
}