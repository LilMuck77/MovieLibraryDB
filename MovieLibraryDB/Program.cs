/*using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NLog.Web;*/

namespace MovieLibraryDB
{
    class Program
    {
        public static void Main(string[] args)
        {

            //Not sure if we need this and not sure how to use it quite yet
            /*IServiceCollection serviceCollection = new ServiceCollection();
            var serviceProvider = serviceCollection
                .AddLogging(x => x.AddConsole())
                .BuildServiceProvider();
            var logger = serviceProvider.GetService<ILoggerFactory>().CreateLogger<Program>();*/

            




            string MovieListFile = "movies.csv";

            //exception handle existing file
            if (!File.Exists(MovieListFile))
            
            {
                ;
                Console.WriteLine("File does not exist : {FILE} ", MovieListFile);
            }
            else
            {
                //jump into file
                //read menu
                string usersChoice;
                do
                {
                    //display menu
                    Console.WriteLine("1) Display Movies ");
                    Console.WriteLine("2) Add A New Movie");
                    //Etra menu Items
                    //Console.WriteLine("3) Display Last Added Movie");
                    //Console.WriteLine("4) Look Up Movie by Id.");
                    Console.WriteLine("Press enter or any other key to quit");

                    usersChoice = Console.ReadLine();
                    
                    List<long> IdList = new List<long>();
                    List<string> TitleList = new List<string>();
                    List<string> GenreList = new List<string>();

                    

                        StreamReader sr = new StreamReader(MovieListFile);

                        //dont read header
                        sr.ReadLine();
                        
                        while (!sr.EndOfStream)
                        {
                            string theMovieElements = sr.ReadLine();
                            int index = theMovieElements.IndexOf('"');
                            
                            //if no quote, then no comma
                            if (index == -1)
                            {
                                //split the movie elements by the comma into an array to hold
                                string[] movieElements = theMovieElements.Split(',');
                                //add 1st array element to movie id list
                                IdList.Add(long.Parse(movieElements[0]));
                                //add 2nd array element to movie title list
                                TitleList.Add(movieElements[1]);
                                //add 3rd array element to movie genre list
                                // replace "|" with ", "
                                GenreList.Add(movieElements[2].Replace("|", ", "));

                            }
                            //else statement if title does have quotes
                            else
                            {
                                //extract movie title by deleting movie id and comma and genre
                                //first movie id and comma
                                IdList.Add(long.Parse(theMovieElements.Substring(0, index - 1)));
                               //get rid of  first quote
                                theMovieElements = theMovieElements.Substring(index + 1);
                                index = theMovieElements.IndexOf('"');
                                //add movie title to movie title list
                                TitleList.Add(theMovieElements.Substring(0, index));
                                theMovieElements = theMovieElements.Substring(index + 2);
                                //add genre from the movie elements
                                GenreList.Add(theMovieElements.Replace("|", ","));

                            }
                        }
                        //close movie file when done
                        sr.Close();

                    
                  
                    

                    if (usersChoice == "1")
                    {
                        //ask user input how many to display


                        string usersNumber;
                        Console.WriteLine("Enter the number of movies to display or enter 0 for all.");
                        usersNumber = Console.ReadLine();
                        int theNumber = Int32.Parse(usersNumber);
                        //handle exception in future for users response

                        if (usersNumber == "0")
                        {

                            for (int i = 0; i < IdList.Count; i++)
                            {
                                Console.WriteLine($"Id: {IdList[i]}");
                                Console.WriteLine($"Title: {TitleList[i]}");
                                Console.WriteLine($"Genre(s): {GenreList[i]}");
                                Console.WriteLine();
                            }
                        }
                        else
                        {
                            for (int i = 0; i < theNumber; i++)
                            {
                                Console.WriteLine($"Id: {IdList[i]}");
                                Console.WriteLine($"Title: {TitleList[i]}");
                                Console.WriteLine($"Genre(s): {GenreList[i]}");
                                Console.WriteLine();
                            }
                        }


                    }
                    else if (usersChoice == "2")
                    {
                        // Add movie to list
                        // get user input for movie title
                        Console.WriteLine("Enter the movie title and (release year).");
                        string usersMovieTitle = Console.ReadLine();
                        //make sure not duplicate, string match
                        if (TitleList.Contains(usersMovieTitle))
                        {
                            Console.WriteLine("Movie title already exists in file data.");
                            //logger.LogInformation("Duplicate movie title {Title}", movieTitle);

                        }
                        else
                        {
                            Console.WriteLine(IdList);
                            //make new movie element
                            long newMovieId = IdList.Max() + 1;
                            //get genres
                            List<string> genresList = new List<string>();
                            string myGenre;
                            do
                            {
                                Console.WriteLine("Enter the movie genres or type 'exit' when finsihed");
                                myGenre = Console.ReadLine();
                                //validate response
                                if (myGenre != "exit" && myGenre.Length > 0)
                                {
                                    genresList.Add(myGenre);
                                }
                               ;



                            } while (myGenre != "exit");
                            //handle response if no genres listed
                            if (genresList.Count == 0)
                            {
                                genresList.Add("N/A");
                            }
                            //join genres by | so when displayed it with split correctly
                            string joinGenres = string.Join("|", genresList);
                            //this part was difficult
                            usersMovieTitle = usersMovieTitle.IndexOf(',') != -1 ? $"\"{usersMovieTitle}\"" : usersMovieTitle;
                            Console.WriteLine($"{newMovieId}, {usersMovieTitle}, {joinGenres}");

                            StreamWriter sw = new StreamWriter(MovieListFile, true);
                            sw.WriteLine($"{newMovieId}, {usersMovieTitle}, {joinGenres}");
                            sw.Close();

                            IdList.Add(newMovieId);
                            TitleList.Add(usersMovieTitle);
                            GenreList.Add(joinGenres);

                        }



                    }

                    //Add menu item for future, but is broken for now.
                    /*else if (usersChoice == "3") {
                        long latest = Convert.ToInt32(IdList.Max());
                    Console.WriteLine($"Last added movie was {IdList.Max()}, {TitleList[Convert.ToInt32(IdList.Max()) - 1]}");
                    }*/

                   /* //future menu code
                    else if (usersChoice == "4") {
                        Console.WriteLine("Enter movie id to look up.");
                        string usersId = Console.ReadLine();
                    
                    }*/


                } while (usersChoice == "1" || usersChoice == "2" || usersChoice == "3" || usersChoice == "4");
            }
        }
    }
}
