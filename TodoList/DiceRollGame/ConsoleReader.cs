namespace DiceRollGame;

public static class ConsoleReader
{
    public static int ReadInteger(string prompt)
    {
        int result;
        do
        {
            Console.WriteLine(prompt);
        } while (!int.TryParse(Console.ReadLine(), out result));

        return result;
    }
}