using MovieLibraryDB.Models;
using MovieLibraryDB.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;


namespace MovieLibraryDB.Services
{
    public class JsonService : IService
    {

        string showFile = "File/shows.csv";
        private List<Show> shows;
        public void Read(string json)
        {
           


            StreamReader sr = new StreamReader(showFile);
            Show show = JsonConvert.DeserializeObject<Show>(json);

            Console.WriteLine(show.Id);
            Console.WriteLine(show.Title);
            Console.WriteLine(show.Episode);
            Console.WriteLine(show.Season);
            Console.WriteLine(show.Writers);
            //string json = JsonConvert.DeserializeObject(showFile);

        }

        public string Write()
        {
            Show show1 = new Show();
            show1.Id = 2;
            show1.Title = "Survivor";
            show1.Episode = 1;
            show1.Season = 20;
            show1.Writers[1] = "Jeff Probst";
            shows.Add(show1);

            string json = JsonConvert.SerializeObject(show1);
            Console.WriteLine(json);
            return json;
        }


        public void Add(Show show)
        {

            /*//open file, write the movie to the file, close file
            StreamWriter sw = new StreamWriter(showFile);
            Show show1 = new Show();
            show1.Id = 2;
            show1.Title = "Survivor";
            show1.Episode = 1;
            show1.Season = 20;
            show1.Writers[1] = "Jeff Probst";
            shows.Add(show1);

            string json = JsonConvert.SerializeObject(show1);
            Console.WriteLine(json);*/
            


        }
        public Show Get(int id)
        {
            //open the file, retrieve the record, return the record
            StreamReader showReader = new StreamReader(showFile);
            showReader.ReadLine();
            Show result = new Show();
            int showCount = 0;
            //Read video list until at end
            while (!showReader.EndOfStream)
            {

                string ElementsOfShowObjeect = showReader.ReadLine();
                string[] arrayOfShowElements = ElementsOfShowObjeect.Split(',');
                result.Id = int.Parse(arrayOfShowElements[0]);
                ;

                showCount += 1;

                
                
            }
           // result = JsonConvert.DeserializeObject(result);
            return result;

        }
         public List<Show> GetAll()
            {
                // open the file
                //retrieve All records
                // return the records
                return new List<Show>();
            }
       

    }
}