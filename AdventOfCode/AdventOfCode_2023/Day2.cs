using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdventOfCode_2023
{
    internal class Day2
    {
        static readonly int _redcubes = 12;
        static readonly int _greencubes = 13;
        static readonly int _bluecubes = 14;

        public static void RunPart1(bool isSample = false)
        {
            Console.WriteLine("Aufgabe 2.1");

            string[] input = Utils.GetInputByLine(2, isSample);
            List<Game> games = SortGames(input);
            int total = 0;

            foreach (Game game in games)
            {
                if (game.Red.Any(r => r > _redcubes) || game.Green.Any(r => r > _greencubes) || game.Blue.Any(r => r > _bluecubes))
                {
                    continue;
                }
                    Console.WriteLine(game.Id);
                    total = total + game.Id;   
            }

            Console.WriteLine("Total= " + total);
        }

        public static void RunPart2(bool isSample = false)
        {
            Console.WriteLine("Aufgabe 2.2");

            string[] input = Utils.GetInputByLine(2, isSample);
            List<Game> games = SortGames(input);
            int total = 0;

            foreach (Game game in games)
            {
                int fewestnumber= game.Green.Max() * game.Blue.Max() * game.Red.Max();
                Console.WriteLine(fewestnumber);
                total = total + fewestnumber;
            }

            Console.WriteLine("Total= " + total);
        }

        private static List<Game> SortGames(string[] input)
        {
            List<Game> games = new List<Game>();
            for (int i = 0; i < input.Length; i++)
            {
                Game game = new Game();
                game.Id = Convert.ToInt32(input[i].Split(':')[0].Split(" ")[1]);
                game.Green = GetMatchets(input[i], "green");
                game.Red = GetMatchets(input[i], "red");
                game.Blue = GetMatchets(input[i], "blue");
                Console.WriteLine($"--------------------------------");
                games.Add(game);
            }
            return games;
        }

        private static List<int> GetMatchets(string input, string color)
        {
            Regex regex = new Regex($@"\d+\s\b(?:{color})\b");
            var matches = regex.Matches(input);
            List<int> counts = new List<int>();
            foreach ( var match in matches )
            {
                counts.Add(Convert.ToInt32(match.ToString().Replace($"{color}", "").Trim()));
            }
            return counts;
        }

        internal class Game
        {
            public int Id { get; set; }
            public List<int> Red { get; set; }
            public List<int> Green { get; set; }
            public List<int> Blue { get; set; }
        }
    }
}
