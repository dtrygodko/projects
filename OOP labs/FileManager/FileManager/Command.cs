using System;
using System.IO;
using Microsoft.VisualBasic.FileIO;

namespace FileManager
{
    interface ICommand
    {
        void Run(string text);
    }

    abstract class CreateDelete : ICommand
    {
        public void Run(string text)
        {
            string[] parts = text.Split(' ');

            if (parts[1] == "file" || parts[1] == "dir")
            {
                string entityName = NameCreator.GetName(parts, 3);

                if (parts[1] == "file")
                {
                    FileOperation(entityName);
                }
                else
                {
                    DirectoryOperation(entityName);
                }
            }
            else
            {
                throw new FormatException($"Use syntax like: {parts[0]} file/dir name");
            }
        }

        protected abstract void FileOperation(string name);

        protected abstract void DirectoryOperation(string name);
    }

    class DeleteEntity : CreateDelete
    {
        protected override void FileOperation(string name)
        {
            File.Delete(FileManager.CurrentDirectory + "\\" + name);
        }

        protected override void DirectoryOperation(string name)
        {
            Directory.Delete(FileManager.CurrentDirectory + "\\" + name);
        }
    }

    class CreateEntity : CreateDelete
    {
        protected override void FileOperation(string name)
        {
            using (FileStream fs = File.Create(FileManager.CurrentDirectory + "\\" + name))
            {

            }
        }

        protected override void DirectoryOperation(string name)
        {
            Directory.CreateDirectory(FileManager.CurrentDirectory + "\\" + name);
        }
    }

    class ExecuteProgram : ICommand
    {
        public void Run(string text)
        {
            string entityName = NameCreator.GetName(text.Split(' '), 2);

            System.Diagnostics.Process.Start(FileManager.CurrentDirectory + "\\" + entityName);
        }
    }

    class RenameEntity : ICommand
    {
        public void Run(string text)
        {
            string[] names = text.Split(new string[] {"=>", "->"}, StringSplitOptions.RemoveEmptyEntries);

            string oldName = FileManager.CurrentDirectory + "\\" + NameCreator.GetName(names[0].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries), 3);
            string newName = NameCreator.GetName(names[1].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries), 1);

            if (names[0].Split(' ')[1] == "dir")
            {
                FileSystem.RenameDirectory(oldName, newName);
            }
            else if (names[0].Split(' ')[1] == "file")
            {
                FileSystem.RenameFile(oldName, newName);
            }
            else
            {
                throw new ArgumentException("Use ren file/dir syntax");
            }
        }
    }
}
