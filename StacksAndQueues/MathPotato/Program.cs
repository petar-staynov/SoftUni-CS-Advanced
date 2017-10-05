using System;
using System.Collections.Generic;

namespace MathPotato
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            string input = Console.ReadLine();
            var queue = new Queue<string>(input.Split(' '));
            int n = int.Parse(Console.ReadLine());


            int cycle = 1;
            while (queue.Count > 1)
            {
                for (int i = 0; i < n-1; i++)
                {
                    queue.Enqueue(queue.Dequeue());
                }

                if (IsPrime(cycle))
                {
                    Console.WriteLine("Prime " + queue.Peek());
                }
                else
                {
                    Console.WriteLine("Removed " + queue.Dequeue());
                }
                cycle++;

            }
            Console.WriteLine("Last is " + queue.Dequeue());
        }
        
        public static bool IsPrime(int number)
        {
            if (number == 1) return false;
            if (number == 2) return true;
            if (number % 2 == 0)  return false;

            var boundary = (int)Math.Floor(Math.Sqrt(number));

            for (int i = 3; i <= boundary; i+=2)
            {
                if (number % i == 0)  return false;
            }

            return true;        
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