using System;
using System.Collections.Generic;
using System.Linq;

namespace HotPotato
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            string input = Console.ReadLine();
            var queue = new Queue<string>(input.Split(' '));
            int n = int.Parse(Console.ReadLine());


            while (queue.Count > 1)
            {
                for (int i = 0; i < n-1; i++)
                {
                    string reminder = queue.Dequeue();
                    queue.Enqueue(reminder);
                }
                Console.WriteLine("Removed " + queue.Dequeue());
            }
            Console.WriteLine("Last is " + queue.Dequeue());
        }
    }
}

/*
Shuffles until n-th element is first and removes him

test inputs:
Mimi Pepi Toshko
2

Gosho Pesho Misho Stefan Krasi
10

*/