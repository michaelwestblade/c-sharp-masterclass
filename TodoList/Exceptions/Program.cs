Console.WriteLine("Enter a number: ");
string input = Console.ReadLine();

try
{
    int number = int.Parse(input);
    var result = 10 / number;
    Console.WriteLine($"10 / {number} = {result}");
}
catch (FormatException e)
{
    Console.WriteLine($"Wrong format. Input string is not parseable to int. Exception message: {e.Message}");
}
catch (DivideByZeroException e)
{
    Console.WriteLine($"Division by zero. Exception message: {e.Message}");
}
catch (Exception e)
{
    Console.WriteLine($"??????? {e.Message}");
}
finally
{
    Console.WriteLine("DONE!");
}

Console.ReadKey();