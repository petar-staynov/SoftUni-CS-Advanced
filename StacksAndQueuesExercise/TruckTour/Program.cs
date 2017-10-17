using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TruckTour
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            var distances = new Queue<int>();
            var fuels = new Queue<int>();

            //QUEUE FILLER
            for (int i = 0; i < n; i++)
            {
                var elements = Console.ReadLine().Split(' ').Select(ele => int.Parse(ele)).ToArray();
                int fuel = elements[0];
                int distance = elements[1];

                distances.Enqueue(distance);
                fuels.Enqueue(fuel);
            }

            //QUEUE TRAVELER
            var possible = true;
            var index = 0;
            for (int i = 0; i < n; i++)
            {
                var currFuel = fuels.Dequeue();
                var currDist = distances.Dequeue();

                var difference = currFuel - currDist;
                if (difference < 0)
                {
                    fuels.Enqueue(currFuel);
                    distances.Enqueue(currDist);
                    index++;
                    continue;
                }


                for (int j = 0; j < n - 1; j++)
                {
                    var distTotal = 0;
                    var fuelTotal = 0;


                    currFuel -= currDist;
                }
            }
        }
    }
}