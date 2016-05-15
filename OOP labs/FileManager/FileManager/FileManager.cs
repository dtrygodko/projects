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
            {"del", new DeleteEntity() },
            {"crt", new CreateEntity() },
            {"exe", new ExecuteProgram() },
            {"ren", new RenameEntity() }
        };

        public void AddCommand(string abbreviation, ICommand command)
        {
            commands.Add(abbreviation, command);
        }

        private FileManager()
        {
            CurrentDirectory = Directory.GetCurrentDirectory();

            SetDrives();
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
                throw new ArgumentException("Drive " + drive + " doesn't exist");
            }
        }

        public void ChangeDirectory(string longPath)
        {
            string path = NameCreator.GetName(longPath.Split(' '), 2);

            string[] pathParts = path.Split(new string[] { @"\", "/" }, StringSplitOptions.RemoveEmptyEntries);

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

                        SetCurrentDirectory(nextDirectory);
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

                    SetCurrentDirectory(nextDirectory);
                }
            }
        }

        void SetCurrentDirectory(string nextDirectory)
        {
            if (Directory.Exists(nextDirectory))
            {
                CurrentDirectory = nextDirectory;
            }
            else
            {
                throw new IOException("Directory " + nextDirectory + " doesn't exist");
            }
        }

        bool WillBeRoot(string path) => path.Length == 2 ? true : false;

        bool IsRoot() => CurrentDirectory.Length == 3 ? true : false;

        void SetDrives()
        {
            foreach (var drive in DriveInfo.GetDrives().Where(dr => dr.DriveType == DriveType.Fixed || dr.DriveType == DriveType.Removable))
            {
                drives.Add(drive.Name.ToLower()[0]);
            }
        }

        public void RefreshDrives()
        {
            while(true)
            {
                lock (drives)
                {
                    drives.Clear();

                    SetDrives();
                }

                Thread.Sleep(30000);
            }
        }
    }
}
