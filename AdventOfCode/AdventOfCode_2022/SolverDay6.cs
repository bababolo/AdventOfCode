using System;
using System.Collections.Generic;

namespace AdventOfCode2022
{
    public static class SolverDay6
    {
        public static void Solve_1(bool isSample = false)
        {
            Console.WriteLine("Aufgabe 6.1");
            string input = Utils.GetInput(6, isSample);

            int counter = 0;
            string common = "";
                foreach (char obj in input)
                {
                    Console.WriteLine(obj);
                    if (common.IndexOf(obj.ToString()) >= 0)
                    {
                        common = common.Split(obj)[1];
                    }
                    common = common + obj.ToString();
                    counter++;
                Console.WriteLine("common: " + common);
                if (common.Length == 4)
                {
                    break;
                }
            }
            
            Console.WriteLine("Max: " + counter );
        }

        public static void Solve_2(bool isSample = false)
        {
            Console.WriteLine("Aufgabe 6.2");
            string input = Utils.GetInput(6, isSample);

            int counter = 0;
            string common = "";
            foreach (char obj in input)
            {
                Console.WriteLine(obj);
                if (common.IndexOf(obj.ToString()) >= 0)
                {
                    common = common.Split(obj)[1];
                }
                common = common + obj.ToString();
                counter++;
                Console.WriteLine("common: " + common);
                if (common.Length == 14)
                {
                    break;
                }
            }

            Console.WriteLine("Max: " + counter);
        }
    }
}
