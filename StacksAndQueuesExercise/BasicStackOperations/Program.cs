using System;
using System.Collections.Generic;

namespace BasicStackOperations
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            string input = Console.ReadLine();
            var elements = input.Split(' ');

            var n = Convert.ToInt32(elements[0]); //num of elements to push
            var s = Convert.ToInt32(elements[1]); //num of elements to pop
            var x = Convert.ToInt32(elements[2]); //element to check if in stack


            string input2 = Console.ReadLine();
            var elements2 = input2.Split(' ');

            if (n == 0 || s >= n || elements2.Length <= 0)
            {
                Console.WriteLine(0);
                return;
            }


            var stack = new Stack<int>();
            for (int i = 0; i < n; i++)
            {
                stack.Push(Convert.ToInt32(elements2[i]));
            }
            for (int i = 0; i < s; i++)
            {
                stack.Pop();
            }

            int smallest = int.MaxValue;
            foreach (var element in stack)
            {
                if (stack.Contains(x))
                {
                    Console.WriteLine("true");
                    return;
                }
                else if (element < smallest)
                {
                    smallest = element;
                }
            }
            Console.WriteLine(smallest);
        }
    }
}

/*
5 2 13
1 13 45 32 4

4 1 666
420 69 13 666

0 1 1
1 1 1

*/