using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

string appName = Assembly.GetEntryAssembly().Location;

if (args.Length != 1)
{
    Console.WriteLine($"USO: {appName} <filename>");
    pressExit();
    return;
}

string filename = args[0];

try
{
    var lines = new List<string>(File.ReadAllLines(filename));

    if (lines.Count == 0)
    {
        Console.WriteLine("El fichero esta vacio.");
        pressExit();
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

    Console.WriteLine("El elegido es... " + chosenLine);
    pressExit();

}
catch (FileNotFoundException)
{
    Console.WriteLine($"Error: el fichero '{filename}' no existe.");
    pressExit();
}
catch (Exception e)
{
    Console.WriteLine($"Error inesperado: {e.Message}");
    pressExit();
}

void pressExit()
{
    Console.WriteLine("Presiona cualquier tecla para continuar...");
    Console.ReadKey();
}