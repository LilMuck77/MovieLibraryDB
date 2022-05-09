using MovieLibraryDB.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieLibraryDB.Services
{
    public class PagingSystem
    {
        public PagingSystem()
        {

            using (var context = new MovieContext())
            {


                Console.WriteLine("1) To display all.");
                Console.WriteLine("2) To display a number of movies.");
                Console.WriteLine("3) To enter paging system.");
                int usersChoice = Int32.Parse(Console.ReadLine());
                var movieList = context.Movies.ToList();

                var pageSize = 50;
                var page = 1;
                var maxPageSize = movieList.Count / 50;
                var totalMovies = movieList.Count;

                if (usersChoice == 1)
                {
                    foreach (var movie in context.Movies)
                    {
                        Console.WriteLine($"{movie.Id}, {movie.Title}");
                    }
                }
                else if (usersChoice == 2)
                {

                    Console.WriteLine("Enter how many movies to display");
                    string numberOfMoviesString = Console.ReadLine();
                    int numberOfMovies = Int32.Parse(numberOfMoviesString);
                    foreach (var movie in movieList.Take(numberOfMovies).Skip(page - 1))
                    {
                        Console.WriteLine($"Results...");
                        Console.WriteLine($"{movie.Id}, {movie.Title}");

                    }





                }
                else if (usersChoice == 3)
                {
                   


                    int pageNumber = 1;
                    do
                    {
                        foreach (var m in movieList.Skip((pageNumber - 1) * pageSize).Take(pageSize))
                        {

                            Console.WriteLine($"{m.Id}, {m.Title}");


                        }
                        Console.WriteLine($"");
                        Console.WriteLine($"Current Page:{pageNumber} out of {maxPageSize}");
                        Console.WriteLine("1) Previos page");
                        Console.WriteLine("2) Next page");
                        Console.WriteLine("3) Page Choice");
                        Console.WriteLine("4) Exit System");
                        usersChoice = Int32.Parse(Console.ReadLine());
                        if (usersChoice == 1 && pageNumber > 1) { --pageNumber; }
                        else if (usersChoice == 2 && pageNumber < maxPageSize) { ++pageNumber; }
                        else if (usersChoice == 3)
                        {
                            Console.WriteLine("Enter Page Number:");
                            pageNumber = Int32.Parse(Console.ReadLine());
                            if (pageNumber == 0 || pageNumber < 0 || pageNumber > maxPageSize)
                            {
                                do
                                {
                                    Console.WriteLine("ERROR: Page number cannot be: 0,");
                                    Console.WriteLine("A negative number,");
                                    Console.WriteLine("Greater than the max page size,");
                                    Console.WriteLine("Try again.");
                                    pageNumber = Int32.Parse(Console.ReadLine());

                                }
                                while (pageNumber == 0 || pageNumber < 0 || pageNumber > maxPageSize);

                            }



                        }
                    }
                    while (usersChoice != 4);


                }
                else { Console.WriteLine("ERROR"); }



            }





        }

    }
}

