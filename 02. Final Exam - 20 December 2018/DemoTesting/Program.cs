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
            Dictionary<string, double> gamesOnly = new Dictionary<string, double>();
            Dictionary<string, Dictionary<string, double>> gamesWithDLC = new Dictionary<string, Dictionary<string, double>>();

            string[] input = Console.ReadLine().Split(", ");

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i].Contains("-"))
                {
                    string[] tokens = input[i].Split("-");
                    string game = tokens[0];
                    double price = double.Parse(tokens[1]);

                    if (!gamesOnly.ContainsKey(game))
                    {
                        gamesOnly.Add(game, price);
                    }
                }
                else
                {
                    string[] tokens = input[i].Split(":");
                    string game = tokens[0];
                    string DLC = tokens[1];

                    if (gamesOnly.ContainsKey(game))
                    {
                        gamesOnly[game] += gamesOnly[game] * 0.2;
                        gamesWithDLC.Add(game, new Dictionary<string, double>());
                        gamesWithDLC[game].Add(DLC, gamesOnly[game]);
                        gamesOnly.Remove(game);
                    }
                }
            }

            foreach (var game in gamesWithDLC)
            {
                foreach (var item in game.Value.OrderBy(x=>x))
                {
                    double price = item.Value * 0.5;
                    Console.WriteLine($"{game.Key} - {item.Key} - {price:F2}");
                }
            }

            foreach (var game in gamesOnly.OrderByDescending(x=>x.Value))
            {
                double price = game.Value * 0.8;
                Console.WriteLine($"{game.Key} - {price:F2}");
            }
        }
    }
}
