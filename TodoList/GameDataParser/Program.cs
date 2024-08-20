// See https://aka.ms/new-console-template for more information

using System.Text.Json;
using GameDataParser;

Console.WriteLine("Enter the name of the file you want to read: ");

bool isFileRead = false;
string fileContents = null;
string fileName = null;
List<VideoGame> videoGames = default;
do
{
    try
    {
        fileName = Console.ReadLine();

        fileContents = await File.ReadAllTextAsync(fileName);
        isFileRead = true;
    }
    catch (ArgumentNullException error)
    {
        Console.WriteLine("The filename cannot be null");
    }
    catch (ArgumentException error)
    {
        Console.WriteLine("The filename cannot be empty");
    }
    catch (FileNotFoundException error)
    {
        Console.WriteLine("The file could not be found");
    }
} while(!isFileRead);

try
{
    videoGames = JsonSerializer.Deserialize<List<VideoGame>>(fileContents);
}
catch (JsonException error)
{
    var originalColor = Console.ForegroundColor;
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine("The file could not be parsed");
    Console.ForegroundColor = originalColor;
    throw new JsonException($"{error.Message}. The file is: {fileName}", error);
}

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