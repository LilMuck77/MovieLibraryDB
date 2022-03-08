using MovieLibraryDB.Code;
using System;


namespace MovieLibraryDB.Interfaces
{
    public interface IService
    {
        void Read(string name);
        string Write();

        void Add(Show show);
        Show Get(int id);
        List<Show> GetAll();
    }
}
