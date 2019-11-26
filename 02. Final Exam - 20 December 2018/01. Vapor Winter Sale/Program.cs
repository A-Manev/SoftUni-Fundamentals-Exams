using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;

namespace DemoTesting
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, double> games = new Dictionary<string, double>();
            Dictionary<string, string> gamesWithDLC = new Dictionary<string, string>();

            string[] input = Console.ReadLine().Split(", ");

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i].Contains("-"))
                {
                    string[] tokens = input[i].Split("-");
                    string game = tokens[0];
                    double price = double.Parse(tokens[1]);

                    if (!games.ContainsKey(game))
                    {
                        games.Add(game, price);
                    }
                }
                else
                {
                    string[] tokens = input[i].Split(":");
                    string game = tokens[0];
                    string DLC = tokens[1];

                    if (games.ContainsKey(game))
                    {
                        games[game] += games[game] * 0.2;
                        gamesWithDLC.Add(game, DLC);
                    }
                }
            }

            foreach (var game in games.OrderBy(x=>x.Value))
            {
                foreach (var dlc in gamesWithDLC)
                {
                    if (game.Key == dlc.Key)
                    {
                        double price = game.Value * 0.5;

                        Console.WriteLine($"{game.Key} - {dlc.Value} - {price:F2}");

                        games.Remove(game.Key);
                    }
                }
            }

            foreach (var game in games.OrderByDescending(x => x.Value))
            {
                double price = game.Value * 0.8;

                Console.WriteLine($"{game.Key} - {price:F2}");
            }
        }
    }
}
