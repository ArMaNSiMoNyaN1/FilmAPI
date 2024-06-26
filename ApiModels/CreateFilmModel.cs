﻿namespace FilmAPI.ApiModels;

public class CreateFilmModel
{
    public string Title { get; set; }
    public string Director { get; set; }
    public int PublishYear { get; set; }
    public string Genre { get; set; }
    public List<Actors> actors;
}