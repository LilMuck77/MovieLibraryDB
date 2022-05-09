using MovieLibraryDB.Context;
using MovieLibraryDB.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieLibraryDB.Services
{
    public class AddUser
    {

        public AddUser()
        {
            using (var context = new MovieContext())
            {
                var User = new User(); 
                var Occupation = new Occupation();

                Console.WriteLine($"Enter Age.");
                    int age = Int32.Parse(Console.ReadLine());
               
                Console.WriteLine($"Enter Gender - M for Male, F for Female");
                string gender = Console.ReadLine().ToUpper();


                Console.WriteLine($"Enter Zipcode");
                string zipcode = Console.ReadLine();

                Console.WriteLine($"Enter your occupation");
                string occupation = Console.ReadLine();

               

                User.Age = age; 
                User.Gender = gender;
                User.ZipCode = zipcode;
                Occupation.Name = occupation;
                context.Occupations.Add(Occupation);
                User.Occupation = Occupation;

                context.Users.Add(User);
                context.SaveChanges();

                var myNewUser = context.Users.FirstOrDefault(x => x.Occupation.Name == occupation);
                Console.WriteLine("Adding new user... ");
                Console.WriteLine($"Id: {myNewUser.Id}\n Age: {myNewUser.Age}\n Gender: {myNewUser.Gender}\n Zipcode: {myNewUser.ZipCode}\n Occupation: {myNewUser.Occupation.Name}");



                /*// build user object (not database)
                var user = context.Users.FirstOrDefault(u => u.Id == 943);
                var movie = context.Movies.FirstOrDefault(m => m.Title.Contains("Babe"));

                // build user/movie relationship object (not database)
                var userMovie = new UserMovie()
                {
                    Rating = 2,
                    RatedAt = DateTime.Now
                };

                // set up the database relationships
                userMovie.User = user;
                userMovie.Movie = movie;

                // db.Users.Add(user);
                context.UserMovies.Add(userMovie);

                // commit
                context.SaveChanges();*/

            }

        }
    }
}
