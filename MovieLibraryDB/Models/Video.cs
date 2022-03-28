using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieLibraryDB.Models
{
    public class Video : Media
    {
        public string Format { get; set; }
        public int Length { get; set; }
        public int[] Regions { get; set; }

        public override string ToString()
        {
            return $"{Id}: {Title}";
        }
        public override void Display()
        {
            //Write to program and loop the array properties
            Console.Write($" Id: {Id}, Title: {Title}, Format: {Format}, Length: {Length}, Regions: ");
            Console.Write($"{Regions[0]}");
            for (int i = 1; i < Regions.Length; i++)
            {
                Console.Write($", {Regions[i]}");
            }
            Console.WriteLine();

        }
    }
}
