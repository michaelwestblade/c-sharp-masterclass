using StarWarsPlanetStats.DTO;

namespace StarWarsPlanetStats;

public readonly record struct Planet
{
    public string Name { get; }
    public int Diameter { get; }
    public int? SurfaceWater { get; }
    public int? Population { get; }

    public Planet(string name, int diameter, int? surfaceWater, int? population)
    {
        if (name is null)
        {
            throw new ArgumentNullException(nameof(name));
        }
        Name = name;
        Diameter = diameter;
        SurfaceWater = surfaceWater;
        Population = population;
    }
    
    public static explicit operator Planet(Result result)
    {
        var name = result.planetName;
        var diameter = int.Parse(result.diameter);
        var population = result.population.ToIntOrNull();
        var surfaceWater = result.surface_water.ToIntOrNull();
        
        return new Planet(name, diameter, surfaceWater, population);
    }
}

public static class StringExtensions
{
    public static int? ToIntOrNull(this string str)
    {
        return int.TryParse(str, out int result) ? result : null;
    }
}