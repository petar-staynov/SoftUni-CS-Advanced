using System;
using System.Collections.Generic;
using System.Text;

namespace Launcher
{
    public static class OutputWriter
    {
        public static void WriteMessage(string message)
        {
            Console.Write(message);
        }

        public static void WriteMessageNewLine(string message)
        {
            Console.WriteLine(message);
        }

        public static void WriteEmptyLine()
        {
            Console.WriteLine();
        }

        public static void DisplayException(string message)
        {
            ConsoleColor currentColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ForegroundColor = currentColor;
        }

        public static void DisplayStudent(KeyValuePair<string, List<int>> student)
        {
            OutputWriter.WriteMessageNewLine(
                String.Format($"{student.Key} - {String.Join(", ", student.Value)}")
            );
        }
    }
}