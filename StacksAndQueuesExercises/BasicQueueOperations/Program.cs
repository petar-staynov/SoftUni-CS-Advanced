using System;
using System.Collections.Generic;
using System.Linq;

namespace BasicQueueOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            var elements = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            int eleToAdd = input[0];
            int eleToRemove = input[1];
            int eleToFind = input[2];

            int smallestEle = int.MaxValue;
            Queue<int> queue = new Queue<int>();

            if (eleToRemove >= elements.Length)
            {
                Console.WriteLine(0);
                return;
            }


            for (int i = 0; i < eleToAdd; i++)
            {
//                if (smallestEle > elements[i])
//                {
//                    smallestEle = elements[i];
//                }
                queue.Enqueue(elements[i]);
            }
            for (int i = 0; i < eleToRemove; i++)
            {
                queue.Dequeue();
            }

            if (queue.Contains(eleToFind))
            {
                Console.WriteLine("true");
                return;
            }
            while (queue.Count > 0)
            {
                int queueEle = queue.Peek();
                if (queueEle < smallestEle)
                {
                    smallestEle = queueEle;
                }
                queue.Dequeue();
            }
            Console.WriteLine(smallestEle);
        }
    }
}