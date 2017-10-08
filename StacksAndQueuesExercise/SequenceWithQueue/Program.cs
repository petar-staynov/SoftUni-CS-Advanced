using System;
using System.Collections.Generic;
using System.Linq;

namespace SequenceWithQueue
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var s1 = long.Parse(Console.ReadLine());

            var queue = new Queue<long>();
            var result = new List<long>();

            queue.Enqueue(s1);
            result.Add(s1);
            //Console.Write(s1 + " ");
            for (int i = 0; i < 20; i++)
            {
                var queueHead = queue.Dequeue();

                var ele2 = queueHead + 1;
                queue.Enqueue(ele2);
                result.Add(ele2);
                //Console.Write(ele2 + " ");

                var ele3 = 2 * queueHead + 1;
                queue.Enqueue(ele3);
                result.Add(ele3);
                //Console.Write(ele3 + " ");

                var ele4 = queueHead + 2;
                queue.Enqueue(ele4);
                result.Add(ele4);
                //Console.Write(ele4 + " ");
            }

            for (int i = 0; i < 50; i++)
            {
                Console.Write(result[i] + " ");
            }
        }
    }
}
/*
s1 = 2 s1
s2 = 3 s1 +1
s3 = 5 2s1+1
s4 = 4 s1+2
s5 = 4 s2+1
s6 = 7 2s2+1
s7 = 5 s2 + 1 
s8 = 6 s3 + 1
11 
7 
5 
9 
6

*/