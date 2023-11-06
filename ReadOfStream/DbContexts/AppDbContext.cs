using Microsoft.EntityFrameworkCore;
using ReadOfStream.Models;

namespace ReadOfStream.DbContexts;

public class AppDbContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<TagToUser> TagToUsers { get; set; }
    public DbSet<Tag> Tags { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseSqlServer("YourConnectionStringHere");
    }
}
