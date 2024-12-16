using Models;
namespace Data;
using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        
    }

    public DbSet<Users> Users { get; set; }
    public DbSet<Clubs> Clubs { get; set; }
    public DbSet<Posts> Posts { get; set; }
    public DbSet<Books> Books { get; set; }
    public DbSet<Genre> Genres { get; set; }
    
    public DbSet<ReadingList> ReadingList { get; set; }

    
}