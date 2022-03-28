using MovieLibraryDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieLibraryDB.Interfaces
{
    public interface IOrchestrator
    {
        List<Media> SearchAllMedia(string searchString);
    }
}
