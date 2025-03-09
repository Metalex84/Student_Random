using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        if (args.Length != 1)
        {
            Console.WriteLine("Usage: dotnet run <filename>"); 
            return;
        }

        string filename = args[0];

        try
        {
            var lines = new List<string>(File.ReadAllLines(filename));

            if (lines.Count == 0)
            {
                Console.WriteLine("CSV file is empty.");
                return;
            }

            Random random = new Random();
            int chosenIndex = random.Next(lines.Count);
            string chosenLine = lines[chosenIndex];

            int delay = 5;
            for (int i = 0; i < lines.Count; i++)
            {
                int randomIndex = random.Next(lines.Count);
                Console.Clear();
                Console.WriteLine(lines[randomIndex]);
                Thread.Sleep(delay);
                delay += 8;
            }

            Console.Clear();
            Console.WriteLine("The chosen one is... " + chosenLine);
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine($"Error: file '{filename}' not found.");
        }
        catch (Exception e)
        {
            Console.WriteLine($"Unexpected error: {e.Message}");
        }
    }
}
