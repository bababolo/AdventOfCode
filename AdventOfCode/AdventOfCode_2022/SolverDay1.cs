using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2022
{
    public static class SolverDay1
    {
        public static void Solve_1(bool isSample = false)
        {
            Console.WriteLine("Aufgabe 1.1");

            string[] input = Utils.GetInputByLine(1, isSample);
            int max = 0;
            int sum = 0;
            for (int i = 0; i < input.Length; i++)
            {

                if (String.IsNullOrEmpty(input[i]))
                {
                    max = sum > max ? sum : max;
                    sum = 0;
                } 
                else {
                sum = sum + Convert.ToInt32(input[i]);
                }
            }
            Console.WriteLine("Max: " + max);
        }

        public static void Solve_2(bool isSample = false)
        {
            Console.WriteLine("Aufgabe 1.2");

            string[] input = Utils.GetInputByLine(1, isSample);
            int max = 0;
            int sum = 0; 
            List<long> sums = new List<long>();
            for (int i = 0; i < input.Length; i++)
            {

                if (String.IsNullOrEmpty(input[i]))
                {
                    sums.Add(sum);
                    sum = 0;
                }
                else
                {
                    sum = sum + Convert.ToInt32(input[i]);
                }
            }

            sums.Add(sum);

            var total = sums.OrderByDescending(i => i).Take(3).Sum();


            Console.WriteLine("Max: " + total);
        }
    }
}
