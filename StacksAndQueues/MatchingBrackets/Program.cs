using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace MatchingBrackets
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            string input = Console.ReadLine();
//            string input = "1 + (2 - (2 + 3) * 4 / (3 + 1)) * 5";
            var stack = new Stack<int>();

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '(')
                {
                    stack.Push(i);
                }

                if (input[i] == ')')
                {
                    for (int startIndex = stack.Pop(); startIndex <= i; startIndex++)
                    {
                        Console.Write(input[startIndex]);
                    }
                    Console.WriteLine();
                }
            }
        }
    }
}

/*
IN/OUT
(2 + 3) - (2 + 3)

(2 + 3)
(2 + 3)


1 + (2 - (2 + 3) * 4 / (3 + 1)) * 5

(2 + 3)
(3 + 1)
(2 - (2 + 3) * 4 / (3 + 1))
*/