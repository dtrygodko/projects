using static System.Console;

namespace FileManager
{
    class Program
    {
        static void Main(string[] args)
        {
            FileManager manager = new FileManager();

           while(true)
            {
                manager.Parse(ReadLine());
            }

            //ReadKey();
        }
    }
}
