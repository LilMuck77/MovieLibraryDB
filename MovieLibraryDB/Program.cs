using Microsoft.Extensions.DependencyInjection;
using System;
using MovieLibraryDB.Interfaces;
using MovieLibraryDB.Services;
using MovieLibraryDB.DataModels;
using Newtonsoft.Json;


namespace MovieLibraryDB
{
    class Program
    {
        public static void Main(string[] args)
        {
           

            //StartUp broken?
            try
            {
                var startUp = new Startup();
                var serviceProvider = startUp.ConfigureServices();
                var service = serviceProvider.GetService<IMainService>();

                service?.Invoke();
            }

            catch (Exception e)
            {
                Console.Error.WriteLine(e);
            }
          
            
        }
    }
}
