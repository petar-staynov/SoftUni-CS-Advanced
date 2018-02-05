using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RubikMatrix
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

            int[,] matrix = new int[rows, cols];

            //Matrix Filler
            int num = 1;
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = num;
                    num++;
                }
            }

            int commandsNum = int.Parse(Console.ReadLine());
            for (int i = 0; i < commandsNum; i++)
            {
                string[] command = Console.ReadLine()
                    .Split(new string[] {" "}, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                int rowCol = int.Parse(command[0]);
                string direction = command[1];
                int moves = int.Parse(command[2]);

                if (direction == "up")
                {
                    for (int move = 0; move < moves % rows; move++)
                    {
                        int temp = matrix[0, rowCol]; //save first col ele
                        for (int row = 0; row < rows - 1; row++)
                        {
                            matrix[row, rowCol] = matrix[row + 1, rowCol];
                        }

                        matrix[rows - 1, rowCol] = temp;
                    }
                }

                if (direction == "down")
                {
                    for (int move = 0; move < moves % rows; move++)
                    {
                        int temp = matrix[rows - 1, rowCol]; //save last col ele
                        for (int row = rows - 1; row > 0; row--)
                        {
                            matrix[row, rowCol] = matrix[row - 1, rowCol];
                        }

                        matrix[0, rowCol] = temp;
                    }
                }

                if (direction == "left")
                {
                    for (int move = 0; move < moves % cols; move++)
                    {
                        int temp = matrix[rowCol, 0]; //save leftmost ele
                        for (int col = 0; col < cols - 1; col++)
                        {
                            matrix[rowCol, col] = matrix[rowCol, col + 1];
                        }

                        matrix[rowCol, cols - 1] = temp;
                    }
                }

                if (direction == "right")
                {
                    for (int move = 0; move < moves % cols; move++)
                    {
                        int temp = matrix[rowCol, cols - 1]; //save rightmost ele
                        for (int col = cols - 1; col > 0; col--)
                        {
                            matrix[rowCol, col] = matrix[rowCol, col - 1];
                        }

                        matrix[rowCol, 0] = temp;
                    }
                }
            }

            //Swapper
            int numMustBe = 1;
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    //Check if matrix num is like original matrix num
                    if (matrix[row, col] != numMustBe)
                    {
                        //Find index of original element
                        for (int findRow = 0; findRow < rows; findRow++)
                        {
                            if (matrix[row, col] == numMustBe) break;
                            for (int findCol = 0; findCol < cols; findCol++)
                            {
                                if (matrix[findRow, findCol] == numMustBe)
                                {
                                    Console.WriteLine($"Swap ({row}, {col}) with ({findRow}, {findCol})");
                                    int swapNum = matrix[row, col];
                                    matrix[row, col] = matrix[findRow, findCol];
                                    matrix[findRow, findCol] = swapNum;
                                    break;
                                }
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("No swap required");
                    }

                    numMustBe++;
                }
            }
        }
    }
}