using System;
using System.Text.RegularExpressions;

namespace Message_Encrypter
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"(?<tag>\*|@)(?<name>[A-Z][a-z]{2,})\k<tag>: \[(?<numOne>[A-z])\]\|\[(?<numTwo>[A-z])\]\|\[(?<numThree>[A-z])\]\|$";

            int numberOfinputs = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfinputs; i++)
            {
                string input = Console.ReadLine();

                Match matches = Regex.Match(input, pattern);

                if (matches.Success)
                {
                    string name = matches.Groups["name"].Value;

                    char numOne = char.Parse(matches.Groups["numOne".ToString()].Value);
                    char numTwo = char.Parse(matches.Groups["numTwo"].Value);
                    char numThree = char.Parse(matches.Groups["numThree"].Value);

                    Console.WriteLine($"{name}: {(int)numOne} {(int)numTwo} {(int)numThree}");
                }
                else
                {
                    Console.WriteLine("Valid message not found!");
                }
            }
 
        }
    }
}
