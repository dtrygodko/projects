using static System.Console;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager
{
    class Program
    {
        static void Main(string[] args)
        {
            FileManager manager = new FileManager();

            WriteLine(manager.CurrentDirectory);

            ReadKey();
        }
    }
}
