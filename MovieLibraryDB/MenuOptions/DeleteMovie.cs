using MovieLibraryDB.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieLibraryDB.Services
{
    public class DeleteMovie
    {
        public DeleteMovie()
        {
            Console.WriteLine("Enter Movie Title to Delete: ");
            var movieToDelete = Console.ReadLine();

            using (var context = new MovieContext())
            {
                var doesItExist = context.Movies.FirstOrDefault(x => x.Title == movieToDelete);

                if (!string.IsNullOrEmpty(movieToDelete) && !string.IsNullOrWhiteSpace(movieToDelete) && doesItExist?.Title == movieToDelete)
                {
                    var deleteMovie = context.Movies.FirstOrDefault(x => x.Title == movieToDelete);
                    Console.WriteLine($"Deleting movie...\n ID: {deleteMovie?.Id} \n Title: {deleteMovie?.Title}");

                    // verify exists first
                    context.Movies.Remove(deleteMovie);
                    context.SaveChanges();
                }

            }

        }
    }
}
