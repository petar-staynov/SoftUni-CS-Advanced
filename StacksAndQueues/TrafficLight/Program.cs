using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficLight
{
    class Program
    {
        static void Main(string[] args)
        {
            int greenPass = int.Parse(Console.ReadLine());
            Queue<string> queue = new Queue<string>();

            int passed = 0;

            while (true)
            {
                string car = Console.ReadLine();
                if (car == "end")
                {
                    Console.WriteLine(passed + " cars passed the crossroads.");
                    break;
                }
                if (car == "green")
                {
                    for (int i = 0; i < greenPass; i++)
                    {
                        Console.WriteLine(queue.Dequeue() + " passed!");
                        passed++;
                        if (queue.Count == 0) break;
                    }
                    continue;
                }
                queue.Enqueue(car);
            }
        }
    }
}