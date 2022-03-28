using MovieLibraryDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieLibraryDB.Dao
{
    public class ShowRepo : IRepository
    {
        private readonly DataContext _context;

        public ShowRepo()
        {
            _context = new DataContext();
        }

        public List<Media> Get()
        {
            return new List<Media>(_context.Shows);
        }

        public Media Search(string searchString)
        {
            var results = _context.Shows.Where(x => x.Title.Contains(searchString));
            return results.FirstOrDefault();
        }
    }
}
