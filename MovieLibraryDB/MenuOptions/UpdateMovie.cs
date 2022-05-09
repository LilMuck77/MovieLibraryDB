using MovieLibraryDB.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieLibraryDB.Services
{
    public class UpdateMovie
    {
        public UpdateMovie()
        {


            //handle if exist, null, and whitespace
            Console.WriteLine("Enter Movie Title to Update: ");
            var movieTitle = Console.ReadLine();



            using (var context = new MovieContext())
            {
                var doesItExist = context.Movies.FirstOrDefault(x => x.Title == movieTitle);

                if (!string.IsNullOrEmpty(movieTitle) && !string.IsNullOrWhiteSpace(movieTitle) && doesItExist?.Title == movieTitle)
                {

                    Console.WriteLine("Enter Updated Movie Title: ");
                    var movieTitleUpdate = Console.ReadLine();

                    var updateMovie = context.Movies.FirstOrDefault(x => x.Title == movieTitle);
                    Console.WriteLine($"Movie Before Update - ID: {updateMovie.Id}, Title: {updateMovie.Title}");

                    updateMovie.Title = movieTitleUpdate;
                    Console.WriteLine($"Movie After Update - ID: {updateMovie.Id}, Title: {updateMovie.Title}");


                    context.Movies.Update(updateMovie);
                    context.SaveChanges();

                }
                else
                {
                    Console.WriteLine("Title cannot be null, empty or it doesn't exist!");

                }


            }

        }
    }
}
