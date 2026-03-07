using System;
using System.Collections.Generic;
using System.Linq;

// Interface for Film
public interface IFilm
{
    string Title { get; set; }
    string Director { get; set; }
    int Year { get; set; }
}

// Film class
public class Film : IFilm
{
    public string Title { get; set; }
    public string Director { get; set; }
    public int Year { get; set; }

    public Film(string title, string director, int year)
    {
        Title = title;
        Director = director;
        Year = year;
    }
}

// Interface for FilmLibrary
public interface IFilmLibrary
{
    void AddFilm(IFilm film);
    void RemoveFilm(string title);
    List<IFilm> GetFilms();
    List<IFilm> SearchFilms(string query);
    int GetTotalFilmCount();
}

// FilmLibrary class
public class FilmLibrary : IFilmLibrary
{
    private List<IFilm> _films = new List<IFilm>();

    // Add film
    public void AddFilm(IFilm film)
    {
        _films.Add(film);
    }

    // Remove film by title
    public void RemoveFilm(string title)
    {
        var film = _films.FirstOrDefault(f => f.Title.Equals(title, StringComparison.OrdinalIgnoreCase));
        if (film != null)
        {
            _films.Remove(film);
        }
    }

    // Get all films
    public List<IFilm> GetFilms()
    {
        return _films;
    }

    // Search by title or director
    public List<IFilm> SearchFilms(string query)
    {
        return _films
            .Where(f => f.Title.Contains(query, StringComparison.OrdinalIgnoreCase) ||
                        f.Director.Contains(query, StringComparison.OrdinalIgnoreCase))
            .ToList();
    }

    // Total films
    public int GetTotalFilmCount()
    {
        return _films.Count;
    }
}

// Example usage
class Program
{
    static void Main(string[] args)
    {
        FilmLibrary library = new FilmLibrary();

        library.AddFilm(new Film("Inception", "Christopher Nolan", 2010));
        library.AddFilm(new Film("Interstellar", "Christopher Nolan", 2014));
        library.AddFilm(new Film("Titanic", "James Cameron", 1997));

        Console.WriteLine("Total Films: " + library.GetTotalFilmCount());

        Console.WriteLine("\nAll Films:");
        foreach (var film in library.GetFilms())
        {
            Console.WriteLine($"{film.Title} - {film.Director} ({film.Year})");
        }

        Console.WriteLine("\nSearch 'Nolan':");
        foreach (var film in library.SearchFilms("Nolan"))
        {
            Console.WriteLine(film.Title);
        }

        library.RemoveFilm("Titanic");

        Console.WriteLine("\nAfter Removing Titanic:");
        Console.WriteLine("Total Films: " + library.GetTotalFilmCount());
    }
}