using System;
using System.Collections.Generic;
using System.Linq;

namespace Messages_Manager
{
    class Program
    {
        //List<int> 
        // [0] = sentMessages
        // [1] = receivedMessages

        static void Main(string[] args)
        {
            int messagesCapacity = int.Parse(Console.ReadLine());

            Dictionary<string, List<int>> users = new Dictionary<string, List<int>>();

            string input = Console.ReadLine();

            while (input != "Statistics")
            {
                string[] tokens = input.Split("=");
                string command = tokens[0];

                if (command == "Add")
                {
                    string username = tokens[1];
                    int sentMessages = int.Parse(tokens[2]);
                    int receivedMessages = int.Parse(tokens[3]);

                    if (!users.ContainsKey(username))
                    {
                        users.Add(username, new List<int>());
                        users[username].Add(sentMessages);
                        users[username].Add(receivedMessages);
                    }
                }
                else if (command == "Message")
                {
                    string sender = tokens[1];
                    string receiver = tokens[2];
                    if (users.ContainsKey(sender) && users.ContainsKey(receiver))
                    {
                        users[sender][0] += 1;
                        if (users[sender][0] + users[sender][1] >= messagesCapacity)
                        {
                            users.Remove(sender);
                            Console.WriteLine($"{sender} reached the capacity!");
                        }
                        users[receiver][1] += 1;

                        if (users[receiver][1] + users[receiver][0] >= messagesCapacity)
                        {
                            users.Remove(receiver);
                            Console.WriteLine($"{receiver} reached the capacity!");
                        }
                    }
                }
                else if (command == "Empty")
                {
                    string username = tokens[1];
                    if (username != "All")
                    {
                        if (users.ContainsKey(username))
                        {
                            users.Remove(username);
                        }
                    }
                    else
                    {
                        users.Clear();
                    }
                }

                input = Console.ReadLine();
            }
            if (users != null)
            {
                Console.WriteLine($"Users count: {users.Count}");
                foreach (var user in users.OrderByDescending(x => x.Value[1]).ThenBy(x => x.Key))
                {
                    int totalMessages = user.Value[0] + user.Value[1];
                    Console.WriteLine($"{user.Key} - {totalMessages}");
                }
            }
        }
    }
}
