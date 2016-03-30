using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager
{
    interface ICommand
    {
        void Run(string innerCommand);
    }
}
