using FilmAPI.Data;
using FilmAPI.Entity;
using FilmAPI.Service.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FilmAPI.Service.Implementations;

public class FilmService(FilmContext context) : IFilmService
{
    private readonly FilmContext _context = context;

    public async Task<List<Film>> GetAll()
    {
        var films = await _context.Films.ToListAsync();
        return films;
    }

    public async Task<Film?> GetById(int id)
    {
        return await _context.Films.FirstOrDefaultAsync(x => x.Id == id);
    }
    
    public async Task<Film> Add(Film film)
    {
        var result = context.Films.Add(film);
        await context.SaveChangesAsync();
        return (await GetById(result.Entity.Id))!;
    }

    public async Task<Film?> Update(Film updateFilm)
    {
        var film = await _context.Films.FindAsync(updateFilm.Id);
        {
            if (film is null) return null;
            {
                film.Id = updateFilm.Id;
                film.Title = updateFilm.Title;
                film.Director = updateFilm.Director;
                film.PublishYear = updateFilm.PublishYear;
                film.Genre = updateFilm.Genre;
                film.actors = updateFilm.actors;

                _context.Films.Update(film);
                await _context.SaveChangesAsync();
                return film;
            }
        }
    }

    public async Task<bool> Delete(int id)
    {
        var film = await _context.Films.FindAsync(id);
        if (film is null) return false;
        _context.Films.Remove(film);
        await _context.SaveChangesAsync();
        return true;
    }
}