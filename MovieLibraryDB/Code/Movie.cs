using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieLibraryDB.Code
{

    


    public class Movie : Media
    {
        
        public string[] Genres { get; set; }

        
        public override void Display()
        {

            List<long> IdList = new List<long>();
            List<string> TitleList = new List<string>();
            List<string> GenreList = new List<string>();
            string MovieListFile = "movies10.csv";


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



            for (int i = 0; i < IdList.Count; i++)
            {
                Console.WriteLine($"Id: {IdList[i]}");
                Console.WriteLine($"Title: {TitleList[i]}");
                Console.WriteLine($"Genre(s): {GenreList[i]}");
                Console.WriteLine();
            }
        }
    }
}
