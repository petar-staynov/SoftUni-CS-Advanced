using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackFibonacci
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Stack<long> stack = new Stack<long>();

            stack.Push(0);
            stack.Push(1);

            for (int i = 0; i < n-1; i++)
            {
                long currNum = stack.Pop();
                long lastNum = stack.Peek();
                stack.Push(currNum);
                long newNum = lastNum + currNum;
                stack.Push(newNum);
            }

            Console.WriteLine(stack.Peek());
        }
    }
}
