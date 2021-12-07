using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode2021
{
    public static class SolverDay7
    {
        public static void Solve_1(bool isSample = false)
        {
            Console.WriteLine("Aufgabe 7.1");
            string[] inputList = Utils.GetInput(7, isSample).Split(",");
            int[] pos = Utils.ConvertArrayToInt(inputList);

            int? total = null;
            for (int i = 1; i < pos.Length; i++)
            {
                int cost = 0;
                for (int j = 0; j < pos.Length; j++)
                {
                    int start = pos[j] >= pos[i] ? pos[j] : pos[i];
                    int end = pos[j] <= pos[i] ? pos[j] : pos[i];

                    cost = cost + start - end;
                }

                total = (cost == null || cost > total) ? total : cost;
            }
            
            Console.WriteLine("Result " + total);
        }

        public static void Solve_2(bool isSample = false)
        {
            Console.WriteLine("Aufgabe 7.2");
            string[] inputList = Utils.GetInput(7, isSample).Split(",");
            int[] pos = Utils.ConvertArrayToInt(inputList);

            int? total = null;
            for (int i = 1; i < pos.Length; i++)
            {
                int cost = 0;
                for (int j = 0; j < pos.Length; j++)
                {
                    int start = pos[j] >= i ? pos[j] : i;
                    int end = pos[j] <= i ? pos[j] : i;

                   int steps = start - end;
                   int costForSteps = 0;
                   for (int k = 0; k < steps; k++)
                   {
                       costForSteps = costForSteps + (k+1);
                   }

                   cost = cost + costForSteps;
                }

                total = (cost == null || cost > total) ? total : cost;
            }

            Console.WriteLine("Result " + total);
        }
    }
}
