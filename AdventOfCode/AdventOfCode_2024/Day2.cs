using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AdventOfCode_2024
{
    internal class Day2
    {
        readonly static int _day = 2;
       
        public static void RunPart1(bool isSample = false)
        {
            Console.WriteLine($"Aufgabe {_day}.1");

            string[] input = Utils.GetInputByLine(_day, isSample);
            int result = 0;
            for (int i = 0; i < input.Length; i++)
            {
                string[] list = input[i].Split(" ");
                bool decrease = (Convert.ToInt32(list[0]) - Convert.ToInt32(list[1])) > 0;
                bool safe = true;
                for (int j = 0; j < list.Length - 1; j++)
                {
                    int value  = Convert.ToInt32(list[j]) - Convert.ToInt32(list[j+1]);
                    Console.WriteLine(value);
                    if (Math.Abs(value) < 1 || Math.Abs(value) > 3 || (value > 0 != decrease))
                    {
                        safe = false;
                        break;
                    }
                }
                if (safe) { result++; }
            }
            Console.WriteLine($"Result {_day} = " + result);
        }

        public static void RunPart2(bool isSample = true)
        {
            Console.WriteLine($"Aufgabe {_day}.2");


            string[] input = Utils.GetInputByLine(_day, isSample);
            int result = 0;
            for (int i = 0; i < input.Length; i++)
            {
                string[] list = input[i].Split(" ");
                bool decrease = (Convert.ToInt32(list[0]) - Convert.ToInt32(list[1])) > 0;
                int count = 0;
                for (int j = 0; j < list.Length - 1; j++)
                {
                    int value = Convert.ToInt32(list[j]) - Convert.ToInt32(list[j + 1]);
                    Console.WriteLine(value);
                    if (Math.Abs(value) < 1 || Math.Abs(value) > 3 || (value > 0 != decrease))
                    {
                        count++;
                    }
                }
                if (count < 2) { 
                    result++; 
                }
            }
            Console.WriteLine($"Result {_day} = " + result);
        }
    }
}
