using MovieLibraryDB.DataModels;
using MovieLibraryDB.Interfaces;
using Newtonsoft.Json;
using MovieLibraryDB.Dao;
using MovieLibraryDB.Context;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MovieLibraryDB.MenuOptions;

namespace MovieLibraryDB.Services;



public class MainService : IMainService
{


    public void Invoke()
    {




        string myMenuChoice;
        do
        {
            //display menu
            Console.WriteLine("1) Search Movies");
            Console.WriteLine("2) Add Movie");
            Console.WriteLine("3) Update Movie");
            Console.WriteLine("4) Delete Movie");
            Console.WriteLine("5) Display Movies");
            Console.WriteLine("6) Add New User");
            Console.WriteLine("7) Rate a Movie");
            Console.WriteLine("8) List Top Rated Movie");
            Console.WriteLine("Press enter or any other key to quit");

            myMenuChoice = Console.ReadLine();



            if (myMenuChoice == "1")
            {
                //SEARCH MOVIE
                Search search = new Search();


            }
            else if (myMenuChoice == "2")
            {
                //ADD MOVIE
                AddMovie add = new AddMovie();

            }

            else if (myMenuChoice == "3")
            {
                //UPDATE MOVIE
                UpdateMovie update = new UpdateMovie();

            }
            else if (myMenuChoice == "4")
            {
                //DELETE MOVIE
                DeleteMovie delete = new DeleteMovie();


            }
            else if (myMenuChoice == "5")
            {
                //Display movies
                PagingSystem pagingSystem = new PagingSystem();



            }
            else if (myMenuChoice == "6")
            {
                //Add New User
                AddUser addUser = new AddUser();



            }
            else if (myMenuChoice == "7")
            {
                //Add User rating
                UserRating userRating = new UserRating();
            }
            else if (myMenuChoice == "8")
            {
                //List Top Rated
                ListTop listTop = new ListTop();
            }



        } while (myMenuChoice == "1" || myMenuChoice == "2" || myMenuChoice == "3" || myMenuChoice == "4" || myMenuChoice == "5" || myMenuChoice == "6" || myMenuChoice == "7");

        Console.WriteLine("Thanks for using the Movie Library and come again!");



    }



}

