using System;
using System.Collections.Generic;
using System.Linq;

namespace Battle_Manager
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<int>> people = new Dictionary<string, List<int>>();

            string input = Console.ReadLine();

            while (input != "Results")
            {
                string[] tokens = input.Split(":");
                string command = tokens[0];

                if (command == "Add")
                {
                    string personName = tokens[1];
                    int health = int.Parse(tokens[2]);
                    int energy = int.Parse(tokens[3]);

                    if (!people.ContainsKey(personName))
                    {
                        people.Add(personName, new List<int>());
                        people[personName].Add(0);
                        people[personName].Add(energy);
                    }

                    people[personName][0] += health;
                }
                else if (command == "Attack")
                {
                    string attackerName = tokens[1];
                    string defenderName = tokens[2];
                    int damage = int.Parse(tokens[3]);

                    if (people.ContainsKey(attackerName) && people.ContainsKey(defenderName))
                    {
                        people[defenderName][0] -= damage;

                        if (people[defenderName][0] <= 0)
                        {
                            people.Remove(defenderName);

                            Console.WriteLine($"{defenderName} was disqualified!");
                        }

                        people[attackerName][1] -= 1;

                        if (people[attackerName][1] == 0)
                        {
                            people.Remove(attackerName);

                            Console.WriteLine($"{attackerName} was disqualified!");
                        }
                    }
                }
                else if (command == "Delete")
                {
                    string username = tokens[1];
                    if (username == "All")
                    {
                        people.Clear();
                    }
                    else
                    {
                        if (people.ContainsKey(username))
                        {
                            people.Remove(username);
                        }
                    }
                }

                input = Console.ReadLine();
            }

            Console.WriteLine($"People count: {people.Count}");
            foreach (var person in people
                .OrderByDescending(x=>x.Value[0])
                .ThenBy(x=>x.Key))
            {
                Console.WriteLine($"{person.Key} - {person.Value[0]} - {person.Value[1]}");
            }
        }
    }
}
