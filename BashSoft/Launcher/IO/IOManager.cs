using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Launcher
{
    public static class IOManager
    {
        public static void TraverseDirectory(int depth)
        {
            OutputWriter.WriteEmptyLine();
            int initialIdentation = SessionData.currentPath.Split('\\').Length;
            Queue<string> subFolders = new Queue<string>();
            subFolders.Enqueue(SessionData.currentPath);

            while (subFolders.Count != 0)
            {
                //Dequeue the folder  at the start of the queue
                string currentPath = subFolders.Dequeue();
                int identation = currentPath.Split('\\').Length - initialIdentation;

                //Print the folder path
                OutputWriter.WriteMessageNewLine($"{new string('-', identation)}{currentPath}");

                //Add all it's subfolders to the end of the queue
                try
                {
                    foreach (var file in Directory.GetFiles(currentPath))
                    {
                        int indexOfLastSlash = file.LastIndexOf("\\");
                        string fileName = file.Substring(indexOfLastSlash);
                        OutputWriter.WriteMessageNewLine(new string('-', indexOfLastSlash) + fileName);
                        if (depth - initialIdentation < 0)
                        {
                            break;
                        }
                    }

                    foreach (var directoryPath in Directory.GetDirectories(currentPath))
                    {
                        subFolders.Enqueue(directoryPath);
                    }
                }
                catch (UnauthorizedAccessException)
                {
                    OutputWriter.DisplayException(ExceptionMessages.UnauthorizedAccessExceptionMessage(currentPath));
                }
            }
        }

        public static void CreateDirInCurrentFolder(string name)
        {
            string path = SessionData.currentPath + "\\" + name;
            try
            {
                Directory.CreateDirectory(path);
            }
            catch (ArgumentException)
            {
                OutputWriter.DisplayException(ExceptionMessages.ForbiddenSymbolsContainedInName());
            }
        }

        public static void ChageCurrentDirectoryRelative(string relativePath)
        {
            if (relativePath == "..")
            {
                try
                {
                    string currentPath = SessionData.currentPath;
                    int indexOfLastSlash = currentPath.LastIndexOf("\\");
                    string newPath = currentPath.Substring(0, indexOfLastSlash);
                    SessionData.currentPath = newPath;
                }
                catch (ArgumentOutOfRangeException)
                {
                    OutputWriter.DisplayException(ExceptionMessages.UnableToGoHigherInPartitionHierarchy());
                }

            }
            else
            {
                string currentPath = SessionData.currentPath;
                currentPath += "\\" + relativePath;
                ChangeCurrentDirectoryAbsolute(currentPath);
            }
        }

        public static void ChangeCurrentDirectoryAbsolute(string absoluetPath)
        {
            if (!Directory.Exists(absoluetPath))
            {
                OutputWriter.DisplayException(ExceptionMessages.InvalidPath(absoluetPath));
                return;
            }

            SessionData.currentPath = absoluetPath;
        }
    }
}