using MovieLibraryDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieLibraryDB.Dao
{
    public class VideoRepo : IRepository
    {
        private readonly DataContext _context;

        public VideoRepo()
        {
            _context = new DataContext();
        }

        public List<Media> Get()
        {
            return new List<Media>(_context.Videos);
        }

        public Media Search(string searchString)
        {
            var results = _context.Videos.Where(x => x.Title.Contains(searchString));
            return results.FirstOrDefault();
        }
    }
}

