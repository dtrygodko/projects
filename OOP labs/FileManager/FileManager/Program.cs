using System;
using static System.Console;

namespace FileManager
{
    class Program
    {
        static void Main(string[] args)
        {
            FileManager manager = FileManager.Manager;

           while(true)
            {
                try
                {
                    Write(manager.CurrentDirectory + " ");

                    string command = ReadLine();

                    if (command[1] == ':')
                    {
                        manager.ChangeDrive(command[0]);
                    }
                    else if(command.Split(' ')[0] == "cd")
                    {
                        manager.ChangeDirectory(command);
                    }
                    else
                    {
                        manager.RunCommand(command);
                    }
                }
                catch(Exception e)
                {
                    WriteLine(e.Message);
                }
            }

            //ReadKey();
        }
    }
}
