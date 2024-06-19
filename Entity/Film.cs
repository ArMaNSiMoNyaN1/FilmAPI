namespace FilmAPI.Entity;

public class Film
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Director { get; set; }
    public int PublishYear { get; set; }
    public string Genre { get; set; }
    public List<Actors> Actors { get; set; } = new List<Actors>();
}