using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace AdventOfCode2021
{
    public static class SolverDay5
    {
        private static int size = 5000;
        public static void Solve_1(bool isSample = false)
        {
            Console.WriteLine("Aufgabe x.5");
            string[] inputList = Utils.GetInputByLine(5, isSample);
            List<Line> lines = CreateLines(inputList);
            int[,] area = DrawHorizontalAndVerticalLines(lines);
            int counter = 0;

            for (int x = 0; x < size; x++)
            {
                for (int y = 0; y < size; y++)
                {
                    if (area[x, y] > 1)
                    {
                        counter++;
                    }
                }
            }

            Console.WriteLine("Result: "+  counter);
        }

        public static void Solve_2(bool isSample = false)
        {
            Console.WriteLine("Aufgabe 5.2");
            string[] inputList = Utils.GetInputByLine(5, isSample);
            List<Line> lines = CreateLines(inputList);
            int[,] area = DrawAllLines(lines);
            int counter = 0;

            for (int y = 0; y < size; y++)
            {
              //  Console.WriteLine();
                for (int x = 0; x < size; x++)
                {
                //    Console.Write(area[x,y] + " ");
                    if (area[x, y] > 1)
                    {
                        counter++;
                    }
                }
            }

            Console.WriteLine("Result: " + counter);
        }

        private static int[,] DrawAllLines(List<Line> lines)
        {
            int[,] area = new int[size, size];
            foreach (var line in lines)
            {
                int xend = line.End[0];
                int yend = line.End[1];

                int x = line.Start[0];
                int y = line.Start[1];

                while (!(x == xend && y == yend))
                {
                    area[x, y]++;
                    x = GetNextValue(x, xend);
                    y = GetNextValue(y, yend);
                }
                area[x, y]++;
            }

            return area;
        }

        private static int GetNextValue(int value, int end)
        {
            if (value < end)
            {
              return value+1;
            } 
            if (value > end)
            {
              return  value-1;
            }
            return value;
        }

        private static int[,] DrawHorizontalAndVerticalLines(List<Line> lines)
        {
            int[,] area = new int[size,size];
            foreach (var line in lines)
            {
                if (line.Start[0] == line.End[0])
                {
                    // x1 = x1
                    int x = line.Start[0];
                    int ymin = line.Start[1] < line.End[1] ? line.Start[1] : line.End[1];
                    int ymax = line.Start[1] > line.End[1] ? line.Start[1] : line.End[1];
                    for (int y = ymin; y <= ymax; y++)
                    {
                        area[x, y]++;
                    }
                }

                if (line.Start[1] == line.End[1])
                {
                    // xy = xy
                    int y = line.Start[1];
                    int xmin = line.Start[0] < line.End[0] ? line.Start[0] : line.End[0];
                    int xmax = line.Start[0] > line.End[0] ? line.Start[0] : line.End[0];
                    for (int x = xmin; x <= xmax; x++)
                    {
                        area[x, y]++;
                    }
                }
            }

            return area;
        }

        private static List<Line> CreateLines(string[] inputList)
        {
            List<Line> lines = new List<Line>();
            foreach (var input in inputList)
            {
                string[] lineString= input.Split(" -> ");

                Line line = new Line()
                {
                    Start = new []{Convert.ToInt32(lineString[0].Split(",")[0]),
                        Convert.ToInt32(lineString[0].Split(",")[1])},
                    End = new []{Convert.ToInt32(lineString[1].Split(",")[0]),
                        Convert.ToInt32(lineString[1].Split(",")[1])}
                };
                lines.Add(line);
            }

            return lines;
        }
        public class Line
        {
            public int[] Start { get; set; }
            public int[] End { get; set; }
        }
    }
}
