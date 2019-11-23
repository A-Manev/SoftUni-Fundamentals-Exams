using System;
using System.Text;
using System.Text.RegularExpressions;

namespace _01._Arriving_in_Kathmandu
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"^(?<peakName>[A-Za-z0-9\!\@\#\$\?]+)=(?<length>\d+)<<(?<code>.+)";

            string input = Console.ReadLine();

            while (input != "Last note")
            {
                Match match = Regex.Match(input, pattern);

                if (match.Success)
                {
                    int geohashcodeLength = int.Parse(match.Groups["length"].Value);
                    string geohashcode = match.Groups["code"].Value;
                    int codeLength = geohashcode.Length;

                    if (geohashcodeLength == codeLength)
                    {
                        string name = match.Groups["peakName"].Value;

                        StringBuilder decryptedGeohashcode = new StringBuilder();

                        for (int i = 0; i < name.Length; i++)
                        {
                            if (char.IsLetterOrDigit(name[i]))
                            {
                                decryptedGeohashcode.Append(name[i]);
                            }
                        }

                        Console.WriteLine($"Coordinates found! {decryptedGeohashcode} -> {geohashcode}");
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
