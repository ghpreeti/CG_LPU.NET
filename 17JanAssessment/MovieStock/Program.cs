using System;
using System.Collections.Generic;
using System.Linq;

namespace MovieStock
{

public class Program
{
    static List<Movie> MovieList = new List<Movie>();

    
    public static void AddMovie(string MovieDetails)
    {
        // Expected format: Title,Artist,Genre,Ratings
        string[] data = MovieDetails.Split(',');

        Movie movie = new Movie();
        movie.Title = data[0];
        movie.Artist = data[1];
        movie.Genre = data[2];
        movie.Ratings = int.Parse(data[3]);

        MovieList.Add(movie);
    }

    public static List<Movie> ViewMoviesByGenre(string genre)
    {
        return MovieList
               .Where(m => m.Genre == genre)
               .ToList();
    }

    public static List<Movie> ViewMoviesByRating()
    {
        return MovieList
               .OrderByDescending(m => m.Ratings)
               .ToList();
    }

    public static void Main()
    {
        Console.WriteLine("Enter Movie Details");

        for (int i = 0; i < 3; i++)
        {
            Console.Write("Enter Movie Title: ");
            string title = Console.ReadLine();

            Console.Write("Enter Movie Artist: ");
            string artist = Console.ReadLine();

            Console.Write("Enter Movie Genre: ");
            string genre = Console.ReadLine();

            Console.Write("Enter Movie Rating: ");
            int rating = int.Parse(Console.ReadLine());

            // Convert everything into ONE string
            string movieDetails = $"{title},{artist},{genre},{rating}";

            AddMovie(movieDetails);
            Console.WriteLine();
        }

        Console.Write("Enter genre to search: ");
        string searchGenre = Console.ReadLine();

        var genreMovies = ViewMoviesByGenre(searchGenre);
        Console.WriteLine("\nMovies by Genre:");
        foreach (var m in genreMovies)
        {
            Console.WriteLine($"{m.Title} - {m.Ratings}");
        }

        Console.WriteLine("\nMovies by Rating:");
        var ratingMovies = ViewMoviesByRating();
        foreach (var m in ratingMovies)
        {
            Console.WriteLine($"{m.Title} - {m.Ratings}");
        }
    }
}
}
