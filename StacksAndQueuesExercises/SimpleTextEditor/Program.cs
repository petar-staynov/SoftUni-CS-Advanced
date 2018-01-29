using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTextEditor
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            string text = "";
            Stack<string> undoStack = new Stack<string>();

            for (int i = 0; i < n; i++)
            {
                var command = Console.ReadLine().Split(' ').ToArray();

                if (command[0] == "1")
                {
                    undoStack.Push(text);
                    text += command[1];
                }
                else if (command[0] == "2")
                {
                    undoStack.Push(text);
                    text = text.Substring(0, text.Length - int.Parse(command[1]));
                }
                else if (command[0] == "3")
                {
                    int indexToReturn = int.Parse(command[1]) - 1;
                    Console.WriteLine(text[indexToReturn]);
                }
                else if (command[0] == "4")
                {
                    text = undoStack.Pop();
                }
            }
        }
    }
}