using System.Text.Json;
using StarWarsPlanetsStats.ApiDataAccess;

namespace StarWarsPlanetStats;

public class PlanetsFromApiReader: IPlanetsReader
{
    private readonly IApiDataReader _dataReader;

    public PlanetsFromApiReader(IApiDataReader dataReader)
    {
        _dataReader = dataReader;
    }

    public async Task<IEnumerable<Planet>> Read()
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
        return ToPlanets(root);
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