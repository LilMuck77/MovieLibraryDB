using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieLibraryDB.Interfaces
{
    public interface IDuplicationChecker
    {
        bool IsExisting();
    }
    public class DuplicationChecker : IDuplicationChecker
    {
        public bool IsExisting(){
            return true;
        }
    
    }
}
