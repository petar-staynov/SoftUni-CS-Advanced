using System;
using System.Collections.Generic;

namespace SequencewithQueue
{
    class Program
    {
        static void Main(string[] args)
        {
            long s1 = long.Parse(Console.ReadLine());
            long s2 = s1 + 1;
            long s3 = 2 * s1 + 1;
            long s4 = s1 + 2;

            Queue<long> queue = new Queue<long>();
            Queue<long> result = new Queue<long>();

            queue.Enqueue(s1);
            result.Enqueue(s1);


            int counter = 1;

            for (int i = 1; i < 50; i++)
            {
                if (counter == 1)
                {
                    long newEle = queue.Peek() + 1;
                    queue.Enqueue(newEle);
                    result.Enqueue(newEle);
                    counter++;
                }
                else if (counter == 2)
                {
                    long newEle = 2 * queue.Peek() + 1;
                    queue.Enqueue(newEle);
                    result.Enqueue(newEle);
                    counter++;
                }
                else if (counter == 3)
                {
                    long newEle = queue.Peek() + 2;
                    queue.Enqueue(newEle);
                    result.Enqueue(newEle);

                    queue.Dequeue();
                    counter = 1;
                }
            }
            while (result.Count > 0)
            {
                Console.Write(result.Dequeue() + " ");
            }
        }
    }
}