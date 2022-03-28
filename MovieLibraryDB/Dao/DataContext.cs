using MovieLibraryDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieLibraryDB.Dao
{
    public class DataContext
    {
        private readonly List<Movie> _getMovies = new() {

            new Movie() { Id = 1, Title = "My new Movie Title"}
        };

        private readonly List<Show> _getShows = new()
        {

            new Show() { Id = 1, Title = "My new Show Title" }
        };

        private readonly List<Video> _getVideos = new()
        {

            new Video() { Id = 1, Title = "My new Video Title" }
        };


        public List<Movie> Movies { get; set; }
        public List<Show> Shows { get; set; }
        public List<Video> Videos { get; set; }

        public DataContext()
        {
            Movies = _getMovies;
            Shows = _getShows;
            Videos = _getVideos;
        }
    }
}
