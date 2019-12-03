using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;

namespace _01.International_SoftUniada
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> contestants = new Dictionary<string, List<string>>();

            Dictionary<string, int> countries = new Dictionary<string, int>();

            string input = Console.ReadLine();

            while (input != "END")
            {
                string[] tokens = input.Split(" -> ");

                string countryName = tokens[0];
                string contestantName = tokens[1];
                int contestantPoints = int.Parse(tokens[2]);

                if (!countries.ContainsKey(countryName))
                {
                    countries.Add(countryName, 0);
                }

                countries[countryName] += contestantPoints;

                if (!contestants.ContainsKey(countryName))
                {
                    contestants.Add(countryName, new List<string>());
                }

                if (!contestants[countryName].Contains(contestantName))
                {
                    contestants[countryName].Add($"{contestantName} -> {contestantPoints}");
                }

                input = Console.ReadLine();
            }

            foreach (var country in countries.OrderByDescending(x => x.Value))
            {
                Console.WriteLine($"{country.Key}: {country.Value}");

                foreach (var contestant in contestants)
                {
                    if (country.Key == contestant.Key)
                    {
                        Console.WriteLine(contestant.Value);
                    }
                }
            }
        }
    }
}
