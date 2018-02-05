using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LineNumbers
{
    class Program
    {
        static void Main(string[] args)
        {

            StreamReader stream = new StreamReader("../../text.txt");

            using (stream)
            {
                int lineNum = 1;
                string line = stream.ReadLine();
                while (line != null)
                {
                    Console.WriteLine($"Line {lineNum}: {line}");
                    line = stream.ReadLine();
                    lineNum++;
                }
            }
        }
    }
}
