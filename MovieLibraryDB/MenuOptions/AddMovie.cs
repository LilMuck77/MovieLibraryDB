using MovieLibraryDB.Context;
using MovieLibraryDB.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieLibraryDB.Services
{
    public class AddMovie
    {
        public AddMovie()
        {
            Console.WriteLine("Add movie selected:");
            Console.WriteLine("Enter the movie title: ");
            string newMovieTitle = Console.ReadLine();


            using (var context = new MovieContext())
            {
                var doesItExist = context.Movies.FirstOrDefault(x => x.Title == newMovieTitle);

                if (!string.IsNullOrEmpty(newMovieTitle) && !string.IsNullOrWhiteSpace(newMovieTitle) && doesItExist?.Title != newMovieTitle)
                {
                    var movie = new Movie();
                    //handle format

                    Console.WriteLine($"Enter release date: (Format: MM/DD/YYYY");
                    string newReleaseDate = Console.ReadLine();


                    movie.Title = newMovieTitle;
                    movie.ReleaseDate = Convert.ToDateTime(newReleaseDate);


                    context.Movies.Add(movie);
                    context.SaveChanges();

                    var myNewMovie = context.Movies.FirstOrDefault(x => x.Title == newMovieTitle);
                    Console.WriteLine($"Movie Added...\nId: {movie.Id} \nTitle: {movie.Title} \nRealase Date: {movie.ReleaseDate:MM/dd/yyyy}");

                }
                else
                {
                    Console.WriteLine("Title cannot be null, empty or it already exists!");
                }

            }

        }
    }
}
