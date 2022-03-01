using MovieLibraryDB.Interfaces;
using MovieLibraryDB.Services;
using MovieLibraryDB.ServiceTest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MovieLibraryDB.Code
{
    internal class StartUp
    {

        public IServiceProvider ConfigureServices()
        {
            IServiceCollection services = new ServiceCollection();

          /*  services.AddLogging(builder => 
            { builder.AddConsole();
                builder.AddFile("app.log");
            });*/

            services.AddTransient<IMainService, MainService>();
            services.AddTransient<IDuplicationChecker, DuplicationChecker>();



            return services.BuildServiceProvider();
        }
    }
}
