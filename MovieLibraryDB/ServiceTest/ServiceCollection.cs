using MovieLibraryDB.Interfaces;

namespace MovieLibraryDB.ServiceTest
{
    internal class ServiceCollection : IServiceCollection
    {
        public void AddLogging(Action<object> p)
        {
            throw new NotImplementedException();
        }

        public void AddTransient<T1, T2>()
        {
            throw new NotImplementedException();
        }

        public IServiceProvider BuildServiceProvider()
        {
            throw new NotImplementedException();
        }
    }
}