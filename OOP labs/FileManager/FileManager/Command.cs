using System;
using System.IO;

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
                string entityName = "";
                if (parts.Length > 3)
                {
                    for (int i = 2; i < parts.Length; ++i)
                    {
                        entityName += parts[i] + " ";
                    }
                }
                else
                {
                    entityName = parts[2];
                }

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
}
