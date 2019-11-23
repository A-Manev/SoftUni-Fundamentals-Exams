using System;

namespace String_Manipulator___Group_2
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            string input = Console.ReadLine();

            while (input != "Done")
            {
                string[] tokens = input.Split();
                string command = tokens[0];

                if (command == "Change")
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
                else if (command == "End")
                {
                    string word = tokens[1];
                     
                    if (text.EndsWith(word))
                    {
                        Console.WriteLine("True");
                    }
                    else
                    {
                        Console.WriteLine("False");
                    }
                }
                else if (command == "Uppercase")
                {
                    text = text.ToUpper();

                    Console.WriteLine(text);
                }
                else if (command == "FindIndex")
                {
                    string symbol = tokens[1];
                    int index = text.IndexOf(symbol);

                    Console.WriteLine(index);
                }
                else if (command == "Cut")
                {
                    int startIndex = int.Parse(tokens[1]);
                    int endIndex = int.Parse(tokens[2]);
                    text = text.Substring(startIndex, endIndex);

                    Console.WriteLine(text);
                }

                input = Console.ReadLine();
            }
        }
    }
}
