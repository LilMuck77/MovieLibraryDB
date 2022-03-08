using System;
using Microsoft.Extensions.Logging;
using MovieLibraryDB.Code;
using MovieLibraryDB.Interfaces;

namespace MovieLibraryDB.Services;

    public class FileService : IService
    {
    private readonly ILogger<IService> _logger;

    public FileService(ILogger<IService> logger)
    {
        _logger = logger;
    }

    public void Add(Show show)
    {
        throw new NotImplementedException();
    }

    public Show Get(int id)
    {
        throw new NotImplementedException();
    }

    public List<Show> GetAll()
    {
        throw new NotImplementedException();
    }

    public void Read(string name)
    {
        _logger.Log(LogLevel.Information, "Reading");
        Console.WriteLine("*** I am reading");
    }

    public string Write()
    {
        _logger.Log(LogLevel.Information, "Writing");
        Console.WriteLine("*** I am writing");
        return Console.ReadLine();
    }

}
