using System;
using System.Collections.Generic;
using System.Linq;

namespace MaximumElement
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            var stack = new Stack<int>();
            for (int i = 0; i < n; i++)
            {
                var querryElements = Console.ReadLine().Split(' ');

                if (querryElements[0] == "1")
                {
                    stack.Push(Convert.ToInt32(querryElements[1]));
                }
                else if (querryElements[0] == "2")
                {
                    stack.Pop();
                }
                else if (querryElements[0] == "3")
                {
                    Console.WriteLine(stack.Max());
                }
            }
        }
    }
}

/*
9
1 97
2
1 20
2
1 26
1 20
3
1 91
3

*/