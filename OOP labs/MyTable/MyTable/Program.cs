using static System.Console;
using System.Collections.Generic;

namespace MyTable
{
    class Program
    {
        public static void Main()
        {
            MyTable table = new MyTable(@"Data Source=.\SQLEXPRESS;Initial Catalog=MyTables; Integrated Security=True", "Lox", new Dictionary<string, string> { { "lox", "text" }, {"lox2", "varchar(50)" } });

            //table.Insert(new List<string> { "'yeah'", "'bitch'" });

            table.Update(new Dictionary<string, string> { { "lox2", "'hoooray'" } }, "WHERE lox2 = 'bitch'");

            foreach(var row in table.Select())
            {
                WriteLine(row[0] + " " + row[1]);
            }

            ReadKey();
        }
    }
}
