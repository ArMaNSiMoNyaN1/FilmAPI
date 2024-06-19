using FilmAPI.Entity;
using Microsoft.EntityFrameworkCore;

namespace FilmAPI.Data;

public class FilmContext : DbContext
{
    public FilmContext(DbContextOptions<FilmContext> options) : base(options)
    {
    }

    public DbSet<Film> Films { get; set; }

}