using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TargetPractice
{
    class Program
    {
        static void Main(string[] args)
        {
            var dimensions = Console.ReadLine()
                .Split(new string[] {" "}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int rows = dimensions[0];
            int cols = dimensions[1];
            char[,] matrix = new char[rows, cols];

            string snake = Console.ReadLine();

            var shotParams = Console.ReadLine()
                .Split(new string[] {" "}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int impactRowIndex = shotParams[0]; //2
            int impactColIndex = shotParams[1]; //3
            int radius = shotParams[2]; //2

            //Snake filler
            string direction = "left";
            int snakeCounter = 0;
            int row = rows - 1;
            int col = cols - 1;
            while (true)
            {
                if (direction == "left")
                {
                    while (col >= 0)
                    {
                        matrix[row, col] = snake[snakeCounter];
                        snakeCounter++;
                        if (snakeCounter > snake.Length - 1) snakeCounter = 0;
                        col--;

//                        Console.WriteLine("NEW MATRIX");
//                        for (int rowPrint = 0; rowPrint < rows; rowPrint++)
//                        {
//                            for (int colPrint = 0; colPrint < cols; colPrint++)
//                            {
//                                Console.Write(matrix[rowPrint, colPrint] + " ");
//                            }
//
//                            Console.WriteLine();
//                        }
                    }

                    col = 0;
                    direction = "up";
                    if (row == 0) break;
                }

                if (direction == "up")
                {
                    if (row > 0)
                    {
                        row--;
                        matrix[row, col] = snake[snakeCounter];
                        snakeCounter++;
                        if (snakeCounter > snake.Length - 1) snakeCounter = 0;

//                        Console.WriteLine("NEW MATRIX");
//                        for (int rowPrint = 0; rowPrint < rows; rowPrint++)
//                        {
//                            for (int colPrint = 0; colPrint < cols; colPrint++)
//                            {
//                                Console.Write(matrix[rowPrint, colPrint] + " ");
//                            }
//
//                            Console.WriteLine();
//                        }


                        //Left or right
                        if (col == 0)
                        {
                            direction = "right";
                            col++;
                        }
                        else
                        {
                            direction = "left";
                            col--;
                        }
                    }
                    else
                    {
                        break;
                    }
                }

                if (direction == "right")
                {
                    while (col < cols)
                    {
                        matrix[row, col] = snake[snakeCounter];
                        snakeCounter++;
                        if (snakeCounter > snake.Length - 1) snakeCounter = 0;
                        col++;

//                        Console.WriteLine("NEW MATRIX");
//                        for (int rowPrint = 0; rowPrint < rows; rowPrint++)
//                        {
//                            for (int colPrint = 0; colPrint < cols; colPrint++)
//                            {
//                                Console.Write(matrix[rowPrint, colPrint] + " ");
//                            }
//
//                            Console.WriteLine();
//                        }
                    }

                    col = cols - 1;
                    direction = "up";
                    if (row == 0) break;
                }

                if (direction == "up" && row == 0)
                {
                    break;
                }
            }
//            Console.WriteLine("WALKED:");
//            for (int rowPrint = 0; rowPrint < rows; rowPrint++)
//            {
//                for (int colPrint = 0; colPrint < cols; colPrint++)
//                {
//                    Console.Write(matrix[rowPrint, colPrint]);
//                }
//
//                Console.WriteLine();
//            }
            //Field shooter
            for (row = 0; row < rows; row++)
            {
                for (col = 0; col < cols; col++)
                {
                    //int distance = Math.Abs(impactRowIndex - row) + Math.Abs(impactColIndex - col);
                    double distance = Math.Sqrt(Math.Pow(row - impactRowIndex, 2) + Math.Pow(col - impactColIndex, 2));
                    if (distance <= radius)
                    {
                        matrix[row, col] = ' ';
                    }
                }
            }

//            Console.WriteLine("SHOOTING:");
//            for (int rowPrint = 0; rowPrint < rows; rowPrint++)
//            {
//                for (int colPrint = 0; colPrint < cols; colPrint++)
//                {
//                    Console.Write(matrix[rowPrint, colPrint]);
//                }
//
//                Console.WriteLine();
//            }

            //Falldown
            for (row = rows - 1; row > 0; row--)
            {
                for (col = 0; col < cols; col++)
                {
                    if (matrix[row, col] == ' ')
                    {
                        //check up
                        int upMoves = 1;
                        for (int rowUp = row - 1; rowUp >= 0;)
                        {
                            if (matrix[rowUp, col] == ' ')
                            {
                                rowUp--;
                            }
                            else
                            {
                                matrix[row, col] = matrix[rowUp, col];
                                matrix[rowUp, col] = ' ';
                                break;
                            }
                        }

//                        for (int rowPrint = 0; rowPrint < rows; rowPrint++)
//                        {
//                            for (int colPrint = 0; colPrint < cols; colPrint++)
//                            {
//                                Console.Write(matrix[rowPrint, colPrint] + " ");
//                            }
//
//                            Console.WriteLine();
//                        }
//
//                        Console.WriteLine("NEW MATRIX\n");
                    }
                }
            }

            //Console.WriteLine("FALLDOWN");
            for (int rowPrint = 0; rowPrint < rows; rowPrint++)
            {
                for (int colPrint = 0; colPrint < cols; colPrint++)
                {
                    Console.Write(matrix[rowPrint, colPrint]);
                }

                Console.WriteLine();
            }
        }
    }
}