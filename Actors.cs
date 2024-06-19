using FilmAPI.Entity;

namespace FilmAPI;

public class Actors
{
    public int Id { get; set; }
    public string Name { get; set; } 
    public string SurName { get; set; } 
    public int FilmId { get; set; } 
    public Film Film { get; set; }

}