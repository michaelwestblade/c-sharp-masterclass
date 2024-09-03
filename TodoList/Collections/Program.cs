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

Console.ReadKey();