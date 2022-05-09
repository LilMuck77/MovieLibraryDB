using Microsoft.EntityFrameworkCore;
using MovieLibraryDB.Context;
using MovieLibraryDB.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieLibraryDB.Services
{
    public class Search
    {
        public Search()
        {


            Console.WriteLine("Enter the Title of the Movie to search.");
            string searchedMovie = Console.ReadLine();



            using (var context = new MovieContext())
            {


                if (!string.IsNullOrEmpty(searchedMovie) && !string.IsNullOrWhiteSpace(searchedMovie))
                {
                    var myMovie = context.Movies.Include(x => x.MovieGenres)
                    .ThenInclude(x => x.Genre)
              .FirstOrDefault(mov => mov.Title.Contains(searchedMovie));
                    myMovie = context.Movies
                   .FirstOrDefault(mov => mov.Title.Contains(searchedMovie));


                    Console.WriteLine($"Movie: {myMovie?.Title} {myMovie?.ReleaseDate:MM/dd/yyyy}");

                    Console.WriteLine("Genres:");

                    foreach (var genre in myMovie?.MovieGenres ?? new List<MovieGenre>())
                    {
                        Console.WriteLine($"\t{genre.Genre.Name}");
                    }




                }

                else
                {
                    Console.WriteLine("Search cannot be null, empty or the movie does not exist!");

                }

            }

        }
    }
}
