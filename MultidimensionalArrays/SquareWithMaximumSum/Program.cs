using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquareWithMaximumSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] rowsCols = Console.ReadLine()
                .Split(new string[] {", "}, StringSplitOptions.None)
                .Select(int.Parse)
                .ToArray();
            int rows = rowsCols[0];
            int cols = rowsCols[1];

            int[][] jaggedArr = new int[rows][];

            //ARRAY FILLER
            for (int row = 0; row < rows; row++)
            {
                jaggedArr[row] = Console.ReadLine()
                    .Split(new string[] {", "}, StringSplitOptions.None)
                    .Select(int.Parse)
                    .ToArray();
            }

            int bestSubMatrixSum = int.MinValue;
            int[,] bestSubMatrix = new int[2, 2];

            //ARRAY WALKER
            for (int row = 0; row < rows - 1; row++)
            {
                int submatrixSum = 0;

                for (int col = 0; col < cols - 1; col++)
                {
                    try
                    {
                        submatrixSum = jaggedArr[row][col] + jaggedArr[row][col + 1] +
                                       jaggedArr[row + 1][col] + jaggedArr[row + 1][col + 1];

                        //Console.WriteLine($"{jaggedArr[row][col]}, {jaggedArr[row][col + 1]}");
                        //Console.WriteLine($"{jaggedArr[row + 1][col]}, {jaggedArr[row + 1][col + 1]}");
                        //Console.WriteLine("-------");

                        if (submatrixSum > bestSubMatrixSum)
                        {
                            bestSubMatrixSum = submatrixSum;
                            bestSubMatrix[0, 0] = jaggedArr[row][col];
                            bestSubMatrix[0, 1] = jaggedArr[row][col + 1];
                            bestSubMatrix[1, 0] = jaggedArr[row + 1][col];
                            bestSubMatrix[1, 1] = jaggedArr[row + 1][col + 1];
                        }
                    }
                    catch (IndexOutOfRangeException e)
                    {
                    }
                }
            }

            //Array Print
            Console.WriteLine(bestSubMatrix[0, 0] + " " + bestSubMatrix[0, 1]);
            Console.WriteLine(bestSubMatrix[1, 0] + " " + bestSubMatrix[1, 1]);
            Console.WriteLine(bestSubMatrixSum);
        }
    }
}