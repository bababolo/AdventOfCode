using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;

namespace AdventOfCode2022
{
    public static class SolverDay4
    {
        public static void Solve_1(bool isSample = false)
        {
            Console.WriteLine("Aufgabe 4.1");
            string[] input = Utils.GetInputByLine(4, isSample);

            int sum = 0;
            for (int i = 0; i < input.Length; i++)
            {
                string first = input[i].Split(",")[0];
                string last = input[i].Split(",")[1];

                int first1 = Convert.ToInt32(first.Split("-")[0]);
                int first2 = Convert.ToInt32(first.Split("-")[1]);

                int last1 = Convert.ToInt32(last.Split("-")[0]);
                int last2 = Convert.ToInt32(last.Split("-")[1]);

                if ((first1 <= last1 && first2 >= last2) || (last1 <= first1 && last2 >= first2))
                {
                    sum++;
                }
            }
            Console.WriteLine("Max: " + sum);
        }

        public static void Solve_2(bool isSample = false)
        {
            Console.WriteLine("Aufgabe 4.2");
            string[] input = Utils.GetInputByLine(4, isSample);

            int sum = 0;
            for (int i = 0; i < input.Length; i++)
            {
                string first = input[i].Split(",")[0];
                string last = input[i].Split(",")[1];

                int first1 = Convert.ToInt32(first.Split("-")[0]);
                int first2 = Convert.ToInt32(first.Split("-")[1]);

                int last1 = Convert.ToInt32(last.Split("-")[0]);
                int last2 = Convert.ToInt32(last.Split("-")[1]);

                if ((first1 >= last1 && first1 <= last2) || (first2 >= last1 && first2 <= last2) || (last1 >= first1 && last1 <= first2) || (last2 >= first1 && last2 <= first2))
                {
                    sum++;
                }
            }
            Console.WriteLine("Max: " + sum);
        }
    }
}
