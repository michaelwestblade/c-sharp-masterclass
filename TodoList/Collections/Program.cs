// See https://aka.ms/new-console-template for more information

using Collections;

var customCollection = new CustomCollection(
    new string[]
    {
        "aaa",
        "bbb",
        "ccc",
        "ddd",
    });

var first = customCollection[0];
customCollection[1] = "abc";

foreach (var word in customCollection)
{
    Console.WriteLine(word);
}

var newCollection = new CustomCollection
{
    "one", "two", "three"
};

foreach (var word in newCollection)
{
    Console.WriteLine(word);
}

Console.ReadKey();