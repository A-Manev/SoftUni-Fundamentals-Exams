using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            string patternTwo = @"(?<=[\s])\:(?<emoji>[a-z]{4,})\:(?=[\s,.!?])";

            List<string> emojis = new List<string>();
            List<string> emojisForPrint = new List<string>();

            string input = Console.ReadLine();

            List<int> emojiCode = Console.ReadLine().Split(":").Select(int.Parse).ToList();

            MatchCollection matchedEmojis = Regex.Matches(input, patternTwo);

            foreach (Match emoji in matchedEmojis)
            {
                string text = emoji.Groups["emoji"].Value;

                if (IsAllCharEnglish(text))
                {
                    emojis.Add(emoji.Groups["emoji"].Value);

                    emojisForPrint.Add($":{emoji.Groups["emoji"].Value}:");
                }
            }

            int emojiPower = SummingTheASCIIValuesFromEmojiLetters(emojis);

            string emojiName = string.Empty;

            for (int i = 0; i < emojiCode.Count; i++)
            {
                emojiName += ((char)emojiCode[i]).ToString();
            }

            if (emojisForPrint.Count == 0)
            {
                Console.WriteLine("Total Emoji Power: 0");
                return;
            }

            if (emojis.Contains(emojiName))
            {
                emojiPower *= 2;

                Console.WriteLine($"Emojis found: {string.Join(", ", emojisForPrint)}");
                Console.WriteLine($"Total Emoji Power: {emojiPower}");
            }
            else
            {
                Console.WriteLine($"Emojis found: {string.Join(", ", emojisForPrint)}");
                Console.WriteLine($"Total Emoji Power: {emojiPower}");
            }

        }

        private static int SummingTheASCIIValuesFromEmojiLetters(List<string> emojis)
        {
            int totalSum = 0;

            for (int i = 0; i < emojis.Count; i++)
            {
                string currentEmoji = emojis[i];

                for (int j = 0; j < currentEmoji.Length; j++)
                {
                    totalSum += currentEmoji[j];
                }
            }

            return totalSum;
        }

        public static bool IsAllCharEnglish(string Input)
        {
            foreach (var item in Input.ToCharArray())
            {
                if (!char.IsLower(item) && !char.IsUpper(item) && !char.IsDigit(item) && !char.IsWhiteSpace(item))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
