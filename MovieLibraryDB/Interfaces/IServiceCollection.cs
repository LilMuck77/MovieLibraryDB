/*using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NLog.Web;*/

namespace MovieLibraryDB.Interfaces
{
    internal interface IServiceCollection
    {
        void AddTransient<T1, T2>();
        void AddLogging(Action<object> p);
        IServiceProvider BuildServiceProvider();
    }
}