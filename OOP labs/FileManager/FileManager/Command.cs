using System;
using System.IO;

namespace FileManager
{
    abstract class Command
    {
        public abstract void Run(string text);

        protected string GetEntityName(string[] parts, int minLength)
        {
            string entityName = "";

            if(parts.Length > minLength)
            {
                for(int i = minLength - 1; i < parts.Length; ++i)
                {
                    entityName += parts[i] + " ";
                }
            }
            else
            {
                entityName = parts[minLength - 1];
            }

            return entityName;
        }
    }

    abstract class CreateDelete : Command
    {
        public override void Run(string text)
        {
            string[] parts = text.Split(' ');

            if (parts[1] == "file" || parts[1] == "dir")
            {
                string entityName = GetEntityName(parts, 3);

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
            File.Create(FileManager.CurrentDirectory + "\\" + name);
        }

        protected override void DirectoryOperation(string name)
        {
            Directory.CreateDirectory(FileManager.CurrentDirectory + "\\" + name);
        }
    }

    class ExecuteProgram : Command
    {
        public override void Run(string text)
        {
            string entityName = GetEntityName(text.Split(' '), 2);

            System.Diagnostics.Process.Start(FileManager.CurrentDirectory + "\\" + entityName);
        }
    }

    class RenameEntity : Command
    {
        public override void Run(string text)
        {
            string[] names = text.Split(new string[] {"=>", "->"}, StringSplitOptions.RemoveEmptyEntries);

            string oldName = FileManager.CurrentDirectory + "\\" + GetEntityName(names[0].Split(' '), 3);
            string newName = FileManager.CurrentDirectory + "\\" + GetEntityName(names[1].Split(' '), 1);

            if (names[0].Split(' ')[1] == "dir")
            {
                Directory.Move(oldName, newName);
            }
            else if (names[0].Split(' ')[1] == "file")
            {
                File.Move(oldName, newName);
            }
            else
            {
                throw new ArgumentException("Use ren file/dir syntax");
            }
        }
    }
}
