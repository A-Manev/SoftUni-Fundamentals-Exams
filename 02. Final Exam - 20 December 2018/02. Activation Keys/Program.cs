using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace _02._Activation_Keys
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"[A-Za-z0-9]+";

            List<string> keys = new List<string>();

            string[] input = Console.ReadLine().Split("&");

            for (int i = 0; i < input.Length; i++)
            {
                Match matches = Regex.Match(input[i], pattern);

                if (matches.Success && matches.Length == 16 || matches.Length == 25)
                {
                    if (matches.Length == 16)
                    {
                        string key = input[i].ToUpper();

                        int iterations = key.Length / 4;

                        string build = BuildingNewKey(iterations, key);

                        keys.Add(SubtractDigitForNine(build));
                    }
                    else
                    {
                        string key = input[i].ToUpper();

                        int iterations = key.Length / 5;

                        string build = BuildingNewKey(iterations, key);

                        keys.Add(SubtractDigitForNine(build));
                    }
                }
            }

            Console.WriteLine(string.Join(", ", keys));
        }

        private static string  BuildingNewKey(int iterations, string key)
        {
            StringBuilder buildKey = new StringBuilder();

            for (int k = 0; k < iterations; k++)
            {
                if (k != iterations - 1)
                {
                    buildKey.Append(key.Substring(0, iterations));
                    buildKey.Append("-");
                    key = key.Remove(0, iterations);
                }
                else
                {
                    buildKey.Append(key.Substring(0, iterations));
                    key = key.Remove(0, iterations);
                }
            }

            return buildKey.ToString();
        }

        private static string SubtractDigitForNine(string build)
        {
            StringBuilder finalKey = new StringBuilder();

            for (int l = 0; l < build.Length; l++)
            {
                if (char.IsDigit(build[l]))
                {
                    int digit = 9 - (build[l] - 48);
                    finalKey.Append(digit);
                }
                else
                {
                    finalKey.Append(build[l]);
                }
            }

            return finalKey.ToString();
        }
    }
}
