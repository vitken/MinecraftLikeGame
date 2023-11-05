using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Find Extra Number\n");
            var inputExamples = new List<int[]>()
            {
                new int[19]{6, 9, 2, -1, -5, 4, 4, 9, 2, 0, 1, 0, 6, 7, 1, 8, -1, 8, 7 },
                new int[20]{6, 9, 2, -1, -5, 4, 4, 9, 2, 0, 1, 0, 6, 7, 1, 8, -1, 8, 7, -5 },
                new int[21]{6, 9, 2, -1, -5, 4, 4, 9, 2, 0, 1, 0, 6, 7, 1, 8, -1, 8, 7, -5, 8 },
                new int[17]{6, 9, 2, -1, -5, 4, 4, 9, 2, 0, 1, 0, 6, 7, 1, 8, -1 },
                new int[0]{},
                new int[2]{1,1}
            };
            foreach (var arg in inputExamples)
            {
                var methodResult = FindExtraNumber(arg);
                Console.WriteLine(methodResult.HasValue ? methodResult.Value.ToString() : "No extra number found");
            }

            Console.WriteLine("\nFind Extra Number using Linq\n");
            foreach (var arg in inputExamples)
            {
                var methodResult = FindExtraNumberUsingLinq(arg);
                Console.WriteLine(methodResult.HasValue ? methodResult.Value.ToString() : "No extra number found");
            }
        }

        /// <summary>
        /// Find an extra number that is not repeated twice in the input.
        /// <summary>
        /// <returns>
        /// The extra number.
        /// <returns>
        public static int? FindExtraNumber(int[] numbers)
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                var isExtra = false;
                for (int j = 0; j < numbers.Length; j++)
                {
                    if (i == j)
                    {
                        continue;
                    }
                    else if (numbers[i] == numbers[j])
                    {
                        isExtra = false;
                        break;
                    }
                    else
                    {
                        isExtra = true;
                    }
                }

                if (isExtra)
                {
                    return numbers[i];
                }
            }

            return null;
        }

        //Same as first method, just using linq expressions
        public static int? FindExtraNumberUsingLinq(int[] numbers)
        {
            var numbersBuffer = numbers.ToList();

            foreach (var number in numbers)
            {
                if (numbersBuffer.Contains(number))
                { 
                    numbersBuffer.Remove(number);
                    if (numbersBuffer.Contains(number))
                    {
                        numbersBuffer.Add(number);
                    }
                    else
                    {
                        return number;
                    }
                }
            }

            return null;
        }
    }
}
