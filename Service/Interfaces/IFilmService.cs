using FilmAPI.Entity;

namespace FilmAPI.Service.Interfaces;

public interface IFilmService
{
    Task<List<Film>> GetAll();

    Task<Film?> GetById(int id);

    Task<Film> Add(Film film);

    Task<Film?> Update(Film updateFilm);

    Task<bool> Delete(int id);
}