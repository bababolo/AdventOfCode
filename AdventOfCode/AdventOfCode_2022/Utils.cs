using System;

namespace AdventOfCode2022
{
    public static class Utils
    {
        public static string[] GetInputByLine(int day, bool isSample = false)
        {
           string currentDirectory = @$"D:\00_Code\AdventOfCode\AdventOfCode\AdventOfCode_2022\PuzzleInputs\Day{day}";
            string fileName = isSample ? "Sample.txt" : "Input.txt";
            string filePath = System.IO.Path.Combine(currentDirectory, fileName);

            return System.IO.File.ReadAllLines(filePath);
        }

        public static string GetInput(int day, bool isSample = false)
        {
            string currentDirectory = @$"D:\00_Code\AdventOfCode\AdventOfCode\AdventOfCode_2022\PuzzleInputs\Day{day}";
            string fileName = isSample ? "Sample.txt" : "Input.txt";
            string filePath = System.IO.Path.Combine(currentDirectory, fileName);

            return System.IO.File.ReadAllText(filePath);
        }

        public static int[] ConvertArrayToInt(string[] input)
        {
            int[] array = new int[input.Length];
            for (int i = 0; i < input.Length; i++)
            {
                array[i] = Convert.ToInt32(input[i]);
            }

            return array;
        }
    }
}
