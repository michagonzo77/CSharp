#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace MtMDemo.Models;
public class Move
{
    [Key]
    public int MoveId {get;set;}
    public string Name {get;set;}
    public string MoveType {get;set;}

    public DateTime CreatedAt {get;set;} = DateTime.Now;
    public DateTime UpdatedAt {get;set;} = DateTime.Now;

    public List<KnownMove> PokemonWhoKnowMove {get;set;} = new List<KnownMove>(); 
}