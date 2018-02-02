using System;
using System.Linq;

namespace DiagonalDifference
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            long[][] matrix = new long[n][];

            //Mapper
            for (int row = 0; row < n; row++)
            {
                matrix[row] = Console.ReadLine()
                    .Split(new string[] {" "}, StringSplitOptions.RemoveEmptyEntries)
                    .Select(long.Parse)
                    .ToArray();
            }

            //Diagonal 1 
            long diag1Sum = 0;
            for (int rowCol = 0; rowCol < n; rowCol++)
            {
                diag1Sum += matrix[rowCol][rowCol];
            }

            //Diagonal2
            long diag2Sum = 0;
            int col = n-1;
            for (int row = 0; row < n; row++)
            {
                diag2Sum += matrix[row][col];
                col--;
            }

            Console.WriteLine(Math.Abs(diag1Sum - diag2Sum));
        }
    }
}