using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace FileManager
{
    class FileManager
    {
        public string CurrentDirectory { get; private set; }

        List<string> drives = new List<string>();

        public FileManager()
        {
            CurrentDirectory = Directory.GetCurrentDirectory();

            foreach(var drive in DriveInfo.GetDrives().Where(dr => dr.DriveType.ToString() == "Fixed" || dr.DriveType.ToString() == "Removable"))
            {
                drives.Add(drive.Name.ToLower());
            }
        }

        public void Parse(string command)
        {
            string[] cmdParts = command.Split(' ');

            switch(cmdParts[0])
            {
                case Commands.ChangeDirectory:
                    {
                        if (cmdParts.Length == 2)
                        {
                            ChangeDirectory(cmdParts[1]);
                        }
                        else
                        {
                            throw new FormatException("Use syntax like: cd path");
                        }
                        break;
                    }
            }
        }

        void ChangeDirectory(string path)
        {
            string[] pathParts = path.Split(new string[] { @"\", "/" }, StringSplitOptions.RemoveEmptyEntries);

            foreach(string part in pathParts)
            {
                if(part == "..")
                {
                    string nextDirectory = CurrentDirectory.Remove(CurrentDirectory.LastIndexOf("\\"));

                    if (Directory.Exists(nextDirectory))
                    {
                        CurrentDirectory = nextDirectory;
                    }
                    else
                    {
                        throw new IOException("Directory " + nextDirectory + " doesn't exist");
                    }
                }
                else
                {
                    string nextDirectory = CurrentDirectory + "\\" + part;

                    if (Directory.Exists(nextDirectory))
                    {
                        CurrentDirectory = nextDirectory;
                    }
                    else
                    {
                        throw new IOException("Directory " + nextDirectory + " doesn't exist");
                    }
                }
            }
        }
    }
}
