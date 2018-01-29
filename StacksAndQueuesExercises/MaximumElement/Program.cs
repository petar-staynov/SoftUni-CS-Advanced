using System;
using System.Collections.Generic;
using System.Linq;

namespace MaximumElement
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Stack<int> stack = new Stack<int>();
            Stack<int> maxStack = new Stack<int>();
            int maxEle = int.MinValue;

            for (int i = 0; i < n; i++)
            {
                var querry = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                if (querry[0] == 1)
                {
                    stack.Push(querry[1]);
                    if (querry[1] > maxEle)
                    {
                        maxEle = querry[1];
                        maxStack.Push(querry[1]);
                    }
                }
                else if (querry[0] == 2)
                {
                    if (stack.Peek() == maxStack.Peek() && maxStack.Count > 0)
                    {
                        maxStack.Pop();
                        if (maxStack.Count > 0)
                        {
                            maxEle = maxStack.Peek();
                        }
                        else
                        {
                            maxEle = int.MinValue;
                        }
                    }

                    stack.Pop();
                }
                else if (querry[0] == 3)
                {
                    Console.WriteLine(maxStack.Peek());
                }
            }
        }
    }
}