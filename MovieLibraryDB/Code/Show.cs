using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieLibraryDB.Code
{
    public class Show : Media
    {
        //Dont think I used these and dont know if I need them either.
        public int Episode { get; set; }
        public int Season { get; set; }
        public string[] Writers { get; set; }
       
        public override void Display()
        {
            List<long> IdList = new List<long>();
            List<string> TitleList = new List<string>();
            List<int> EpisodeList = new List<int>();
            List<int> SeasonList = new List<int>();
            List<string> WritersList = new List<string>();

            string ShowListFile = "shows.csv";


            StreamReader sr = new StreamReader(ShowListFile);

            //dont read header
            sr.ReadLine();

            while (!sr.EndOfStream)
            {
                string theShowElements = sr.ReadLine();
                int index = theShowElements.IndexOf('"');

                //if no quote, then no comma
                if (index == -1)
                {
                    //split the movie elements by the comma into an array to hold
                    string[] showElements = theShowElements.Split(',');
                    //add 1st array element to movie id list
                    IdList.Add(long.Parse(showElements[0]));
                    //add 2nd array element to movie title list
                    TitleList.Add(showElements[1]);
                    //add 3rd array element to movie genre list
                    // replace "|" with ", "
                    EpisodeList.Add(int.Parse(showElements[2]));
                    //4th element
                    SeasonList.Add(int.Parse(showElements[3]));
                    //5th element
                    WritersList.Add(showElements[4].Replace("|", ","));


                    

                }
                //else statement if title does have quotes



                //MIGHT NOT NEED BECAUSE SHOWS MIGHT NOT HAVE QUOTES BUT THIS COULD BE AN EXCEPTION HABDLER IF IT DOES
                /*else
                {
                    //1st element
                    IdList.Add(long.Parse(theShowElements.Substring(0, index - 1)));                  
                    theShowElements = theShowElements.Substring(index + 1);

                    //2nd element
                    index = theShowElements.IndexOf('"');                   
                    TitleList.Add(theShowElements.Substring(0, index));
                    theShowElements = theShowElements.Substring(index + 2);

                    //3rd element
                    index = theShowElements.IndexOf(',');
                    EpisodeList.Add(int.Parse(theShowElements.Substring(0, index)));                  
                    theShowElements = theShowElements.Substring(index + 3);

                    //4th element
                    index = theShowElements.IndexOf(',');
                    SeasonList.Add(int.Parse(theShowElements.Substring(0, index))); 
                    theShowElements = theShowElements.Substring(index + 4);

                    //5th element                 
                    WritersList.Add(theShowElements.Replace("|", ","));

                }*/
            }
            //close show file when done
            sr.Close();



            for (int i = 0; i < IdList.Count; i++)
            {
                Console.WriteLine($"Id: {IdList[i]}");
                Console.WriteLine($"Title: {TitleList[i]}");
                Console.WriteLine($"Episode: {EpisodeList[i]}");
                Console.WriteLine($"Season: {SeasonList[i]}");
                Console.WriteLine($"Writers: {WritersList[i]}");
                Console.WriteLine();
            }

            
        }
    }
}
