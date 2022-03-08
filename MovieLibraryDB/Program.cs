using Microsoft.Extensions.DependencyInjection;
using System;
using MovieLibraryDB.Interfaces;
using MovieLibraryDB.Services;
using MovieLibraryDB.Code;
using Newtonsoft.Json;


namespace MovieLibraryDB
{
    class Program
    {
        public static void Main(string[] args)
        {
            Show show = new Show();

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
            JsonService js = new JsonService();
            js.Add(show);
           var json = js.Write();
            Console.WriteLine(json);
            
        }
    }
}
