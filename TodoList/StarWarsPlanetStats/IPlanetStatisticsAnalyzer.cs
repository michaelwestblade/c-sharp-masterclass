namespace StarWarsPlanetStats;

public interface IPlanetStatisticsAnalyzer
{
    void Analyze(IEnumerable<Planet> planets);
}