namespace DiceRollGame;

public class Die
{
    private readonly Random _random;
    private readonly int _sides;

    public Die(Random random, int sides)
    {
        _random = random;
        _sides = sides;
    }

    public int Roll() => _random.Next(1, _sides + 1);

    public void Describe() => Console.WriteLine($"This is a die with {_sides} sides");
}