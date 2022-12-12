#pragma warning disable CS8618

using Microsoft.EntityFrameworkCore;
namespace BeltReview.Models;

public class MyContext : DbContext 
{   

    public MyContext(DbContextOptions options) : base(options) { }    
    
    public DbSet<User> Users { get; set; }
    public DbSet<Craft> Crafts { get; set; }
    public DbSet<Order> Orders { get; set; }

}