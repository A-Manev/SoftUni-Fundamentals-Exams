using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Practice_Sessions
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> collection = new Dictionary<string, List<string>>();

            string input = Console.ReadLine();

            while (input != "END")
            {
                string[] tokens = input.Split("->");
                string command = tokens[0];

                if (command == "Add")
                {
                    string road = tokens[1];
                    string racer = tokens[2];

                    if (!collection.ContainsKey(road))
                    {
                        collection.Add(road, new List<string>());
                    }

                    collection[road].Add(racer);
                    //if (!collection[road].Contains(racer))
                    //{
                    //    collection[road].Add(racer);
                    //}
                }
                else if (command == "Move")
                {
                    string currentRoad = tokens[1];
                    string racer = tokens[2];
                    string nextRoad = tokens[3];

                    if (collection[currentRoad].Contains(racer))
                    {
                        collection[nextRoad].Add(racer);
                        collection[currentRoad].Remove(racer);
                    }
                }
                else if (command == "Close")
                {
                    string road = tokens[1];
                    if (collection.ContainsKey(road))
                    {
                        collection.Remove(road);
                    }
                }

                input = Console.ReadLine();
            }

            Console.WriteLine("Practice sessions:");

            foreach (var road in collection
                .OrderByDescending(x => x.Value.Count)
                .ThenBy(x => x.Key))
            {
                if (road.Value.Count > 0)
                {
                    Console.WriteLine(road.Key);
                    foreach (var racer in road.Value)
                    {
                        Console.WriteLine($"++{racer}");
                    }
                }
            }
        }
    }
}
