using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static AdventOfCode_2023.Day2;

namespace AdventOfCode_2023
{
    internal class Day5
    {
        readonly static int _day = 5;

        public static void RunPart1(bool isSample = false)
        {
            Console.WriteLine($"Aufgabe {_day}.1");
            List<long> seeds = new List<long> ();
            List<Plan> plans = new List<Plan> ();
            List<KeyValuePair<long, long>> seedSoilMap = new List<KeyValuePair<long, long>>();
            string[] input = Utils.GetInputByLine(_day, isSample);
            int result = 0;
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i].StartsWith("seeds:")){
                    seeds = input[i].Split(':')[1].Split(' ').Where(n => !string.IsNullOrWhiteSpace(n.ToString())).Select(x => Convert.ToInt64(x)).ToList();
                    continue;
                }
                if (input[i].StartsWith("seed-to-soil"))
                {
                    i++;
                    List<Map> map = new List<Map>();
                    while (!String.IsNullOrEmpty(input[i]))
                    {
                        GetKeyValuePair(input[i], map);
                        i++;
                    }
                    i++;
                    plans = FillSeedToSoil(map, seeds);
                }
                if (input[i].StartsWith("soil-to-fertilizer"))
                {
                    i++;
                    List<Map> map = new List<Map>();
                    while (!String.IsNullOrEmpty(input[i]))
                    {
                        GetKeyValuePair(input[i], map);
                        i++;
                    }
                    i++;
                    FillSoilToFertilizer(map, seeds, plans);
                }
                if (input[i].StartsWith("fertilizer-to-water"))
                {
                    i++;
                    List<Map> map = new List<Map>();
                    while (!String.IsNullOrEmpty(input[i]))
                    {
                        GetKeyValuePair(input[i], map);
                        i++;
                    }
                    i++;
                    FillFertilizerToWater(map, seeds, plans);
                }
                if (input[i].StartsWith("water-to-light"))
                {
                    i++;
                    List<Map> map = new List<Map>();
                    while (!String.IsNullOrEmpty(input[i]))
                    {
                        GetKeyValuePair(input[i], map);
                        i++;
                    }
                    i++;
                    FillWaterToLight(map, seeds, plans);
                }
                if (input[i].StartsWith("light-to-temperature"))
                {
                    i++;
                    List<Map> map = new List<Map>();
                    while (!String.IsNullOrEmpty(input[i]))
                    {
                        GetKeyValuePair(input[i], map);
                        i++;
                    }
                    i++;
                    FillLightToTemperature(map, seeds, plans);
                }
                if (input[i].StartsWith("temperature-to-humidity"))
                {
                    i++;
                    List<Map> map = new List<Map>();
                    while (!String.IsNullOrEmpty(input[i]))
                    {
                        GetKeyValuePair(input[i], map);
                        i++;
                    }
                    i++;
                    FillTemperatureToHumidity(map, seeds, plans);
                }
                if (input[i].StartsWith("humidity-to-location"))
                {
                    i++;
                    List<Map> map = new List<Map>();
                    while (!String.IsNullOrEmpty(input[i]) && i < input.Length-1)
                    {
                        GetKeyValuePair(input[i], map);
                        i++;
                    }
                    i++;
                    FillTHumidityToLocation(map, seeds, plans);
                }


            }
            Console.WriteLine($"Result {_day} = " + plans.Select(p => p.Location).Min());
        }

        public static void RunPart2(bool isSample = false)
        {
            Console.WriteLine($"Aufgabe {_day}.1");
            List<long> seeds = new List<long>();
            List<Plan> plans = new List<Plan>();
            List<KeyValuePair<long, long>> seedSoilMap = new List<KeyValuePair<long, long>>();
            string[] input = Utils.GetInputByLine(_day, isSample);
            int result = 0;
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i].StartsWith("seeds:"))
                {
                    var pairs = input[i].Split(':')[1].Split(' ').Where(n => !string.IsNullOrWhiteSpace(n.ToString())).ToArray();
                    for (int j = 0; j < pairs.Length; j = j+2)
                    {
                        for (int y = 0; y < Convert.ToInt32(pairs[j+1]); y++)
                        {
                            seeds.Add(Convert.ToInt64(pairs[j]) + y);
                        }
                    }
                        continue;
                }
                if (input[i].StartsWith("seed-to-soil"))
                {
                    i++;
                    List<Map> map = new List<Map>();
                    while (!String.IsNullOrEmpty(input[i]))
                    {
                        GetKeyValuePair(input[i], map);
                        i++;
                    }
                    i++;
                    plans = FillSeedToSoil(map, seeds);
                }
                if (input[i].StartsWith("soil-to-fertilizer"))
                {
                    i++;
                    List<Map> map = new List<Map>();
                    while (!String.IsNullOrEmpty(input[i]))
                    {
                        GetKeyValuePair(input[i], map);
                        i++;
                    }
                    i++;
                    FillSoilToFertilizer(map, seeds, plans);
                }
                if (input[i].StartsWith("fertilizer-to-water"))
                {
                    i++;
                    List<Map> map = new List<Map>();
                    while (!String.IsNullOrEmpty(input[i]))
                    {
                        GetKeyValuePair(input[i], map);
                        i++;
                    }
                    i++;
                    FillFertilizerToWater(map, seeds, plans);
                }
                if (input[i].StartsWith("water-to-light"))
                {
                    i++;
                    List<Map> map = new List<Map>();
                    while (!String.IsNullOrEmpty(input[i]))
                    {
                        GetKeyValuePair(input[i], map);
                        i++;
                    }
                    i++;
                    FillWaterToLight(map, seeds, plans);
                }
                if (input[i].StartsWith("light-to-temperature"))
                {
                    i++;
                    List<Map> map = new List<Map>();
                    while (!String.IsNullOrEmpty(input[i]))
                    {
                        GetKeyValuePair(input[i], map);
                        i++;
                    }
                    i++;
                    FillLightToTemperature(map, seeds, plans);
                }
                if (input[i].StartsWith("temperature-to-humidity"))
                {
                    i++;
                    List<Map> map = new List<Map>();
                    while (!String.IsNullOrEmpty(input[i]))
                    {
                        GetKeyValuePair(input[i], map);
                        i++;
                    }
                    i++;
                    FillTemperatureToHumidity(map, seeds, plans);
                }
                if (input[i].StartsWith("humidity-to-location"))
                {
                    i++;
                    List<Map> map = new List<Map>();
                    while (!String.IsNullOrEmpty(input[i]) && i < input.Length - 1)
                    {
                        GetKeyValuePair(input[i], map);
                        i++;
                    }
                    i++;
                    FillTHumidityToLocation(map, seeds, plans);
                }


            }
            Console.WriteLine($"Result {_day} = " + plans.Select(p => p.Location).Min());
        }


        private static List<Plan> FillSeedToSoil(List<Map> map, List<long> seeds)
        {
            List<Plan> plans = new List<Plan>();
            foreach (long seed in seeds)
            {

                Plan plan = new Plan()
                {
                    Seed = seed,                
                };

                var x = map.FirstOrDefault(m => seed >= m.SourceMin && seed <= m.SourceMax);
                
                if (x != null)
                {
                    var diff = seed - x.SourceMin;
                    plan.Soil = x.DestMin + diff;
                }
                else 
                {
                    plan.Soil = seed;
                }
                plans.Add(plan);
            }
            return plans;
        }

        private static void FillSoilToFertilizer(List<Map> map, List<long> seeds, List<Plan> plans)
        {
            foreach (long seed in seeds)
            {
                Plan plan = plans.First(p => p.Seed == seed);
                var x = map.FirstOrDefault(m => plan.Soil >= m.SourceMin && plan.Soil <= m.SourceMax);
                if (x != null)
                {
                    var diff = plan.Soil - x.SourceMin;
                    plan.Fertilizer = x.DestMin + diff;
                } else
                {
                    plan.Fertilizer = plan.Soil;
                }
            }
        }

        private static void FillFertilizerToWater(List<Map> map, List<long> seeds, List<Plan> plans)
        {
            foreach (long seed in seeds)
            {
                Plan plan = plans.First(p => p.Seed == seed);
                var x = map.FirstOrDefault(m => plan.Fertilizer >= m.SourceMin && plan.Fertilizer <= m.SourceMax);
                if (x != null)
                {
                    var diff = plan.Fertilizer - x.SourceMin;
                    plan.Water = x.DestMin + diff;
                } 
                else
                {
                    plan.Water = plan.Fertilizer;
                }
            }
        }

        private static void FillWaterToLight(List<Map> map, List<long> seeds, List<Plan> plans)
        {
            foreach (long seed in seeds)
            {
                Plan plan = plans.First(p => p.Seed == seed);
                var x = map.FirstOrDefault(m => plan.Water >= m.SourceMin && plan.Water <= m.SourceMax);
                if (x != null)
                {
                    var diff = plan.Water - x.SourceMin;
                    plan.Light = x.DestMin + diff;
                } else { 
                    plan.Light = plan.Water;
                }
            }
        }

        private static void FillLightToTemperature(List<Map> map, List<long> seeds, List<Plan> plans)
        {
            foreach (long seed in seeds)
            {
                Plan plan = plans.First(p => p.Seed == seed);
                var x = map.FirstOrDefault(m => plan.Light >= m.SourceMin && plan.Light <= m.SourceMax);
                if (x != null)
                {
                    var diff = plan.Light - x.SourceMin;
                    plan.Temperature = x.DestMin + diff;
                }
               else
                {
                    plan.Temperature = plan.Light;
                }
            }
        }

        private static void FillTemperatureToHumidity(List<Map> map, List<long> seeds, List<Plan> plans)
        {
            foreach (long seed in seeds)
            {
                Plan plan = plans.First(p => p.Seed == seed);
                var x = map.FirstOrDefault(m => plan.Temperature >= m.SourceMin && plan.Temperature <= m.SourceMax);
                if (x != null)
                {
                    var diff = plan.Temperature - x.SourceMin;
                    plan.Humidity = x.DestMin + diff;
                }
             else
                {
                    plan.Humidity = plan.Temperature;
                }
            }
        }


        private static void FillTHumidityToLocation(List<Map> map, List<long> seeds, List<Plan> plans)
        {
            foreach (long seed in seeds)
            {
                Plan plan = plans.First(p => p.Seed == seed);
                var x = map.FirstOrDefault(m => plan.Humidity >= m.SourceMin && plan.Humidity <= m.SourceMax);
                if (x != null)
                {
                    var diff = plan.Humidity - x.SourceMin;
                    plan.Location = x.DestMin + diff;
                }
                else
                {
                    plan.Location = plan.Humidity;
                }
            }
        }

        private static void GetKeyValuePair(string input, List<Map> maps)
        {
            long destination = Convert.ToInt64(input.Split(' ')[0]);
            long source = Convert.ToInt64(input.Split(' ')[1]);
            long range = Convert.ToInt64(input.Split(' ')[2]);

            Map map = new Map()
            {
                SourceMin = source,
                SourceMax = source + (range - 1),
                DestMin = destination,
                DestMax = destination + (range - 1)
            };
            maps.Add(map);
        }
    }

    internal class Plan
    {
        public long  Seed { get; set; }
        public long Soil { get; set; }
        public long Fertilizer { get; set; }
        public long Water { get; set; }
        public long Light { get; set; }
        public long Temperature { get; set; }
        public long Humidity { get; set; }
        public long Location { get; set; }
    }

    internal class Map
    {
        public long SourceMin { get; set; }
        public long SourceMax { get; set; }

        public long DestMin { get; set; }
        public long DestMax { get; set; }
    }
}
