using System;
using System.Text;
using System.Text.RegularExpressions;

namespace _02._Song_Encryption
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"(?<artist>^[A-Z][a-z\s']+):(?<song>[A-Z\s]+\b)";

            string input = Console.ReadLine();

            while (input != "end")
            {
                Match matches = Regex.Match(input, pattern);

                if (matches.Success)
                {
                    string artist = matches.Groups["artist"].Value;
                    string song = matches.Groups["song"].Value;

                    int key = artist.Length;

                    string encrypedArtist = EncryptArtist(artist, key);
                    string encrypedSong = EncryptSong(song, key);

                    Console.WriteLine($"Successful encryption: {encrypedArtist}@{encrypedSong}");
                }
                else
                {
                    Console.WriteLine("Invalid input!");
                }

                input = Console.ReadLine();
            }
        }

        private static string EncryptSong(string song, int key)
        {
            StringBuilder encrypedSong = new StringBuilder();

            for (int i = 0; i < song.Length; i++)
            {
                if (!char.IsWhiteSpace(song[i]))
                {
                    char currentSymbol = (char)(song[i] + key);

                    if (currentSymbol >= 'A' && currentSymbol <= 'Z')
                    {
                        encrypedSong.Append(currentSymbol);
                    }
                    else
                    {
                        encrypedSong.Append((char)(currentSymbol - 26));
                    }
                }
                else
                {
                    encrypedSong.Append(song[i]);
                }
            }

            return encrypedSong.ToString();
        }

        private static string EncryptArtist(string artist, int key)
        {
            StringBuilder encrypedArtist = new StringBuilder();

            for (int i = 0; i < artist.Length; i++)
            {
                if (!(char.IsWhiteSpace(artist[i]) || artist[i] == '\''))
                {
                    char currentSymbol = (char)(artist[i] + key);

                    if (currentSymbol >= 'A' && currentSymbol <= 'Z')
                    {
                        encrypedArtist.Append(currentSymbol);
                    }
                    else if (currentSymbol >= 'a' && currentSymbol <= 'z')
                    {
                        encrypedArtist.Append(currentSymbol);
                    }
                    else
                    {
                        encrypedArtist.Append((char)(currentSymbol - 26));
                    }
                }
                else
                {
                    encrypedArtist.Append(artist[i]);
                }
            }

            return encrypedArtist.ToString();
        }
    }
}
