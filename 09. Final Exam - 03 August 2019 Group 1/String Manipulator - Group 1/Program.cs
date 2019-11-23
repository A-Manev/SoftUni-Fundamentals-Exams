using System;

namespace String_Manipulator___Group_1
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            string input = Console.ReadLine();

            while (input != "End")
            {
                string[] tokens = input.Split();
                string command = tokens[0];

                if (command == "Translate")
                {
                    string character = tokens[1];
                    string replacement = tokens[2];
                    text = text.Replace(character, replacement);
                    Console.WriteLine(text);
                }
                else if (command == "Includes")
                {
                    string word = tokens[1];

                    if (text.Contains(word))
                    {
                        Console.WriteLine("True");
                    }
                    else
                    {
                        Console.WriteLine("False");
                    }
                }
                else if (command == "Start")
                {
                    string word = tokens[1];

                    if (text.StartsWith(word))
                    {
                        Console.WriteLine("True");
                    }
                    else
                    {
                        Console.WriteLine("False");
                    }
                }
                else if (command == "Lowercase")
                {
                    text = text.ToLower();

                    Console.WriteLine(text);
                }
                else if (command == "FindIndex")
                {
                    string character = tokens[1];
                    int index = text.LastIndexOf(character);

                    Console.WriteLine(index);
                }
                else if (command == "Remove")
                {
                    int startIndex = int.Parse(tokens[1]);
                    int count = int.Parse(tokens[2]);
                    text = text.Remove(startIndex, count);

                    Console.WriteLine(text);
                }

                input = Console.ReadLine();
            }
        }
    }
}
