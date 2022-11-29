using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode2021
{
    public static class SolverDay3
    {
        public static void Solve_1(bool isSample = false)
        {
            Console.WriteLine("Aufgabe 3.1");

            string[] inputList = Utils.GetInputByLine(3, isSample);
            int count = inputList.Length;
            int length = inputList[0].Length;
            string gamma = "";
            string epsilon = "";

            int[] sumArray = GetSumArray(inputList, length);

            for (int i = 0; i < length; i++)
            {
                gamma = gamma + (sumArray[i] > (count / 2) ? "1" : "0");
                epsilon = epsilon + (sumArray[i] > (count / 2) ? "0" : "1");
            }

            Console.WriteLine("Gamma " + gamma);
            Console.WriteLine("Epsilon " + epsilon);

            int gammaInt = Convert.ToInt32(gamma, 2);
            int epsilonInt = Convert.ToInt32(epsilon, 2);
            int power = gammaInt * epsilonInt;

            Console.WriteLine("Gamma Dezimal " + gammaInt);
            Console.WriteLine("Epsilon Dezimal " + epsilonInt);
            Console.WriteLine("Power " + gammaInt * epsilonInt);
        }

        public static void Solve_2(bool isSample = false)
        {
            Console.WriteLine("Aufgabe 3.2");
            string[] inputList = Utils.GetInputByLine(3, isSample);
            int length = inputList[0].Length;

            List<string> oxygenList = inputList.ToList();
            List<string> co2List = inputList.ToList();

            for (int i = 0; i < length; i++)
            {
                int[] currentSumArray = GetSumArray(oxygenList.ToArray(), length);
                string value = Convert.ToDecimal(currentSumArray[i]) >= (Convert.ToDecimal(oxygenList.Count) / 2) ? "1" : "0";
                oxygenList = oxygenList.Where(o => o[i].ToString().Equals(value)).ToList();
                if (oxygenList.Count == 1)
                {
                    break;
                }
            }

            for (int i = 0; i < length; i++)
            {
                int[] currentSumArray = GetSumArray(co2List.ToArray(), length);
                string value = Convert.ToDecimal(currentSumArray[i]) >= (Convert.ToDecimal(co2List.Count) / 2) ? "0" : "1";
                co2List = co2List.Where(c => c[i].ToString().Equals(value)).ToList();
                if (co2List.Count == 1)
                {
                    break;
                }
            }

            int oxygen = Convert.ToInt32(oxygenList.FirstOrDefault(), 2);
            int co2 = Convert.ToInt32(co2List.FirstOrDefault(), 2);
            Console.WriteLine("oxygon bit " + oxygenList.FirstOrDefault());
            Console.WriteLine("oxygon " + oxygen);
            Console.WriteLine("co2 bit " + co2List.FirstOrDefault());
            Console.WriteLine("co2 " + co2);
            Console.WriteLine("Result " + co2*oxygen);
        }

        private static int[] GetSumArray(string[] inputList, int length)
        {
            int[] sumArray = new int[length];
            foreach (var input in inputList)
            {
                for (int i = 0; i < length; i++)
                {
                    sumArray[i] = sumArray[i] + Convert.ToInt32(input.Substring(i, 1));
                }
            }

            return sumArray;
        }
    }
}
