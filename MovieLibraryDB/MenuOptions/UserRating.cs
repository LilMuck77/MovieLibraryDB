using MovieLibraryDB.Context;
using MovieLibraryDB.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieLibraryDB.Services
{
    public class UserRating
    {

        public UserRating()
        {
            using (var context = new MovieContext())
            {
               
                Console.WriteLine("Enter the User's Id number?");
                int usersId = Int32.Parse(Console.ReadLine());

                Console.WriteLine("Enter the movie title you wish to rate.");
                string theMovie = Console.ReadLine();

                Console.WriteLine("Enter the rating between 1-10.");
                int ratingMovie = Int32.Parse(Console.ReadLine());




                var user = context.Users.FirstOrDefault(u => u.Id == usersId);
                var movie = context.Movies.FirstOrDefault(m => m.Title.Contains(theMovie));

              
                var userMovie = new UserMovie()
                {
                    Rating = ratingMovie,
                    RatedAt = DateTime.Now
                };

                userMovie.User = user;
                userMovie.Movie = movie;

                // db.Users.Add(user);
                context.UserMovies.Add(userMovie);

                context.SaveChanges();

                Console.WriteLine($"User's Information - Id: {user.Id} and Age: {user.Age}\n Gender: {user.Gender} and Occupation: {user.Occupation.Name}");
                Console.WriteLine($"Movie's Information - Id: {movie.Id} and Movie's Title: {movie.Title}");
                Console.WriteLine($"Rating of Movie: {ratingMovie} and Rated at: {userMovie.RatedAt: MM/dd/yyyy}");



            }
        }
    }
}
