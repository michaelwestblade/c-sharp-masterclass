// See https://aka.ms/new-console-template for more information

Console.WriteLine("Hello, World!");

bool IsAnyWordUppercase(IEnumerable<string> words)
{
    foreach (var word in words)
    {
        bool areAllUppercase = true;
        foreach (var letter in word)
        {
            if (char.IsLower(letter))
            {
                areAllUppercase = false;
            }
        }

        if (areAllUppercase)
        {
            return true;
        }
    }

    return false;
}

bool IsAnyWordUppercaseWithLINQ(IEnumerable<string> words)
{
    return words.Any(word => word.All(char.IsUpper));
}

Console.WriteLine(IsAnyWordUppercase(new[] { "quick", "brown", "fox"}));
Console.WriteLine(IsAnyWordUppercase(new[] { "quick", "brown", "FOX"}));


Console.WriteLine(IsAnyWordUppercaseWithLINQ(new[] { "quick", "brown", "fox"}));
Console.WriteLine(IsAnyWordUppercaseWithLINQ(new[] { "quick", "brown", "FOX"}));

var words = new[] { "a", "bb", "ccc", "dddd" };
var wordsLongerThan2Letters = words.Where(word => word.Length > 2);
Console.WriteLine($"These words are longer than 2 letters: {string.Join(", ", wordsLongerThan2Letters)}");

var numbers = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
var oddNumbers = numbers.Where(number => number % 2 == 1);

Console.WriteLine($"Odd numbers: {string.Join(", ", oddNumbers)}");

var numbers2 = new List<int> { 5, 9, 2, 12, 6 };
bool isAnyLargerThan10 = numbers2.Any(number => number > 10);

var numbers3 = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
var areAllLargerThanZero = numbers3.All(number => number > 0);
var evenNumbers = numbers3.Where(number => number % 2 == 0);


Console.WriteLine($"Are there numbers larger than ten? {isAnyLargerThan10}");

Console.WriteLine($"Are there numbers larger than zero? {areAllLargerThanZero}");

Console.ReadKey();