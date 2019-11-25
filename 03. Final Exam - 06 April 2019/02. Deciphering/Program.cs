using System;
using System.Text;
using System.Text.RegularExpressions;

namespace _02._Deciphering
{
    class Program
    {
        static void Main(string[] args)
        {
            string encryptedString = Console.ReadLine();

            string[] lettersOrSubstrings = Console.ReadLine().Split();

            string pattern = @"^[d-z\{\}\|#]+$";

            Match match = Regex.Match(encryptedString, pattern);

            if (match.Success)
            {
                string oldLetters = lettersOrSubstrings[0];
                string newLetters = lettersOrSubstrings[1];

                StringBuilder decodedString = new StringBuilder();

                for (int i = 0; i < encryptedString.Length; i++)
                {
                    decodedString.Append((char)(encryptedString[i] - 3));
                }

                decodedString.Replace(oldLetters, newLetters);

                Console.WriteLine(decodedString.ToString());
            }
            else
            {
                Console.WriteLine("This is not the book you are looking for.");
            }
        }
    }
}
