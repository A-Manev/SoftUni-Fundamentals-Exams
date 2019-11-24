using System;
using System.Text.RegularExpressions;

namespace Password
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"^(.+)>(?<nums>\d{3})\|(?<LCL>[a-z]{3})\|(?<UCL>[A-Z]{3})\|(?<symbols>[^<>]{3})<\1$";

            int countOfInputs = int.Parse(Console.ReadLine());

            for (int i = 0; i < countOfInputs; i++)
            {
                string input = Console.ReadLine();

                Match matches = Regex.Match(input, pattern);

                if (matches.Success)
                {
                    string numbers = matches.Groups["nums"].Value;
                    string lowerCaseLetters = matches.Groups["LCL"].Value;
                    string upperCaseLetters = matches.Groups["UCL"].Value;
                    string symbols = matches.Groups["symbols"].Value;

                    Console.WriteLine($"Password: {numbers}{lowerCaseLetters}{upperCaseLetters}{symbols}");
                }
                else
                {
                    Console.WriteLine("Try another password!");
                }
            }
        }
    }
}