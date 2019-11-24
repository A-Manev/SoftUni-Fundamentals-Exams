using System;
using System.Collections.Generic;
using System.Linq;

namespace Followers
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<int>> followers = new Dictionary<string, List<int>>();

            string input = Console.ReadLine();
            while (input == "Log out")
            {
                string[] tokens = input.Split(": ");
                string command = tokens[0];
                string username = tokens[1];

                if (command == "New follower")
                {
                    if (!followers.ContainsKey(username))
                    {
                        followers.Add(username, new List<int>());
                        followers[username].Add(0);
                        followers[username].Add(0);
                    }
                }
                else if (command == "Like")
                {
                    int count = int.Parse(tokens[2]);
                    if (!followers.ContainsKey(username))
                    {
                        followers.Add(username, new List<int>());
                        followers[username].Add(0);
                        followers[username].Add(0);
                        followers[username][0] = 0;
                    }

                    followers[username][0] += count;
                }
                else if (command == "Comment")
                {
                    if (!followers.ContainsKey(username))
                    {
                        followers.Add(username, new List<int>());
                        followers[username].Add(0);
                        followers[username].Add(0);
                        followers[username][1] = 0;
                    }

                    followers[username][1] += 1;
                }
                else if (command == "Blocked")
                {
                    if (!followers.ContainsKey(username))
                    {
                        Console.WriteLine($"{username} doesn't exist.");
                    }
                    else
                    {
                        followers.Remove(username);
                    }
                }

                input = Console.ReadLine();
            }

            Console.WriteLine($"{followers.Count} followers");
            foreach (var username in followers
                .OrderByDescending(x => x.Value[0])
                .ThenBy(x => x.Key))
            {
                int total = username.Value[0] + username.Value[1];
                Console.WriteLine($"{username.Key}: {total}");
            }
        }
    }
}
