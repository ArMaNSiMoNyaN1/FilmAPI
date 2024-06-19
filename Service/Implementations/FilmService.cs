using FilmAPI.Data;
using FilmAPI.Entity;
using FilmAPI.Service.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FilmAPI.Service.Implementations
{
    public class FilmService : IFilmService
    {
        private readonly DataContext _context;

        public FilmService(DataContext context)
        {
            _context = context;
        }

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
            var result = _context.Films.Add(film);
            await _context.SaveChangesAsync();
            return (await GetById(result.Entity.Id))!;
        }

        public async Task<Film?> Update(Film updateFilm)
        {
            var film = await _context.Films.FindAsync(updateFilm.Id);
            if (film == null)
            {
                return null;
            }

            film.Title = updateFilm.Title;
            film.Director = updateFilm.Director;
            film.PublishYear = updateFilm.PublishYear;
            film.Genre = updateFilm.Genre;
            film.Actors = updateFilm.Actors;

            _context.Films.Update(film);
            await _context.SaveChangesAsync();
            return film;
        }

        public async Task<bool> Delete(int id)
        {
            var film = await _context.Films.FindAsync(id);
            if (film == null)
            {
                return false;
            }

            _context.Films.Remove(film);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}