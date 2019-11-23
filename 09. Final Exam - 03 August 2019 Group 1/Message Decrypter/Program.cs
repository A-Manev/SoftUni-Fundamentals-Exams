using System;
using System.Text.RegularExpressions;

namespace Message_Decrypter
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"^(?<start>[$|%])(?<name>[A-Z][a-z]{2,})\k<start>: \[(?<numOne>[\d]+)\]\|\[(?<numTwo>[\d]+)\]\|\[(?<numThree>[\d]+)\]\|$";
            int numberOfInputs = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfInputs; i++)
            {
                string input = Console.ReadLine();

                Match matches = Regex.Match(input, pattern);

                if (matches.Success)
                {
                    int numOne = int.Parse(matches.Groups["numOne"].Value);
                    int numTwo = int.Parse(matches.Groups["numTwo"].Value);
                    int numThree = int.Parse(matches.Groups["numThree"].Value);

                    string name = matches.Groups["name"].Value;
                    string word = $"{(char)numOne}{(char)numTwo}{(char)numThree}";

                    Console.WriteLine($"{name}: {word}");
                }
                else
                {
                    Console.WriteLine("Valid message not found!");
                }
            }
        }
    }
}
