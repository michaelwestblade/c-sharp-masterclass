// See https://aka.ms/new-console-template for more information

var weatherData = new WeatherData(25.1m, 65);
Console.WriteLine(weatherData);

var weatherData2 = new WeatherDataRecord(25.2, 65);
Console.WriteLine(weatherData2);

var rectangle = new Rectangle(10, 20);
rectangle.A = 30;
Console.WriteLine(rectangle);

Console.ReadKey();

public record WeatherDataRecord(double Temperature, double Humidity);

public record struct Rectangle(int A, int B);

public class WeatherData : IEquatable<WeatherData>
{
    public bool Equals(WeatherData? other)
    {
        if (other is null) return false;
        if (ReferenceEquals(this, other)) return true;
        return Temperature == other.Temperature && Humidity == other.Humidity;
    }

    public override bool Equals(object? obj)
    {
        if (obj is null) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != GetType()) return false;
        return Equals((WeatherData)obj);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Temperature, Humidity);
    }

    public static bool operator ==(WeatherData? left, WeatherData? right)
    {
        return Equals(left, right);
    }

    public static bool operator !=(WeatherData? left, WeatherData? right)
    {
        return !Equals(left, right);
    }

    public decimal Temperature { get; }
    public int Humidity { get; }

    public WeatherData(decimal temperature, int humidity)
    {
        Temperature = temperature;
        Humidity = humidity;
    }
    
    public override string ToString() => $"Temperature: {Temperature} Humidity: {Humidity}";
}