using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace StreamsLab
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var stream = new StreamReader("../../Program.cs"))
            {
                int line = 1;
                string lineString = stream.ReadLine();

                using (var writeStream = new StreamWriter("../../reversed.txt"))
                {
                    while ((lineString = stream.ReadLine()) != null)
                    {
                        for (int i = lineString.Length - 1; i >= 0; i--)
                        {
                            writeStream.Write(lineString[i]);
                        }

                        writeStream.WriteLine();
                    }
                }
            }
        }
    }
}