using System;
using System.Text.RegularExpressions;

namespace FinalExamPrep1
{
    class Program
    {
        static void Main(string[] args)
        {
            //string pattern = @"(#|\|)(?<product>[A-Z][a-z]+)\1(?<date>\d{2}/\d{2}/\d{2})\1(?<callories>\d+)\1";
            string pattern = @"(#|\|)(?<product>[A-Z][a-z]+(\s[A-Z][a-z]+)*?)\1(?<date>\d{2}/\d{2}/\d{2})\1(?<callories>\d+)\1";
            string input = Console.ReadLine();
            MatchCollection matchCollection = Regex.Matches(input, pattern);
            int totalCallories = 0;
            
            foreach (Match match in matchCollection)
            {
                int currentCallories = int.Parse(match.Groups["callories"].Value);
                totalCallories += currentCallories;
                
                
            }
            int daysAlive = totalCallories / 2000;
            Console.WriteLine($"You have food to last you for: {daysAlive} days!");
            foreach (Match match in matchCollection)
            {
                Console.WriteLine($"Item: {match.Groups["product"].Value}, Best before: {match.Groups["date"].Value}, Nutrition: {match.Groups["callories"].Value}");
            }
        }
    }
}
