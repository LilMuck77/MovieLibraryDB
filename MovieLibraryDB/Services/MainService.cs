using MovieLibraryDB.Code;
using MovieLibraryDB.Interfaces;
using Newtonsoft.Json;


namespace MovieLibraryDB.Services;


/// <summary>
///     You would need to inject your interfaces here to execute the methods in Invoke()
///     See the commented out code as an example
/// </summary>
public class MainService : IMainService
    {
    private readonly string movieListFile = "Files/movies10.csv";
    private readonly string showListFile = "Files/shows.csv";
    private readonly string videoListFile = "Files/videos.csv";
    private readonly IService _fileService;
    private readonly IService _jsonService;
    public MainService(IService jsonService)
    {
        _jsonService = jsonService;
    }

    // Logic would need to exist to validate inputs and data prior to writing to the file
    // You would need to decide where this logic would reside.
    // Is it part of the FileService or some other service?

    public void Invoke()
        {

        var mediaManager = new MediaManager();
        string movieListFile = "Files/movies.csv";


        //exception handle existing file
        if (!File.Exists(movieListFile))

        {
            ;
            Console.WriteLine("File does not exist : {FILE} ", movieListFile);
        }
        else
        {
            //jump into file
            //read menu
            string myMenuChoice;
            do
            {
                //display menu
                Console.WriteLine("1) Display Movies ");
                Console.WriteLine("2) Add A New Movie");
                Console.WriteLine("3) Media Display Choice");
                Console.WriteLine("Press enter or any other key to quit");

                myMenuChoice = Console.ReadLine();

                List<long> IdList = new List<long>();
                List<string> TitleList = new List<string>();
                List<string> GenreList = new List<string>();



                StreamReader sr = new StreamReader(movieListFile);

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





                if (myMenuChoice == "1")
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
                else if (myMenuChoice == "2")
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

                        StreamWriter sw = new StreamWriter(movieListFile, true);
                        sw.WriteLine($"{newMovieId}, {usersMovieTitle}, {joinGenres}");
                        sw.Close();

                        IdList.Add(newMovieId);
                        TitleList.Add(usersMovieTitle);
                        GenreList.Add(joinGenres);

                    }



                }

                else if (myMenuChoice == "3")
                {
                    Console.WriteLine("Which Media would you like to display? 1) Movie, 2) Show, 3)Video");
                    string myMediaChoice = Console.ReadLine();

                    if (myMediaChoice == "1")
                    {
                        mediaManager.ListMovies();
                    }
                    else if (myMediaChoice == "2")
                    {

                        mediaManager.ListShows();
                    }
                    else if (myMediaChoice == "3")
                    {

                        mediaManager.ListVideos();
                    }


                }



            } while (myMenuChoice == "1" || myMenuChoice == "2" || myMenuChoice == "3");
        }




    }
}

