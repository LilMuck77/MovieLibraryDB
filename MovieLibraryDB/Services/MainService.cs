using MovieLibraryDB.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieLibraryDB.Services
{
    public class MainService : IMainService
    {

        private readonly ITesting _test1;

        public MainService(ITesting testing) { 
        _test1 = testing;
        }
        private readonly IFileService _fileService;
        public MainService(IFileService fileService)
        {
            _fileService = fileService;
        }

        public void Invoke()
        {
            _test1.test1();
        }
    }
}
