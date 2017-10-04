using System;
using System.Collections.Generic;

namespace DecimalToBinaryConverter
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var stack = new Stack<int>();

            if (n == 0)
            {
                Console.WriteLine(0);
                return;
            }

            while (n != 0)
            {
                stack.Push(n % 2);
                n /= 2;
            }

            while (stack.Count > 0)
            {
                Console.Write(stack.Pop());
            }
        }
    }
}