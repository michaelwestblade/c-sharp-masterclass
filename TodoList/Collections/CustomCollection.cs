using System.Collections;

namespace Collections;

public class CustomCollection: IEnumerable<string>
{
    private int _currentIndex = 0;
    public string[] Words { get; }

    public CustomCollection(string[] words)
    {
        Words = words;
    }

    public CustomCollection()
    {
        Words = new string[10];
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

    public void Add(string item)
    {
        Words[_currentIndex] = item;
        ++_currentIndex;
    }
}