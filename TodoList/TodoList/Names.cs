namespace TodoList;

public class Names
{
    private List<string> _names = new List<string>();

    public void AddName(string name)
    {
        if (NamesValidator.IsValid(name))
        {
            _names.Add(name);
        }
    }

    private bool IsValidName(string name)
    {
        return name.Length >= 2 && name.Length < 25 && char.IsUpper(name[0]) && name.All(char.IsLetter);
    }
}