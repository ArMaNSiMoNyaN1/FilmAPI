﻿namespace FilmAPI.ApiModels;

public class UpdateFilmModel
{
    public int Id { get; set; }
    public string Title { get; set; }
    public int PublishYear { get; set; }
    public string Genre { get; set; }
}