using System;
using System.Text;
using System.Text.RegularExpressions;

namespace _03._The_Isle_of_Man_TT_Race
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"(?<start>[#|$|%|&|*])(?<name>[A-z]+)\k<start>=(?<length>[\d]+)!!(?<geohashcode>.+)";

            string input = Console.ReadLine();
            while (true)
            {
                Match matches = Regex.Match(input, pattern);

                if (matches.Success)
                {
                    string name = matches.Groups["name"].Value;
                    int length = int.Parse(matches.Groups["length"].Value);
                    string geohashcode = matches.Groups["geohashcode"].Value;
                    char[] geohashcodeArray = geohashcode.ToCharArray();
                    int geohashcodeLength = geohashcode.Length;

                    StringBuilder decryptedGeohashcode = new StringBuilder();

                    for (int i = 0; i < geohashcodeLength; i++)
                    {
                        decryptedGeohashcode.Append((char)(geohashcodeArray[i] + length));
                    }

                    if (length == geohashcodeLength)
                    {
                        Console.WriteLine($"Coordinates found! {name} -> {decryptedGeohashcode.ToString()}");
                        return;
                    }
                    else
                    {
                        Console.WriteLine("Nothing found!");
                    }
                }
                else
                {
                    Console.WriteLine("Nothing found!");
                }

                input = Console.ReadLine();
            }
        }
    }
}
