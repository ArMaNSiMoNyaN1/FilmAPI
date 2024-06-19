using FilmAPI.Entity;
using Microsoft.EntityFrameworkCore;

namespace FilmAPI.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }

    public DbSet<Film> Films { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Actors>()
            .HasOne(a => a.Film)      
            .WithMany(f => f.Actors)    
            .HasForeignKey(a => a.FilmId); 

        base.OnModelCreating(modelBuilder);
    }
}