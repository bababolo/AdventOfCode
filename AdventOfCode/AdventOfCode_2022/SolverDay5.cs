using System;

namespace AdventOfCode2022
{
    public static class SolverDay5
    {
        public static void Solve_1(bool isSample = true)
        {
            Console.WriteLine("Aufgabe 5.1");
            string[] input = Utils.GetInputByLine(5, isSample);
            string [,] crates = new string[9,1000];
            string [] moves = {};

            int x = 0;
            while (!String.IsNullOrEmpty(input[x]))
            {
                var test = input[x].Split();
                x++;
            }


            Console.WriteLine("Max: " );
        }

        public static void Solve_2(bool isSample = false)
        {
            Console.WriteLine("Aufgabe 5.2");

            Console.WriteLine("Max: " );
        }
    }
}
