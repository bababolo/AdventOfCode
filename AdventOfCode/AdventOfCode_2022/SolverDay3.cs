using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;

namespace AdventOfCode2022
{
    public static class SolverDay3
    {
        public static void Solve_1(bool isSample = false)
        {
            Console.WriteLine("Aufgabe 3.1");
            string[] input = Utils.GetInputByLine(3, isSample);
            var az = Enumerable.Range('a', 'z' - 'a' + 1).Select(c => (char)c).ToList();
            var AZ = Enumerable.Range('A', 'Z' - 'A' + 1).Select(c => (char)c).ToList();

            int sum = 0;
            for (int i = 0; i < input.Length; i++)
            {
                //Console.WriteLine(input[i]);
                var first = input[i].Substring(0, (int)(input[i].Length / 2));
                var last = input[i].Substring((int)(input[i].Length / 2), (int)(input[i].Length / 2));

                //Console.WriteLine(first);
                //Console.WriteLine(last);
                foreach (char obj in first) {
                    Console.WriteLine(obj);
                    if (last.Contains(obj))
                    {
                        Console.WriteLine("common: " +obj);
                        if (az.Contains(obj))
                        {
                            sum = sum + az.IndexOf(obj) + 1;
                        }
                        if (AZ.Contains(obj))
                        {
                            sum = sum + AZ.IndexOf(obj) + 27;
                        }
                        break;
                    }
                }
            }
            Console.WriteLine("Max: " + sum);
        }

        public static void Solve_2(bool isSample = false)
        {
            Console.WriteLine("Aufgabe 3.2");
            string[] input = Utils.GetInputByLine(3, isSample);
            var az = Enumerable.Range('a', 'z' - 'a' + 1).Select(c => (char)c).ToList();
            var AZ = Enumerable.Range('A', 'Z' - 'A' + 1).Select(c => (char)c).ToList();

            int sum = 0;
            for (int i = 0; i < input.Length-2; i = i+3 )
            {
                Console.WriteLine(i);
                var first = input[i];
                var second = input[i + 1];
                var third = input[i + 2];

                foreach (char obj in first)
                {
                    Console.WriteLine(obj);
                    if (second.Contains(obj) && third.Contains(obj))
                    {
                        Console.WriteLine("common: " + obj);
                        if (az.Contains(obj))
                        {
                            sum = sum + az.IndexOf(obj) + 1;
                        }
                        if (AZ.Contains(obj))
                        {
                            sum = sum + AZ.IndexOf(obj) + 27;
                        }
                        break;
                    }
                }
            }
            Console.WriteLine("Max: " + sum);
        }
    }
}
