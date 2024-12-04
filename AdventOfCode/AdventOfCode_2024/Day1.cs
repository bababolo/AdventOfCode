using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode_2024
{
    internal class Day1
    {
        readonly static int _day = 1;
       
        public static void RunPart1(bool isSample = false)
        {
            Console.WriteLine($"Aufgabe {_day}.1");

            string[] input = Utils.GetInputByLine(_day, isSample);
            int result = 0;
            int[] list1 = new int[input.Length];
            int[] list2 = new int[input.Length];
            for (int i = 0; i < input.Length; i++)
            {
                list1[i] = Convert.ToInt32(input[i].Split("   ")[0]);
                list2[i] = Convert.ToInt32(input[i].Split("   ")[1]);
            }
            Array.Sort(list1);
            Array.Sort(list2);

            for (int i = 0; i < input.Length; i++)
            {
              int diff = 0;
              if (list1[i] > list2[i])
                {                
                   diff = (list1[i] - list2[i]);
                }
                if (list2[i] > list1[i])
                {
                    diff = (list2[i] - list1[i]);
                }
                Console.WriteLine(diff.ToString());
                result = result + diff;
            }
            Console.WriteLine($"Result {_day} = " + result);
        }

        public static void RunPart2(bool isSample = false)
        {
            Console.WriteLine($"Aufgabe {_day}.2");

            string[] input = Utils.GetInputByLine(_day, isSample);
            int result = 0;
            int[] list1 = new int[input.Length];
            int[] list2 = new int[input.Length];
            for (int i = 0; i < input.Length; i++)
            {
                list1[i] = Convert.ToInt32(input[i].Split("   ")[0]);
                list2[i] = Convert.ToInt32(input[i].Split("   ")[1]);
            }

            for (int i = 0; i < input.Length; i++)
            {
                int count = list2.Count(n => n == list1[i]);
                int value = list1[i] * count;
                Console.WriteLine(list1[i] + " * " +  count + " = " + value);
                result = result + value;
            }
            Console.WriteLine($"Result {_day} = " + result);
        }
    }
}
