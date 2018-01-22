using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotPotato
{
    class Program
    {
        static void Main(string[] args)
        {
            string kids = Console.ReadLine();
            int n = int.Parse(Console.ReadLine());

            Queue<string> queue = new Queue<string>(kids.Split(' '));

            int counter = 1;
            while (queue.Count > 1)
            {
                if (counter != n)
                {
                    queue.Enqueue(queue.Dequeue());
                    counter++;
                }
                else
                {
                    Console.WriteLine("Removed " + queue.Dequeue());
                    counter = 1;
                }
            }
            Console.WriteLine("Last is " + queue.Peek());
        }
    }
}