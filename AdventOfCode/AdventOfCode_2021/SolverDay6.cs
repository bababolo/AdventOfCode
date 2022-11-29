using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode2021
{
    public static class SolverDay6
    {
        public static void Solve_1(bool isSample = false)
        {
            Console.WriteLine("Aufgabe 6.1");
            string[] inputList = Utils.GetInputByLine(6, isSample)[0].Split(",");
            List<int> startFishes = Utils.ConvertArrayToInt(inputList).ToList();
            Array fishes = new long[9];

            foreach (var fish in startFishes)
            {
                fishes.SetValue(Convert.ToInt64(fishes.GetValue(fish))+1,fish);
            }

            fishes = CountFishes(80, fishes);
            int sum = 0;
            for (int i = 0; i < 9; i++)
            {
                sum = sum + Convert.ToInt32(fishes.GetValue(i));
            }

            Console.WriteLine("Result " + sum);
        }

        public static void Solve_2(bool isSample = false)
        {
            Console.WriteLine("Aufgabe 6.2");
            string[] inputList = Utils.GetInputByLine(6, isSample)[0].Split(",");
            List<int> startFishes =Utils.ConvertArrayToInt(inputList).ToList();
            Array fishes = new long[9];

            foreach (var fish in startFishes)
            {
                fishes.SetValue(Convert.ToInt64(fishes.GetValue(fish)) + 1, fish);
            }

            fishes = CountFishes(256, fishes);
            long sum = 0;
            for (int i = 0; i < 9; i++)
            {
                sum = sum + Convert.ToInt64(fishes.GetValue(i));
            }

            Console.WriteLine("Result " + sum);
        }

        private static Array CountFishes(int day, Array fishes)
        {
            for (int d = 0; d < day; d++)
            {
                Array newFishes = new long[9];
                var countTyp0 = Convert.ToInt64(fishes.GetValue(0));
                Array.Copy(fishes, 1, newFishes, 0, newFishes.Length-1);
                newFishes.SetValue(countTyp0, 8);
                newFishes.SetValue(Convert.ToInt64(newFishes.GetValue(6)) + countTyp0, 6);
                fishes = newFishes;
            }
            return fishes;
        }
    }
}
