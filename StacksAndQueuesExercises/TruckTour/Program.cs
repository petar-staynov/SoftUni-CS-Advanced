using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace TruckTour
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Queue<int> fuels = new Queue<int>();
            Queue<int> distances = new Queue<int>();

            //Read Input
            for (int i = 0; i < n; i++)
            {
                int[] line = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                fuels.Enqueue(line[0]);
                distances.Enqueue(line[1]);
            }


            //Station walker
//            int distanceTotal = 0;
//            int fuelTotal = 0;
            int smallestIndex = 0;

            for (int startPump = 0; startPump < n; startPump++)
            {
                int currentFuel = 0;
                int currentDistance = 0;
                bool possibleRun = true;
                for (int currentPump = 0; currentPump < n; currentPump++)
                {
                    currentFuel += fuels.Peek();
                    fuels.Enqueue(fuels.Dequeue());

                    currentDistance += distances.Peek();
                    distances.Enqueue(distances.Dequeue());

                    if (currentDistance > currentFuel)
                    {
                        possibleRun = false;
                    }
                }

                if (!possibleRun)
                {
                    smallestIndex++;
                    fuels.Enqueue(fuels.Dequeue());
                    distances.Enqueue(distances.Dequeue());
                }
                else
                {
                    Console.WriteLine(smallestIndex);
                    return;
                }
            }
        }
    }
}