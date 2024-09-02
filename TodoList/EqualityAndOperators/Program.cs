// See https://aka.ms/new-console-template for more information

var point1 = new Point(1, 5);
var point2 = new Point(2, 4);
var added = point1 + point2;

Console.WriteLine($"Point1 == Point2 {point1 == point2}");

Console.ReadKey();

readonly struct Point : IEquatable<Point>
{
    public int X { get; init; }
    public int Y { get; init; }

    public Point(int x, int y)
    {
        X = x;
        Y = y;
    }
    
    public bool Equals(Point other)
    {
        return X == other.X && Y == other.Y;
    }

    public override bool Equals(object? obj)
    {
        return obj is Point other && Equals(other);
    }
    
    public override string ToString() => $"({X}, {Y})";
    
    public static Point operator +(Point a, Point b) => new(a.X + b.X, a.Y + b.Y);
    
    public static bool operator ==(Point a, Point b) => a.Equals(b);

    public static bool operator !=(Point a, Point b) => !a.Equals(b);

    public override int GetHashCode()
    {
        return HashCode.Combine(X, Y);
    }
}