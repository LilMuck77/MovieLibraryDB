using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieLibraryDB.Code
{
    public class Video : Media
    {
        public string Format{ get; set; }
        public int Length { get; set; }
        public int[] Regions { get; set; }

        public override void Display()
        {
            List<long> IdList = new List<long>();
            List<string> TitleList = new List<string>();
            List<string> FormatList = new List<string>();
            List<int> LengthList = new List<int>();
            //Had to switch to string, what about int?
            List<string> RegionsList = new List<string>();

            string VideoListFile = "videos.csv";


            StreamReader sr = new StreamReader(VideoListFile);

            //dont read header
            sr.ReadLine();

            while (!sr.EndOfStream)
            {
                string theVideoElements = sr.ReadLine();
                int index = theVideoElements.IndexOf('"');

                //if no quote, then no comma
                if (index == -1)
                {
                    //split the movie elements by the comma into an array to hold
                    string[] videoElements = theVideoElements.Split(',');
                    //add 1st array element to movie id list
                    IdList.Add(long.Parse(videoElements[0]));
                    //add 2nd array element to movie title list
                    TitleList.Add(videoElements[1]);
                    //add 3rd array element to movie genre list
                    // replace "|" with ", "
                    FormatList.Add(videoElements[2].Replace("|", ","));
                    //4th element
                    LengthList.Add(int.Parse(videoElements[3]));
                    //5th element
                    //Could not convert int to string. So had to switch. Can you do the other way.
                    RegionsList.Add(videoElements[4].Replace("|", ","));
                    





                }
                //else statement if title does have quotes



                //MIGHT NOT NEED BECAUSE VIDEOS MIGHT NOT HAVE QUOTES BUT THIS COULD BE AN EXCEPTION HABDLER IF IT DOES
                /* else
                 {
                     //1st element
                     IdList.Add(long.Parse(theVideoElements.Substring(0, index - 1)));                                       
                     theVideoElements = theVideoElements.Substring(index + 1);

                     //2nd element
                     index = theVideoElements.IndexOf('"');                  
                     TitleList.Add(theVideoElements.Substring(0, index));
                     theVideoElements = theVideoElements.Substring(index + 2);

                     //3rd element
                     index = theVideoElements.IndexOf(',');
                     FormatList.Add(theVideoElements.Substring(0, index));
                     theVideoElements = theVideoElements.Substring(index + 3);

                     //4th element
                     index = theVideoElements.IndexOf(',');
                     LengthList.Add(int.Parse(theVideoElements.Substring(0, index)));
                     theVideoElements = theVideoElements.Substring(index + 4);

                     //5th element                 
                     RegionsList.Add(int.Parse(theVideoElements.Replace("|", ",")));

                 }*/
            }
            //close video file when done
            sr.Close();



            for (int i = 0; i < IdList.Count; i++)
            {
                Console.WriteLine($"Id: {IdList[i]}");
                Console.WriteLine($"Title: {TitleList[i]}");
                Console.WriteLine($"Format: {FormatList[i]}");
                Console.WriteLine($"Length: {LengthList[i]}");
                Console.WriteLine($"Regions: {RegionsList[i]}");
                Console.WriteLine();
            }
           
            
        }
    }
}
