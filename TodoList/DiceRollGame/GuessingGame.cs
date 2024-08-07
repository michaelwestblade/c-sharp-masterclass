namespace DiceRollGame;

public enum GameResult
{
    Victory,
    Loss
}

public class GuessingGame
{
    private readonly Die _die;
    private readonly Random _random;
    private const int IniitalTries = 3;

    public GuessingGame(Die die)
    {
        _random = new Random();
        _die = new Die(_random, 6);
    }

    public GameResult Play()
    {
        var diceRollResult = _die.Roll();
        Console.WriteLine($"Die rolled. Guess what number it is in {IniitalTries} tries.");
        var remainingTries = IniitalTries;

        while (remainingTries > 0)
        {
            var guess = ConsoleReader.ReadInteger("Enter a number: ");

            if (guess == diceRollResult)
            {
                remainingTries = 0;
                Console.WriteLine($"You won the game by guessing {guess}");
                return GameResult.Victory;
            }
            else
            {
                --remainingTries;
                Console.WriteLine($"Your guess of {guess} was incorrect");
            }
        }

        return GameResult.Loss;
    }

    public static void PrintResult(GameResult result)
    {
        string message = result == GameResult.Victory ? "YOU WIN" : "YOU LOSE";
        Console.WriteLine(message);
    }
}