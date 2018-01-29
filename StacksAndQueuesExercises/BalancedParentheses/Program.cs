using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BalancedParentheses
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] input = Console.ReadLine().ToCharArray();

            Stack<char> stack = new Stack<char>();

            for (int i = 0; i < input.Length; i++)
            {
                char element = input[i];

                switch (element)
                {
                    case '{':
                        stack.Push('{');
                        break;
                    case '[':
                        stack.Push('[');
                        break;
                    case '(':
                        stack.Push('(');
                        break;


                    case '}':
                        if (stack.Count > 0)
                        {
                            char currentSymbol = stack.Pop();
                            if (currentSymbol != '{')
                            {
                                Console.WriteLine("NO");
                                return;
                            }
                        }
                        else
                        {
                            Console.WriteLine("NO");
                            return;
                        }

                        break;
                    case ']':
                        if (stack.Count > 0)
                        {
                            char currentSymbol = stack.Pop();
                            if (currentSymbol != '[')
                            {
                                Console.WriteLine("NO");
                                return;
                            }
                        }
                        else
                        {
                            Console.WriteLine("NO");
                            return;
                        }

                        break;
                    case ')':
                        if (stack.Count > 0)
                        {
                            char currentSymbol = stack.Pop();
                            if (currentSymbol != '(')
                            {
                                Console.WriteLine("NO");
                                return;
                            }
                        }
                        else
                        {
                            Console.WriteLine("NO");
                            return;
                        }

                        break;
                }
            }

            if (stack.Count == 0)
            {
                Console.WriteLine("YES");
            }
            else
            {
                Console.WriteLine("NO");
            }
        }
    }
}