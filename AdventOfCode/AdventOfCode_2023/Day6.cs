using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode_2023
{
    internal class Day6
    {
        readonly static int _day = 6;

        public static void RunPart1(bool isSample = true)
        {
            Console.WriteLine($"Aufgabe {_day}.1");

            string[] input = Utils.GetInputByLine(_day, isSample);
            List<Race> races = new List<Race>();
            int result = 0;
            var times = input[0].Split(':')[1].Split(' ').Where(n => !string.IsNullOrWhiteSpace(n.ToString())).Select(x => Convert.ToInt32(x)).ToArray();
            var distances = input[1].Split(':')[1].Split(' ').Where(n => !string.IsNullOrWhiteSpace(n.ToString())).Select(x => Convert.ToInt32(x)).ToArray();
            for (int i = 0; i < times.Length; i++)
            {
                Race race = new Race()
                {
                    Time = times[i],
                    Distance = distances[i],
                    Wins = 0,
                };
                races.Add(race);
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

            }
            Console.WriteLine($"Result {_day} = " + result);
        }

        internal class Race
        {
            public int Time { get; set; }
            public int Distance { get; set; }
            public int Wins { get; set; }
        }
    }
}
