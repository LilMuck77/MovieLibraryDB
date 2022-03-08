using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieLibraryDB.Code
{
    public class Show : Media
    {
        
        public int Episode { get; set; }
        public int Season { get; set; }
        public string[] Writers { get; set; }
       
        public override void Display()
        {
            //Write to program and loop the array properties
            Console.Write($" Id: {Id}, Title: {Title}, Episode: {Episode}, Season: {Season}, Writers: ");
            Console.Write($"{Writers[0]}");
            for (int i = 1; i < Writers.Length; i++)
            {
                Console.Write($", {Writers[i]}");
            }
            Console.WriteLine();
           
        }
    }
}
