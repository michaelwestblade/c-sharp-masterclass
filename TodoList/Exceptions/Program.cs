// try
// {
//     var reult = GetFirstElement(new int[0]);
// }
// catch (Exception e)
// {
//     Console.WriteLine(e.Message);
// }

using Exceptions;

try
{
    ComplexMethod();
}
catch (ConnectionException e)
{
    Console.WriteLine("Check your internet");
    throw;
}
catch (JsonParsingException e)
{
    Console.WriteLine($"Unable to parse JSON. JSON body is: {e.JsonBody}");
}
catch (DataAccessException e)
{
    Console.WriteLine("");
}
catch (AuthorizationException e)
{
    Console.WriteLine("");
}

void TryCatchFinally()
{
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
}

int GetFirstElement(IEnumerable<int> numbers)
{
    foreach (var number in numbers)
    {
        return number;
    }

    throw new Exception("The collection cannot be empty.");
}

void ComplexMethod()
{
    // step 1: connecting
    throw new ConnectionException("Cannot connect to a service.");

    // step 2: authorizing
    throw new AuthorizationException("Cannot authorize the user.");

    // step 3: retrieving data as JSON
    throw new DataAccessException("Cannot retrieve data.");

    // step 4: parsing the JSON to some c# type
    throw new JsonParsingException("Cannot parse JSON data.");
}