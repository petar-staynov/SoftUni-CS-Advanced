using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;

namespace ZippingFiles
{
    class Program
    {
        private const int bufferSize = 4096;

        static void Main(string[] args)
        {
            string sourceFile = "../sliceMe.mp4";
            string destination = "./";
            int parts = 5;
            Zip(sourceFile, destination, parts);

            var files = new List<string>()
            {
                "Part-0.mp4",
                "Part-1.mp4",
                "Part-2.mp4",
                "Part-3.mp4",
                "Part-4.mp4",
            };
            Unzip(files, destination);
        }

        static void Zip(string sourceFile, string destinationDirectory, int parts)
        {
            using (FileStream reader = new FileStream(sourceFile, FileMode.Open))
            {
                long sliceSize = (long)Math.Ceiling((double)reader.Length / parts);
                string extension = sourceFile.Substring(sourceFile.LastIndexOf('.'));

                for (int part = 0; part < parts; part++)
                {
                    long currentSlizeSize = 0;
                    string sliceFileName = destinationDirectory + "Part-" + part + extension + ".gz";

                    using (
                        GZipStream writer = new GZipStream
                            (new FileStream(sliceFileName, FileMode.Create), CompressionLevel.Optimal))
                    {
                        byte[] buffer = new byte[bufferSize];
                        while (reader.Read(buffer, 0, bufferSize) == bufferSize)
                        {
                            writer.Write(buffer, 0, bufferSize);
                            currentSlizeSize += 4096;
                            if (currentSlizeSize >= sliceSize)
                            {
                                break;
                            }
                        }
                    }
                }
            }
        }

        static void Unzip(List<string> filesList, string destiantionDirectory)
        {
            if (destiantionDirectory == string.Empty)
            {
                destiantionDirectory = "./";
            }

            int extension = filesList[0].LastIndexOf(".");

            string fileName = "Assembled" + filesList[0].Substring(extension);
            using (FileStream writer = new FileStream(destiantionDirectory + fileName, FileMode.Create))
            {
                byte[] buffer = new byte[bufferSize];

                foreach (var file in filesList)
                {
                    using (GZipStream reader =
                        new GZipStream(new FileStream(destiantionDirectory + file +".gz", FileMode.Open), CompressionMode.Decompress))
                    {
                        while (reader.Read(buffer, 0, bufferSize) == bufferSize)
                        {
                            writer.Write(buffer, 0, bufferSize);
                        }
                    }
                }
            }
        }
    }
}