#pragma warning disable CS8618
using Microsoft.EntityFrameworkCore;
namespace MtMDemo.Models;
public class MyViewModel
{
    public Pokemon? Pokemon {get;set;}
    public List<Pokemon> AllPokemon {get;set;}
    public Move Move {get;set;}
    public List<Move> AllMoves {get;set;}
}