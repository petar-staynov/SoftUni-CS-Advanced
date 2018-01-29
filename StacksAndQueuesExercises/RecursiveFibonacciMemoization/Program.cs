using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecursiveFibonacciMemoization
{
    class Program
    {
//        public static List<long> fibArr = new List<long>();
        private static long[] fibArr = new long[4096];
        static void Main(string[] args)
        {
            fibArr[0] = 1;
            fibArr[1] = 1;

            long n = long.Parse(Console.ReadLine());
            long result = Fib(n);
            Console.WriteLine(result);

            
        }


        static long Fib(long n)
        {
            long fibValue = 0;
            if (n <= 1)
            {
                return n;
            }
            else if (n == 1)
            {
                return 1;
            }
            else if (fibArr[(int)n] != 0)
            {
                return fibArr[(int) n];
            }
            else
            {
                fibValue = Fib(n - 1) + Fib(n - 2);
                fibArr[(int)n] = fibValue;
                return fibValue;
            }
        }
    }
}
