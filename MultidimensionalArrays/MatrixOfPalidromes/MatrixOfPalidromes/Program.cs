using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SumMatrixElements
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine()
                .Split(new string[] {", "}, StringSplitOptions.None)
                .Select(int.Parse)
                .ToArray();

            int rows = input[0];
            int cols = input[1];

            var matrix = new int[rows][];

            for (int row = 0; row < rows; row++)
            {
                matrix[row] = Console.ReadLine().Split(new string[] { ", " }, StringSplitOptions.None)
                    .Select(int.Parse).ToArray();
            }

            int sum = 0;
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    sum += matrix[row][col];
                }
            }

            Console.WriteLine($"{rows}\n{cols}\n{sum}");
        }
    }
}