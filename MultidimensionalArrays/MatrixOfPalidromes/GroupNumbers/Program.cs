using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine()
                .Split(new string[] {", "}, StringSplitOptions.None)
                .Select(int.Parse)
                .ToArray();

            List<int>[] listArr = new List<int>[3];

            for (int i = 0; i < numbers.Length; i++)
            {
                if (Math.Abs(numbers[i] % 3) == 0)
                {
                    if (listArr[0] == null)
                    {
                        listArr[0] = new List<int>();
                    }
                    listArr[0].Add(numbers[i]);
                }
                else if (Math.Abs(numbers[i] % 3) == 1)
                {
                    if (listArr[1] == null)
                    {
                        listArr[1] = new List<int>();
                    }
                    listArr[1].Add(numbers[i]);
                }
                else if (Math.Abs(numbers[i] % 3) == 2)
                {
                    if (listArr[2] == null)
                    {
                        listArr[2] = new List<int>();
                    }
                    listArr[2].Add(numbers[i]);
                }
            }

            for (int row = 0; row < listArr.Length; row++)
            {
                try
                {
                    for (int col = 0; col < listArr[row].Count; col++)
                    {
                        Console.Write(listArr[row][col] + " ");
                    }
                }
                catch (Exception e)
                {
                    continue;
                }

                Console.WriteLine();
            }
        }
    }
}
