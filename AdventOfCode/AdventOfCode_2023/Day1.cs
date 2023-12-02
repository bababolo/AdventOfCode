namespace AdventOfCode_2023
{
    internal class Day1
    {
        static readonly string[] _letters = { "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };

        public static void RunPart1(bool isSample = false)
        {
            Console.WriteLine("Aufgabe 1.1");

            String[] input = Utils.GetInputByLine(1, isSample);
            int total = 0;
            for (int i = 0; i < input.Length; i++)
            {
                int number = 0;
                String numberOnly = new String(input[i].Where(Char.IsDigit).ToArray());
                number = Convert.ToInt32(numberOnly[0].ToString() + numberOnly[^1]);
                
                total = total + number;
            }

            Console.WriteLine("Total= " + total);
        }

        public static void RunPart2(bool isSample = false)
        {
            Console.WriteLine("Aufgabe 1.2");


            String[] input = Utils.GetInputByLine(1, isSample);
            int total = 0;
           
            int number = 0;
            for (int i = 0; i < input.Length; i++)
            {
                string numberstring = "";
                for (int j=0; j <input[i].Length; j++)
                {
                    numberstring = numberstring + SearchLetters(input[i][j].ToString(), input[i],j, false);
                    Console.WriteLine(numberstring);
                }
                number = Convert.ToInt32(numberstring[0].ToString() + numberstring[^1]);

                total = total + number;
            }

            Console.WriteLine("Total= " + total);
        }

        private static string SearchLetters(string value, string input, int i, bool found)
        {
            if (int.TryParse(value, out _))
            {
                found = true;
                return value.ToString();
                
            }
            if (_letters.Contains(value.ToString()))
            {
              int index = Array.IndexOf(_letters, value);
              found = true;
              return (index +1).ToString();
            }
            if (i < input.Length-1 && !found) { 
               i++;
                value = value + input[i];
                return SearchLetters(value, input, i,found);
            }
            return "";
        }
    }
}



