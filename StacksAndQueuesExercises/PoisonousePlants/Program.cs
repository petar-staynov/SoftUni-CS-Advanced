using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoisonousePlants
{
    class Program
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            var plants = Console.ReadLine().Split().Select(int.Parse).ToArray();

            var indexes = new Stack<int>();
            indexes.Push(0);

            var days = new int[n];

            for (int day = 1; day < n; day++)
            {
                var maxDays = 0;
                while (indexes.Count > 0 && plants[indexes.Peek()] >= plants[day])
                {
                    maxDays = Math.Max(maxDays, days[indexes.Pop()]);
                }

                if (indexes.Count > 0)
                {
                    days[day] = maxDays + 1;
                }

                indexes.Push(day);
            }

            Console.WriteLine(days.Max());
        }
    }
}