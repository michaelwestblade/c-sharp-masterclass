using System.Collections;

namespace Collections;

public class WordsEnumerator: IEnumerator, IEnumerator<string>
{
    private const int InitialPosition = -1;
    private int _currentPosition = InitialPosition;
    private readonly string[] _words;
    private string _current;

    public WordsEnumerator(string[] words)
    {
        _words = words;
    }

    public object Current
    {
        get
        {
            try
            {
                return _words[_currentPosition];
            }
            catch (IndexOutOfRangeException exc)
            {
               throw new IndexOutOfRangeException("The word was not found", exc);
            }
        }
    }

    public bool MoveNext()
    {
        ++_currentPosition;
        return _currentPosition < _words.Length;
    }

    public void Reset()
    {
        _currentPosition = InitialPosition;
    }

    string IEnumerator<string>.Current
    {
        get
        {
            try
            {
                return _words[_currentPosition];
            }
            catch (IndexOutOfRangeException exc)
            {
                throw new IndexOutOfRangeException("The word was not found", exc);
            }
        }
    }

    public void Dispose()
    {
        
    }
}