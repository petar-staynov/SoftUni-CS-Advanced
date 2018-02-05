using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DirectoryTraversal
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = Console.ReadLine();

            var files = Directory.GetFiles(path);

            var extensionsDictionary = new Dictionary<string, List<FileInfo>>();


            foreach (var file in files)
            {
                var fileInfo = new FileInfo(file);
                var extension = fileInfo.Extension;
                long size = fileInfo.Length;

                if (!extensionsDictionary.ContainsKey(extension))
                {
                    extensionsDictionary[extension] = new List<FileInfo>();
                }

                extensionsDictionary[extension].Add(fileInfo);
            }

            extensionsDictionary = extensionsDictionary
                .OrderByDescending(file => file.Value.Count)
                .ThenBy(file => file.Key)
                .ToDictionary(file => file.Key, file2 => file2.Value);

            string desktopLocation = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            //string desktop = @"%USERPROFILE%/Desktop";
            string fullFileName = desktopLocation + "\\report.txt";

            using (var writer = new StreamWriter(fullFileName))
            {
                foreach (var pair in extensionsDictionary)
                {
                    string extension = pair.Key;
                    var fileInfo = pair.Value.OrderByDescending(fi => fi.Length);

                    writer.WriteLine(extension);

                    foreach (var info in fileInfo)
                    {
                        double fileSize = (double)info.Length / 1024;
                        writer.WriteLine($"--{info.Name} - {fileSize:f3}kb");
                    }
                }
            }
        }
    }
}