using System;
using System.Collections.Generic;
using System.Linq;

namespace BasicStackOperation
{
    class Program
    {
        static void Main(string[] args)
        {
            var line1 = Console.ReadLine().Split(' ');
            int elementsToPush = int.Parse(line1[0]);
            int elementsToPop = int.Parse(line1[1]);
            int elementToFind = int.Parse(line1[2]);

            var elements = Console.ReadLine().Split(' ');

            Stack<int> stack = new Stack<int>();

            for (int i = 0; i < elementsToPush; i++)
            {
                stack.Push(int.Parse(elements[i]));
            }

            if (elementsToPop >= stack.Count)
            {
                Console.WriteLine(0);
                return;
            }

            for (int i = 0; i < elementsToPop; i++)
            {
                if (stack.Count == 0) break;
                stack.Pop();
            }
            if (stack.Contains(elementToFind))
            {
                Console.WriteLine("true");
            }
            else
            {
                int smallestEle = int.MaxValue;
                while (stack.Count > 0)
                {
                    int poppedEle = stack.Pop();
                    if (poppedEle <= smallestEle)
                    {
                        smallestEle = poppedEle;
                    }
                }
                Console.WriteLine(smallestEle);
            }
        }
    }
}