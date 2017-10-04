using System;
using System.Collections.Generic;

namespace StacksAndQueues
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var input = Console.ReadLine();
            var stack = new Stack<char>();

            for (int i = 0; i < input.Length; i++)
            {
                stack.Push(input[i]);
            }

            for (int i = 0; i < input.Length; i++)
            {
                Console.Write(stack.Pop());
            }
        }
    }
}
//push adds on top of stack
//pop - removes last ele
//peak - reads last ele
//stack.Clear() - clears ctack
//stack.TrimExcess() - resizes
//stack.Contains(index) - checks index existence - bool
//stack.Count - returns stack count