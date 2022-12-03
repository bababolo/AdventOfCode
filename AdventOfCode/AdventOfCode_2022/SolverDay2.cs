using System;

namespace AdventOfCode2022
{
    public static class SolverDay2
    {
        public static void Solve_1(bool isSample = false)
        {
            Console.WriteLine("Aufgabe 2.1");

            string[] input = Utils.GetInputByLine(2, isSample);
            int sum = 0;
            for (int i = 0; i < input.Length; i++)
            {
                int row = 0;
                string other = input[i].Split(" ")[0];
                string me = input[i].Split(" ")[1];

                switch (me)
                {
                    case "X":
                        row = 1;
                        break;
                    case "Y":
                        row = 2;
                        break;
                    case "Z":
                        row = 3;
                        break;
                }

                if (other.Equals("A") && me.Equals("X") || other.Equals("B") && me.Equals("Y") || other.Equals("C") && me.Equals("Z"))
                {
                    row = row + 3;
                } else if (other.Equals("A") && me.Equals("Y") || other.Equals("B") && me.Equals("Z") || other.Equals("C") && me.Equals("X"))
                {
                    row = row + 6;
                }
                else if (other.Equals("A") && me.Equals("Z") || other.Equals("B") && me.Equals("X") || other.Equals("C") && me.Equals("Y"))
                {
                    row = row + 0;
                }
                sum = sum + row;
            }

            Console.WriteLine("Max: " + sum);
        }

        public static void Solve_2(bool isSample = false)
        {
            Console.WriteLine("Aufgabe 1.2");

            string[] input = Utils.GetInputByLine(2, isSample);
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
