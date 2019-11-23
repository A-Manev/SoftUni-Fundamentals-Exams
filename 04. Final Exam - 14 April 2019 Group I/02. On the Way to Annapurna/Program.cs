using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._On_the_Way_to_Annapurna
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> stores = new Dictionary<string, List<string>>();

            string input = Console.ReadLine();

            while (input != "END")
            {
                string[] tokens = input.Split("->");
                string command = tokens[0];

                if (command == "Add")
                {
                    string store = tokens[1];
                    string[] items = tokens[2].Split(new char[] {','});

                    if (!stores.ContainsKey(store))
                    {
                        stores.Add(store, new List<string>());
                    }

                    for (int i = 0; i < items.Length; i++)
                    {
                        stores[store].Add(items[i]);
                    }
                }
                else if (command == "Remove")
                {
                    string store = tokens[1];
                    if (stores.ContainsKey(store))
                    {
                        stores.Remove(store);
                    }
                }

                input = Console.ReadLine();
            }

            Console.WriteLine("Stores list:");
            foreach (var store in stores
                .OrderByDescending(x=>x.Value.Count)
                .ThenByDescending(x=>x.Key))
            {
                Console.WriteLine(store.Key);
                foreach (var item in store.Value)
                {
                    Console.WriteLine($"<<{item}>>");
                }
            }
        }
    }
}
