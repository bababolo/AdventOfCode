using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode2022
{
    public static class SolverDay7
    {
        private static List<Directory> resultList = new List<Directory>();
        private static int sum = 0;

        public static void Solve_1(bool isSample = false)
        {
            Console.WriteLine("Aufgabe 7.1");
            string[] input= Utils.GetInputByLine(7, isSample);

            Directory root = new Directory() { Name = "root" };
            Directory currentDirectory = root;

            foreach (string line in input)
            {
                if (line.StartsWith("$ cd"))
                {
                    string cd = line.Replace("$", "").Trim().Split(' ')[1];
                    if (cd == "..")
                    {
                        if (currentDirectory.Parent == null)
                        {
                            currentDirectory = root;
                        }
                        else
                        {
                            currentDirectory = currentDirectory.Parent;
                        }
                    }
                    else
                    {
                        if (cd != "/")
                        {
                            currentDirectory = currentDirectory.Directories.Single(x => x.Name == cd);
                        }
                    }
                }

                if (line.Contains("dir", StringComparison.OrdinalIgnoreCase))
                {
                    string dirname = line.Split(' ')[1];
                    Directory directory = new Directory
                    {
                        Name = dirname,
                        Parent = currentDirectory,
                    };
                    if (!currentDirectory.Directories.Any(x => x.Name == dirname))
                    {
                        currentDirectory.Directories.Add(directory);
                    }
                }

                Regex regex = new Regex("[0-9]");

                if (regex.IsMatch(line))
                {
                    int size = int.Parse(line.Split(" ")[0]);
                    string name = line.Split(" ")[1];
                    AocFile file = new AocFile();
                    file.Name = name;
                    file.Size = size;
                    currentDirectory?.Files.Add(file);
                }
            }

            SumUpSize(root);
            resultList.ForEach(x => Console.WriteLine($"{x.Name}: {x.Size}"));
            Console.WriteLine($"07.2022_1: {resultList.Sum(x => x.Size)}");
        }

        public static void Solve_2(bool isSample = false)
        {
        }

        private static void SumUpSize(Directory directory)
        {
            foreach (var dir in directory.Directories)
            {
                var size = dir.Size;
                if (size < 100000)
                {
                    resultList.Add(dir);
                }
                SumUpSize(dir);
            }
        }
    }

    internal class Directory
    {
        public List<AocFile> Files { get; set; } = new List<AocFile>();
        public string Name { get; set; }
        public List<Directory> Directories { get; set; } = new List<Directory>();
        public Directory Parent { get; set; }
        int size = 0;
        public int Size
        {
            get
            {
                size = 0;
                SumUpSize(this);
                return size;
            }
        }

        private int SumUpSize(Directory directory)
        {
            size += directory.Files.Sum(x => x.Size);
            foreach (var dir in directory.Directories)
            {
                SumUpSize(dir);
            }
            return size;
        }
    }

    internal class AocFile
    {
        public string Name { get; set; }
        public int Size { get; set; }
    }

}
