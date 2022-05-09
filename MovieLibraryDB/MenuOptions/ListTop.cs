using MovieLibraryDB.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieLibraryDB.MenuOptions
{
    public class ListTop
    {

        public ListTop() {
            using (var context = new MovieContext())
            { 
            
                var userMovieTopRated = context.UserMovies.OrderBy(x => x.Rating).ToList();     
                var user = context.Users.ToList();
                foreach (var u in user)
                {
                    Console.WriteLine($"{u.Occupation.Name}");
                    foreach (var m in userMovieTopRated)
                    {
                        Console.WriteLine($"{m.Rating}");
                    }
                
                }



            }
        
        }
    }
}
