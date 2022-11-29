using System;

namespace AdventOfCode2022
{
    public static class SolverDay1
    {
        public static void Solve_1(bool isSample = false)
        {
            Console.WriteLine("Aufgabe 1.1");

            string[] input = Utils.GetInputByLine(1, isSample);
            int counter = 0; 

            for (int i = 1; i < input.Length; i++)
            {
                if (Convert.ToInt32(input[i]) > Convert.ToInt32(input[i - 1]))
                {
                    counter++;
                }
            }

            Console.WriteLine("Anzahl Messungen: " + counter);
        }

        public static void Solve_2(bool isSample = false)
        {
            Console.WriteLine("Aufgabe 1.2");

            string[] input = Utils.GetInputByLine(1, isSample);
            int counter = 0;
            int previousSum = 0;

            for (int i = 0; i < input.Length-2 ; i++)
            {
                int sum = Convert.ToInt32(input[i]) + 
                             Convert.ToInt32(input[i + 1]) +
                             Convert.ToInt32(input[i + 2]);

                if (previousSum> 0 && sum > previousSum)
                {
                    counter++;
                }

                previousSum = sum;
            }

            Console.WriteLine("Anzahl Messungen: " + counter);
        }
    }
}
