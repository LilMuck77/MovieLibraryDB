using MovieLibraryDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieLibraryDB.Dao
{
    public class MovieRepo : IRepository
    {
        //Dependency injection
        private readonly DataContext _context;

        public MovieRepo()
        {
            //retrieve movie data from DataContext
            _context = new DataContext();
        }
        public List<Media> Get()
        {
            return new List<Media>(_context.Movies);
        }

        public Media Search(string searchString)
        {
            var results = _context.Movies.Where(x => x.Title.Contains(searchString));
            return results.FirstOrDefault();
        }
    }
}
