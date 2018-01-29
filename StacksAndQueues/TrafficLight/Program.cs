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

            string command = Console.ReadLine();
            while (command != "end")
            {
                if (command == "green")
                {
                    for (int i = 0; i < greenPass; i++)
                    {
                        if (queue.Count == 0) break;
                        Console.WriteLine(queue.Dequeue() + " passed!");
                        passed++;
                    }
                }
                else
                {
                    queue.Enqueue(command);
                }
                command = Console.ReadLine();
            }
            Console.WriteLine(passed + " cars passed the crossroads.");
        }
    }
}