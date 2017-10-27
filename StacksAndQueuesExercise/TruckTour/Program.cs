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
            var index = 0;
            for (int i = 0; i < n; i++)
            {
                var possible = true;

                var totalFuel = 0;
                var totalDist = 0;

                //Starts running in circle from top element.
                for (int j = 0; j < n; j++)
                {
                    var currFuel = fuels.Dequeue();
                    var currDist = distances.Dequeue();
                    totalDist += currDist;
                    totalFuel += currFuel;

                    distances.Enqueue(currDist);
                    fuels.Enqueue(currFuel);
                    if (totalDist > totalFuel) //Marks current run as impossible
                    {
                        possible = false;
                    }
                }

                //If run is impossible increase index and spin the circle 1 time. Else return the first possible index
                if (possible == false)
                {
                    index++;
                    fuels.Enqueue(fuels.Dequeue());
                    distances.Enqueue(distances.Dequeue());
                }
                else
                {
                    Console.WriteLine(index);
                    return;
                }
            }
        }
    }
}