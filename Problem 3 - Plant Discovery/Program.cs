using System;
using System.Collections.Generic;
using System.Linq;
namespace Problem_3___Plant_Discovery
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, Plants> plants = new Dictionary<string, Plants>();
            for (int i = 0; i < n; i++)
            {
                string[] info = Console.ReadLine().Split("<->");
                string plantName = info[0];
                int rarity = int.Parse(info[1]);
                Plants plant = new Plants(plantName, rarity, new List<int>());
                plants.Add(plantName, plant);
            }
            string command = Console.ReadLine();

            while (command != "Exhibition")
            {
                string[] info = command.Split(new char[] { ' ', ':' }, StringSplitOptions.RemoveEmptyEntries);
                string action = info[0];
                string plantName = info[1];
                if (action == "Rate")
                {
                    if (plants.ContainsKey(plantName))
                    {
                        int rating = int.Parse(info[3]);
                        plants[plantName].Ratings.Add(rating);
                    }
                    else
                    {
                        Console.WriteLine("error");
                    }
                }
                else if (action == "Update")
                {
                    if (plants.ContainsKey(plantName))
                    {
                    int newRarity = int.Parse(info[3]);
                    plants[plantName].Rarity = newRarity;

                    }
                    else
                    {
                        Console.WriteLine("error");
                    }
                }
                else if (action == "Reset")
                {
                    if (plants.ContainsKey(plantName))
                    {
                        plants[plantName].Ratings.RemoveAll(x => x >= 0);
                    }
                    else
                    {
                        Console.WriteLine("error");
                    }
                }


                command = Console.ReadLine();
            }
            Console.WriteLine("Plants for the exhibition:");
            foreach (var item in plants)
            {
                if (item.Value.Ratings.Any())
                {
                Console.WriteLine($"- {item.Value.Name}; Rarity: {item.Value.Rarity}; Rating: {item.Value.Ratings.Average():f2}");

                }
                else
                {
                    Console.WriteLine($"- {item.Value.Name}; Rarity: {item.Value.Rarity}; Rating: {0:f2}");
                }
               
            }
        }
    }
    class Plants
    {
        public string Name { get; set; }
        public int Rarity { get; set; }
        public List<int> Ratings { get; set; }

        public Plants(string name, int rarity, List<int> ratings)
        {
            Name = name;
            Rarity = rarity;
            Ratings = ratings;
        }

    }
}
