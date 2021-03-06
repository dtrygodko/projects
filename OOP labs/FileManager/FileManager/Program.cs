﻿using System;
using static System.Console;
using System.Threading;

namespace FileManager
{
    class Program
    {
        static void Main(string[] args)
        {
            FileManager manager = FileManager.Manager;

            Thread refresher = new Thread(new ThreadStart(manager.RefreshDrives));
            refresher.Start();

            while(true)
            {
                try
                {
                    Write(FileManager.CurrentDirectory + " ");

                    string command = ReadLine();

                    if(command.ToLower() == "exit")
                    {
                        refresher.Abort();
                        break;
                    }
                    else if (command[1] == ':')
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
        }
    }
}
