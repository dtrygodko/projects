using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager
{
    class FileManager
    {
        public string CurrentDirectory { get; private set; }

        public FileManager()
        {
            CurrentDirectory = Directory.GetCurrentDirectory();
        }

        public void InfiniteParse()
        {
            while(true)
            {

            }
        }
    }
}
