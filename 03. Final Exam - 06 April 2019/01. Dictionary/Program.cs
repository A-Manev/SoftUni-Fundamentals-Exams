using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Dictionary
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> definitions = new Dictionary<string, List<string>>();

            List<string> allWords = new List<string>();

            string[] input = Console.ReadLine().Split(" | ");

            string[] someWords = Console.ReadLine().Split(" | ");

            string endOrList = Console.ReadLine();

            for (int i = 0; i < input.Length; i++)
            {
                string[] pairsOfWordsAndDescriptions = input[i].Split(": ");

                string word = pairsOfWordsAndDescriptions[0];
                string definition = pairsOfWordsAndDescriptions[1];

                if (!definitions.ContainsKey(word))
                {
                    allWords.Add(word);
                    definitions.Add(word, new List<string>());
                }

                definitions[word].Add(definition);
            }

            for (int i = 0; i < someWords.Length; i++)
            {
                if (definitions.ContainsKey(someWords[i]))
                {
                    Console.WriteLine($"{someWords[i]}");

                    foreach (var definition in definitions[someWords[i]].OrderByDescending(x=>x.Length))
                    {
                        Console.WriteLine($" -{definition}");
                    }
                }
            }

            if (endOrList == "List")
            {
                allWords.Sort();
                Console.WriteLine(string.Join(" ", allWords));
            }
        }
    }
}
