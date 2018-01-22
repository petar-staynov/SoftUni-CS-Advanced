using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecimanToBinaryconverter
{
    class Program
    {
        static void Main(string[] args)
        {
            int decNum = int.Parse(Console.ReadLine());
            Stack<int> stack = new Stack<int>();

            if (decNum == 0)
            {
                Console.WriteLine(0);
                return;
            }
            while (decNum != 0)
            {
                stack.Push(decNum % 2);
                decNum /= 2;
            }
            while (stack.Count != 0)
            {
                Console.Write(stack.Pop());
            }

        }
    }
}
