using MovieLibraryDB.DataModels;
using MovieLibraryDB.Interfaces;
using Newtonsoft.Json;
using MovieLibraryDB.Dao;
using MovieLibraryDB.Context;
using System.Linq;

namespace MovieLibraryDB.Services;



public class MainService : IMainService
{


    public void Invoke()
    {




        string myMenuChoice;
        do
        {
            //display menu
            Console.WriteLine("1) Search Movies ");
            Console.WriteLine("2) Add Movie");
            Console.WriteLine("3) Update Movie");
            Console.WriteLine("4) Delete Movie");
            Console.WriteLine("Press enter or any other key to quit");

            myMenuChoice = Console.ReadLine();



            if (myMenuChoice == "1")
            {
                //SEARCH MOVIE

                //handle empty nulls for ALL
                //handle if exist
                //search all or by user count



                string searchMovie;
                Console.WriteLine("Enter the Title of the Movie to search.");
                searchMovie = Console.ReadLine();
                


                using (var context = new MovieContext())
                {
                    var doesItExist = context.Movies.FirstOrDefault(x => x.Title == searchMovie);

                    if (!string.IsNullOrEmpty(searchMovie) && !string.IsNullOrWhiteSpace(searchMovie))// && doesItExist?.Title == searchMovie)
                    {
                        var myMovieSearch = context.Movies.ToList().Where(x => x.Title.Contains(searchMovie, StringComparison.CurrentCultureIgnoreCase));                        // Console.WriteLine($"ID: {myMovieSearch.Id}, Title: {myMovieSearch.Title}, Release Date: {myMovieSearch.ReleaseDate}");

                        //multiple search diplay
                        Console.WriteLine("Searching Movies");
                        foreach (var movie in myMovieSearch)
                        {
                            Console.WriteLine($"Id: {movie.Id}, Title: {movie.Title}, Realase Date: {movie.ReleaseDate}");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Search cannot be null or empty or the movie does not exist!");

                    }

                }



            }
            else if (myMenuChoice == "2")
            {
                //ADD MOVIE
                Console.WriteLine("Add movie selected:");
                Console.WriteLine("Enter the movie title: ");
                string newMovieTitle = Console.ReadLine();

                //handle duplicate
                //make sure not duplicate, string match


                /* if (movie.Title.Contains(newMovieTitle))
                 {
                     Console.WriteLine("Movie title already exists in file data.");

                 }*/

                // else

                using (var context = new MovieContext())
                {
                    var doesItExist = context.Movies.FirstOrDefault(x => x.Title == newMovieTitle);

                    if (!string.IsNullOrEmpty(newMovieTitle) && !string.IsNullOrWhiteSpace(newMovieTitle) && doesItExist?.Title != newMovieTitle)
                    {
                        var movie = new Movie();
                        //handle format

                        Console.WriteLine("Enter release date: (Format: DD/MM/YYYY) ");
                        string newReleaseDate = Console.ReadLine();


                        movie.Title = newMovieTitle;
                        movie.ReleaseDate = Convert.ToDateTime(newReleaseDate);


                        context.Movies.Add(movie);
                        context.SaveChanges();

                        var myNewMovie = context.Movies.FirstOrDefault(x => x.Title == newMovieTitle);
                        Console.WriteLine($"Added Movie - Id: {movie.Id}, Title: {movie.Title}, Realase Date: {movie.ReleaseDate}");

                    }
                    else
                    {
                        Console.WriteLine("Title cannot be null, empty or it already exists!");
                    }

                }



            }

            else if (myMenuChoice == "3")
            {
                //UPDATE MOVEI

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
            else if (myMenuChoice == "4")
            {
                //DELETE MOVIE
                Console.WriteLine("Enter Movie Title to Delete: ");
                var movieToDelete = Console.ReadLine();

                using (var context = new MovieContext())
                {
                    var doesItExist = context.Movies.FirstOrDefault(x => x.Title == movieToDelete);

                    if (!string.IsNullOrEmpty(movieToDelete) && !string.IsNullOrWhiteSpace(movieToDelete) && doesItExist?.Title == movieToDelete)
                    { 
                         var deleteMovie = context.Movies.FirstOrDefault(x => x.Title == movieToDelete);
                    Console.WriteLine($"Deleting movie with ID: {deleteMovie?.Id} and Title: {deleteMovie?.Title}");

                    // verify exists first
                    context.Movies.Remove(deleteMovie);
                    context.SaveChanges();
                    }
                   
                }


            }



        } while (myMenuChoice == "1" || myMenuChoice == "2" || myMenuChoice == "3" || myMenuChoice == "4");

        Console.WriteLine("Thanks for using the Movie Library!");



    }



}

