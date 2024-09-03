using System.Text.Json;
using StarWarsPlanetsStats.ApiDataAccess;

namespace StarWarsPlanetStats;

public class StarWarsPlanetStatsApp
{
    private readonly IApiDataReader _dataReader;

    public StarWarsPlanetStatsApp(IApiDataReader dataReader)
    {
        _dataReader = dataReader;
    }
    public async Task Run()
    {
        var baseAddress = "https://swapi.dev/";
        var requestUri = "api/planets";

        IApiDataReader apiDataReader = new ApiDataReader();
        string json = null;
        try
        {
            json = await apiDataReader.Read(baseAddress, requestUri);
        }
        catch (HttpRequestException ex)
        {
            Console.Error.WriteLine(ex.Message);
        }

        var root = JsonSerializer.Deserialize<Root>(json);
        var planets = ToPlanets(root);

        var propertyNamesToSelectorsMapping = new Dictionary<string, Func<Planet, int?>>()
        {
            ["population"] = p => p.Population,
            ["diameter"] = p => p.Diameter,
            ["surface water"] = p => p.SurfaceWater,
        };
        
        Console.WriteLine();
        Console.WriteLine("The statistics of which property would you like to see?");
        Console.WriteLine(string.Join(
            Environment.NewLine,
            propertyNamesToSelectorsMapping.Keys
        ));

        var userChoice = Console.ReadLine();

        if (userChoice is null || !propertyNamesToSelectorsMapping.ContainsKey(userChoice))
        {
            Console.WriteLine("Invalid Choice");
        }
        else
        {
            ShowStatistics(
                planets,
                userChoice,
                propertyNamesToSelectorsMapping[userChoice]
            );
        }
    }

    private static void ShowStatistics(IEnumerable<Planet> planets, string propertyName, Func<Planet, int?> propertySelector)
    {
        ShowStatistics("Max", planets.MaxBy(propertySelector), propertySelector, propertyName);
        ShowStatistics("Min", planets.MinBy(propertySelector), propertySelector, propertyName);
    }

    private static void ShowStatistics(string descriptor, Planet selectedPlanet, Func<Planet, int?> propertySelector, string propertyName)
    {
        Console.WriteLine($"{descriptor} {propertyName} is {propertySelector(selectedPlanet)} (planet: {selectedPlanet.Name})");
    }

    private static IEnumerable<Planet> ToPlanets(Root? root)
    {
        if (root is null)
        {
            throw new ArgumentNullException(nameof(root));
        }

        return root.results.Select(planetDTO => (Planet)planetDTO);
    }
}