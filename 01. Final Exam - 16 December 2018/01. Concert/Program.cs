using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Concert
{
    class Program
    {
        public static object Dictionaty { get; private set; }

        static void Main(string[] args)
        {
            Dictionary<string, List<string>> bands = new Dictionary<string, List<string>>();
            Dictionary<string, int> bandsTime = new Dictionary<string, int>();

            string input = Console.ReadLine();

            while (input != "start of concert")
            {
                string[] tokens = input.Split("; ");
                string command = tokens[0];

                if (command == "Add")
                {
                    string bandName = tokens[1];
                    string[] members = tokens[2].Split(", ");

                    AddBand(bands, bandName, members);
                }
                else if (command == "Play")
                {
                    string bandName = tokens[1];
                    int time = int.Parse(tokens[2]);

                    AddBandTimeOnStage(bandsTime, bandName, time);
                }

                input = Console.ReadLine();
            }

            string finalInputBandName = Console.ReadLine();

            PrintTotalTime(bandsTime);

            PrintBandsTimeOnStage(bandsTime);

            PrintAllMembersForOneBand(bands, finalInputBandName);
        }

        private static void AddBand(Dictionary<string, List<string>> bands, string bandName, string[] members)
        {
            if (!bands.ContainsKey(bandName))
            {
                bands.Add(bandName, new List<string>());
            }
            for (int i = 0; i < members.Length; i++)
            {
                if (!bands[bandName].Contains(members[i]))
                {
                    bands[bandName].Add(members[i]);
                }
            }
        }

        private static void AddBandTimeOnStage(Dictionary<string, int> bandsTime, string bandName, int time)
        {
            if (!bandsTime.ContainsKey(bandName))
            {
                bandsTime.Add(bandName, 0);
            }

            bandsTime[bandName] += time;
        }

        private static void PrintTotalTime(Dictionary<string, int> bandsTime)
        {
            int totalTime = 0;

            foreach (var time in bandsTime)
            {
                totalTime += time.Value;
            }

            Console.WriteLine($"Total time: {totalTime}");
        }

        private static void PrintBandsTimeOnStage(Dictionary<string, int> bandsTime)
        {
            foreach (var band in bandsTime
                .OrderByDescending(x=>x.Value)
                .ThenBy(x=>x.Key))
            {
                Console.WriteLine($"{band.Key} -> {band.Value}");
            }
        }

        private static void PrintAllMembersForOneBand(Dictionary<string, List<string>> bands, string finalInputBandName)
        {
            foreach (var band in bands)
            {
                if (band.Key == finalInputBandName)
                {
                    Console.WriteLine(band.Key);

                    foreach (var member in band.Value)
                    {
                        Console.WriteLine($"=> {member}");
                    }
                }
            }
        }
    }
}
