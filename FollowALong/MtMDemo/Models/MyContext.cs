#pragma warning disable CS8618
using Microsoft.EntityFrameworkCore;
namespace MtMDemo.Models;
public class MyContext : DbContext 
{   
    public MyContext(DbContextOptions options) : base(options) { }    
    public DbSet<Pokemon> Pokemon { get; set; } 
    public DbSet<Move> Moves { get; set; } 
    public DbSet<KnownMove> KnownMoves {get;set;}
}
