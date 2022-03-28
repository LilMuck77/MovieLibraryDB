using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieLibraryDB.Models
{

    public class Movie : Media
    {

        public string[] Genres { get; set; }


        public override string ToString()
        {
            return $"{Id}: {Title}";
        }
        public override void Display()
        {
            //Write to program and loop the array properties
            Console.Write($" Id: {Id}, Title: {Title}, Genre(s): ");
            Console.Write($"{Genres[0]}");
            for (int i = 1; i < Genres.Length; i++)
            {
                Console.Write($", {Genres[i]}");
            }
            Console.WriteLine();


        }
    }
}
