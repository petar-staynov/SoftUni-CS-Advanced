using System;
using System.Linq;

namespace SquareInMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] rowsCols = Console.ReadLine()
                .Split(new string[] {" "}, StringSplitOptions.None)
                .Select(int.Parse)
                .ToArray();
            int rows = rowsCols[0];
            int cols = rowsCols[1];

            string[][] matrix = new string[rows][];

            //Matrix filler
            for (int row = 0; row < rows; row++)
            {
                matrix[row] = Console.ReadLine()
                    .Split(new string[] {" "}, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
            }

            int foundSquares = 0;
            //Matrix walker
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    try
                    {
                        string ele1 = matrix[row][col];
                        string ele2 = matrix[row][col + 1];
                        string ele3 = matrix[row + 1][col];
                        string ele4 = matrix[row + 1][col + 1];

                        if (ele1 == ele2 && ele1 == ele3 && ele1 == ele4)
                        {
                            foundSquares++;
                        }
                    }
                    catch (Exception e)
                    {
                    }
                }
            }

            Console.WriteLine(foundSquares);
        }
    }
}