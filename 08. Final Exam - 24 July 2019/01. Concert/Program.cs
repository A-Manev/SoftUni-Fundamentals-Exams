using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Concert
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> bands = new Dictionary<string, List<string>>();
            Dictionary<string, int> bandsTimeOnStage = new Dictionary<string, int>();

            string input = Console.ReadLine();
            while (input != "start of concert")
            {
                string[] tokens = input.Split("; ");
                string command = tokens[0];

                if (command == "Add")
                {
                    string bandName = tokens[1];
                    string[] members = tokens[2].Split(", ");

                    AddBand(bands, bandsTimeOnStage, bandName, members);
                }
                else if (command == "Play")
                {
                    string bandName = tokens[1];
                    int time = int.Parse(tokens[2]);

                    AddBandTimeOnStage(bandsTimeOnStage, bandName, time);
                }

                input = Console.ReadLine();
            }

            string bandNameForPrinting = Console.ReadLine();

            PrintBandsTotalTimeOnStage(bandsTimeOnStage);

            PrintBandTimeOnStage(bandsTimeOnStage);

            PrintBandMembers(bands, bandNameForPrinting);
        }

        private static void AddBandTimeOnStage(Dictionary<string, int> bandsTimeOnStage, string bandName, int time)
        {
            if (!bandsTimeOnStage.ContainsKey(bandName))
            {
                bandsTimeOnStage.Add(bandName, time);
            }
            else
            {
                bandsTimeOnStage[bandName] += time;
            }
        }

        private static void AddBand(Dictionary<string, List<string>> bands, Dictionary<string, int> bandsTimeOnStage, string bandName, string[] members)
        {
            if (!bandsTimeOnStage.ContainsKey(bandName))
            {
                bandsTimeOnStage.Add(bandName, 0);
            }

            if (!bands.ContainsKey(bandName))
            {
                bands.Add(bandName, new List<string>());
                foreach (var member in members)
                {
                    bands[bandName].Add(member);
                }
            }
            else
            {
                foreach (var member in members)
                {
                    if (!bands[bandName].Contains(member))
                    {
                        bands[bandName].Add(member);
                    }
                }
            }
        }

        private static void PrintBandsTotalTimeOnStage(Dictionary<string, int> bandsTimeOnStage)
        {
            int totalTime = 0;
            foreach (var bandTime in bandsTimeOnStage)
            {
                totalTime += bandTime.Value;
            }

            Console.WriteLine($"Total time: {totalTime}");
        }

        private static void PrintBandTimeOnStage(Dictionary<string, int> bandsTimeOnStage)
        {
            foreach (var band in bandsTimeOnStage
                .OrderByDescending(x => x.Value)
                .ThenBy(x => x.Key))
            {
                Console.WriteLine($"{band.Key} -> {band.Value}");
            }
        }

        private static void PrintBandMembers(Dictionary<string, List<string>> bands, string bandNameForPrinting)
        {
            foreach (var band in bands)
            {
                if (band.Key == bandNameForPrinting)
                {
                    Console.WriteLine(bandNameForPrinting);
                    foreach (var member in band.Value)
                    {
                        Console.WriteLine($"=> {member}");
                    }
                }
            }
        }
    }

}
