namespace Moovik.Domain.Entities;

public class Movie
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public decimal Imdb { get; set; }

    public Movie()
    {
    }

    public Movie(string name, decimal imdb)
    {
        Name = name;
        Imdb = imdb;
    }

    public Movie(int id, string name, decimal imdb) : this(name, imdb)
    {
        Id = id;
    }
}
