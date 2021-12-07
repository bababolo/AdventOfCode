using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace AdventOfCode2021
{
    public static class SolverDay4
    {
        public static void Solve_1(bool isSample = false)
        {
            Console.WriteLine("Aufgabe 4.1");
            List<string> inputList = Utils.GetInputByLine(4, isSample).ToList();

            List<int> numbers = inputList[0].Split(",").Select(i => Convert.ToInt32(i)).ToList();
            inputList.RemoveAt(0);

            List<Board> boards = CreateBoards(inputList);

            int winner = 0;
            foreach (var number in numbers)
            {
                bool winnerFound = false;
                foreach (var board in boards)
                {
                    winnerFound = BoardHasWon(number, board);
                    if (winnerFound)
                    {
                        Console.WriteLine("Number: " + number);
                        Console.WriteLine("WinnerBoard: " + board.Id);
                        int sum = FindSumOfUncheckedFields(board);
                        Console.WriteLine("Summe: " + sum);
                        Console.WriteLine("Result: " + number * sum);
                        break;
                    }
                }
                if (winnerFound)
                {
                    break;
                }
            }
        }

        public static void Solve_2(bool isSample = false)
        {
            Console.WriteLine("Aufgabe 4.2");
            List<string> inputList = Utils.GetInputByLine(4, isSample).ToList();

            List<int> numbers = inputList[0].Split(",").Select(i => Convert.ToInt32(i)).ToList();
            inputList.RemoveAt(0);

            List<Board> boards = CreateBoards(inputList);
            List<int> ids = new List<int>();
            int lastNumber = 0;
            bool finished = false;
            foreach (var number in numbers)
            {
                foreach (var board in boards)
                {
                    if (BoardHasWon(number, board))
                    {
                        ids.Add(board.Id);
                    }

                    if (boards.Select(b => b.Id).ToList().All(id => ids.Contains(id)))
                    {
                        lastNumber = number;
                        finished = true;
                        break;
                    }
                }

                if (finished)
                {
                    break;
                }
            }

            Console.WriteLine("Lastnumber " + lastNumber);
            Console.WriteLine("winnerBoard " + ids.Last());
            Console.WriteLine("sum " + FindSumOfUncheckedFields(boards.FirstOrDefault(b => b.Id == ids.Last())));
            Console.WriteLine("result " + lastNumber * FindSumOfUncheckedFields(boards.FirstOrDefault(b => b.Id == ids.Last())));
        }

        private static int FindSumOfUncheckedFields(Board board)
        {
            int sum = 0;
            for (int col = 0; col < 5 ; col++)
            {
                var values = GetRow(board, col);
                foreach (var value in values)
                {
                    int add = value != null ? (int)value : 0;
                    sum = sum + add ;
                }
            }
            return sum;
        }

        private static bool BoardHasWon( int number, Board board)
        {
                int?[,] fields = board.Fields;
                for (int row = 0; row < fields.GetLength(0); row++)
                {
                    for (int col = 0; col < fields.GetLength(1); col++)
                    {
                        if (fields[row, col] == number)
                        {
                            fields[row, col] = null;
                            var rowValues = GetRow(board, row);
                            var colValues = GetCol(board, col);

                            if (rowValues.All(r => r == null) || colValues.All(c => c == null))
                            {
                                return true;
                            }
                        }
                    }
                }
                return false;
        }

        private static List<int?> GetRow(Board board, int row)
        {
            List<int?> values = new List<int?>();
            for (int i = 0; i < 5; i++)
            {
                values.Add(board.Fields[row, i]);
            }
            return values;
        }
        private static List<int?> GetCol(Board board, int col)
        {
            List<int?> values = new List<int?>();
            for (int i = 0; i < 5; i++)
            {
                values.Add(board.Fields[i, col]);
            }
            return values;
        }



        private static List<Board> CreateBoards(List<string> inputList)
        {
            int id = 1;
            int row = 0;
            Board board = null;
            List<Board> boards = new List<Board>();
            foreach (var input in inputList)
            {
                if (String.IsNullOrEmpty(input))
                {
                    if (board != null)
                    {
                        boards.Add(board);
                    }

                    board = new Board() { Id = id, Fields = new int?[5, 5] };
                    row = 0;
                    id++;
                }
                else
                {
                    List<string> rowlist = input.Split(" ").ToList();
                    rowlist.RemoveAll(String.IsNullOrEmpty);

                    for (int i = 0; i < 5; i++)
                    {
                        if (board != null)
                        {
                            board.Fields[row, i] = Convert.ToInt32(rowlist[i]);
                        }
                    }

                    row++;
                }
            }

            boards.Add(board);
            return boards;
        }

        public class Board
        {
            public int Id { get; set; }
            public int?[,] Fields { get; set; }
        }

        //public class Field
        //{
        //    public int Value { get; set; }
        //    public bool Marked { get; set; }
        //}
    }
}
