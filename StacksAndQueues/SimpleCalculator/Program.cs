using System;
using System.Collections.Generic;
using System.Linq;

namespace SimpleCalculator
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            string input = Console.ReadLine();
            var elements = input.Split(' ');
            var stack = new Stack<string>(elements.Reverse());

            int result = 0;

            while (stack.Count > 1)
            {
                int num1 = int.Parse(stack.Pop());
                string op = stack.Pop();
                int num2 = int.Parse(stack.Pop());

                if (op == "+")
                {
                    result = num1 + num2;
                    stack.Push(result.ToString());
                }
                else if (op == "-")
                {
                    result = num1 - num2;
                    stack.Push(result.ToString());
                }
                
            }
            Console.WriteLine(stack.Pop());
        }
    }
}