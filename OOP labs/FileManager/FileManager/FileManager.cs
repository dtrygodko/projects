using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;

namespace FileManager
{
    class FileManager
    {
        static FileManager manager;

        public static FileManager Manager
        {
            get
            {
                if(manager == null)
                {
                    manager = new FileManager();
                }

                return manager;
            }
        }

        public static string CurrentDirectory { get; private set; }

        List<char> drives = new List<char>();

        Dictionary<string, ICommand> commands = new Dictionary<string, ICommand>
        {
            
        };

        public void AddCommand(string abbreviation, ICommand command)
        {
            commands.Add(abbreviation, command);
        }

        private FileManager()
        {
            CurrentDirectory = Directory.GetCurrentDirectory();

            RefreshDrives();
        }

        public void RunCommand(string command)
        {
            commands[command.Split(' ')[0]].Run(command);
        }

        public void ChangeDrive(char drive)
        {
            if (drives.Contains(drive))
            {
                CurrentDirectory = drive + ":\\";
            }
            else
            {
                throw new ArgumentException("Drive " + drive + "doesn't exist");
            }
        }

        public void ChangeDirectory(string path)
        {
            string[] cmdParts = path.Split(' ');

            if (cmdParts.Length == 2)
            {
                string[] pathParts = cmdParts[1].Split(new string[] { @"\", "/" }, StringSplitOptions.RemoveEmptyEntries);

                foreach (string part in pathParts)
                {
                    if (part == "..")
                    {
                        if (IsRoot())
                        {
                            throw new ArgumentException("This is root directory, you can't navigate up");
                        }
                        else
                        {
                            string nextDirectory = CurrentDirectory.Remove(CurrentDirectory.LastIndexOf("\\"));
                            if (WillBeRoot(nextDirectory))
                            {
                                nextDirectory += "\\";
                            }

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
                    else
                    {
                        string nextDirectory;
                        if (IsRoot())
                        {
                            nextDirectory = CurrentDirectory + part;
                        }
                        else
                        {
                            nextDirectory = CurrentDirectory + "\\" + part;
                        }

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
            else
            {
                throw new FormatException("Use syntax like: cd path");
            }
        }

        bool WillBeRoot(string path) => path.Length == 2 ? true : false;

        bool IsRoot() => CurrentDirectory.Length == 3 ? true : false;

        void RefreshDrives()
        {
            lock(drives)
            {
                drives.Clear();

                foreach (var drive in DriveInfo.GetDrives().Where(dr => dr.DriveType == DriveType.Fixed || dr.DriveType == DriveType.Removable))
                {
                    drives.Add(drive.Name.ToLower()[0]);
                }
            }
        }

        public void RefreshAllDrives()
        {
            while(true)
            {
                RefreshDrives();

                Thread.Sleep(30000);
            }
        }
    }
}
