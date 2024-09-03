using System.Text.Json;
using StarWarsPlanetsStats.ApiDataAccess;

namespace StarWarsPlanetStats;

public class StarWarsPlanetStatsApp
{
    private readonly IPlanetsReader _planetsReader;
    private readonly IPlanetStatisticsAnalyzer _planetStatisticsAnalyzer;

    public StarWarsPlanetStatsApp(IPlanetsReader planetsReader, PlanetStatisticsAnalyzer planetStatisticsAnalyzer)
    {
        _planetsReader = planetsReader;
        _planetStatisticsAnalyzer = planetStatisticsAnalyzer;
    }
    public async Task Run()
    {
        var planets = await _planetsReader.Read();

        _planetStatisticsAnalyzer.Analyze(planets);
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