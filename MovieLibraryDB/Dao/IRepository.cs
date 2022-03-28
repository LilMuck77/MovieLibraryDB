using MovieLibraryDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieLibraryDB.Dao
{
    public interface IRepository
    {
        List<Media> Get();

        Media Search(string searchString);
    }
}
