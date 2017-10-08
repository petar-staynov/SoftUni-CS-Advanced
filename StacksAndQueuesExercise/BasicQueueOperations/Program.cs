using System;
using System.Collections.Generic;

namespace BasicQueueOperations
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(' ');
            var elements = Console.ReadLine().Split(' ');
            
            var amount = Convert.ToInt32(input[0]);
            var remove = Convert.ToInt32(input[1]);
            var exists = Convert.ToInt32(input[2]);

            if (amount <= remove)
            {
                Console.WriteLine(0);
                return;
            }
            
            var queue = new Queue<int>();
            for (int i = 0; i < amount; i++)
            {
                queue.Enqueue(Convert.ToInt32(elements[i]));
                
            }

            for (int i = 0; i < remove; i++)
            {
                queue.Dequeue();
            }
            if (queue.Contains(exists))
            {
                Console.WriteLine("true");
                return;
            }
            var smallest = int.MaxValue;
            foreach (var element in queue)
            {
                //var elementValue = queue.Dequeue();
                if (element < smallest)
                {
                    smallest = element;
                }
            }
            Console.WriteLine(smallest);
        }
    }
}

/*
5 2 32
1 13 45 32 4

4 1 666
666 69 13 420

3 3 90
90 90 90
*/