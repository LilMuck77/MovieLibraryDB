using MovieLibraryDB.Dao;
using MovieLibraryDB.Interfaces;
using MovieLibraryDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieLibraryDB.Services
{
    public class OrchestratorService : IOrchestrator
    {

        private readonly List<Media> _mediaList = new();
        private readonly MovieRepo _movieRepository;
        private readonly ShowRepo _showRepository;
        private readonly VideoRepo _videoRepository;

        public OrchestratorService()
        {
            _movieRepository = new MovieRepo();
            _videoRepository = new VideoRepo();
            _showRepository = new ShowRepo();
        }

        public List<Media> SearchAllMedia(string searchString)
        {
            _mediaList.Add(_movieRepository.Search(searchString));
            _mediaList.Add(_videoRepository.Search(searchString));
            _mediaList.Add(_showRepository.Search(searchString));

            return _mediaList;
        }
    }
}
