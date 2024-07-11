namespace GameAppWebAPI.Helpers;

using Microsoft.EntityFrameworkCore;
using GameAppWebAPI.Entities;

public class DataContext:DbContext
{        
    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseInMemoryDatabase("GameDatabase");
    }

    public DbSet<Game> Games { get; set; }

}
