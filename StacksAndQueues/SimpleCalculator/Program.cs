using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            var inputArr = input.Split(' ');
            Stack<string> stack =  new Stack<string>(inputArr.Reverse());

            int result = 0;
            while (stack.Count > 1)
            {
                int num1 = int.Parse(stack.Pop());
                string op = stack.Pop();
                int num2 = int.Parse(stack.Pop());

                if (op == "+")
                {
                    stack.Push((num1+num2).ToString());
                }
                else if (op == "-")
                {
                    stack.Push((num1 - num2).ToString());
                }
            }
            Console.WriteLine(stack.Pop());
        }
    }
}
