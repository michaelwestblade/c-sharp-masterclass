// See https://aka.ms/new-console-template for more information

using System.Text.Json;
using GameDataParser;

Console.WriteLine("Enter the name of the file you want to read: ");
var fileName = Console.ReadLine();

var fileContent = await File.ReadAllTextAsync(fileName);

var videoGames = JsonSerializer.Deserialize<List<VideoGame>>(fileContent);

if (videoGames.Count > 0)
{
    Console.WriteLine();
    Console.WriteLine("Loaded the following games: ");
    foreach (var videoGame in videoGames)
    {
        Console.WriteLine(videoGame);
    }
}
else
{
    Console.WriteLine("No video games found.");
}

Console.ReadKey();