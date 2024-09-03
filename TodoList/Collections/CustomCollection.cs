using System.Collections;

namespace Collections;

public class CustomCollection: IEnumerable<string>
{
    public string[] Words { get; }

    public CustomCollection(string[] words)
    {
        Words = words;
    }

    IEnumerator<string> IEnumerable<string>.GetEnumerator()
    {
        return new WordsEnumerator(Words);
    }

    public IEnumerator GetEnumerator()
    {
        return new WordsEnumerator(Words);
    }

    public string this[int index]
    {
        get => Words[index];
        set => Words[index] = value;
    }
}