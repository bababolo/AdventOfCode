using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace AdventOfCode2021
{
    public  static  class SolverDay2
    {
        public static void Solve_1(bool isSample = false)
        {
            Console.WriteLine("Aufgabe 2.1");

            string[] inputList = Utils.GetInputByLine(2, isSample);
            int horizontal = 0;
            int depth = 0;

            foreach (var input in inputList)
            {
                string direction = input.Split(" ")[0];
                int value = Convert.ToInt32(input.Split(" ")[1]);

                switch (direction)
                { case "forward":
                        horizontal = horizontal + value;
                        break;
                    case "down":
                        depth = depth + value;
                        break;
                    case "up":
                        depth = depth - value;
                        break;
                }
            }

            Console.WriteLine("Horizontal " + horizontal);
            Console.WriteLine("Depth " + depth);
            Console.WriteLine("Result " + depth * horizontal);
        }

        public static void Solve_2(bool isSample = false)
        {
            Console.WriteLine("Aufgabe 2.2");

            string[] inputList = Utils.GetInputByLine(2, isSample);
            int horizontal = 0;
            int depth = 0;
            int aim = 0;

            foreach (var input in inputList)
            {
                string direction = input.Split(" ")[0];
                int value = Convert.ToInt32(input.Split(" ")[1]);

                switch (direction)
                {
                    case "down":
                        aim = aim + value;
                        break;
                    case "up":
                        aim = aim - value;
                        break;
                    case "forward":
                        horizontal = horizontal + value;
                        depth = depth + (aim * value);
                        break;
                }
            }

            Console.WriteLine("Horizontal " + horizontal);
            Console.WriteLine("Depth " + depth);
            Console.WriteLine("Result " + depth * horizontal);
        }
    }
}
