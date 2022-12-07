#pragma warning disable CS8618
using Microsoft.EntityFrameworkCore;
namespace EFDemo.Models;
public class MyContext : DbContext 
{   
    // This line will always be here. It is what constructs our context upon initialization  
    public MyContext(DbContextOptions options) : base(options) { }    
    // We need to set up all our possible tables
    public DbSet<Song> Songs { get; set; } 
}