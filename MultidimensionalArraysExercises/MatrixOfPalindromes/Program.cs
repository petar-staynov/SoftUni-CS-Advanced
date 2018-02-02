using System;
using System.Linq;

namespace MatrixOfPalindromes
{
    class Program
    {
        static void Main(string[] args)
        {
//            Console.WriteLine((int)'a'); //97
//            Console.WriteLine((int)'a' + 1); //98
//            Console.WriteLine((char)98); //b
//            return;

            var input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int rows = input[0];
            int cols = input[1];

            string[,] matrix = new string[rows,cols];

            //char[] alphabet = "abcdefghijklmnopqrstuvwxyz".ToCharArray();

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    var element1 = (int)'a' + row;
                    var elementChar1 = (char) element1;

                    var element2 = (int)'a' + row + col;
                    var elementChar2 = (char)element2;

                    string result = "";
                    result += elementChar1;
                    result += elementChar2;
                    result += elementChar1;

                    matrix[row, col] = result;
                    Console.Write(matrix[row, col] + " ");
                }

                Console.WriteLine();
            }
        }
    }
}
