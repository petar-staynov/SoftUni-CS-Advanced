using System;
using System.Linq;

namespace MaximalSum
{
    class Program
    {
        static void Main(string[] args)
        {
            var rowsCols = Console.ReadLine()
                .Split(new string[] {" "}, StringSplitOptions.None)
                .Select(int.Parse)
                .ToArray();
            int rows = rowsCols[0];
            int cols = rowsCols[1];

            long[][] matrix = new long[rows][];

            for (int row = 0; row < rows; row++)
            {
                matrix[row] = Console.ReadLine().Split(new string[] {" "}, StringSplitOptions.RemoveEmptyEntries)
                    .Select(long.Parse).ToArray();
            }

            //Matrix walker
            long bestSum = int.MinValue;
            int[] bestIndex = {0, 0};

            for (int row = 0; row < rows; row++)
            {

                for (int col = 0; col < cols; col++)
                {
                    try
                    {
                        long currentSum = 0;

                        currentSum += matrix[row][col]
                                      + matrix[row][col + 1]
                                      + matrix[row][col + 2]
                                      + matrix[row + 1][col]
                                      + matrix[row + 1][col + 1]
                                      + matrix[row + 1][col + 2]
                                      + matrix[row + 2][col]
                                      + matrix[row + 2][col + 1]
                                      + matrix[row + 2][col + 2];

                        if (currentSum > bestSum)
                        {
                            bestSum = currentSum;
                            bestIndex[0] = row;
                            bestIndex[1] = col;
                        }
                    }
                    catch (Exception e)
                    {
                    }
                }
            }

            Console.WriteLine("Sum = " + bestSum);
            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    Console.Write(matrix[bestIndex[0] + row][bestIndex[1] + col] + " ");
                }

                Console.WriteLine();
            }
        }
    }
}