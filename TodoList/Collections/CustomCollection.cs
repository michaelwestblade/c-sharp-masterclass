using System.Collections;

namespace Collections;

public class CustomCollection: IEnumerable
{
    public string[] Words { get; }

    public CustomCollection(string[] words)
    {
        Words = words;
    }

    public IEnumerator GetEnumerator()
    {
        return new WordsEnumerator(Words);
    }
}