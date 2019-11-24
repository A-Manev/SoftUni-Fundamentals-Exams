using System;
using System.Collections.Generic;

namespace Username
{
    class Program
    {
        static void Main(string[] args)
        {
            string username = Console.ReadLine();

            string input = Console.ReadLine();
            while (input != "Sign up")
            {
                string[] tokens = input.Split();
                string command = tokens[0];

                if (command == "Case")
                {
                    string size = tokens[1];
                    if (size == "lower")
                    {
                        username = username.ToLower();
                        Console.WriteLine(username);
                    }
                    else
                    {
                        username = username.ToUpper();
                        Console.WriteLine(username);
                    }
                }
                else if (command == "Reverse")
                {
                    int startIndex = int.Parse(tokens[1]);
                    int endIndex = int.Parse(tokens[2]);
                    // care with this indexs 
                    if (startIndex >= 0 && startIndex < username.Length && endIndex >= 0 && endIndex < username.Length)
                    {
                        if (startIndex < endIndex)
                        {
                            string text = username.Substring(startIndex, (endIndex - startIndex) + 1);
                            char[] reversedText = text.ToCharArray();
                            Array.Reverse(reversedText);
                            Console.WriteLine(new string(reversedText));
                        }
                    }
                }
                else if (command == "Cut")
                {
                    string substring = tokens[1];
                    if (username.Contains(substring))
                    {
                        username = username.Replace(substring, "");
                        Console.WriteLine(username);
                    }
                    else
                    {
                        Console.WriteLine($"The word {username} doesn't contain {substring}.");
                    }
                }
                else if (command == "Replace")
                {
                    string character = tokens[1];
                    username = username.Replace(character, new string('*', character.Length));
                    Console.WriteLine(username);
                }
                else if (command == "Check")
                {
                    char symbol = char.Parse(tokens[1]);
                    if (username.Contains(symbol))
                    {
                        Console.WriteLine("Valid");
                    }
                    else
                    {
                        Console.WriteLine($"Your username must contain {symbol}.");
                    }
                }

                input = Console.ReadLine();
            }
        }
    }
}
