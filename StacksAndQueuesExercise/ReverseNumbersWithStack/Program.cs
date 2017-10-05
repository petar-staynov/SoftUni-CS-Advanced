using System;
using System.Collections.Generic;
using System.Linq;

namespace ReverseNumbersWithStack
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            string input = Console.ReadLine();
            var elements = input.Split(' ');
            
            

            var stack = new Stack<string>(elements);

            while (stack.Count > 0)
            {
                Console.Write(stack.Pop() + " ");
            }
        }
    }
}

/*
1 2 3 4 5

1

*/