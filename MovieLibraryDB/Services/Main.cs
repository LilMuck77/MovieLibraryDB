using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieLibraryDB.Services
{
    public class Main : IMain
    {

        private readonly ITesting _test1;

        public Main(ITesting testing) { 
        _test1 = testing;
        }

        public void Invoke()
        {
            _test1.test1();
        }
    }
}
