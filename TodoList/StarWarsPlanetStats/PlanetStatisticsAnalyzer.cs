namespace StarWarsPlanetStats;

public class PlanetStatisticsAnalyzer: IPlanetStatisticsAnalyzer
{
    public void Analyze(IEnumerable<Planet> planets)
    {
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
}