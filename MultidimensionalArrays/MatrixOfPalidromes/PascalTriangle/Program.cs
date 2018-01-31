using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PascalTriangle
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());

            List<long>[] jaggedList = new List<long>[rows];

            for (int row = 0; row < rows; row++)
            {
                if (jaggedList[row] == null)
                {
                    jaggedList[row] = new List<long>();
                    jaggedList[row].Add(1);
                }

                for (int col = 1; col < row + 1; col++)
                {
                    long topLeft = 0;
                    long top = 0;
                    try
                    {
                        topLeft = jaggedList[row - 1][col - 1];
                    }
                    catch (Exception e)
                    {

                    }

                    try
                    {
                        top = jaggedList[row - 1][col];
                    }
                    catch (Exception e)
                    {

                    }

                    long newCol = topLeft + top;
                    jaggedList[row].Add(newCol);
                }

                Console.WriteLine(string.Join(" ", jaggedList[row]));
            }
        }
    }
}