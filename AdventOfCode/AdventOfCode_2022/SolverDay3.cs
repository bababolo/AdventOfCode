using System;
using System.Collections.Generic;

namespace AdventOfCode2022
{
    public static class SolverDay3
    {
        public static void Solve_1(bool isSample = true)
        {
            Console.WriteLine("Aufgabe 3.1");

            string[] input = Utils.GetInputByLine(3, isSample);

            int sum = 0;
          List<string> list = new List<string>();
            for (int i = 0; i < input.Length; i++)
            {
                var first = input[i].Substring(0, (int)(input[i].Length / 2));
                var last = input[i].Substring((int)(input[i].Length / 2), (int)(input[i].Length / 2));

                foreach (char obj in first)
                    if (last.IndexOf(obj) > -1)
                    {
                        list.Add(obj.ToString());
                    }

            }

            Console.WriteLine("Max: " + sum);
        }

        public static void Solve_2(bool isSample = false)
        {
            Console.WriteLine("Aufgabe 3.2");

            string[] input = Utils.GetInputByLine(3, isSample);
            int sum = 0;
            for (int i = 0; i < input.Length; i++)
            {
                int row = 0;
                string other = input[i].Split(" ")[0];
                string me = input[i].Split(" ")[1];
                  if (me.Equals("X")) {
                      row = 0;
                      switch (other)
                      {
                          case "A":
                              row = row +3;
                              break;
                          case "B":
                              row = row + 1;
                              break;
                          case "C":
                            row = row + 2;
                            break;
                      }
                  }

                   else if (me.Equals("Y"))
                  {
                      row = 3;
                      switch (other)
                      {
                          case "A":
                              row = row + 1;
                              break;
                          case "B":
                              row = row + 2;
                              break;
                          case "C":
                              row = row + 3;
                              break;
                      }
                  }


                  if (me.Equals("Z"))
                  {
                      row = 6;
                      switch (other)
                      {
                          case "A":
                              row = row + 2;
                              break;
                          case "B":
                              row = row + 3;
                              break;
                          case "C":
                              row = row + 1;
                              break;
                      }
                  }

                  sum = sum + row;
            }

            Console.WriteLine("Max: " + sum);
        }
    }
}
