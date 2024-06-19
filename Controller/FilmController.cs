using AutoMapper;
using FilmAPI.ApiModels;
using FilmAPI.Entity;
using FilmAPI.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FilmAPI.Controller;

[Route("api/[controller]")]
[ApiController]
public class FilmController : ControllerBase
{
    private readonly IFilmService _filmService;
    private readonly IMapper _mapper;

    public FilmController(IFilmService filmService, IMapper mapper)
    {
        _filmService = filmService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<List<GetByFilmModel>>> GetAll()
    {
        var films = await _filmService.GetAll();
        var result = films.Select(x => _mapper.Map<GetByFilmModel>(x)).ToList();
        return Ok(result);
    }

    [HttpGet]
    [Route("{id}")]
    public async Task<ActionResult<GetByIdFilmModel>> GetById(CreateFilmModel filmModel)
    {
        var film = _mapper.Map<Film>(filmModel);
        var newFilm = await _filmService.Add(film);
        var result = _mapper.Map<GetByIdFilmModel>(newFilm);
        return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult<GetByIdFilmModel>> Add(CreateFilmModel filmModel)
    {
        var film = _mapper.Map<Film>(filmModel);
        var newFilm = await _filmService.Add(film);
        var result = _mapper.Map<GetByIdFilmModel>(newFilm);
        return Ok(result);
    }

    [HttpPut]
    public async Task<ActionResult<GetByIdFilmModel>> Update(UpdateFilmModel updateFilmModel)
    {
        var film = _mapper.Map<Film>(updateFilmModel);
        var updatedFilmModel = await _filmService.Update(film);
        if (updatedFilmModel is null) return BadRequest();
        var filmModel = _mapper.Map<GetByIdFilmModel>(film);
        return Ok(filmModel);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var result = await _filmService.Delete(id);
        if (!result) return BadRequest();
        return NoContent();
    }
}